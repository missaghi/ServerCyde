using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Proc_Modify_Item  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 proc_modify_id { get; set; }
		public String item_name { get; set; }
        
        //Parents          
        public Proc_Modify parent_proc_modify_proc_modify_id { get { if (_parent_proc_modify_proc_modify_id == null || _parent_proc_modify_proc_modify_id.id == 0) _parent_proc_modify_proc_modify_id = new Proc_Modify(proc_modify_id, val); return _parent_proc_modify_proc_modify_id; } set { _parent_proc_modify_proc_modify_id = value; } }
        private Proc_Modify _parent_proc_modify_proc_modify_id { get; set; }
        
        //Children          
        public IList<Proc_Modify_Attribute> get_children_proc_modify_attribute_proc_modify_item_ids { get { if (_proc_modify_attribute_proc_modify_item_ids == null || _proc_modify_attribute_proc_modify_item_ids.Count == 0) _proc_modify_attribute_proc_modify_item_ids = Proc_Modify_Attribute.GetProc_Modify_AttributesByProc_Modify_Item_proc_modify_item_id(id ,val); return _proc_modify_attribute_proc_modify_item_ids; } set { _proc_modify_attribute_proc_modify_item_ids = value; } }
        private IList<Proc_Modify_Attribute> _proc_modify_attribute_proc_modify_item_ids ;         
        public IList<Proc_Modify_Expected> get_children_proc_modify_expected_proc_modify_item_ids { get { if (_proc_modify_expected_proc_modify_item_ids == null || _proc_modify_expected_proc_modify_item_ids.Count == 0) _proc_modify_expected_proc_modify_item_ids = Proc_Modify_Expected.GetProc_Modify_ExpectedsByProc_Modify_Item_proc_modify_item_id(id ,val); return _proc_modify_expected_proc_modify_item_ids; } set { _proc_modify_expected_proc_modify_item_ids = value; } }
        private IList<Proc_Modify_Expected> _proc_modify_expected_proc_modify_item_ids ;

        //default
        public Proc_Modify_Item(Validate val)
        {
            this.val = val;
        }

        //select one
        public Proc_Modify_Item(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_proc_modify_item_sel dal = new DAL.Procs.usp_proc_modify_item_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_proc_modify_item_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.proc_modify_id = rs1.proc_modify_id;
					this.item_name = rs1.item_name;
                }
            }
        }

#region Lists        
        //get Proc_Modify_Items by Proc_Modify proc_modify_id
        public static IList<Proc_Modify_Item> GetProc_Modify_ItemsByProc_Modify_proc_modify_id(Int64 proc_modify_id, Validate val)
        {

            List<Proc_Modify_Item> _Proc_Modify_Items = new List<Proc_Modify_Item>();
            using (DAL.Procs.usp_proc_modify_item_sel_by_proc_modify_id dal = new DAL.Procs.usp_proc_modify_item_sel_by_proc_modify_id())
            {
                dal.proc_modify_id = proc_modify_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_proc_modify_item_sel_by_proc_modify_id.ResultSet1 rs1 in dal.RS1)
                {
                    Proc_Modify_Item _Proc_Modify_Item = new Proc_Modify_Item(val);
                    
					_Proc_Modify_Item.id = rs1.id;
					if (rs1.created_dt.HasValue) _Proc_Modify_Item.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Proc_Modify_Item.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Proc_Modify_Item.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Proc_Modify_Item.is_deleted = rs1.is_deleted.Value;
					_Proc_Modify_Item.proc_modify_id = rs1.proc_modify_id;
					_Proc_Modify_Item.item_name = rs1.item_name;
                    _Proc_Modify_Items.Add(_Proc_Modify_Item);
                }

            }
            return _Proc_Modify_Items;
        }   
#endregion

        public Proc_Modify_Item UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_proc_modify_item_ups dal = new DAL.Procs.usp_proc_modify_item_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.proc_modify_id = this.proc_modify_id;
					dal.item_name = this.item_name;
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

            using (DAL.Procs.usp_proc_modify_item_del dal = new DAL.Procs.usp_proc_modify_item_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}