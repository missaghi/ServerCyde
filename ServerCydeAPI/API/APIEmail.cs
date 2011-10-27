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
using System.Net.Mail;

namespace ServerCydeAPI
{ 

    [HttpHandler("/API/*/Email/*/", Type = HttpHandler.ContentType.JSON)]
    [DataContract]
    public class APIEmail : ServerCydeAPI.APICall, ISimpleDBCall
    {
        [DataMember]
        public Item[] Result { get; set; }
        [DataMember]
        public String ProcName { get; set; }
        public Emails emails { get; set; }
        string[][] ISimpleDBCall.Parameters()
        {
            return new string[][] { emails.ReturnFields() };
        }

        public APIEmail()
        {
            if (!context.Request.IsLocal)
            {
                if (context.Request.UserHostName.NNOE())
                    if (!(site.name ?? "").Like(context.Request.UserHostName))
                    {
                        //throw new Exception("This domain name (" + context.Request.UserHostName + ") is not registered");
                    }
            }

            emails = new Emails(long.Parse(UrlParts[3]), new Validate());

            this.ProcName = emails.name;

            //check SMTP
            val.TestEmpty(site.smtpserver, "SMTP server is not specified");
            //val.TestEmpty(site.smtpusername, "SMTP server username is not specified");
            //val.TestEmpty(site.smtppassword, "SMTP server password is not specified");

            if (val.Valid)
            {

                Person recipent = new Person(ParseTags(Form["ToUserID"]).ToLong(0), val);

                val.Test(recipent.confirmed ?? false, "We can only send to confirmed user accounts.");

                if (val.Valid)
                {

                    Email email = site.SiteEmail();
                    email.From = new MailAddress(site.supportemail, site.supportemailname);
                    email.To.Add(new MailAddress(recipent.email, recipent.Name));
                    if (Form["replytoemail"].NNOE())
                    {
                        email.ReplyToList.Add(new MailAddress(Form["replytoemail"], Form["replytoname"]));
                    }
                    email.Subject = emails.subject;
                    email.IsBodyHtml = emails.is_html ?? true;
                    email.Body = emails.ParseTags(person, (Web)this).ToHTMLDecode();

                    email.Send(val);
                }
            }
        }

       
    }
}
 