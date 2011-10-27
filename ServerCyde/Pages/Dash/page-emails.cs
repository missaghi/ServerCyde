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
    [HttpHandler("/dash/*/emails/")]
    public class page_emails : DashPages
    {
        public page_emails()
            : base("/a/html/dash/email/emails.htm")
        {
            site.get_children_emails_site_ids.ToList().ForEach( x => {
                Template temp = new Template("/a/html/dash/email/email-item.htm");
                temp.Set("id", x.id);
                temp.Set("name", x.name);
                temp.Set("siteid", SiteID);
                temp.Set("fields", string.Join(", ", x.ReturnSampleFields(new Person(1, val), (Web)this)).ToHTMLEnc());
                template.Append("emails", temp.ToString());
            });
        }
    }

    [HttpHandler("/dash/*/emails/email/*/")]
    public class page_edit_emails : SimpleDBPages
    {
        public page_edit_emails()
            : base("/a/html/dash/email/email-edit.htm")
        {

            Emails emails = new Emails(UrlParts[4].ToLong(0), val);
            template.Set("editnew", emails.id == 0 ? "New" : "Edit");

            if (emails.id != 0 && emails.site_id != SiteID) //security check ownership
                throw new Exception("Invalid GetID");
             

            if (isPost)
            {
                emails.name = val.TestEmpty(Form["nickname"], "Enter a name please.");
                emails.site_id = SiteID;
                emails.email_template = Form["emailtemplate"];
                emails.subject = Form["subject"];
                emails.is_html = Form["ishtml"].ToBool();
                emails.UpSert(CurrentUser);

                if (val.Valid)
                {
                    template.Msg = "Email template saved at " + DateTime.Now.ToString();
                    template.Set("action", "/dash/" + SiteID + "/emails/email/" + emails.id + "/");
                }
                else
                    val.Reset(template);
            }

            if (emails.id != 0)
            {
                emails = new Emails(emails.id, val);
                template.Set("nickname", emails.name);
                template.Set("subject", emails.subject);
                template.Set("ishtml", emails.is_html.ToChecked());
                template.Set("emailtemplate", emails.email_template);
            }
        }
    }

}