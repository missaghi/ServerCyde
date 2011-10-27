using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Proc_Select_Field  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 proc_select_id { get; set; }
		public String attribute_name { get; set; }
		public Boolean? is_count { get; set; }
        
        //Parents          
        public Proc_Select parent_proc_select_proc_select_id { get { if (_parent_proc_select_proc_select_id == null || _parent_proc_select_proc_select_id.id == 0) _parent_proc_select_proc_select_id = new Proc_Select(proc_select_id, val); return _parent_proc_select_proc_select_id; } set { _parent_proc_select_proc_select_id = value; } }
        private Proc_Select _parent_proc_select_proc_select_id { get; set; }
        
        //Children 

        //default
        public Proc_Select_Field(Validate val)
        {
            this.val = val;
        }

        //select one
        public Proc_Select_Field(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_proc_select_field_sel dal = new DAL.Procs.usp_proc_select_field_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_proc_select_field_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.proc_select_id = rs1.proc_select_id;
					this.attribute_name = rs1.attribute_name;
					if (rs1.is_count.HasValue) this.is_count = rs1.is_count.Value;;
                }
            }
        }

#region Lists        
        //get Proc_Select_Fields by Proc_Select proc_select_id
        public static IList<Proc_Select_Field> GetProc_Select_FieldsByProc_Select_proc_select_id(Int64 proc_select_id, Validate val)
        {

            List<Proc_Select_Field> _Proc_Select_Fields = new List<Proc_Select_Field>();
            using (DAL.Procs.usp_proc_select_field_sel_by_proc_select_id dal = new DAL.Procs.usp_proc_select_field_sel_by_proc_select_id())
            {
                dal.proc_select_id = proc_select_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_proc_select_field_sel_by_proc_select_id.ResultSet1 rs1 in dal.RS1)
                {
                    Proc_Select_Field _Proc_Select_Field = new Proc_Select_Field(val);
                    
					_Proc_Select_Field.id = rs1.id;
					if (rs1.created_dt.HasValue) _Proc_Select_Field.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Proc_Select_Field.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Proc_Select_Field.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Proc_Select_Field.is_deleted = rs1.is_deleted.Value;
					_Proc_Select_Field.proc_select_id = rs1.proc_select_id;
					_Proc_Select_Field.attribute_name = rs1.attribute_name;
					if (rs1.is_count.HasValue) _Proc_Select_Field.is_count = rs1.is_count.Value;
                    _Proc_Select_Fields.Add(_Proc_Select_Field);
                }

            }
            return _Proc_Select_Fields;
        }   
#endregion

        public Proc_Select_Field UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_proc_select_field_ups dal = new DAL.Procs.usp_proc_select_field_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.proc_select_id = this.proc_select_id;
					dal.attribute_name = this.attribute_name;
					dal.is_count = this.is_count;
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

            using (DAL.Procs.usp_proc_select_field_del dal = new DAL.Procs.usp_proc_select_field_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}