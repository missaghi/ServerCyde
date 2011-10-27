using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Proc_Api  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 site_id { get; set; }
		public String name { get; set; }
		public String url { get; set; }
		public String useragent { get; set; }
		public String port { get; set; }
		public String return_type { get; set; }
        
        //Parents          
        public Site parent_site_site_id { get { if (_parent_site_site_id == null || _parent_site_site_id.id == 0) _parent_site_site_id = new Site(site_id, val); return _parent_site_site_id; } set { _parent_site_site_id = value; } }
        private Site _parent_site_site_id { get; set; }
        
        //Children 

        //default
        public Proc_Api(Validate val)
        {
            this.val = val;
        }

        //select one
        public Proc_Api(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_proc_api_sel dal = new DAL.Procs.usp_proc_api_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_proc_api_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.site_id = rs1.site_id;
					this.name = rs1.name;
					this.url = rs1.url;
					this.useragent = rs1.useragent;
					this.port = rs1.port;
					this.return_type = rs1.return_type;
                }
            }
        }

#region Lists        
        //get Proc_Apis by Site site_id
        public static IList<Proc_Api> GetProc_ApisBySite_site_id(Int64 site_id, Validate val)
        {

            List<Proc_Api> _Proc_Apis = new List<Proc_Api>();
            using (DAL.Procs.usp_proc_api_sel_by_site_id dal = new DAL.Procs.usp_proc_api_sel_by_site_id())
            {
                dal.site_id = site_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_proc_api_sel_by_site_id.ResultSet1 rs1 in dal.RS1)
                {
                    Proc_Api _Proc_Api = new Proc_Api(val);
                    
					_Proc_Api.id = rs1.id;
					if (rs1.created_dt.HasValue) _Proc_Api.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Proc_Api.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Proc_Api.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Proc_Api.is_deleted = rs1.is_deleted.Value;
					_Proc_Api.site_id = rs1.site_id;
					_Proc_Api.name = rs1.name;
					_Proc_Api.url = rs1.url;
					_Proc_Api.useragent = rs1.useragent;
					_Proc_Api.port = rs1.port;
					_Proc_Api.return_type = rs1.return_type;
                    _Proc_Apis.Add(_Proc_Api);
                }

            }
            return _Proc_Apis;
        }   
#endregion

        public Proc_Api UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_proc_api_ups dal = new DAL.Procs.usp_proc_api_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.site_id = this.site_id;
					dal.name = this.name;
					dal.url = this.url;
					dal.useragent = this.useragent;
					dal.port = this.port;
					dal.return_type = this.return_type;
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

            using (DAL.Procs.usp_proc_api_del dal = new DAL.Procs.usp_proc_api_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}