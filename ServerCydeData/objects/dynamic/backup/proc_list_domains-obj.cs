using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Proc_List_Domains  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 site_id { get; set; }
		public String name { get; set; }
		public Int32? maxresults { get; set; }
        
        //Parents          
        public Site parent_site_site_id { get { if (_parent_site_site_id == null || _parent_site_site_id.id == 0) _parent_site_site_id = new Site(site_id, val); return _parent_site_site_id; } set { _parent_site_site_id = value; } }
        private Site _parent_site_site_id { get; set; }
        
        //Children 

        //default
        public Proc_List_Domains(Validate val)
        {
            this.val = val;
        }

        //select one
        public Proc_List_Domains(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_proc_list_domains_sel dal = new DAL.Procs.usp_proc_list_domains_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_proc_list_domains_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.site_id = rs1.site_id;
					this.name = rs1.name;
					if (rs1.maxresults.HasValue) this.maxresults = rs1.maxresults.Value;;
                }
            }
        }

#region Lists        
        //get Proc_List_Domainss by Site site_id
        public static IList<Proc_List_Domains> GetProc_List_DomainssBySite_site_id(Int64 site_id, Validate val)
        {

            List<Proc_List_Domains> _Proc_List_Domainss = new List<Proc_List_Domains>();
            using (DAL.Procs.usp_proc_list_domains_sel_by_site_id dal = new DAL.Procs.usp_proc_list_domains_sel_by_site_id())
            {
                dal.site_id = site_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_proc_list_domains_sel_by_site_id.ResultSet1 rs1 in dal.RS1)
                {
                    Proc_List_Domains _Proc_List_Domains = new Proc_List_Domains(val);
                    
					_Proc_List_Domains.id = rs1.id;
					if (rs1.created_dt.HasValue) _Proc_List_Domains.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Proc_List_Domains.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Proc_List_Domains.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Proc_List_Domains.is_deleted = rs1.is_deleted.Value;
					_Proc_List_Domains.site_id = rs1.site_id;
					_Proc_List_Domains.name = rs1.name;
					if (rs1.maxresults.HasValue) _Proc_List_Domains.maxresults = rs1.maxresults.Value;
                    _Proc_List_Domainss.Add(_Proc_List_Domains);
                }

            }
            return _Proc_List_Domainss;
        }   
#endregion

        public Proc_List_Domains UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_proc_list_domains_ups dal = new DAL.Procs.usp_proc_list_domains_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.site_id = this.site_id;
					dal.name = this.name;
					dal.maxresults = this.maxresults;
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

            using (DAL.Procs.usp_proc_list_domains_del dal = new DAL.Procs.usp_proc_list_domains_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}