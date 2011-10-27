using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Proc_Get_Attribute  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 proc_get_id { get; set; }
		public String attribute_name { get; set; }
        
        //Parents          
        public Proc_Get parent_proc_get_proc_get_id { get { if (_parent_proc_get_proc_get_id == null || _parent_proc_get_proc_get_id.id == 0) _parent_proc_get_proc_get_id = new Proc_Get(proc_get_id, val); return _parent_proc_get_proc_get_id; } set { _parent_proc_get_proc_get_id = value; } }
        private Proc_Get _parent_proc_get_proc_get_id { get; set; }
        
        //Children 

        //default
        public Proc_Get_Attribute(Validate val)
        {
            this.val = val;
        }

        //select one
        public Proc_Get_Attribute(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_proc_get_attribute_sel dal = new DAL.Procs.usp_proc_get_attribute_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_proc_get_attribute_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.proc_get_id = rs1.proc_get_id;
					this.attribute_name = rs1.attribute_name;
                }
            }
        }

#region Lists        
        //get Proc_Get_Attributes by Proc_Get proc_get_id
        public static IList<Proc_Get_Attribute> GetProc_Get_AttributesByProc_Get_proc_get_id(Int64 proc_get_id, Validate val)
        {

            List<Proc_Get_Attribute> _Proc_Get_Attributes = new List<Proc_Get_Attribute>();
            using (DAL.Procs.usp_proc_get_attribute_sel_by_proc_get_id dal = new DAL.Procs.usp_proc_get_attribute_sel_by_proc_get_id())
            {
                dal.proc_get_id = proc_get_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_proc_get_attribute_sel_by_proc_get_id.ResultSet1 rs1 in dal.RS1)
                {
                    Proc_Get_Attribute _Proc_Get_Attribute = new Proc_Get_Attribute(val);
                    
					_Proc_Get_Attribute.id = rs1.id;
					if (rs1.created_dt.HasValue) _Proc_Get_Attribute.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Proc_Get_Attribute.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Proc_Get_Attribute.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Proc_Get_Attribute.is_deleted = rs1.is_deleted.Value;
					_Proc_Get_Attribute.proc_get_id = rs1.proc_get_id;
					_Proc_Get_Attribute.attribute_name = rs1.attribute_name;
                    _Proc_Get_Attributes.Add(_Proc_Get_Attribute);
                }

            }
            return _Proc_Get_Attributes;
        }   
#endregion

        public Proc_Get_Attribute UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_proc_get_attribute_ups dal = new DAL.Procs.usp_proc_get_attribute_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.proc_get_id = this.proc_get_id;
					dal.attribute_name = this.attribute_name;
                dal.Execute(val);

                if (dal.InsertedID.HasValue)
                    this.id = dal.InsertedID.Value;
            }
            postUpsertEvent(val);

            return this;
        }

        public void Delete(bool HardDelete, GenObjects executinguser) 
        {  
           val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            using (DAL.Procs.usp_proc_get_attribute_del dal = new DAL.Procs.usp_proc_get_attribute_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}