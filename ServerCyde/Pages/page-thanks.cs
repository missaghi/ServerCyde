using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;

namespace ServerCyde.Pages
{
    [HttpHandler("/signup/thanks/")]
    public class page_thanks : Handler
    {
        public page_thanks()
            : base("/a/html/public/thanks.html")
        {



        }

    }
}