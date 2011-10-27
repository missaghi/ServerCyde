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
    [HttpHandler("/dash/*/SimpleDB/Modify/")]
    public class page_modifys : SimpleDBPages
    {
        public page_modifys()
            : base("/a/html/dash/simpledb/Modifys.htm")
        {
            site.get_children_proc_modify_site_ids.ToList().ForEach( x => {
                Template temp = new Template("/a/html/dash/simpledb/Modify-calls.htm");
                temp.Set("id", x.id);
                temp.Set("name", x.name);
                temp.Set("siteid", SiteID);
                string fields = "";
                temp.Set("itemname", x.get_children_proc_modify_item_proc_modify_ids[0].item_name.ToHTMLEnc());
                x.get_children_proc_modify_item_proc_modify_ids[0].get_children_proc_modify_attribute_proc_modify_item_ids.ToList().ForEach( y => {
                   fields += ("\"Item.1." + y.attribute_name + "\" : \"" + (y.value ?? "") + "\", ");
                });
                temp.Set("fields", fields.TrimEnd().TrimEnd(new char[] { ',' }).ToHTMLEnc());
                template.Append("queries", temp.ToString());
            });
        }
    }

    [HttpHandler("/dash/*/SimpleDB/Modify/*/")]
    public class page_edit_modifys : SimpleDBPages
    {
        public page_edit_modifys()
            : base("/a/html/dash/simpledb/Modify-edit.htm")
        {

            Proc_Modify Modify = new Proc_Modify(UrlParts[4].ToLong(0), val);

            if (Modify.id != 0 && Modify.site_id != SiteID) //security check ownership
                throw new Exception("Invalid ModifyID");

            template.Set("editnew", Modify.id == 0 ? "New" : "Edit");
            template.Set("hidenew", (Modify.id == 0).ToCustom("hidden", ""));

            template.Set("domains_options", HTML.SelectOptions(Domains.ToArray(), FormArray["domain"].Else(new string[] {   }), true).Else("<option>Please add domains first</option>"));

            if (isPost)
            {
                using (DBTransaction tn = new DBTransaction(val))
                {

                    //upsert
                    Modify.site_id = SiteID;
                    Modify.domain_name = val.TestEmpty(Form["domain"], "select a domain");
                    Modify.name = val.TestEmpty(Form["nickname"], "enter a unique nickname").MakeAlphaNumeric();
                    Modify.delete_put = Form["Delete"].ToBool();
                    Modify.batch = Form["batch"].ToBool();
                    Modify.UpSert(CurrentUser);

                    

                    //delete items
                    Modify.get_children_proc_modify_item_proc_modify_ids.ToList().ForEach((x) => {

                        //delete conditions
                        x.get_children_proc_modify_expected_proc_modify_item_ids.ToList().ForEach((y) => { y.Delete(true, CurrentUser); });

                        //delete attributes
                        x.get_children_proc_modify_attribute_proc_modify_item_ids.ToList().ForEach((y) => { y.Delete(true, CurrentUser); });
                        
                        x.Delete(true, CurrentUser); 
                    
                    });

                    //add items 
                    Proc_Modify_Item item = new Proc_Modify_Item(val);
                    item.item_name = Form["item_name"];
                    item.proc_modify_id = Modify.id;
                    item.UpSert(CurrentUser);
                   
                    //add attributes
                    int clauses = 0;
                    while (Form[clauses + "_attribute"].NNOE() && clauses < 100)
                    {
                        Proc_Modify_Attribute attribute = new Proc_Modify_Attribute(val);
                        attribute.proc_modify_item_id = item.id;
                        attribute.attribute_name = Form[clauses + "_attribute"];
                        attribute.value = Form[clauses + "_attributevalue"];
                        attribute.replace = Form[clauses + "_replace"].ToBool();
                        attribute.UpSert(CurrentUser);
                        clauses++;
                    }
                   
                    //add conditions
                    clauses = 0;
                    while (Form[clauses + "_existsattribute"].NNOE() && clauses < 100)
                    {
                        Proc_Modify_Expected condition = new Proc_Modify_Expected(val);
                        condition.proc_modify_item_id = item.id;
                        condition.attribute_name = Form[clauses + "_" + "existsattribute"];
                        condition.value = Form[clauses + "_" + "existsvalue"];
                        condition.exists = Form[clauses + "_" + "exists"].ToBool();
                        condition.UpSert(CurrentUser);
                        clauses++;
                    }
                }

                if (val.Valid)
                {
                    template.Msg = "Call Saved at " + DateTime.Now;
                    template.Set("action", "/dash/" + SiteID + "/simpledb/modify/" + Modify.id + "/");
                }
                else val.Reset(template);
                
            }
            
            if (Modify.id != 0)
            {
                Modify = new Proc_Modify(Modify.id, val); //refresh
                HashSet<string> attributeNames = ServerCyde.Domains.GetFields(Modify.domain_name, sdb);

                //addcondition
                template.Set("attributeslist", HTML.BuildUnOrderedList(attributeNames.ToArray()));

                template.Set("domains_options", HTML.SelectOptions(Domains.ToArray(),  new string[] { Modify.domain_name }, true).Else("<option>Please add domains first</option>"));

                //show select
                template.Set("nickname", Modify.name);
                template.Set("delete", Modify.delete_put.ToChecked());
                template.Set("batch", Modify.batch.ToChecked());
                template.Set("item_name", Modify.get_children_proc_modify_item_proc_modify_ids.ElementAtOrDefault(0).item_name);

                //show conditions 
                int count = 0;
                foreach (Proc_Modify_Expected condition in Modify.get_children_proc_modify_item_proc_modify_ids[0].get_children_proc_modify_expected_proc_modify_item_ids)
                {
                    Template temp = new Template("/a/html/dash/simpledb/Modify-conditions.htm");
                    temp.Set("exists" + condition.exists.ToString().ToLower(), true.ToChecked());
                    temp.Set("existsvalue", condition.value);
                    temp.Set("existsattribute", condition.attribute_name);
                    temp.Set("count", count + "_");
                    temp.Set("counter", count + 1);
                    template.Append("Conditions", temp.ToString());
                    count++;
                }

                count = 0;
                //show fields
                foreach (Proc_Modify_Attribute attribute in Modify.get_children_proc_modify_item_proc_modify_ids[0].get_children_proc_modify_attribute_proc_modify_item_ids)
                {
                    Template temp = new Template("/a/html/dash/simpledb/Modify-attributes.htm");
                    temp.Set("attribute", attribute.attribute_name);
                    temp.Set("attributevalue", attribute.value);
                    temp.Set("replace", attribute.replace.ToChecked());
                    temp.Set("count", count + "_");
                    temp.Set("counter", count + 1);
                    template.Append("Attributes", temp.ToString());
                    count++;
                }
            }
        }
    }

}