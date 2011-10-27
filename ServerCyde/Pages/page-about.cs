using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;

namespace ServerCyde.Pages
{
    [HttpHandler("/about/")]
    public class page_about : Handler
    {
        public page_about()
            : base("/a/html/public/about.html")
        {



        }

    }
}