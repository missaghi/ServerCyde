using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;

namespace ServerCyde.Pages
{
    [HttpHandler("/support/")]
    public class page_support : Handler { public page_support() : base("/a/html/public/support.html") { } }
}