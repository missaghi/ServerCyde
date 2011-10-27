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

    [HttpHandler("/API/*/Get/*/", Type = HttpHandler.ContentType.JSON, Verb=HttpHandler.HTTPVerb.POST)]
    [DataContract]
    public class APIGet : ServerCydeAPI.APICall, ISimpleDBCall
    {
        [DataMember]
        public Item[] Result { get; set; }
        [DataMember]
        public String ProcName { get; set; }

        public Proc_Get proc_Get { get; set; }
        string[][] ISimpleDBCall.Parameters()
        {
            return new string[][] { new string[] { "ItemName", proc_Get.item_name } };
        }

        public APIGet()
        {
            if (!context.Request.IsLocal)
            {
                if (context.Request.UserHostName.NNOE())
                    if (!(site.name ?? "").Like(context.Request.UserHostName))
                    {
                        //throw new Exception("This domain name (" + context.Request.UserHostName + ") is not registered");
                    }
            }

            proc_Get = new Proc_Get(long.Parse(UrlParts[3]), new Validate());

            this.ProcName = proc_Get.name;

            if (val.Valid)
            {
                AmazonSimpleDB sdb = AWSClientFactory.CreateAmazonSimpleDBClient(site.AmazonKey.Else("AKIAJLVIIXIIHCKMCVXQ"), site.AmazonPassword.Else("xstfFHFNhKlEN1dYfXOB1HR/WbqkfznK6oeseEH8"));
                string itemName = ParseTags(proc_Get.item_name.Else(Form["ItemName"]));
                GetAttributesRequest gar = new GetAttributesRequest().WithDomainName(proc_Get.domain_name).WithConsistentRead(proc_Get.consistent_read.Value).WithItemName(itemName);
                gar.AttributeName = proc_Get.get_children_proc_get_attribute_proc_get_ids.Select(x => { return x.attribute_name; }).ToList();
                GetAttributesResponse garesponse = sdb.GetAttributes(gar);

                if (garesponse.IsSetGetAttributesResult())
                {
                    List<ServerCydeAPI.Item> items = new List<Item>();
                     
                    List<Attribute> attributes = new List<Attribute>();
                    foreach (Amazon.SimpleDB.Model.Attribute attribute in garesponse.GetAttributesResult.Attribute)
                    {
                        attributes.Add(new Attribute() { Name = attribute.IsSetName() ? attribute.Name : null, Value = attribute.IsSetValue() ? attribute.Value : null });
                    }
                    items.Add(new Item() { Name = ParseTags(proc_Get.item_name.Else(Form["ItemName"])), Attributes = attributes.ToArray() });
                    
                    Result = items.ToArray();
                }

            }
        }
    }
}
 