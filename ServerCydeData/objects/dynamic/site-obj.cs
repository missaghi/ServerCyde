using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Site  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 user_id { get; set; }
		public String name { get; set; }
		public String url { get; set; }
		public String FBKey { get; set; }
		public String FBPassword { get; set; }
		public String GoogleKey { get; set; }
		public String GooglePassword { get; set; }
		public String AmazonKey { get; set; }
		public String AmazonPassword { get; set; }
		public String smtpserver { get; set; }
		public String smtpusername { get; set; }
		public String smtppassword { get; set; }
		public Int64? Requests { get; set; }
		public Boolean? is_protected { get; set; }
		public String supportemailname { get; set; }
		public String supportemail { get; set; }
        
        //Parents          
        public User parent_user_user_id { get { if (_parent_user_user_id == null || _parent_user_user_id.id == 0) _parent_user_user_id = new User(user_id, val); return _parent_user_user_id; } set { _parent_user_user_id = value; } }
        private User _parent_user_user_id { get; set; }
        
        //Children          
        public IList<Custom_Tokens> get_children_custom_tokens_site_ids { get { if (_custom_tokens_site_ids == null || _custom_tokens_site_ids.Count == 0) _custom_tokens_site_ids = Custom_Tokens.GetCustom_TokenssBySite_site_id(id ,val); return _custom_tokens_site_ids; } set { _custom_tokens_site_ids = value; } }
        private IList<Custom_Tokens> _custom_tokens_site_ids ;         
        public IList<Emails> get_children_emails_site_ids { get { if (_emails_site_ids == null || _emails_site_ids.Count == 0) _emails_site_ids = Emails.GetEmailssBySite_site_id(id ,val); return _emails_site_ids; } set { _emails_site_ids = value; } }
        private IList<Emails> _emails_site_ids ;         
        public IList<Person> get_children_person_site_ids { get { if (_person_site_ids == null || _person_site_ids.Count == 0) _person_site_ids = Person.GetPersonsBySite_site_id(id ,val); return _person_site_ids; } set { _person_site_ids = value; } }
        private IList<Person> _person_site_ids ;         
        public IList<Proc_Api> get_children_proc_api_site_ids { get { if (_proc_api_site_ids == null || _proc_api_site_ids.Count == 0) _proc_api_site_ids = Proc_Api.GetProc_ApisBySite_site_id(id ,val); return _proc_api_site_ids; } set { _proc_api_site_ids = value; } }
        private IList<Proc_Api> _proc_api_site_ids ;         
        public IList<Proc_Create_Domain> get_children_proc_create_domain_site_ids { get { if (_proc_create_domain_site_ids == null || _proc_create_domain_site_ids.Count == 0) _proc_create_domain_site_ids = Proc_Create_Domain.GetProc_Create_DomainsBySite_site_id(id ,val); return _proc_create_domain_site_ids; } set { _proc_create_domain_site_ids = value; } }
        private IList<Proc_Create_Domain> _proc_create_domain_site_ids ;         
        public IList<Proc_Delete_Domain> get_children_proc_delete_domain_site_ids { get { if (_proc_delete_domain_site_ids == null || _proc_delete_domain_site_ids.Count == 0) _proc_delete_domain_site_ids = Proc_Delete_Domain.GetProc_Delete_DomainsBySite_site_id(id ,val); return _proc_delete_domain_site_ids; } set { _proc_delete_domain_site_ids = value; } }
        private IList<Proc_Delete_Domain> _proc_delete_domain_site_ids ;         
        public IList<Proc_Get> get_children_proc_get_site_ids { get { if (_proc_get_site_ids == null || _proc_get_site_ids.Count == 0) _proc_get_site_ids = Proc_Get.GetProc_GetsBySite_site_id(id ,val); return _proc_get_site_ids; } set { _proc_get_site_ids = value; } }
        private IList<Proc_Get> _proc_get_site_ids ;         
        public IList<Proc_List_Domains> get_children_proc_list_domains_site_ids { get { if (_proc_list_domains_site_ids == null || _proc_list_domains_site_ids.Count == 0) _proc_list_domains_site_ids = Proc_List_Domains.GetProc_List_DomainssBySite_site_id(id ,val); return _proc_list_domains_site_ids; } set { _proc_list_domains_site_ids = value; } }
        private IList<Proc_List_Domains> _proc_list_domains_site_ids ;         
        public IList<Proc_Modify> get_children_proc_modify_site_ids { get { if (_proc_modify_site_ids == null || _proc_modify_site_ids.Count == 0) _proc_modify_site_ids = Proc_Modify.GetProc_ModifysBySite_site_id(id ,val); return _proc_modify_site_ids; } set { _proc_modify_site_ids = value; } }
        private IList<Proc_Modify> _proc_modify_site_ids ;         
        public IList<Proc_Select> get_children_proc_select_site_ids { get { if (_proc_select_site_ids == null || _proc_select_site_ids.Count == 0) _proc_select_site_ids = Proc_Select.GetProc_SelectsBySite_site_id(id ,val); return _proc_select_site_ids; } set { _proc_select_site_ids = value; } }
        private IList<Proc_Select> _proc_select_site_ids ;

        //default
        public Site(Validate val)
        {
            this.val = val;
        }

        //select one
        public Site(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_site_sel dal = new DAL.Procs.usp_site_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_site_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.user_id = rs1.user_id;
					this.name = rs1.name;
					this.url = rs1.url;
					this.FBKey = rs1.FBKey;
					this.FBPassword = rs1.FBPassword;
					this.GoogleKey = rs1.GoogleKey;
					this.GooglePassword = rs1.GooglePassword;
					this.AmazonKey = rs1.AmazonKey;
					this.AmazonPassword = rs1.AmazonPassword;
					this.smtpserver = rs1.smtpserver;
					this.smtpusername = rs1.smtpusername;
					this.smtppassword = rs1.smtppassword;
					if (rs1.Requests.HasValue) this.Requests = rs1.Requests.Value;;
					if (rs1.is_protected.HasValue) this.is_protected = rs1.is_protected.Value;;
					this.supportemailname = rs1.supportemailname;
					this.supportemail = rs1.supportemail;
                }
            }
        }

