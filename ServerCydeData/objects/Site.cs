using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;

namespace ServerCydeData
{
    public partial class Site
    {
        public static void ValidateSite(Web web, string siteid)
        {
            Site site = new Site(long.Parse(siteid), new Validate());

            if (!web.context.Request.IsLocal && web.context.Request.UserHostName != web.context.Request.UserHostAddress)
            {
                if (web.context.Request.UrlReferrer != null)
                    if (!(site.url ?? "").Replace("http://", "").Replace("https://", "").Like(web.context.Request.UrlReferrer.Host.Replace("http://", "").Replace("https://", "")))
                    {
                        //throw new Exception("This domain name (" + web.context.Request.UserHostName + ") is not registered"); nned support for aliases
                    }
            }
        }

        public Email SiteEmail()
        {
            return new Email(this.smtpserver, this.smtpusername, this.smtppassword);
        }
    }
}