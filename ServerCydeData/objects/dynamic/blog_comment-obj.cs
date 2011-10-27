using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Blog_Comment  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 blog_post_id { get; set; }
		public Int64 user_id { get; set; }
		public String comment { get; set; }
        
        //Parents          
        public Blog_Post parent_blog_post_blog_post_id { get { if (_parent_blog_post_blog_post_id == null || _parent_blog_post_blog_post_id.id == 0) _parent_blog_post_blog_post_id = new Blog_Post(blog_post_id, val); return _parent_blog_post_blog_post_id; } set { _parent_blog_post_blog_post_id = value; } }
        private Blog_Post _parent_blog_post_blog_post_id { get; set; }         
        public User parent_user_user_id { get { if (_parent_user_user_id == null || _parent_user_user_id.id == 0) _parent_user_user_id = new User(user_id, val); return _parent_user_user_id; } set { _parent_user_user_id = value; } }
        private User _parent_user_user_id { get; set; }
        
        //Children 

        //default
        public Blog_Comment(Validate val)
        {
            this.val = val;
        }

        //select one
        public Blog_Comment(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_blog_comment_sel dal = new DAL.Procs.usp_blog_comment_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_blog_comment_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.blog_post_id = rs1.blog_post_id;
					this.user_id = rs1.user_id;
					this.comment = rs1.comment;
                }
            }
        }

#region Lists        
        //get Blog_Comments by Blog_Post blog_post_id
        public static IList<Blog_Comment> GetBlog_CommentsByBlog_Post_blog_post_id(Int64 blog_post_id, Validate val)
        {

            List<Blog_Comment> _Blog_Comments = new List<Blog_Comment>();
            using (DAL.Procs.usp_blog_comment_sel_by_blog_post_id dal = new DAL.Procs.usp_blog_comment_sel_by_blog_post_id())
            {
                dal.blog_post_id = blog_post_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_blog_comment_sel_by_blog_post_id.ResultSet1 rs1 in dal.RS1)
                {
                    Blog_Comment _Blog_Comment = new Blog_Comment(val);
                    
					_Blog_Comment.id = rs1.id;
					if (rs1.created_dt.HasValue) _Blog_Comment.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Blog_Comment.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Blog_Comment.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Blog_Comment.is_deleted = rs1.is_deleted.Value;
					_Blog_Comment.blog_post_id = rs1.blog_post_id;
					_Blog_Comment.user_id = rs1.user_id;
					_Blog_Comment.comment = rs1.comment;
                    _Blog_Comments.Add(_Blog_Comment);
                }

            }
            return _Blog_Comments;
        }           //get Blog_Comments by User user_id
        public static IList<Blog_Comment> GetBlog_CommentsByUser_user_id(Int64 user_id, Validate val)
        {

            List<Blog_Comment> _Blog_Comments = new List<Blog_Comment>();
            using (DAL.Procs.usp_blog_comment_sel_by_user_id dal = new DAL.Procs.usp_blog_comment_sel_by_user_id())
            {
                dal.user_id = user_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_blog_comment_sel_by_user_id.ResultSet1 rs1 in dal.RS1)
                {
                    Blog_Comment _Blog_Comment = new Blog_Comment(val);
                    
					_Blog_Comment.id = rs1.id;
					if (rs1.created_dt.HasValue) _Blog_Comment.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Blog_Comment.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Blog_Comment.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Blog_Comment.is_deleted = rs1.is_deleted.Value;
					_Blog_Comment.blog_post_id = rs1.blog_post_id;
					_Blog_Comment.user_id = rs1.user_id;
					_Blog_Comment.comment = rs1.comment;
                    _Blog_Comments.Add(_Blog_Comment);
                }

            }
            return _Blog_Comments;
        }   
#endregion

        public Blog_Comment UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_blog_comment_ups dal = new DAL.Procs.usp_blog_comment_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.blog_post_id = this.blog_post_id;
					dal.user_id = this.user_id;
					dal.comment = this.comment;
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

            using (DAL.Procs.usp_blog_comment_del dal = new DAL.Procs.usp_blog_comment_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}