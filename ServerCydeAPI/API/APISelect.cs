using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;
using System.Reflection;
using Amazon;
using Amazon.SimpleDB;
using Amazon.SimpleDB.Model;
using ServerCydeData;
using ServerCydeAPI;

namespace ServerCydeAPI
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public Attribute[] Attributes { get; set; }
        [DataMember]
        public String Name { get; set; }
    }

    [DataContract]
    public class Attribute
    {
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String Value { get; set; }
    }

    

    [HttpHandler("/API/*/Select/*/", Type = HttpHandler.ContentType.JSON, Verb = HttpHandler.HTTPVerb.POST)]
    [DataContract]
    public class APISelect : ServerCydeAPI.APICall, ISimpleDBCall
    {
        [DataMember]
        public Item[] Result { get; set; }

        [DataMember]
        public String ProcName { get; set; }

        public Proc_Select proc_select { get; set; }
        string[][] ISimpleDBCall.Parameters()
        {
            return proc_select.GetParameters();
        }

        public APISelect()
        {
            if (!context.Request.IsLocal)
            {
                if (context.Request.UserHostName.NNOE())
                    if (!(site.name ?? "").Like(context.Request.UserHostName))
                    {
                        //throw new Exception("This domain name (" + context.Request.UserHostName + ") is not registered");
                    }
            }

            proc_select = new Proc_Select(long.Parse(UrlParts[3]), new Validate());

            this.ProcName = proc_select.name;

            if (val.Valid)
            {
                AmazonSimpleDB sdb = AWSClientFactory.CreateAmazonSimpleDBClient(site.AmazonKey.Else("AKIAJLVIIXIIHCKMCVXQ"), site.AmazonPassword.Else("xstfFHFNhKlEN1dYfXOB1HR/WbqkfznK6oeseEH8"));

                //build select expression
                String selectExpression = "Select ";
                selectExpression += String.Join(", ", (from c in proc_select.get_children_proc_select_field_proc_select_ids select (c.is_count ?? false ? "count(" : "") + ("`" + c.attribute_name + "`").Replace("`*`", "*") + (c.is_count ?? false ? ")" : "")).ToArray()).Else("*");
                selectExpression += " from `" + proc_select.domain_name + "`";

                if (proc_select.get_children_proc_select_condition_proc_select_ids.Count > 0)
                {
                    selectExpression += " where";

                    bool secondaryConditions = false;
                    foreach (Proc_Select_Condition condition in proc_select.get_children_proc_select_condition_proc_select_ids)
                    {
                        if (secondaryConditions)
                            selectExpression += " " + condition.or_and_intersect;

                        if (condition.use_every ?? false)
                            selectExpression += " every(`" + condition.attribute_name + "`)";
                        else
                            selectExpression += " `" + condition.attribute_name + "`";

                        selectExpression += " " + condition.comparison_operator.ToHTMLDecode();

                        switch (condition.comparison_operator)
                        {
                            case "in":
                                selectExpression += " (";
                                if (condition.constant_value.NNOE())
                                    selectExpression += condition.constant_value;
                                else
                                {
                                    if (val.TestEmpty(ParseTags(Form[condition.param_name]), "Missing param: " + condition.param_name).NNOE())
                                    {
                                        selectExpression += String.Join(", ", (from c in context.Request.Form.GetValues(condition.param_name) select "'" + c.Replace("'", "''") + "'").ToArray()); //escape each value
                                    }
                                }
                                selectExpression += ")";
                                break;
                            case "is null":
                                break;
                            case "is not null":
                                break;
                            default:
                                selectExpression += " '" + ParseTags(condition.constant_value.Else(Form[condition.param_name])).Replace("'", "''") + "'";
                                break;
                        }

                        if (condition.comparison_operator.Like("between"))
                        {
                            selectExpression += " and '" + ParseTags(condition.constant_value_2.Else(Form[condition.param_name_2])).Replace("'", "''") + "'";
                        }

                        secondaryConditions = true;
                    } 
                }

                if (proc_select.sort_by.NNOE())
                    selectExpression += " order by `" + proc_select.sort_by + "` " + proc_select.sort_order.Else("");

                if (proc_select.limit.HasValue && proc_select.limit.Value > 0)
                    selectExpression += " limit " + proc_select.limit.Value.ToString();

                SelectRequest selectRequestAction = new SelectRequest().WithSelectExpression(selectExpression).WithConsistentRead(proc_select.consistent_read ?? false);
                SelectResponse selectResponse = new SelectResponse();
                try
                {
                       selectResponse = sdb.Select(selectRequestAction);
                }
                catch (Exception e)
                {
                    val.ErrorMsg = e.Message;
                    val.ErrorMsg = selectExpression;
                }

                if (selectResponse.IsSetSelectResult())
                {
                    List<Item> items = new List<Item>();
                    foreach (Amazon.SimpleDB.Model.Item item in selectResponse.SelectResult.Item)
                    {
                        List<Attribute> attributes = new List<Attribute>();
                        foreach (Amazon.SimpleDB.Model.Attribute attribute in item.Attribute)
                        {
                            attributes.Add(new Attribute() { Name = attribute.IsSetName() ? attribute.Name : null, Value = attribute.IsSetValue() ? attribute.Value : null });
                        }
                        items.Add(new Item() { Name = item.IsSetName() ? item.Name : null, Attributes = attributes.ToArray() });
                    }

                   

                    Result = items.ToArray();
                }
            }

        }

         
    }

}
 