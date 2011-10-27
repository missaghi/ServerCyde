using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Proc_Get  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 site_id { get; set; }
		public String item_name { get; set; }
		public String domain_name { get; set; }
		public Boolean? consistent_read { get; set; }
		public String name { get; set; }
        
        //Parents          
        public Site parent_site_site_id { get { if (_parent_site_site_id == null || _parent_site_site_id.id == 0) _parent_site_site_id = new Site(site_id, val); return _parent_site_site_id; } set { _parent_site_site_id = value; } }
        private Site _parent_site_site_id { get; set; }
        
        //Children          
        public IList<Proc_Get_Attribute> get_children_proc_get_attribute_proc_get_ids { get { if (_proc_get_attribute_proc_get_ids == null || _proc_get_attribute_proc_get_ids.Count == 0) _proc_get_attribute_proc_get_ids = Proc_Get_Attribute.GetProc_Get_AttributesByProc_Get_proc_get_id(id ,val); return _proc_get_attribute_proc_get_ids; } set { _proc_get_attribute_proc_get_ids = value; } }
        private IList<Proc_Get_Attribute> _proc_get_attribute_proc_get_ids ;

        //default
        public Proc_Get(Validate val)
        {
            this.val = val;
        }

        //select one
        public Proc_Get(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_proc_get_sel dal = new DAL.Procs.usp_proc_get_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_proc_get_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.site_id = rs1.site_id;
					this.item_name = rs1.item_name;
					this.domain_name = rs1.domain_name;
					if (rs1.consistent_read.HasValue) this.consistent_read = rs1.consistent_read.Value;;
					this.name = rs1.name;
                }
            }
        }

#region Lists        
        //get Proc_Gets by Site site_id
        public static IList<Proc_Get> GetProc_GetsBySite_site_id(Int64 site_id, Validate val)
        {

            List<Proc_Get> _Proc_Gets = new List<Proc_Get>();
            using (DAL.Procs.usp_proc_get_sel_by_site_id dal = new DAL.Procs.usp_proc_get_sel_by_site_id())
            {
                dal.site_id = site_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_proc_get_sel_by_site_id.ResultSet1 rs1 in dal.RS1)
                {
                    Proc_Get _Proc_Get = new Proc_Get(val);
                    
					_Proc_Get.id = rs1.id;
					if (rs1.created_dt.HasValue) _Proc_Get.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Proc_Get.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Proc_Get.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Proc_Get.is_deleted = rs1.is_deleted.Value;
					_Proc_Get.site_id = rs1.site_id;
					_Proc_Get.item_name = rs1.item_name;
					_Proc_Get.domain_name = rs1.domain_name;
					if (rs1.consistent_read.HasValue) _Proc_Get.consistent_read = rs1.consistent_read.Value;
					_Proc_Get.name = rs1.name;
                    _Proc_Gets.Add(_Proc_Get);
                }

            }
            return _Proc_Gets;
        }   
#endregion

        public Proc_Get UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_proc_get_ups dal = new DAL.Procs.usp_proc_get_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.site_id = this.site_id;
					dal.name = this.name;
					dal.item_name = this.item_name;
					dal.domain_name = this.domain_name;
					dal.consistent_read = this.consistent_read;
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

            using (DAL.Procs.usp_proc_get_del dal = new DAL.Procs.usp_proc_get_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}