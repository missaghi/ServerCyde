using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Blog_Category  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public String title { get; set; }
		public String description { get; set; }
        
        //Parents 
        
        //Children          
        public IList<Blog_Post> get_children_blog_post_blog_category_ids { get { if (_blog_post_blog_category_ids == null || _blog_post_blog_category_ids.Count == 0) _blog_post_blog_category_ids = Blog_Post.GetBlog_PostsByBlog_Category_blog_category_id(id ,val); return _blog_post_blog_category_ids; } set { _blog_post_blog_category_ids = value; } }
        private IList<Blog_Post> _blog_post_blog_category_ids ;

        //default
        public Blog_Category(Validate val)
        {
            this.val = val;
        }

        //select one
        public Blog_Category(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_blog_category_sel dal = new DAL.Procs.usp_blog_category_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_blog_category_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.title = rs1.title;
					this.description = rs1.description;
                }
            }
        }

#region Lists        

#endregion

        public Blog_Category UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_blog_category_ups dal = new DAL.Procs.usp_blog_category_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.title = this.title;
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

            using (DAL.Procs.usp_blog_category_del dal = new DAL.Procs.usp_blog_category_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}