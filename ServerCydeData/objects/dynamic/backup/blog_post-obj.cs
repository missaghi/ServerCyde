using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Blog_Post  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public String title { get; set; }
		public String post { get; set; }
		public Int64 blog_category_id { get; set; }
        
        //Parents          
        public Blog_Category parent_blog_category_blog_category_id { get { if (_parent_blog_category_blog_category_id == null || _parent_blog_category_blog_category_id.id == 0) _parent_blog_category_blog_category_id = new Blog_Category(blog_category_id, val); return _parent_blog_category_blog_category_id; } set { _parent_blog_category_blog_category_id = value; } }
        private Blog_Category _parent_blog_category_blog_category_id { get; set; }
        
        //Children          
        public IList<Blog_Comment> get_children_blog_comment_blog_post_ids { get { if (_blog_comment_blog_post_ids == null || _blog_comment_blog_post_ids.Count == 0) _blog_comment_blog_post_ids = Blog_Comment.GetBlog_CommentsByBlog_Post_blog_post_id(id ,val); return _blog_comment_blog_post_ids; } set { _blog_comment_blog_post_ids = value; } }
        private IList<Blog_Comment> _blog_comment_blog_post_ids ;

        //default
        public Blog_Post(Validate val)
        {
            this.val = val;
        }

        //select one
        public Blog_Post(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_blog_post_sel dal = new DAL.Procs.usp_blog_post_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_blog_post_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.title = rs1.title;
					this.post = rs1.post;
					this.blog_category_id = rs1.blog_category_id;
                }
            }
        }

#region Lists        
        //get Blog_Posts by Blog_Category blog_category_id
        public static IList<Blog_Post> GetBlog_PostsByBlog_Category_blog_category_id(Int64 blog_category_id, Validate val)
        {

            List<Blog_Post> _Blog_Posts = new List<Blog_Post>();
            using (DAL.Procs.usp_blog_post_sel_by_blog_category_id dal = new DAL.Procs.usp_blog_post_sel_by_blog_category_id())
            {
                dal.blog_category_id = blog_category_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_blog_post_sel_by_blog_category_id.ResultSet1 rs1 in dal.RS1)
                {
                    Blog_Post _Blog_Post = new Blog_Post(val);
                    
					_Blog_Post.id = rs1.id;
					if (rs1.created_dt.HasValue) _Blog_Post.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Blog_Post.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Blog_Post.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Blog_Post.is_deleted = rs1.is_deleted.Value;
					_Blog_Post.title = rs1.title;
					_Blog_Post.post = rs1.post;
					_Blog_Post.blog_category_id = rs1.blog_category_id;
                    _Blog_Posts.Add(_Blog_Post);
                }

            }
            return _Blog_Posts;
        }   
#endregion

        public Blog_Post UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_blog_post_ups dal = new DAL.Procs.usp_blog_post_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.title = this.title;
					dal.post = this.post;
					dal.blog_category_id = this.blog_category_id;
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

            using (DAL.Procs.usp_blog_post_del dal = new DAL.Procs.usp_blog_post_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}