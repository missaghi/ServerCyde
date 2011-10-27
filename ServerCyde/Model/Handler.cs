using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;
using ServerCydeData;

namespace ServerCyde
{
    public class Handler : SharpFusion.Handler
    { 
        protected User CurrentUser { get; set; }

        public Handler(SharpFusion.Handler.ContentType contentType) : base(contentType) { Init(false); }
        public Handler(SharpFusion.Handler.ContentType contentType, Boolean SessionRequired) : base(contentType) { Init(SessionRequired); }

        public Handler() {
            Init(false);
        }

        public Handler(String templatepath)
            : base(templatepath)
        {
            Init(false);
        }

        public Handler(string TemplatePath, bool SessionRequired)
            : base(TemplatePath)
        {
            Init(SessionRequired);
        }

        public Handler(bool SessionRequired)
        {
            Init(SessionRequired);
        }

        public void Init(bool SessionRequired)
        {
            //onDispose += new OnDisposeHandler(Page_onDispose);

            CurrentUser = User.GetUser(context, val); 

            if (SessionRequired && CurrentUser.id == 0)
                context.Response.Redirect("/signin/?msg=1&redirect=" + context.Request.RawUrl.ToURL());
        }

        void Page_onDispose() 
        {
            if (template != null)
            {
                val.Reset(this.template);

                if (CurrentUser.id != 0)
                {
                    template.Set("username", CurrentUser.name);
                    template.Set((CurrentUser.id == 0).ToCustom("memberbox", "anonbox"), "hidden");
                }
            }
        } 
    }
}
