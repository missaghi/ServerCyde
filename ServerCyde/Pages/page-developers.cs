using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;

namespace ServerCyde.Pages
{
    [HttpHandler("/developers/")]
    public class page_developers : Handler
    { public page_developers() : base("/a/html/public/developers.html") { } }

    [HttpHandler("/docs/")]
    public class page_docs : Handler
    { public page_docs() : base("/a/html/public/docs.html") { } }

    [HttpHandler("/demos/")]
    public class page_demos : Handler
    { public page_demos() : base("/a/html/sandbox/sandbox.htm") { } }


    [HttpHandler("/showcase/")]
    public class page_showcase : Handler
    { public page_showcase() : base("/a/html/public/showcase.html") { } }


    
    
}