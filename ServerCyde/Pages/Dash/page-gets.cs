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
    [HttpHandler("/dash/*/SimpleDB/Get/")]
    public class page_gets : SimpleDBPages
    {
        public page_gets()
            : base("/a/html/dash/simpledb/gets.htm")
        {
            site.get_children_proc_get_site_ids.ToList().ForEach( x => {
                Template temp = new Template("/a/html/dash/simpledb/Get-calls.htm");
                temp.Set("id", x.id);
                temp.Set("name", x.name);
                temp.Set("siteid", SiteID);
                //string fields = "";
                temp.Set("itemname", x.item_name.ToHTMLEnc());
                //x.get_children_proc_get_attribute_proc_get_ids.ToList().ForEach( y => {
                //   fields += ("\"Item.1." + y.attribute_name + "\" : \"" + (y.value ?? "") + "\", ");
                //});
                //temp.Set("fields", fields.TrimEnd().TrimEnd(new char[] { ',' }).ToHTMLEnc());
                template.Append("queries", temp.ToString());
            });
        }
    }

    [HttpHandler("/dash/*/SimpleDB/get/*/")]
    public class page_edit_Gets : SimpleDBPages
    {
        public page_edit_Gets()
            : base("/a/html/dash/simpledb/get-edit.htm")
        {

            Proc_Get Get = new Proc_Get(UrlParts[4].ToLong(0), val);

            if (Get.id != 0 && Get.site_id != SiteID) //security check ownership
                throw new Exception("Invalid GetID");

            template.Set("editnew", Get.id == 0 ? "New" : "Edit");
            template.Set("hidenew", (Get.id == 0).ToCustom("hidden", ""));

            template.Set("domains_options", HTML.SelectOptions(Domains.ToArray(), FormArray["domain"].Else(new string[] {   }), true).Else("<option>Please add domains first</option>"));

            if (isPost)
            {
                using (DBTransaction tn = new DBTransaction(val))
                {

                    //upsert
                    Get.site_id = SiteID;
                    Get.domain_name = val.TestEmpty(Form["domain"], "select a domain");
                    Get.name = val.TestEmpty(Form["nickname"], "enter a unique nickname").MakeAlphaNumeric();
                    Get.item_name = Form["item_name"];
                    Get.consistent_read = Form["consistent_read"].ToBool();
                    Get.UpSert(CurrentUser);
 
                    //delete attributes
                    Get.get_children_proc_get_attribute_proc_get_ids.ToList().ForEach((x) => { x.Delete(true, CurrentUser); });

                    //add attributes
                    foreach(string attributename in FormArray["attribute"])
                    {
                        Proc_Get_Attribute attribute = new Proc_Get_Attribute(val);
                        attribute.attribute_name = attributename;
                        attribute.proc_get_id = Get.id;
                        attribute.UpSert(CurrentUser);
                    }
                }

                if (val.Valid)
                {
                    template.Msg = "Call Saved at " + DateTime.Now;
                    template.Set("action", "/dash/" + SiteID + "/simpledb/get/" + Get.id + "/");

                }
                else val.Reset(template);
                
            }
            
            if (Get.id != 0)
            {
                Get = new Proc_Get(Get.id, val); //refresh
                HashSet<string> attributeNames = ServerCyde.Domains.GetFields(Get.domain_name, sdb);

                //addcondition
                template.Set("attributeslist", HTML.BuildUnOrderedList(attributeNames.ToArray()));

                template.Set("domains_options", HTML.SelectOptions(Domains.ToArray(),  new string[] { Get.domain_name }, true).Else("<option>Please add domains first</option>"));

                //show select
                template.Set("nickname", Get.name);
                template.Set("consistent_read", Get.consistent_read.ToChecked());
                template.Set("item_name", Get.item_name);
 
                //show fields
                foreach (Proc_Get_Attribute attribute in Get.get_children_proc_get_attribute_proc_get_ids)
                {
                    Template temp = new Template("/a/html/dash/simpledb/Get-attributes.htm");
                    temp.Set("attribute", attribute.attribute_name);
                    template.Append("Attributes", temp.ToString());
                }
            }
        }
    }

}