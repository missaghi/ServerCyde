using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;

namespace ServerCyde.Pages
{
    [HttpHandler("/signup/")]
    public class page_newsletter : Handler
    {
        public page_newsletter()
            : base("/a/html/public/sign-up.html")
        {

            context.Response.Redirect("/register/", true);

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
}