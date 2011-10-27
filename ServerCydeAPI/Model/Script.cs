using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;
using ServerCydeData;

namespace ServerCydeAPI
{
    public class Script : SharpFusion.Handler
    {
        public Person CurrentPerson { get; set; }

        public Script() { Init(false); }

        public Script(String templatepath)
            : base(templatepath)
        {
            Init(false);
        }

        public Script(string TemplatePath, bool SessionRequired)
            : base(TemplatePath)
        {
            Init(SessionRequired);
        }

        public Script(bool SessionRequired)
        {
            Init(SessionRequired);
        }

        public void Init(bool SessionRequired)
        {
            base.onDispose+=new OnDisposeHandler(Page_onDispose);

            context.Response.ContentType = "application/javascript";
            context.Response.Charset = "utf-8";
        }

        void Page_onDispose() 
        {
            if (template != null)
            {
                val.Reset(this.template);

                if (CurrentPerson != null && CurrentPerson.id != 0)
                {
                    template.Set("CurrentPersonName", CurrentPerson.name); 
                }

                template.WritePage(context);
                 
            }
        } 
    }
}
