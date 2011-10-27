using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Threading;
using SharpFusion;
using ServerCydeData;


namespace ServerCydeAPI
{
    [HttpHandler("/API/*/Comet/APICometPost/", Type = HttpHandler.ContentType.JSON, Verb = HttpHandler.HTTPVerb.ALL, Parameters = new string[] { "ChannelID", "Message" })]
    [DataContract]
    public class APICometPost : APICall
    {
        [DataMember]
        public String Message { get; set; }
        [DataMember]
        public Person Person { get; set; }

        public APICometPost() 
        {
            Site.ValidateSite(this, UrlParts[1]);

            if (SiteID != 3) //demo site
            {
                val.Test(person.IsAuthenticated, "You need to sign in to do this");
                if (val.Valid)
                    val.Test(person.confirmed ?? false, "You need to confirm your email to do this");
            }

            if (val.Valid)
            {
                Message = ParseTags(Form["message"]);
                Person = person;

                HashSet<Comet.AsyncRequestState> clients;
                if ((HttpRuntime.Cache[UrlParts[1] + "-" + Form["ChannelID"]] != null))
                {
                    clients = ((HashSet<Comet.AsyncRequestState>)HttpRuntime.Cache[UrlParts[1] + "-" + Form["ChannelID"]]);
                    HttpRuntime.Cache.Remove(UrlParts[1] + "-" + Form["ChannelID"]);
                }
                else
                    clients = new HashSet<Comet.AsyncRequestState>();

                foreach (Comet.AsyncRequestState ar in clients)
                {
                    APICometSubscribe.ReturnPiComet(ar, this.ToJSON());
                }
            }
        }
    }

    [HttpHandler("/API/*/Comet/Count/", Type = HttpHandler.ContentType.JSON, Verb = HttpHandler.HTTPVerb.ALL, Parameters = new string[] { "userid" })]
    [DataContract]
    public class APICountUser : APICall
    {
        [DataMember]
        public int count { get; set; }

        public APICountUser()
        {
            count = 0;

            HashSet<Comet.AsyncRequestState> clients;
            if ((HttpRuntime.Cache[UrlParts[1] + "-" + Form["ChannelID"]] != null))
            {
                count = ((HashSet<Comet.AsyncRequestState>)HttpRuntime.Cache[UrlParts[1] + "-" + Form["ChannelID"]]).Count();
            }

        }
    }

    [HttpHandler("/API/*/Comet/APIFlagUser/", Type = HttpHandler.ContentType.JSON, Verb = HttpHandler.HTTPVerb.ALL, Parameters = new string[] { "userid" })]
    [DataContract]
    public class APIFlagUser : APICall
    {
        public APIFlagUser()
        {
            Person user = new Person(Form["userid"].ToLong(0), val);
            user.FlaggedBy.Add(context.Request.UserHostAddress);
        }
    }

    [HttpHandler("/API/*/Comet/APICometSubscribe/", Type = HttpHandler.ContentType.JSON, Verb = HttpHandler.HTTPVerb.ALL, Parameters = new string[] { "ChannelID" })]
    public class APICometSubscribe : SharpFusion.Comet
    {
        public APICometSubscribe() : base(ProcessRequest)
        {
            
        }

        public static void ProcessRequest(Comet.AsyncRequestState cometstate)
        {
            Web web = new Web(cometstate._context);

            //add context to hashset else create new set 
            Site.ValidateSite(web, web.UrlParts[1]);

            HashSet<Comet.AsyncRequestState> clients;

            if (HttpRuntime.Cache[web.UrlParts[1] + "-" + web.Query["ChannelID"]] == null)
            {
                clients = new HashSet<Comet.AsyncRequestState>();
            }
            else
                clients = (HashSet<Comet.AsyncRequestState>)(HttpRuntime.Cache[web.UrlParts[1] + "-" + web.Query["ChannelID"]]);

            clients.Add(cometstate);

            HttpRuntime.Cache.Add(web.UrlParts[1] + "-" + web.Query["ChannelID"], clients, null,
                System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 20), System.Web.Caching.CacheItemPriority.Normal,
                new System.Web.Caching.CacheItemRemovedCallback(Expired));
        }

        private static void Expired(string str, object obj, System.Web.Caching.CacheItemRemovedReason reason)
        {
            if (reason == System.Web.Caching.CacheItemRemovedReason.Expired)
            {
                //Recconect 
                HashSet<Comet.AsyncRequestState> clients = (HashSet<Comet.AsyncRequestState>)obj;
                foreach (Comet.AsyncRequestState ar in clients)
                { 
                   ReturnPiComet(ar, "{\"val\":{\"ErrorMsg\":\"Timeout\",\"Errors\":[],\"Valid\":false}}");
                }
            }

        }

        public static void ReturnPiComet(Comet.AsyncRequestState ar, string data)
        {
            if (!ar.IsCompleted)
            {
                ar._context.Response.AppendHeader("Access-Control-Allow-Origin", ("*"));
                ar._context.Response.Expires = 0;

                if ((ar._context.Request.Form["ServerCydeRequestType"] ?? "").Like("failsafe"))
                {
                    String guid = Guid.NewGuid().ToString();
                    HttpRuntime.Cache.Add(guid, data, null, DateTime.Now.AddMinutes(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.BelowNormal, null);
                    ar._context.Response.Redirect("http://" + ar._context.Request.UrlReferrer.DnsSafeHost + "/servercyde/?id=" + guid);
                }
                else if (ar._context.Request.QueryString["callback"] != null)
                {
                    ar._context.Response.Write(
                    ar._context.Request.QueryString["callback"] + "(" + data + ");");
                }
                else
                {
                    ar._context.Response.ContentType = "application/json";
                    ar._context.Response.Write(data);
                }

                ar.CompleteRequest();
            }
        }
    }

     

}
