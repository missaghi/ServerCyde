using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class User  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public String name { get; set; }
		public String email { get; set; }
		public String password { get; set; }
		public String ip { get; set; }
		public DateTime? last_authentication { get; set; }
		public Boolean? confirmed { get; set; }
        
        //Parents 
        
        //Children          
        public IList<Blog_Comment> get_children_blog_comment_user_ids { get { if (_blog_comment_user_ids == null || _blog_comment_user_ids.Count == 0) _blog_comment_user_ids = Blog_Comment.GetBlog_CommentsByUser_user_id(id ,val); return _blog_comment_user_ids; } set { _blog_comment_user_ids = value; } }
        private IList<Blog_Comment> _blog_comment_user_ids ;         
        public IList<Site> get_children_site_user_ids { get { if (_site_user_ids == null || _site_user_ids.Count == 0) _site_user_ids = Site.GetSitesByUser_user_id(id ,val); return _site_user_ids; } set { _site_user_ids = value; } }
        private IList<Site> _site_user_ids ;         
        public IList<User_Payments> get_children_user_payments_user_ids { get { if (_user_payments_user_ids == null || _user_payments_user_ids.Count == 0) _user_payments_user_ids = User_Payments.GetUser_PaymentssByUser_user_id(id ,val); return _user_payments_user_ids; } set { _user_payments_user_ids = value; } }
        private IList<User_Payments> _user_payments_user_ids ;

        //default
        public User(Validate val)
        {
            this.val = val;
        }

        //select one
        public User(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_user_sel dal = new DAL.Procs.usp_user_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_user_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.name = rs1.name;
					this.email = rs1.email;
					this.password = rs1.password;
					this.ip = rs1.ip;
					if (rs1.last_authentication.HasValue) this.last_authentication = rs1.last_authentication.Value;;
					if (rs1.confirmed.HasValue) this.confirmed = rs1.confirmed.Value;;
                }
            }
        }

#region Lists        
        //get Users by  email
        public static IList<User> GetUsersBy_email(String email, Validate val)
        {

            List<User> _Users = new List<User>();
            using (DAL.Procs.usp_user_sel_by_email dal = new DAL.Procs.usp_user_sel_by_email())
            {
                dal.email = email; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_user_sel_by_email.ResultSet1 rs1 in dal.RS1)
                {
                    User _User = new User(val);
                    
                    _Users.Add(_User);
                }

            }
            return _Users;
        }   
#endregion

        public User UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_user_ups dal = new DAL.Procs.usp_user_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.name = this.name;
					dal.email = this.email;
					dal.password = this.password;
					dal.ip = this.ip;
					dal.last_authentication = this.last_authentication;
					dal.confirmed = this.confirmed;
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

            using (DAL.Procs.usp_user_del dal = new DAL.Procs.usp_user_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}