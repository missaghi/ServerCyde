using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using SharpFusion;
using System.Reflection;


namespace ServerCyde
{
    public class Module : IHttpModule
    {

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Init(HttpApplication app)
        {
            app.BeginRequest += new EventHandler(app_BeginRequest); 
            //if (!HttpContext.Current.IsDebuggingEnabled)
                app.Error +=  new EventHandler(this.app_Error);
        }
         

        void app_BeginRequest(object sender, EventArgs e)
        {
            ((HttpApplication)sender).Context.Items.Add("Time", DateTime.Now);
            ((HttpApplication)sender).Context.Items.Add("Queries", "");
        }
              

        public void app_Error(Object source, EventArgs e)
        {



            //try
            //{
            HttpContext context = ((HttpApplication)source).Context;
            HandleError(context);
            //}
            //catch (Exception ex)
            //{
            //    context = ((HttpApplication)source).Context;
            //    if (context.IsDebuggingEnabled)
            //        throw ex;
            //    else
            //    {
            //        context.Response.Write("Invalid URL?");
            //        Email.Send("riaz.missaghi@deluxe.com", "support@partnerup.com", "Prod Error", ex.Message + ex.StackTrace);
            //    }
            //    context.Response.End();
            //}
        }

        public static void Handle404(HttpContext context)
        {
            context.Response.StatusCode = 404;
            Exception ee;
              
            if (context.Server.GetLastError() == null)
            { 
                context.Response.Write("404");
                context.Response.End();
            }
            else
            {
                if (context.Server.GetLastError().InnerException == null)
                    ee = context.Server.GetLastError();
                else
                    ee = context.Server.GetLastError().InnerException;

                context.Response.Write(ee.Message);
                context.Server.ClearError();
                context.Response.End();
            }
        }

        public static void HandleError(HttpContext context)
        {
            Exception ee;

            String errorMsg = "";
            String subject = "";

            if (context.Response.StatusCode == 404)
            {
                Handle404(context);
            }
            else
            {

                try { context.Response.StatusCode = 200; }
                catch { }

                if (context.Server.GetLastError() == null)
                {
                     
                    context.Response.Write("500");

                    context.Server.ClearError();

                   context.Response.End();
                }
                else
                {

                    if (context.Server.GetLastError().InnerException == null)
                        ee = context.Server.GetLastError();
                    else
                        ee = context.Server.GetLastError().InnerException;

                    context.Server.ClearError(); 

                    StringBuilder sb = new StringBuilder();
                    foreach (DictionaryEntry de in ee.Data)
                    {
                        sb.AppendLine("\n" + de.Key.ToString() + ": " + de.Value.ToString());
                    }

                    sb.AppendLine("\n<h3>Form Data</h3>");

                    foreach (String key in context.Request.Form.AllKeys)
                    {
                        sb.AppendLine("\n<b>" + key + ":</b> " + context.Request.Form[key]);
                    }

                    if (ee.StackTrace.Contains("SqlClient") || ee.Message.Contains("SqlClient"))
                    {
                        errorMsg += "<h3>SqlDump: " + context.Items["LastSP"] + "</h3>";
                    }

                    if (ee.Message.ToLower().Contains("File does not exist".ToLower()) || ee.Message.Contains("File Not Found"))
                    {
                        Handle404(context);
                    }
                    else
                    {
                        
                            string guid = Guid.NewGuid().ToString();


                        errorMsg += "<h2>Error: " + ee.Message.Else("No message?") + "</h2>";
                        subject = ee.Message.Else("No message?");
                        errorMsg += "<h3>IP</h3> " + context.Request.UserHostAddress.Else("");
                        errorMsg += "<h3>HostName</h3> " + context.Request.UserHostName.Else("");
                        errorMsg += "<h3>ServeTime</h3> " + (DateTime.Now.Subtract((DateTime)context.Items["Time"])).TotalMilliseconds.ToString() + "ms";
                        errorMsg += "<h3>Queries</h3> " + (context.Items["Queries"] ?? "").ToString() + "ms";
                        errorMsg += "<h3>Session</h3> " + (context.Request.Cookies["Identity"] != null ? context.Request.Cookies["Identity"].Else("na") : "na");
                        errorMsg += "<h3>URL</h3> " + context.Request.Url.ToString() + " " + context.Request.RawUrl;
                        errorMsg += "<h3>UrlReferrer</h3> " + (context.Request.UrlReferrer == null ? "" : context.Request.UrlReferrer.ToString());
                        errorMsg += "<h3>Type</h3>" + context.Request.RequestType;
                        errorMsg += "<h3>Reflected Type: " + ee.TargetSite.ReflectedType + "</h3>";
                        errorMsg += "<h3>Stack</h3>" + ee.StackTrace.Replace("\n", "<br>");
                        errorMsg += "<h3>Data</h3>" + sb.ToString().Replace("/n", "<br>");

                        //if (!errorMsg.ToLower().Contains("The remote host closed the connection".ToLower())
                        //       && !errorMsg.Contains("Input string was not in a correct format")
                        //       && !errorMsg.Contains("Cannot redirect after HTTP headers have been sent.")
                        //       && !errorMsg.Contains("-Not"))
                        {

                            string output;
                            if (ConfigurationManager.AppSettings["debug"].ToBool() || context.Request.IsLocal  )
                            {
                                output = "Errordetails: " + errorMsg;
                               // EmailError("zse-" + ConfigurationManager.AppSettings["Location"] + " " + subject.Else("Error"), errorMsg);
                               
                            }
                            else
                            {
                                output =" 500 " + ee.Message + (context.IsDebuggingEnabled ? ee.StackTrace : "");
                                //EmailError("zse-" + ConfigurationManager.AppSettings["Location"] + " " + subject.Else("Error"), errorMsg);
                            }

                            context.Server.ClearError();

                            context.Response.AppendHeader("Access-Control-Allow-Credentials", "true");
                            context.Response.AppendHeader("Access-Control-Allow-Origin", "*"); 
                            context.Response.Expires = 0;




                            if (context.Request.IsLocal)
                            {
                                context.Response.Write(errorMsg);
                            }
                            else
                            {

                                //context.Response.ContentType = "application/json";

                                context.Response.Write("Sorry for the ugly error screen, imagine some rainbows :). I've emailed the error to the dev, your error id is: " + guid);

                                Email eml = new Email();
                                eml.Subject = "error id: " + guid;
                                eml.Body = errorMsg;
                                eml.IsBodyHtml = true;
                                eml.To.Add("easymovet@gmail.com");
                                eml.From = new System.Net.Mail.MailAddress("support@servercyde.com");
                                eml.Send(new Validate());
                            }
                            context.Response.End();
                                     


                        }

                       
                    }

                }
            }
        }
         
    }
}