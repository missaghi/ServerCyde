using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using SharpFusion;
using ServerCydeData;
using System.Net;
using System.IO;

namespace ServerCydeAPI.API
{ 

    [HttpHandler("/API/*/Person/oAuth/Facebook/", Type = HttpHandler.ContentType.JSON, Verb = HttpHandler.HTTPVerb.POST, Parameters = new string[] { "id" })]
    [DataContract]
    public class APIFacebook : ServerCydeAPI.APICall
    {
        [DataMember]
        public Person Person { get; set; }

        public APIFacebook()
        {
            //get token 
            if (Query["error_reason"].NOE())  //didn't decline
            {
                string code = Query["code"];

                string url = "https://graph.facebook.com/oauth/access_token?" +
                    "client_id=" + site.FBKey +
                    "&redirect_uri=" + "http://" + context.Request.UrlReferrer.DnsSafeHost + "/servercyde" +
                    "&client_secret=" + site.FBPassword +
                    //"&type=client_cred" + //might be unessesary from server
                    "&code=" + code;

                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

                string token = string.Empty;
                try
                {
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        token = HttpUtility.ParseQueryString(reader.ReadToEnd())["access_token"];
                    }
                }
                catch (WebException e)
                {
                    using (WebResponse response = e.Response)
                    {
                        HttpWebResponse httpResponse = (HttpWebResponse)response;
                        context.Response.Write(string.Format("Error code: {0}", httpResponse.StatusCode));
                        using (Stream data = response.GetResponseStream())
                        {
                            string text = new StreamReader(data).ReadToEnd();
                            throw new Exception("Error code: " + httpResponse.StatusCode.ToString() + "\n\n" + text + "\n\n code:" + code);
                        }
                    }
                }

                Facebook.FacebookAPI api = new Facebook.FacebookAPI(token);
                Facebook.JSONObject me = api.Get("/me", Facebook.ApiType.Graph);

                //now signup or if signed up and authed for facebook then sign in
                if (me.Dictionary["email"].String.Like(person.email))
                {
                    person.confirmed = true;
                    new Person_Oauth(val) { person_id = person.id, service_name = "Facebook", authorized = true, token = token }.UpSert(person);
                }                
                else
                {
                    Person user = new Person(Person.GetUserID(val.TestPattern(me.Dictionary["email"].String, StringType.Email, "Email is required"), SiteID, val), val);
                    if (user.id != 0) //existing user
                    {
                        if (user.get_children_person_oauth_person_ids.Any(x => x.service_name.Like("Facebook") && (x.authorized ?? false)))
                        {
                            person = user;
                            person.NewSession(context, true);
                        }
                        else
                        {
                            val.ErrorMsg = "You have not yet authorized Facebook login for this account. To do so sign in with another method then connect with Facebook";
                        }
                    }
                    else //new user
                    {

                        person = new Person(val);

                        person.name = val.TestEmpty(me.Dictionary["first_name"].String + " " + me.Dictionary["last_name"].String, "Name is required");
                        person.email = val.TestPattern(me.Dictionary["email"].String, StringType.Email, "Email is required");
                        person.Password = (val.TestEmpty(token, "Password is required")); //store encrypted password
                        person.site_id = SiteID;
                        person.ip = context.Request.UserHostAddress;
                        person.AuthorizedLevel = GenObjects.AuthLevel.Write;
                        person.confirmed = true; //facebook already confirms emails
                        person.UpSert(person);

                        if (val.Valid)
                        {
                            new Person_Oauth(val) { person_id = person.id, service_name = "Facebook", authorized = true, token = token }.UpSert(person);
                            person.NewSession(context, true); 
                        }
                    }
                } 
            }
        }
    }
   

}