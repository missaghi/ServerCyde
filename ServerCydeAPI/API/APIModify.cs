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

namespace ServerCydeAPI
{ 

    [HttpHandler("/API/*/Modify/*/", Type = HttpHandler.ContentType.JSON, Verb = HttpHandler.HTTPVerb.POST)]
    [DataContract]
    public class APIModify : ServerCydeAPI.APICall, ISimpleDBCall
    {
        [DataMember]
        public String[] ItemName { get; set; }
        [DataMember]
        public String ProcName { get; set; }
        public Proc_Modify proc_Modify { get; set; }
        string[][] ISimpleDBCall.Parameters()
        {
            List<String[]> list = new List<string[]>();
            list.Add(new string[] { "Item.1.ItemName", proc_Modify.get_children_proc_modify_item_proc_modify_ids.FirstOrDefault().item_name });
            proc_Modify.get_children_proc_modify_item_proc_modify_ids.FirstOrDefault().get_children_proc_modify_attribute_proc_modify_item_ids.ToList().ForEach(x => {
                list.Add(new string[] { "Item.1." + x.attribute_name, x.value });
            });
            proc_Modify.get_children_proc_modify_item_proc_modify_ids.FirstOrDefault().get_children_proc_modify_expected_proc_modify_item_ids.ToList().ForEach(x =>
            {
                list.Add(new string[] { "Item.1.Expected." + x.attribute_name, x.value });
            });
            return list.ToArray();
        }

        public APIModify()
        {
            if (!context.Request.IsLocal)
            {
                if (context.Request.UserHostName.NNOE())
                    if (!(site.name ?? "").Like(context.Request.UserHostName))
                    {
                        //throw new Exception("This domain name (" + context.Request.UserHostName + ") is not registered");
                    }
            }

            proc_Modify = new Proc_Modify(long.Parse(UrlParts[3]), new Validate());

            this.ProcName = proc_Modify.name;

            if (val.Valid)
            {
                //increment request counter
                this.shortguid = proc_Modify.Increment(val);

                List<string> ItemNames = new List<string>();

                AmazonSimpleDB sdb = AWSClientFactory.CreateAmazonSimpleDBClient(site.AmazonKey.Else("AKIAJLVIIXIIHCKMCVXQ"), site.AmazonPassword.Else("xstfFHFNhKlEN1dYfXOB1HR/WbqkfznK6oeseEH8"));

                Proc_Modify_Item modify_item = proc_Modify.get_children_proc_modify_item_proc_modify_ids.FirstOrDefault();

                int count = 1;
                do
                {
                    if (proc_Modify.delete_put ?? false)
                    {
                        DeleteAttributesRequest delAttributes = new DeleteAttributesRequest().WithDomainName(proc_Modify.domain_name)
                        .WithItemName(ParseTags(modify_item.item_name.Else(Form["Item." + count + ".ItemName"])));

                        modify_item.get_children_proc_modify_attribute_proc_modify_item_ids.ToList().ForEach(x =>
                        {
                            delAttributes.Attribute.Add(new Amazon.SimpleDB.Model.Attribute().WithName(x.attribute_name).WithValue(ParseTags(x.value.Else(Form["Item." + count + "." + x.attribute_name]))));
                        });

                        try
                        {
                            if (val.Valid)
                                sdb.DeleteAttributes(delAttributes);
                        }
                        catch (Exception e)
                        {
                            val.ErrorMsg = e.Message;
                        }
                    }

                    else
                    {
                        string Preface = "Item." + count + ".";
                        if (!(proc_Modify.batch ?? false) || !context.Request.Form.AllKeys.ToList().Any(x => x.IndexOf("Item." + count + ".") > -1)) //not batch or not itemized
                        {
                            Preface = "";
                        }

                        PutAttributesRequest putAttributes = new PutAttributesRequest().WithDomainName(proc_Modify.domain_name)
                            .WithItemName(ParseTags(modify_item.item_name.Else(Form[Preface + "ItemName"])));

                        ItemNames.Add(putAttributes.ItemName);

                        modify_item.get_children_proc_modify_attribute_proc_modify_item_ids.ToList().ForEach(x =>
                        {
                            putAttributes.Attribute.Add(new ReplaceableAttribute().WithName(x.attribute_name).WithValue(ParseTags(x.value.Else(Form[Preface + x.attribute_name]))).WithReplace(x.replace.Value));
                        });

                        modify_item.get_children_proc_modify_expected_proc_modify_item_ids.ToList().ForEach(x =>
                        {
                            UpdateCondition uc = new UpdateCondition();
                            uc.Exists = x.exists.Value;
                            uc.Name = x.attribute_name;
                            uc.Value = ParseTags(x.value.Else(Form[Preface + "Expected" + x.attribute_name]));
                            putAttributes.WithExpected(uc);
                        });

                        try
                        {
                            if (val.Valid)
                                sdb.PutAttributes(putAttributes);
                        }
                        catch (Exception e)
                        {
                            val.ErrorMsg = e.Message;
                        }
                    }
                   

                    count++;
                }
                while (Form["Item." + count + ".ItemName"].NNOE());

                ItemName = ItemNames.ToArray();
            }
        }
    }
}
 