#region Lists        
        //get Sites by User user_id
        public static IList<Site> GetSitesByUser_user_id(Int64 user_id, Validate val)
        {

            List<Site> _Sites = new List<Site>();
            using (DAL.Procs.usp_site_sel_by_user_id dal = new DAL.Procs.usp_site_sel_by_user_id())
            {
                dal.user_id = user_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_site_sel_by_user_id.ResultSet1 rs1 in dal.RS1)
                {
                    Site _Site = new Site(val);
                    
					_Site.id = rs1.id;
					if (rs1.created_dt.HasValue) _Site.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Site.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Site.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Site.is_deleted = rs1.is_deleted.Value;
					_Site.user_id = rs1.user_id;
					_Site.name = rs1.name;
					_Site.url = rs1.url;
					_Site.FBKey = rs1.FBKey;
					_Site.FBPassword = rs1.FBPassword;
					_Site.GoogleKey = rs1.GoogleKey;
					_Site.GooglePassword = rs1.GooglePassword;
					_Site.AmazonKey = rs1.AmazonKey;
					_Site.AmazonPassword = rs1.AmazonPassword;
					_Site.smtpserver = rs1.smtpserver;
					_Site.smtpusername = rs1.smtpusername;
					_Site.smtppassword = rs1.smtppassword;
					if (rs1.Requests.HasValue) _Site.Requests = rs1.Requests.Value;
					if (rs1.is_protected.HasValue) _Site.is_protected = rs1.is_protected.Value;
					_Site.supportemailname = rs1.supportemailname;
					_Site.supportemail = rs1.supportemail;
                    _Sites.Add(_Site);
                }

            }
            return _Sites;
        }   
#endregion

        public Site UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_site_ups dal = new DAL.Procs.usp_site_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.user_id = this.user_id;
					dal.name = this.name;
					dal.url = this.url;
					dal.AmazonKey = this.AmazonKey;
					dal.AmazonPassword = this.AmazonPassword;
					dal.FBKey = this.FBKey;
					dal.FBPassword = this.FBPassword;
					dal.GoogleKey = this.GoogleKey;
					dal.GooglePassword = this.GooglePassword;
					dal.Requests = this.Requests;
					dal.is_protected = this.is_protected;
					dal.smtpserver = this.smtpserver;
					dal.smtpusername = this.smtpusername;
					dal.smtppassword = this.smtppassword;
					dal.supportemail = this.supportemail;
					dal.supportemailname = this.supportemailname;
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

            using (DAL.Procs.usp_site_del dal = new DAL.Procs.usp_site_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}