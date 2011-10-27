using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;
using ServerCydeData;

namespace ServerCyde.Pages
{
    public class DashPages : Handler
    {
        protected long SiteID { get; set; }
        protected Site site { get { if (_site == null) _site = new Site(SiteID, new Validate()); return _site; } }
        private Site _site { get; set; }

        public DashPages() {
            Init();
        }

        public DashPages(string templatepath) : base(templatepath, true) {
            Init();
        }

        private void Init()
        {
            if (!CurrentUser.IsAuthenticated)
                context.Response.Redirect("/signin/?msg=1&redirect=" + context.Request.RawUrl.ToURL() , true);

            if (UrlParts.Length > 1 && !UrlParts[1].Like("0"))
            {
                SiteID = long.Parse(UrlParts[1]);

                if (site.user_id != CurrentUser.id) //prevent someone changing someone elses site
                {
                    context.Response.Write("You are not allowed to do that, tsk, tsk.");
                    context.Response.End();
                }
            }
            else
            {
                if (template != null)
                template.Set("hidesitenav", "hidden");
            }

            if (template != null)
            {
                template.Set("dash_site_options", HTML.SelectOptions((from x in CurrentUser.get_children_site_user_ids select new string[] { x.id.ToString(), x.name }).ToList().AddToList(new String[] {"0", "Add New Site"}).ToArray(), new string[] { SiteID.ToString() }, true));
                template.Set("dash_currentusername", CurrentUser.Name);
                template.Set("siteid", SiteID);
                template.Set("footer", Cached.GetFile("/a/html/dash/footer.htm"));
            }
        }
    }
}