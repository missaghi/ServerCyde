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
    [HttpHandler("/dash/*/apis/")]
    public class page_apis : DashPages
    {
        public page_apis()
            : base("/a/html/dash/apis/apis.htm")
        {
            site.get_children_proc_api_site_ids.ToList().ForEach( x => {
                Template temp = new Template("/a/html/dash/apis/apis-item.htm");
                temp.Set("id", x.id);
                temp.Set("name", x.name);
                temp.Set("siteid", SiteID);
                temp.Set("fields", string.Join(", ", x.ReturnSampleFields(new Person(1, val), (Web)this)).ToHTMLEnc());
                template.Append("apis", temp.ToString());
            });
        }
    }

    [HttpHandler("/dash/*/apis/api/*/")]
    public class page_edit_apis : SimpleDBPages
    {
        public page_edit_apis()
            : base("/a/html/dash/apis/apis-edit.htm")
        {

            Proc_Api api = new Proc_Api(UrlParts[4].ToLong(0), val);
            template.Set("editnew", api.id == 0 ? "New" : "Edit");

            if (api.id != 0 && api.site_id != SiteID) //security check ownership
                throw new Exception("Invalid GetID");
             

            if (isPost)
            {
                api.name = val.TestEmpty(Form["nickname"].MakeFileSystemSafe().Replace(".", ""), "Enter a name please.");
                api.site_id = SiteID;
                api.url = Form["url"];
                api.return_type = Form["return_type"];
                api.port = Form["port"];
                api.useragent = Form["useragent"];
                api.method = Form["method"];
                api.accept = Form["accept"];
                api.content_type = Form["content_type"];
                api.cookie = Form["cookie"];
                api.UpSert(CurrentUser);

                if (val.Valid)
                {
                    template.Msg = "Call saved at " + DateTime.Now.ToString();
                    template.Set("action", "/dash/" + SiteID + "/apis/api/" + api.id + "/");
                }
                else
                    val.Reset(template);
            }

            if (api.id != 0)
            {
                api = new Proc_Api(api.id, val);
                template.Set("nickname", api.name);
                template.Set("url", api.url);
                template.Set("return_type", api.return_type);
                template.Set("port", api.port);
                template.Set("useragent", api.useragent);
                template.Set("method", api.method);
                template.Set("content_type", api.content_type);
                template.Set("accept", api.accept);
                template.Set("cookie", api.cookie);
            }
        }
    }

}