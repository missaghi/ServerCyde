using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;

namespace ServerCyde.Pages
{ 

    [HttpHandler("/dash/*/site/")]
    public class SitePage : DashPages
    {
        public SitePage()
            : base("/a/html/dash/sitedetails.htm")
        {
            if (isPost)
            {
                site.id = SiteID;
				site.user_id = CurrentUser.id;
				site.name = val.TestEmpty(Form["site_name"], "invalid name");
                site.url = val.TestEmpty(Form["site_url"], "invalid url");
                site.supportemail = Form["supportemail"];
                site.supportemailname = Form["supportemailname"];
                site.smtppassword = Form["smtppassword"];
                site.smtpserver = Form["smtpserver"];
                site.smtpusername = Form["smtpusername"];
                site.AmazonKey = Form["AmazonKey"];
                site.AmazonPassword = Form["AmazonPassword"];
                site.FBKey = Form["FBKey"];
                site.FBPassword = Form["FBPassword"];
                site.is_protected = false;
				site.UpSert(CurrentUser);

                context.Response.Redirect("/dash/?msg=2");

            }
            else
            {
                if (site.id != 0)
                {  
					template.Set("created_dt", site.created_dt);
					template.Set("updated_dt", site.updated_dt); 
					template.Set("site_name", site.name);
                    template.Set("site_url", site.url);
                    template.Set("supportemail", site.supportemail);
                    template.Set("supportemailname", site.supportemailname);
                    template.Set("smtppassword", site.smtppassword);
                    template.Set("smtpserver", site.smtpserver);
                    template.Set("smtpusername", site.smtpusername);
                    template.Set("AmazonKey", site.AmazonKey);
                    template.Set("AmazonPassword", site.AmazonPassword);
                    template.Set("FBKey", site.FBKey);
                    template.Set("FBPassword", site.FBPassword);
					template.Set("Requests", site.Requests);
					//template.Set("is_protected", site.is_protected.ToChecked()); 
                }
            }

            template.Set("editnew", site.id == 0 ? "New" : "Edit");
            template.Set("hidenew", (site.id == 0).ToCustom("hidden", ""));

        }
    }
}