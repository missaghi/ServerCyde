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
using System.Net;
using System.IO;

namespace ServerCydeAPI
{ 

    [HttpHandler("/API/*/API/*/")]
    [DataContract]
    public class APIapi : ServerCydeAPI.APICall, ISimpleDBCall
    {
        [DataMember]
        public Item[] Result { get; set; }
        [DataMember]
        public String ProcName { get; set; }
        public Proc_Api api { get; set; }
        string[][] ISimpleDBCall.Parameters()
        {
            return new string[][] { api.ReturnFields() };
        }

        public APIapi()
        {
            if (!context.Request.IsLocal)
            {
                if (context.Request.UserHostName.NNOE())
                    if (!(site.name ?? "").Like(context.Request.UserHostName))
                    {
                        //throw new Exception("This domain name (" + context.Request.UserHostName + ") is not registered");
                    }
            }

            api = new Proc_Api(long.Parse(UrlParts[3]), new Validate());

            this.ProcName = api.name;

            if (val.Valid)
            {

                context.Response.ContentType = api.return_type;

                string url = api.ParseTags(person, (Web)this).ToHTMLDecode();
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = api.method.Else("GET");
                request.UserAgent = api.useragent.Else(" Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.163 Safari/535.1");
                //request.Referer
                request.MaximumAutomaticRedirections = 10;
                request.AllowAutoRedirect = true;

                string result = string.Empty;
                try
                {
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        result = reader.ReadToEnd();
                        context.Response.Write(result); 
                    }
                }
                catch (WebException e)
                { 
                    context.Response.StatusCode = 500;

                    using (WebResponse response = e.Response)
                    {
                        HttpWebResponse httpResponse = (HttpWebResponse)response;
                        context.Response.Write(string.Format(url +"/n Error code: {0}", httpResponse.StatusCode));
                        using (Stream data = response.GetResponseStream())
                        {
                            string text = new StreamReader(data).ReadToEnd();
                            //throw new Exception("Error code: " + httpResponse.StatusCode.ToString() + "\n" + text + "/n" + url);
                            context.Response.Write("\n" + text);
                            
                        }
                    }
                }

                context.Response.End();
            }
        }

       
    }
}
 