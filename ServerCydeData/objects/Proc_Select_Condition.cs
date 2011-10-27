using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;

namespace ServerCydeData
{
    public partial class Proc_Select_Condition
    {
        public String ParameterName1
        {
            get {return this.attribute_name.MakeSEOURL().Replace("-", "");}
        }
        public String ParameterName2
        {
            get { return this.attribute_name.MakeSEOURL().Replace("-", "") + "2"; }
        }

    }
}