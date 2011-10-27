using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Proc_Modify_Attribute  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 proc_modify_item_id { get; set; }
		public String attribute_name { get; set; }
		public String value { get; set; }
		public Boolean? replace { get; set; }
        
        //Parents          
        public Proc_Modify_Item parent_proc_modify_item_proc_modify_item_id { get { if (_parent_proc_modify_item_proc_modify_item_id == null || _parent_proc_modify_item_proc_modify_item_id.id == 0) _parent_proc_modify_item_proc_modify_item_id = new Proc_Modify_Item(proc_modify_item_id, val); return _parent_proc_modify_item_proc_modify_item_id; } set { _parent_proc_modify_item_proc_modify_item_id = value; } }
        private Proc_Modify_Item _parent_proc_modify_item_proc_modify_item_id { get; set; }
        
        //Children 

        //default
        public Proc_Modify_Attribute(Validate val)
        {
            this.val = val;
        }

        //select one
        public Proc_Modify_Attribute(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_proc_modify_attribute_sel dal = new DAL.Procs.usp_proc_modify_attribute_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_proc_modify_attribute_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.proc_modify_item_id = rs1.proc_modify_item_id;
					this.attribute_name = rs1.attribute_name;
					this.value = rs1.value;
					if (rs1.replace.HasValue) this.replace = rs1.replace.Value;;
                }
            }
        }

#region Lists        
        //get Proc_Modify_Attributes by Proc_Modify_Item proc_modify_item_id
        public static IList<Proc_Modify_Attribute> GetProc_Modify_AttributesByProc_Modify_Item_proc_modify_item_id(Int64 proc_modify_item_id, Validate val)
        {

            List<Proc_Modify_Attribute> _Proc_Modify_Attributes = new List<Proc_Modify_Attribute>();
            using (DAL.Procs.usp_proc_modify_attribute_sel_by_proc_modify_item_id dal = new DAL.Procs.usp_proc_modify_attribute_sel_by_proc_modify_item_id())
            {
                dal.proc_modify_item_id = proc_modify_item_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_proc_modify_attribute_sel_by_proc_modify_item_id.ResultSet1 rs1 in dal.RS1)
                {
                    Proc_Modify_Attribute _Proc_Modify_Attribute = new Proc_Modify_Attribute(val);
                    
					_Proc_Modify_Attribute.id = rs1.id;
					if (rs1.created_dt.HasValue) _Proc_Modify_Attribute.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Proc_Modify_Attribute.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Proc_Modify_Attribute.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Proc_Modify_Attribute.is_deleted = rs1.is_deleted.Value;
					_Proc_Modify_Attribute.proc_modify_item_id = rs1.proc_modify_item_id;
					_Proc_Modify_Attribute.attribute_name = rs1.attribute_name;
					_Proc_Modify_Attribute.value = rs1.value;
					if (rs1.replace.HasValue) _Proc_Modify_Attribute.replace = rs1.replace.Value;
                    _Proc_Modify_Attributes.Add(_Proc_Modify_Attribute);
                }

            }
            return _Proc_Modify_Attributes;
        }   
#endregion

        public Proc_Modify_Attribute UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_proc_modify_attribute_ups dal = new DAL.Procs.usp_proc_modify_attribute_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.proc_modify_item_id = this.proc_modify_item_id;
					dal.attribute_name = this.attribute_name;
					dal.value = this.value;
					dal.replace = this.replace;
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

            using (DAL.Procs.usp_proc_modify_attribute_del dal = new DAL.Procs.usp_proc_modify_attribute_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}