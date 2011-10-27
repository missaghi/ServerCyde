using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Proc_Modify  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 site_id { get; set; }
		public String domain_name { get; set; }
		public Boolean? delete_put { get; set; }
		public Boolean? batch { get; set; }
		public String name { get; set; }
		public Int64? requests { get; set; }
        
        //Parents          
        public Site parent_site_site_id { get { if (_parent_site_site_id == null || _parent_site_site_id.id == 0) _parent_site_site_id = new Site(site_id, val); return _parent_site_site_id; } set { _parent_site_site_id = value; } }
        private Site _parent_site_site_id { get; set; }
        
        //Children          
        public IList<Proc_Modify_Item> get_children_proc_modify_item_proc_modify_ids { get { if (_proc_modify_item_proc_modify_ids == null || _proc_modify_item_proc_modify_ids.Count == 0) _proc_modify_item_proc_modify_ids = Proc_Modify_Item.GetProc_Modify_ItemsByProc_Modify_proc_modify_id(id ,val); return _proc_modify_item_proc_modify_ids; } set { _proc_modify_item_proc_modify_ids = value; } }
        private IList<Proc_Modify_Item> _proc_modify_item_proc_modify_ids ;

        //default
        public Proc_Modify(Validate val)
        {
            this.val = val;
        }

        //select one
        public Proc_Modify(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_proc_modify_sel dal = new DAL.Procs.usp_proc_modify_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_proc_modify_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.site_id = rs1.site_id;
					this.domain_name = rs1.domain_name;
					if (rs1.delete_put.HasValue) this.delete_put = rs1.delete_put.Value;;
					if (rs1.batch.HasValue) this.batch = rs1.batch.Value;;
					this.name = rs1.name;
					if (rs1.requests.HasValue) this.requests = rs1.requests.Value;;
                }
            }
        }

#region Lists        
        //get Proc_Modifys by Site site_id
        public static IList<Proc_Modify> GetProc_ModifysBySite_site_id(Int64 site_id, Validate val)
        {

            List<Proc_Modify> _Proc_Modifys = new List<Proc_Modify>();
            using (DAL.Procs.usp_proc_modify_sel_by_site_id dal = new DAL.Procs.usp_proc_modify_sel_by_site_id())
            {
                dal.site_id = site_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_proc_modify_sel_by_site_id.ResultSet1 rs1 in dal.RS1)
                {
                    Proc_Modify _Proc_Modify = new Proc_Modify(val);
                    
					_Proc_Modify.id = rs1.id;
					if (rs1.created_dt.HasValue) _Proc_Modify.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Proc_Modify.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Proc_Modify.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Proc_Modify.is_deleted = rs1.is_deleted.Value;
					_Proc_Modify.site_id = rs1.site_id;
					_Proc_Modify.domain_name = rs1.domain_name;
					if (rs1.delete_put.HasValue) _Proc_Modify.delete_put = rs1.delete_put.Value;
					if (rs1.batch.HasValue) _Proc_Modify.batch = rs1.batch.Value;
					_Proc_Modify.name = rs1.name;
					if (rs1.requests.HasValue) _Proc_Modify.requests = rs1.requests.Value;
                    _Proc_Modifys.Add(_Proc_Modify);
                }

            }
            return _Proc_Modifys;
        }   
#endregion

        public Proc_Modify UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_proc_modify_ups dal = new DAL.Procs.usp_proc_modify_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.site_id = this.site_id;
					dal.domain_name = this.domain_name;
					dal.delete_put = this.delete_put;
					dal.name = this.name;
					dal.batch = this.batch;
					dal.requests = this.requests;
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

            using (DAL.Procs.usp_proc_modify_del dal = new DAL.Procs.usp_proc_modify_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}