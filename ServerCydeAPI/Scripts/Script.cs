using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;
using Amazon.SimpleDB;
using ServerCydeData;

namespace ServerCydeAPI.Scripts
{

    [HttpHandler("/Comet/*/", Type = HttpHandler.ContentType.JAVASCRIPT)]
    public class CometScript : ServerCydeAPI.Script
    {
        public CometScript() 
            : base("/Script/comet.js")
        {
            Site site = new Site(long.Parse(UrlParts[1]), val);
            Site.ValidateSite((Web)this, site.id.ToString());
            template.Set("siteid", site.id);

        }
    }


    [HttpHandler("/API/*/", Type=HttpHandler.ContentType.JAVASCRIPT)]
    public class Script : ServerCydeAPI.Script
    {
        public Script() : base("/Script/api.js")
        {
            Site site = new Site(long.Parse(UrlParts[1]), val);
            Site.ValidateSite((Web)this, site.id.ToString());
            
            //Paths
            template.Set("hostname", context.Request.Url.DnsSafeHost);
            template.Set("protocol", context.Request.IsSecureConnection ? "https" : "http");

            //insert FBKey
            template.Set("FBKey", site.FBKey);


            //insert functions for each of the queries
            
                StringBuilder procs = new StringBuilder();
                List<String> returnprocs = new List<String>();
                foreach (Proc_Select select in site.get_children_proc_select_site_ids)
                {
                    procs.Append(string.Format("\n        ,{0} = function (data, callback, errorHandler) {{ API.Post('/select/{1}/', data, callback, errorHandler); }}",
                        select.name, select.id));
                    returnprocs.Add(select.name + " : " + select.name );
                }
                template.Set("selects", procs.ToString());
                template.Set("returnselects", string.Join(", ", returnprocs.ToArray()));

                procs = new StringBuilder();
                returnprocs = new List<String>();
                foreach (Proc_Modify select in site.get_children_proc_modify_site_ids)
                {
                    procs.Append(string.Format("\n        ,{0} = function (data, callback, errorHandler) {{ API.Post('/modify/{1}/', data, callback, errorHandler); }}",
                        select.name, select.id));
                    returnprocs.Add(select.name + " : " + select.name);
                }
                template.Set("modifys", procs.ToString());
                template.Set("returnmodifys", string.Join(", ", returnprocs.ToArray()));

                procs = new StringBuilder();
                returnprocs = new List<String>();
                foreach (Proc_Get select in site.get_children_proc_get_site_ids)
                {
                    procs.Append(string.Format("\n        ,{0} = function (data, callback, errorHandler) {{ API.Post('/get/{1}/', data, callback, errorHandler); }}",
                        select.name, select.id));
                    returnprocs.Add(select.name + " : " + select.name);
                }
                template.Set("gets", procs.ToString());
                template.Set("returngets", string.Join(", ", returnprocs.ToArray()));

                procs = new StringBuilder();
                returnprocs = new List<String>();
                foreach (Emails select in site.get_children_emails_site_ids)
                {
                    procs.Append(string.Format("\n        ,{0} = function (data, callback, errorHandler) {{ API.Post('/email/{1}/', data, callback, errorHandler); }}",
                        select.name, select.id));
                    returnprocs.Add(select.name + " : " + select.name);
                }
                template.Set("emails", procs.ToString());
                template.Set("returnemails", string.Join(", ", returnprocs.ToArray()));

                //APIs
                procs = new StringBuilder();
                returnprocs = new List<String>();
                foreach (Proc_Api select in site.get_children_proc_api_site_ids)
                {
                    procs.Append(string.Format("\n        ,{0} = function (data, callback, errorHandler) {  API.Post('/API/{1}', params, function(data) { if (undefined != callback) callback(data);  }, function(data) { if (undefined != failure) failure(data); });  }",
                        select.name, select.id));
                    returnprocs.Add(select.name + " : " + select.name);
                }
                template.Set("apiscalls", procs.ToString());
                template.Set("apiscallsreturn", string.Join(", ", returnprocs.ToArray()));

                
            
                template.Set("siteid", site.id);
                
                

               

            //TODO cache this page dependant on database, and minify?


        }
    }
}