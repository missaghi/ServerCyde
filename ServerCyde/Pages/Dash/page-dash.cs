using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;

namespace ServerCyde.Pages
{ 
    [HttpHandler("/dash/")]
    public class page_dash : DashPages
    {
        public page_dash()
            : base("/a/html/dash/home.htm")
        {

            template.Set("Sites", string.Join("\n", (from x in CurrentUser.get_children_site_user_ids select string.Format("<li><a href='/dash/{0}/site/'>{1}</a> <small>( Requests: {2} )</small></li>", x.id, x.name, x.Requests)).ToList().AddToList("<li><a href='/dash/0/site/'><b>+</b> Add new site</a></li>").ToArray()));
            
        }
    }
}