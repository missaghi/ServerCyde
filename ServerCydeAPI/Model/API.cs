using System;
using System.Data;
using System.Reflection;
using System.Text;
using System.Configuration;
using System.Runtime.Serialization;
using System.Web;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using SharpFusion;
using ServerCydeData;

namespace ServerCydeAPI
{

    [HttpHandler("/API/APIResponse/", Type = HttpHandler.ContentType.JSON)]
    [DataContract]
    public class APIResponse : Web, IHttpHandler
    {
        [DataMember]
        public Item[] Result { get; set; }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.AppendHeader("Access-Control-Allow-Origin", context.Request.Headers["Origin"] ?? "*");
            context.Response.AppendHeader("Access-Control-Allow-Credentials", "true");
            context.Response.Expires = 0;
            string response;

            if (HttpRuntime.Cache[Query["id"]] != null)
            {
                response = HttpRuntime.Cache[Query["id"]].ToString();
                HttpRuntime.Cache.Remove(Query["id"]);
            }
            else 
            { 
                val.ErrorMsg = "Sorry it took so long for you to get the response that I forgot what to give you";
                response = this.ToJSON(); 
            }

            //JSONP
            if (Query["callback"].NNOE())
                Write(Query["callback"] + "(" + response + ")");
            else
                context.Response.Write(response);

        }
    }

    public interface ISimpleDBCall
    {
        String[][] Parameters();
    }

    [DataContract]
    public class APICall : Web , IHttpHandler
    {
        protected Person person { get; set; }
        protected long SiteID { get; set; }
        protected Site site { get { if (_site == null) _site = new Site(SiteID, new Validate()); return _site; } }
        private Site _site { get; set; }
        protected String path {get;set;}
        protected String method { get; set; }
        protected bool isTest { get; set; }
        protected String Output { get; set; }
         

        public APICall(Validate Val)
        {
            val = Val;
            Init();
        }


        public APICall()
        {
            Init();
        }

        private void Init()
        {
            //Set properties
            path = "/" + context.Request.Path.ToLower().Trim(new char[] { '/' });
            method = path.Substring(path.LastIndexOf("/") + 1);
            SiteID = long.Parse(UrlParts[1]);
            person = Person.GetUser(context, SiteID, val);

            //Security
            if (person.id != 0)
                if (person.site_id != SiteID)
                {
                    val.Test(person.site_id == SiteID, "You account is invalid on this site");
                }

            context.Items.Add("HandlerType", Handler.ContentType.JSON); //forgot why this is here


            //Put in test mode, do this last becasue it will valid = false
            val.Test(!(isTest = context.Request.QueryString["test"] != null), "Testing");

        } 

        public void RenderTestForm(string _class)
        {
            //gen test form
            StringBuilder sb = new StringBuilder();
            Template template = new Template("/model/api.htm");

            String Field = @"<label>{0}</label><br /><input name=""{0}"" value=""{1}"" /><br />";

            foreach (Object attr in context.CurrentHandler.GetType().GetCustomAttributes(typeof(HttpHandler), false))
            {
                template.Set("RequestType", ((HttpHandler)attr).Verb);
                template.Set("URL", context.Request.Url.AbsolutePath); // ((Handler)attr).Url);
                //Gen Form Fields
                if (typeof(ISimpleDBCall).IsAssignableFrom(context.CurrentHandler.GetType()))
                {
                    foreach (String[] str in ((ISimpleDBCall)context.CurrentHandler).Parameters())
                    {
                        sb.AppendFormat(Field, str[0] ?? "", str[1] ?? "");
                    }
                }
                else
                { 
                    foreach (String str in ((HttpHandler)attr).Parameters ?? new String[] { })
                    {
                        sb.AppendFormat(Field, str, string.Empty);
                    }
                }
                template.Set("fields", sb.ToString());
            }
            Write(template.ToString());
            Write(context.CurrentHandler.ToJSON());
            context.Response.End();
        }

        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AppendHeader("Access-Control-Allow-Origin",  context.Request.Headers["Origin"] ?? "*");
            context.Response.AppendHeader("Access-Control-Allow-Credentials", "true");  
            context.Response.Expires = 0;

            if (isTest)
                RenderTestForm(context.CurrentHandler.ToString());
            else
            {
                if (Form["ServerCydeRequestType"].Like("failsafe"))
                {
                    String guid = Guid.NewGuid().ToString();
                    HttpRuntime.Cache.Add(guid, context.CurrentHandler.ToJSON(), null, DateTime.Now.AddMinutes(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.BelowNormal, null);
                    context.Response.Redirect("http://" + context.Request.UrlReferrer.DnsSafeHost + (context.Request.UrlReferrer.IsDefaultPort ? "" : ":" + context.Request.UrlReferrer.Port) + "/servercyde/?id=" + guid);
                    //context.Response.Redirect("http://" + context.Request.UrlReferrer.DnsSafeHost + "/servercyde/?id=" + guid);
                }
                else
                {
                    context.Response.ContentType = "application/json";
                    context.Response.Write(context.CurrentHandler.ToJSON());
                }
            }

        }

        #endregion

        protected long shortguid { get; set; }

        public string ParseTags(string template)
        {
            if (template.NNOE())
            {
                //tokens (including ads)
                Regex reg = new Regex(SharpFusion.Template.TokenRegex, RegexOptions.IgnoreCase); //@"\[%(\w+)%\]|token=""(\w+)""|(""~/)|[%ad:(.*?)%\]";
                MatchEvaluator replaceCallback = new MatchEvaluator(ReplaceTokenHandler);
                template = reg.Replace(template, replaceCallback); //replace tokens with any matching tags or string.Empty
            }
            return template;
        }


        /// <summary>Replaces the token Tag with the token Value.</summary> 
        /// <param name="token">Token.</param> 
        private string ReplaceTokenHandler(Match token)
        {
            //first group match is the original match
            String value = token.Groups[1].ToString().ToLower();
            value = value.Trim().NOE() ? token.Groups[2].ToString().ToLower() : value;
            value = value.Trim().NOE() ? token.Groups[3].ToString().ToLower() : value;
            value = value.Trim().NOE() ? token.Groups[4].ToString().ToLower() : value;

            if (value.LikeOne(new string[] { "currentusername", "currentuserid" }))
            {
                if (person != null)
                {
                    //Security
                    val.Test(person.IsAuthenticated, "You need to sign in to do this");
                    if (val.Valid)
                        val.Test(person.confirmed ?? false, "You need to confirm your email to do this");
                }
            }

            if (val.Valid)
            {

                if (value.Like("currenttime"))
                {
                    return DateTime.Now.ToMsSinceEpoch().ToJSON();
                }
                if (value.Like("ipaddress"))
                {
                    return HttpContext.Current.Request.UserHostAddress;
                }
                else if (value.Like("currentuserid"))
                {
                    return person.id.ToString();
                }
                else if (value.Like("currentusername"))
                {
                    return person.Name.ToString();
                }
                else if (value.Like("shortguid"))
                { return shortguid == 0 ? Guid.NewGuid().ToString() : rBase62.NumberTorBase62(shortguid); }
                else if (value.Like("guid"))
                { return Guid.NewGuid().ToString(); }
                else return "";
            }
            else return "";

        }
    }
}
