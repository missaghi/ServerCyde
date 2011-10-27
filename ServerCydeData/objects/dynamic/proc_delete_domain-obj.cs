using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Proc_Delete_Domain  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 site_id { get; set; }
		public String domain_name { get; set; }
        
        //Parents          
        public Site parent_site_site_id { get { if (_parent_site_site_id == null || _parent_site_site_id.id == 0) _parent_site_site_id = new Site(site_id, val); return _parent_site_site_id; } set { _parent_site_site_id = value; } }
        private Site _parent_site_site_id { get; set; }
        
        //Children 

        //default
        public Proc_Delete_Domain(Validate val)
        {
            this.val = val;
        }

        //select one
        public Proc_Delete_Domain(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_proc_delete_domain_sel dal = new DAL.Procs.usp_proc_delete_domain_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_proc_delete_domain_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.site_id = rs1.site_id;
					this.domain_name = rs1.domain_name;
                }
            }
        }

#region Lists        
        //get Proc_Delete_Domains by Site site_id
        public static IList<Proc_Delete_Domain> GetProc_Delete_DomainsBySite_site_id(Int64 site_id, Validate val)
        {

            List<Proc_Delete_Domain> _Proc_Delete_Domains = new List<Proc_Delete_Domain>();
            using (DAL.Procs.usp_proc_delete_domain_sel_by_site_id dal = new DAL.Procs.usp_proc_delete_domain_sel_by_site_id())
            {
                dal.site_id = site_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_proc_delete_domain_sel_by_site_id.ResultSet1 rs1 in dal.RS1)
                {
                    Proc_Delete_Domain _Proc_Delete_Domain = new Proc_Delete_Domain(val);
                    
					_Proc_Delete_Domain.id = rs1.id;
					if (rs1.created_dt.HasValue) _Proc_Delete_Domain.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Proc_Delete_Domain.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Proc_Delete_Domain.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Proc_Delete_Domain.is_deleted = rs1.is_deleted.Value;
					_Proc_Delete_Domain.site_id = rs1.site_id;
					_Proc_Delete_Domain.domain_name = rs1.domain_name;
                    _Proc_Delete_Domains.Add(_Proc_Delete_Domain);
                }

            }
            return _Proc_Delete_Domains;
        }   
#endregion

        public Proc_Delete_Domain UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_proc_delete_domain_ups dal = new DAL.Procs.usp_proc_delete_domain_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.site_id = this.site_id;
					dal.domain_name = this.domain_name;
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

            using (DAL.Procs.usp_proc_delete_domain_del dal = new DAL.Procs.usp_proc_delete_domain_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}