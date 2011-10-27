using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;

namespace ServerCydeData
{
    public partial class Proc_Modify
    {
        public long Increment(Validate val)
        {
            using (DAL.Procs.usp_proc_modify_increment dal = new DAL.Procs.usp_proc_modify_increment())
            {
                dal.id = this.id;
                dal.Execute(val);
                this.requests = dal.newid;
            }

            return this.requests ?? 0;
        }
    }
}