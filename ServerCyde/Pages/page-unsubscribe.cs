using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;

namespace ServerCyde.Pages
{
    [HttpHandler("/unsubscribe/")]
    public class page_unsubscribe : Handler
    {
        public page_unsubscribe()
            : base("/a/html/public/unsubscribe.html")
        {
            if (isPost)
            {
                System.IO.File.AppendAllText("c:/iis/servercyde/unsubscribed.txt", val.TestPattern(Form["email"], StringType.Email, "Does not compute") + "\t" + context.Request.UserHostAddress + "\t" + DateTime.Now.ToString() + "\r");
                if (val.Valid)
                {
                    context.Response.Redirect("/unsubscribed/");
                }
            }
        }
    }

    [HttpHandler("/unsubscribed/")]
    public class page_unsubscribed : Handler
    {
        public page_unsubscribed()
            : base("/a/html/public/unsubscribed.html")
        {

        }
    }

}