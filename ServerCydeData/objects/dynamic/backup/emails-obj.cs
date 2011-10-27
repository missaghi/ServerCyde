using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Emails  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 site_id { get; set; }
		public String name { get; set; }
		public String email_template { get; set; }
		public Int64? hits { get; set; }
		public String subject { get; set; }
		public Boolean? is_html { get; set; }
        
        //Parents          
        public Site parent_site_site_id { get { if (_parent_site_site_id == null || _parent_site_site_id.id == 0) _parent_site_site_id = new Site(site_id, val); return _parent_site_site_id; } set { _parent_site_site_id = value; } }
        private Site _parent_site_site_id { get; set; }
        
        //Children 

        //default
        public Emails(Validate val)
        {
            this.val = val;
        }

        //select one
        public Emails(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_emails_sel dal = new DAL.Procs.usp_emails_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_emails_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.site_id = rs1.site_id;
					this.name = rs1.name;
					this.email_template = rs1.email_template;
					if (rs1.hits.HasValue) this.hits = rs1.hits.Value;;
					this.subject = rs1.subject;
					if (rs1.is_html.HasValue) this.is_html = rs1.is_html.Value;;
                }
            }
        }

#region Lists        
        //get Emailss by Site site_id
        public static IList<Emails> GetEmailssBySite_site_id(Int64 site_id, Validate val)
        {

            List<Emails> _Emailss = new List<Emails>();
            using (DAL.Procs.usp_emails_sel_by_site_id dal = new DAL.Procs.usp_emails_sel_by_site_id())
            {
                dal.site_id = site_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_emails_sel_by_site_id.ResultSet1 rs1 in dal.RS1)
                {
                    Emails _Emails = new Emails(val);
                    
					_Emails.id = rs1.id;
					if (rs1.created_dt.HasValue) _Emails.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Emails.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Emails.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Emails.is_deleted = rs1.is_deleted.Value;
					_Emails.site_id = rs1.site_id;
					_Emails.name = rs1.name;
					_Emails.email_template = rs1.email_template;
					if (rs1.hits.HasValue) _Emails.hits = rs1.hits.Value;
					_Emails.subject = rs1.subject;
					if (rs1.is_html.HasValue) _Emails.is_html = rs1.is_html.Value;
                    _Emailss.Add(_Emails);
                }

            }
            return _Emailss;
        }   
#endregion

        public Emails UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_emails_ups dal = new DAL.Procs.usp_emails_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.site_id = this.site_id;
					dal.name = this.name;
					dal.subject = this.subject;
					dal.is_html = this.is_html;
					dal.email_template = this.email_template;
					dal.hits = this.hits;
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

            using (DAL.Procs.usp_emails_del dal = new DAL.Procs.usp_emails_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}