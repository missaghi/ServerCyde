using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Custom_Tokens  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 site_id { get; set; }
		public String name { get; set; }
		public String description { get; set; }
        
        //Parents          
        public Site parent_site_site_id { get { if (_parent_site_site_id == null || _parent_site_site_id.id == 0) _parent_site_site_id = new Site(site_id, val); return _parent_site_site_id; } set { _parent_site_site_id = value; } }
        private Site _parent_site_site_id { get; set; }
        
        //Children 

        //default
        public Custom_Tokens(Validate val)
        {
            this.val = val;
        }

        //select one
        public Custom_Tokens(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_custom_tokens_sel dal = new DAL.Procs.usp_custom_tokens_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_custom_tokens_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.site_id = rs1.site_id;
					this.name = rs1.name;
					this.description = rs1.description;
                }
            }
        }

#region Lists        
        //get Custom_Tokenss by Site site_id
        public static IList<Custom_Tokens> GetCustom_TokenssBySite_site_id(Int64 site_id, Validate val)
        {

            List<Custom_Tokens> _Custom_Tokenss = new List<Custom_Tokens>();
            using (DAL.Procs.usp_custom_tokens_sel_by_site_id dal = new DAL.Procs.usp_custom_tokens_sel_by_site_id())
            {
                dal.site_id = site_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_custom_tokens_sel_by_site_id.ResultSet1 rs1 in dal.RS1)
                {
                    Custom_Tokens _Custom_Tokens = new Custom_Tokens(val);
                    
					_Custom_Tokens.id = rs1.id;
					if (rs1.created_dt.HasValue) _Custom_Tokens.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Custom_Tokens.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Custom_Tokens.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Custom_Tokens.is_deleted = rs1.is_deleted.Value;
					_Custom_Tokens.site_id = rs1.site_id;
					_Custom_Tokens.name = rs1.name;
					_Custom_Tokens.description = rs1.description;
                    _Custom_Tokenss.Add(_Custom_Tokens);
                }

            }
            return _Custom_Tokenss;
        }   
#endregion

        public Custom_Tokens UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_custom_tokens_ups dal = new DAL.Procs.usp_custom_tokens_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.site_id = this.site_id;
					dal.name = this.name;
					dal.description = this.description;
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

            using (DAL.Procs.usp_custom_tokens_del dal = new DAL.Procs.usp_custom_tokens_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}