using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;

namespace ServerCyde.Pages
{
    [HttpHandler("/")]
    public class page_home : Handler
    {
        public page_home()
            : base("/a/html/public/home.html")
        {

            if (isPost)
            {
                System.IO.File.AppendAllText("c:/iis/servercyde/emails.txt", val.TestPattern(Form["email"], StringType.Email, "Does not compute") + "\t" + context.Request.UserHostAddress + "\t" + DateTime.Now.ToString() + "\r");
                if (val.Valid)
                {
                    context.Response.Redirect("/signup/thanks/");
                }
            }


        }

    }


    [HttpHandler("/pricing/")]
    public class page_pricing : Handler
    {
        public page_pricing()
            : base("/a/html/public/plans-pricing.html")
        {

            


        }

    }

}