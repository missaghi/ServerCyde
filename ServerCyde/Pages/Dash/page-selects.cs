using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SharpFusion;
using ServerCydeData;

using Amazon;
using Amazon.SimpleDB;
using Amazon.SimpleDB.Model;

namespace ServerCyde.Pages
{
    [HttpHandler("/dash/*/SimpleDB/Selects/")]
    public class page_selects : SimpleDBPages
    {
        public page_selects()
            : base("/a/html/dash/simpledb/selects.htm")
        {
            site.get_children_proc_select_site_ids.ToList().ForEach( x => {
                Template temp = new Template("/a/html/dash/simpledb/select-queries.htm");
                temp.Set("id", x.id);
                temp.Set("name", x.name);
                temp.Set("siteid", SiteID);
                string fields = "";
                x.GetParameters().ToList().ForEach( y => {
                   fields += (y[0] + " : \"" + (y[1] ?? "") + "\", ");
                });
                temp.Set("fields", fields.TrimEnd().TrimEnd(new char[] { ',' }).ToHTMLEnc());
                template.Append("queries", temp.ToString());
            });
        }
    }

    [HttpHandler("/dash/*/SimpleDB/Selects/*/")]
    public class page_edit_selects : SimpleDBPages
    {
        public page_edit_selects()
            : base("/a/html/dash/simpledb/selects-edit.htm")
        {

            Proc_Select select = new Proc_Select(UrlParts[4].ToLong(0), val);

            if (select.id != 0 && select.site_id != SiteID) //security check ownership
                throw new Exception("Invalid SelectID");

            template.Set("editnew", select.id == 0 ? "New" : "Edit");
            template.Set("hidenew", (select.id == 0).ToCustom("hidden", ""));

            template.Set("domains_options", HTML.SelectOptions(Domains.ToArray(), FormArray["domain"].Else(new string[] {   }), true).Else("<option>Please add domains first</option>"));

            string[][] sortoptions = new string[][] { new string[] { "", "None" }, new string[] { "asc", "ascending" }, new string[] { "desc", "descending" } };
            template.Set("sort_order", HTML.SelectOptions(sortoptions, FormArray["sort_order"].Else(new string[] { select.sort_order }), true));

            string[] operators = new string[] { "=", "!=", ">", ">=", "<", "<=", "like", "not like", "between", "in", "is null", "is not null" };
            template.Set("operator", HTML.SelectOptions(operators, FormArray["operator"], false));

            string[] orandintersect = new string[] { "or", "and", "intersect" };
            template.Set("or_and_intersect", HTML.SelectOptions(orandintersect, FormArray["or_and_intersect"], false));

            if (isPost)
            {
                using (DBTransaction tn = new DBTransaction(val))
                {

                    //upsert
                    select.site_id = SiteID;
                    select.consistent_read = Form["consistent_read"].ToBool();
                    select.domain_name = val.TestEmpty(Form["domain"], "select a domain");
                    select.limit = Form["limit"].ToInt(0);
                    select.name = val.TestEmpty(Form["nickname"], "enter a unique nickname").MakeAlphaNumeric();
                    select.sort_by = Form["sort_by"];
                    select.sort_order = Form["sort_order"];
                    select.UpSert(CurrentUser);

                    //delete attributes
                    select.get_children_proc_select_field_proc_select_ids.ToList().ForEach((x) => { x.Delete(true, CurrentUser); });

                    //add attributes
                    foreach (String fieldname in FormArray["field"])
                    {
                        Proc_Select_Field field = new Proc_Select_Field(val);
                        field.proc_select_id = select.id;
                        field.attribute_name = fieldname.Trim(new char[] { '`' });
                        field.is_count = Form["field" + fieldname.Trim(new char[] { '`' })].ToBool();
                        field.UpSert(CurrentUser);
                    }

                    //delete conditions
                    select.get_children_proc_select_condition_proc_select_ids.ToList().ForEach((x) => { x.Delete(true, CurrentUser); });

                    //add conditions
                    int clauses = 0;
                    while (Form[clauses + "_where_field"].NNOE() && clauses < 100)
                    {
                        Proc_Select_Condition condition = new Proc_Select_Condition(val);
                        condition.proc_select_id = select.id;
                        condition.attribute_name = Form[clauses + "_" + "where_field"];
                        condition.or_and_intersect = Form[clauses + "_" + "or_and_intersect"];
                        condition.comparison_operator = Form[clauses + "_" + "operator"];
                        condition.constant_value = Form[clauses + "_" + "const_value_1"];
                        condition.constant_value_2 = Form[clauses + "_" + "const_value_2"];
                        condition.use_every = Form[clauses + "_" + "every"].ToBool();
                        condition.param_name = condition.ParameterName1;
                        condition.param_name_2 = condition.ParameterName2;
                        condition.UpSert(CurrentUser);
                        clauses++;
                    }

                }
                if (val.Valid)
                {
                    template.Msg = "Query Saved at " + DateTime.Now;
                    template.Set("action", "/dash/" + SiteID + "/simpledb/selects/" + select.id + "/");
                }
                else
                    val.Reset(template);

            }
            
            if (select.id != 0)
            {
                select = new Proc_Select(select.id, val); //refresh
                HashSet<string> attributeNames = ServerCyde.Domains.GetFields(select.domain_name, sdb);

                //addcondition
                template.Set("where_field", HTML.SelectOptions(attributeNames.ToArray(), new String[] {  }, false));

                template.Set("domains_options", HTML.SelectOptions(Domains.ToArray(),  new string[] { select.domain_name }, true).Else("<option>Please add domains first</option>"));

                //show select
                template.Set("nickname", select.name);
                template.Set("limit", select.limit == 0 ? "" : select.limit.ToString());
                template.Set("consistent_read", select.consistent_read.ToChecked());
                template.Set("sort_by", HTML.SelectOptions(attributeNames.ToArray(), new String[] { select.sort_by }, false));

                //show conditions 
                int count = 0;
                foreach (Proc_Select_Condition condition in select.get_children_proc_select_condition_proc_select_ids)
                {
                    Template temp = new Template("/a/html/dash/simpledb/select-conditions.htm");
                    temp.Set("where_field", HTML.SelectOptions(attributeNames.ToArray(), new String[] { condition.attribute_name }, false));
                    temp.Set("operator", HTML.SelectOptions(operators, new string[] { condition.comparison_operator.ToHTMLDecode() }, false));
                    temp.Set("or_and_intersect", HTML.SelectOptions(orandintersect, new string[] {condition.or_and_intersect}, false));
                    temp.Set("every", condition.use_every.ToChecked());
                    temp.Set("const_value_1", condition.constant_value);
                    temp.Set("const_value_2", condition.constant_value_2);
                    temp.Set("count", count + "_");
                    temp.Set("counter", count + 1);
                    temp.Set("remove", count == 0 ? "remove" : "");
                    template.Append("Conditions", temp.ToString());
                    count++;
                }
                
                //show fields
                attributeNames.Add("*");
                template.Set("fields", HTML.BuildUnOrderedList(attributeNames.Select(x =>
                {
                    Template temp = new Template("/a/html/dash/simpledb/select-fields.htm");
                    temp.Set("value", x.ToHTMLEnc());
                    temp.Set("countname", x.MakeSEOURL());
                    temp.Set("fieldchecked", select.get_children_proc_select_field_proc_select_ids.Any(y => y.attribute_name.Like(x)).ToChecked());
                    temp.Set("countchecked", select.get_children_proc_select_field_proc_select_ids.Any(y => y.attribute_name.Like(x) && (y.is_count ?? false)).ToChecked());
                    return temp.ToString();
                }).ToArray()));
            }
        }
    }

    [HttpHandler("/dash/*/API/GetFields/", Verb = HttpHandler.HTTPVerb.POST, Parameters = new String[] { "Domain", "Type" })]
    public class page_selects_get_fields : SimpleDBPages
    {
        public page_selects_get_fields()
        {

            HashSet<string> attributeNames = ServerCyde.Domains.GetFields(Form["Domain"], sdb);

            switch (Form["Type"].ToLower())
            {
                case "list": attributeNames.Add("*"); context.Response.Write(HTML.BuildUnOrderedList((attributeNames.ToArray().Else(new string[] { "Add some attributes first" }).Select(x =>
                {
                    Template temp = new Template("/a/html/dash/simpledb/select-fields.htm");
                    temp.Set("value", x.ToHTMLEnc());
                    temp.Set("countname", x.MakeSEOURL());
                    return temp.ToString();
                })).ToArray()));
                    break;
                case "options": context.Response.Write(HTML.SelectOptions((attributeNames.ToArray().Else(new string[] { "Add some attributes first" }).ToArray()), new String[] {}, false));
                    break;
                default :
                    context.Response.Write((attributeNames.ToArray().Else(new string[] { "Add some attributes first" }).ToJSON())); 
                    break;
            }

           

        }

       
    }
}