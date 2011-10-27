using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;

namespace ServerCyde.Pages
{
    [HttpHandler("/blog/")]
    public class page_blog : Handler
    {
        public page_blog()
            : base("/a/html/public/blog/blog-post.html")
        {



        }

    }
}