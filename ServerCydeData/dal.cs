using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using SharpFusion;  

// Code Auto Generated 9/19/2011 9:16:07 PM
namespace DAL.Procs
{


public partial class usp_blog_category_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_blog_category_del() {

		db = new DB("usp_blog_category_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_blog_category_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_blog_category_sel() {

		db = new DB("usp_blog_category_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public String title {get;set;}
		public String description {get;set;}

		public static ResultSet1[] Init(usp_blog_category_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["title"] != DBNull.Value) rs1.title = (String)dal["title"];
				if (dal["description"] != DBNull.Value) rs1.description = (String)dal["description"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_blog_category_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  140  </summary>
	public String title{get;set;}

	///<summary>  -1  </summary>
	public String description{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_blog_category_ups() {

		db = new DB("usp_blog_category_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		if (title == null)  db.NewParameter("title", SqlDbType.VarChar, 140, DBNull.Value, false); else  db.NewParameter("title", SqlDbType.VarChar, 140,Encode(title), false); 
		if (description == null)  db.NewParameter("description", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("description", SqlDbType.VarChar, -1,Encode(description), false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["title"].Value != DBNull.Value) title = (String)base.db.cmd.Parameters["title"].Value;
		if (base.db.cmd.Parameters["description"].Value != DBNull.Value) description = (String)base.db.cmd.Parameters["description"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_blog_comment_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_blog_comment_del() {

		db = new DB("usp_blog_comment_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_blog_comment_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_blog_comment_sel() {

		db = new DB("usp_blog_comment_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 blog_post_id {get;set;}
		public Int64 user_id {get;set;}
		public String comment {get;set;}

		public static ResultSet1[] Init(usp_blog_comment_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["blog_post_id"] != DBNull.Value) rs1.blog_post_id = (Int64)dal["blog_post_id"];
				if (dal["user_id"] != DBNull.Value) rs1.user_id = (Int64)dal["user_id"];
				if (dal["comment"] != DBNull.Value) rs1.comment = (String)dal["comment"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_blog_comment_sel_by_blog_post_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 blog_post_id{get;set;}


	public usp_blog_comment_sel_by_blog_post_id() {

		db = new DB("usp_blog_comment_sel_by_blog_post_id");
	}

	private void preExecute() {
		db.NewParameter("blog_post_id", SqlDbType.BigInt, 8, blog_post_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["blog_post_id"].Value != DBNull.Value) blog_post_id = (Int64)base.db.cmd.Parameters["blog_post_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 blog_post_id {get;set;}
		public Int64 user_id {get;set;}
		public String comment {get;set;}

		public static ResultSet1[] Init(usp_blog_comment_sel_by_blog_post_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["blog_post_id"] != DBNull.Value) rs1.blog_post_id = (Int64)dal["blog_post_id"];
				if (dal["user_id"] != DBNull.Value) rs1.user_id = (Int64)dal["user_id"];
				if (dal["comment"] != DBNull.Value) rs1.comment = (String)dal["comment"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_blog_comment_sel_by_blog_post_id_and_user_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 blog_post_id{get;set;}

	///<summary>  8  </summary>
	public Int64 user_id{get;set;}


	public usp_blog_comment_sel_by_blog_post_id_and_user_id() {

		db = new DB("usp_blog_comment_sel_by_blog_post_id_and_user_id");
	}

	private void preExecute() {
		db.NewParameter("blog_post_id", SqlDbType.BigInt, 8, blog_post_id, false); 
		db.NewParameter("user_id", SqlDbType.BigInt, 8, user_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["blog_post_id"].Value != DBNull.Value) blog_post_id = (Int64)base.db.cmd.Parameters["blog_post_id"].Value;
		if (base.db.cmd.Parameters["user_id"].Value != DBNull.Value) user_id = (Int64)base.db.cmd.Parameters["user_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 blog_post_id {get;set;}
		public Int64 user_id {get;set;}
		public String comment {get;set;}

		public static ResultSet1[] Init(usp_blog_comment_sel_by_blog_post_id_and_user_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["blog_post_id"] != DBNull.Value) rs1.blog_post_id = (Int64)dal["blog_post_id"];
				if (dal["user_id"] != DBNull.Value) rs1.user_id = (Int64)dal["user_id"];
				if (dal["comment"] != DBNull.Value) rs1.comment = (String)dal["comment"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_blog_comment_sel_by_parent_blog_category  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_blog_comment_sel_by_parent_blog_category() {

		db = new DB("usp_blog_comment_sel_by_parent_blog_category");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 blog_post_id {get;set;}
		public Int64 user_id {get;set;}
		public String comment {get;set;}

		public static ResultSet1[] Init(usp_blog_comment_sel_by_parent_blog_category dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["blog_post_id"] != DBNull.Value) rs1.blog_post_id = (Int64)dal["blog_post_id"];
				if (dal["user_id"] != DBNull.Value) rs1.user_id = (Int64)dal["user_id"];
				if (dal["comment"] != DBNull.Value) rs1.comment = (String)dal["comment"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_blog_comment_sel_by_parent_blog_category_and_user_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 user_id{get;set;}

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_blog_comment_sel_by_parent_blog_category_and_user_id() {

		db = new DB("usp_blog_comment_sel_by_parent_blog_category_and_user_id");
	}

	private void preExecute() {
		db.NewParameter("user_id", SqlDbType.BigInt, 8, user_id, false); 
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["user_id"].Value != DBNull.Value) user_id = (Int64)base.db.cmd.Parameters["user_id"].Value;
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 blog_post_id {get;set;}
		public Int64 user_id {get;set;}
		public String comment {get;set;}

		public static ResultSet1[] Init(usp_blog_comment_sel_by_parent_blog_category_and_user_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["blog_post_id"] != DBNull.Value) rs1.blog_post_id = (Int64)dal["blog_post_id"];
				if (dal["user_id"] != DBNull.Value) rs1.user_id = (Int64)dal["user_id"];
				if (dal["comment"] != DBNull.Value) rs1.comment = (String)dal["comment"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_blog_comment_sel_by_user_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 user_id{get;set;}


	public usp_blog_comment_sel_by_user_id() {

		db = new DB("usp_blog_comment_sel_by_user_id");
	}

	private void preExecute() {
		db.NewParameter("user_id", SqlDbType.BigInt, 8, user_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["user_id"].Value != DBNull.Value) user_id = (Int64)base.db.cmd.Parameters["user_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 blog_post_id {get;set;}
		public Int64 user_id {get;set;}
		public String comment {get;set;}

		public static ResultSet1[] Init(usp_blog_comment_sel_by_user_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["blog_post_id"] != DBNull.Value) rs1.blog_post_id = (Int64)dal["blog_post_id"];
				if (dal["user_id"] != DBNull.Value) rs1.user_id = (Int64)dal["user_id"];
				if (dal["comment"] != DBNull.Value) rs1.comment = (String)dal["comment"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_blog_comment_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 blog_post_id{get;set;}

	///<summary>  8  </summary>
	public Int64 user_id{get;set;}

	///<summary>  2000  </summary>
	public String comment{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_blog_comment_ups() {

		db = new DB("usp_blog_comment_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("blog_post_id", SqlDbType.BigInt, 8, blog_post_id, false); 
		db.NewParameter("user_id", SqlDbType.BigInt, 8, user_id, false); 
		if (comment == null)  db.NewParameter("comment", SqlDbType.VarChar, 2000, DBNull.Value, false); else  db.NewParameter("comment", SqlDbType.VarChar, 2000,Encode(comment), false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["blog_post_id"].Value != DBNull.Value) blog_post_id = (Int64)base.db.cmd.Parameters["blog_post_id"].Value;
		if (base.db.cmd.Parameters["user_id"].Value != DBNull.Value) user_id = (Int64)base.db.cmd.Parameters["user_id"].Value;
		if (base.db.cmd.Parameters["comment"].Value != DBNull.Value) comment = (String)base.db.cmd.Parameters["comment"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_blog_post_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_blog_post_del() {

		db = new DB("usp_blog_post_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_blog_post_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_blog_post_sel() {

		db = new DB("usp_blog_post_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public String title {get;set;}
		public String post {get;set;}
		public Int64 blog_category_id {get;set;}

		public static ResultSet1[] Init(usp_blog_post_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["title"] != DBNull.Value) rs1.title = (String)dal["title"];
				if (dal["post"] != DBNull.Value) rs1.post = (String)dal["post"];
				if (dal["blog_category_id"] != DBNull.Value) rs1.blog_category_id = (Int64)dal["blog_category_id"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_blog_post_sel_by_blog_category_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 blog_category_id{get;set;}


	public usp_blog_post_sel_by_blog_category_id() {

		db = new DB("usp_blog_post_sel_by_blog_category_id");
	}

	private void preExecute() {
		db.NewParameter("blog_category_id", SqlDbType.BigInt, 8, blog_category_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["blog_category_id"].Value != DBNull.Value) blog_category_id = (Int64)base.db.cmd.Parameters["blog_category_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public String title {get;set;}
		public String post {get;set;}
		public Int64 blog_category_id {get;set;}

		public static ResultSet1[] Init(usp_blog_post_sel_by_blog_category_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["title"] != DBNull.Value) rs1.title = (String)dal["title"];
				if (dal["post"] != DBNull.Value) rs1.post = (String)dal["post"];
				if (dal["blog_category_id"] != DBNull.Value) rs1.blog_category_id = (Int64)dal["blog_category_id"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_blog_post_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  140  </summary>
	public String title{get;set;}

	///<summary>  -1  </summary>
	public String post{get;set;}

	///<summary>  8  </summary>
	public Int64 blog_category_id{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_blog_post_ups() {

		db = new DB("usp_blog_post_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		if (title == null)  db.NewParameter("title", SqlDbType.VarChar, 140, DBNull.Value, false); else  db.NewParameter("title", SqlDbType.VarChar, 140,Encode(title), false); 
		if (post == null)  db.NewParameter("post", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("post", SqlDbType.VarChar, -1,Encode(post), false); 
		db.NewParameter("blog_category_id", SqlDbType.BigInt, 8, blog_category_id, false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["title"].Value != DBNull.Value) title = (String)base.db.cmd.Parameters["title"].Value;
		if (base.db.cmd.Parameters["post"].Value != DBNull.Value) post = (String)base.db.cmd.Parameters["post"].Value;
		if (base.db.cmd.Parameters["blog_category_id"].Value != DBNull.Value) blog_category_id = (Int64)base.db.cmd.Parameters["blog_category_id"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_custom_tokens_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_custom_tokens_del() {

		db = new DB("usp_custom_tokens_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_custom_tokens_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_custom_tokens_sel() {

		db = new DB("usp_custom_tokens_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public String description {get;set;}

		public static ResultSet1[] Init(usp_custom_tokens_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["description"] != DBNull.Value) rs1.description = (String)dal["description"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_custom_tokens_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_custom_tokens_sel_by_parent_user() {

		db = new DB("usp_custom_tokens_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public String description {get;set;}

		public static ResultSet1[] Init(usp_custom_tokens_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["description"] != DBNull.Value) rs1.description = (String)dal["description"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_custom_tokens_sel_by_site_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}


	public usp_custom_tokens_sel_by_site_id() {

		db = new DB("usp_custom_tokens_sel_by_site_id");
	}

	private void preExecute() {
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public String description {get;set;}

		public static ResultSet1[] Init(usp_custom_tokens_sel_by_site_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["description"] != DBNull.Value) rs1.description = (String)dal["description"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_custom_tokens_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}

	///<summary>  -1  </summary>
	public String name{get;set;}

	///<summary>  -1  </summary>
	public String description{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_custom_tokens_ups() {

		db = new DB("usp_custom_tokens_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
		if (name == null)  db.NewParameter("name", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("name", SqlDbType.VarChar, -1,Encode(name), false); 
		if (description == null)  db.NewParameter("description", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("description", SqlDbType.VarChar, -1,Encode(description), false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
		if (base.db.cmd.Parameters["name"].Value != DBNull.Value) name = (String)base.db.cmd.Parameters["name"].Value;
		if (base.db.cmd.Parameters["description"].Value != DBNull.Value) description = (String)base.db.cmd.Parameters["description"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_emails_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_emails_del() {

		db = new DB("usp_emails_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_emails_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_emails_sel() {

		db = new DB("usp_emails_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public String subject {get;set;}
		public Boolean? is_html {get;set;}
		public String email_template {get;set;}
		public Int64? hits {get;set;}

		public static ResultSet1[] Init(usp_emails_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["subject"] != DBNull.Value) rs1.subject = (String)dal["subject"];
				if (dal["is_html"] != DBNull.Value) rs1.is_html = (Boolean)dal["is_html"];
				if (dal["email_template"] != DBNull.Value) rs1.email_template = (String)dal["email_template"];
				if (dal["hits"] != DBNull.Value) rs1.hits = (Int64)dal["hits"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_emails_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_emails_sel_by_parent_user() {

		db = new DB("usp_emails_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public String email_template {get;set;}
		public Int64? hits {get;set;}
		public String subject {get;set;}
		public Boolean? is_html {get;set;}

		public static ResultSet1[] Init(usp_emails_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["email_template"] != DBNull.Value) rs1.email_template = (String)dal["email_template"];
				if (dal["hits"] != DBNull.Value) rs1.hits = (Int64)dal["hits"];
				if (dal["subject"] != DBNull.Value) rs1.subject = (String)dal["subject"];
				if (dal["is_html"] != DBNull.Value) rs1.is_html = (Boolean)dal["is_html"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_emails_sel_by_site_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}


	public usp_emails_sel_by_site_id() {

		db = new DB("usp_emails_sel_by_site_id");
	}

	private void preExecute() {
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public String subject {get;set;}
		public Boolean? is_html {get;set;}
		public String email_template {get;set;}
		public Int64? hits {get;set;}

		public static ResultSet1[] Init(usp_emails_sel_by_site_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["subject"] != DBNull.Value) rs1.subject = (String)dal["subject"];
				if (dal["is_html"] != DBNull.Value) rs1.is_html = (Boolean)dal["is_html"];
				if (dal["email_template"] != DBNull.Value) rs1.email_template = (String)dal["email_template"];
				if (dal["hits"] != DBNull.Value) rs1.hits = (Int64)dal["hits"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_emails_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}

	///<summary>  50  </summary>
	public String name{get;set;}

	///<summary>  250  </summary>
	public String subject{get;set;}

	///<summary>  1  </summary>
	public Boolean? is_html{get;set;}

	///<summary>  -1  </summary>
	public String email_template{get;set;}

	///<summary>  8  </summary>
	public Int64? hits{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_emails_ups() {

		db = new DB("usp_emails_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
		if (name == null)  db.NewParameter("name", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("name", SqlDbType.VarChar, 50,Encode(name), false); 
		if (subject == null)  db.NewParameter("subject", SqlDbType.VarChar, 250, DBNull.Value, false); else  db.NewParameter("subject", SqlDbType.VarChar, 250,Encode(subject), false); 
		if (!is_html.HasValue)  db.NewParameter("is_html", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("is_html", SqlDbType.Bit, 1, is_html, false); 
		if (email_template == null)  db.NewParameter("email_template", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("email_template", SqlDbType.VarChar, -1,Encode(email_template), false); 
		if (!hits.HasValue)  db.NewParameter("hits", SqlDbType.BigInt, 8, DBNull.Value, false); else  db.NewParameter("hits", SqlDbType.BigInt, 8, hits, false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
		if (base.db.cmd.Parameters["name"].Value != DBNull.Value) name = (String)base.db.cmd.Parameters["name"].Value;
		if (base.db.cmd.Parameters["subject"].Value != DBNull.Value) subject = (String)base.db.cmd.Parameters["subject"].Value;
		if (base.db.cmd.Parameters["is_html"].Value != DBNull.Value) is_html = (Boolean)base.db.cmd.Parameters["is_html"].Value;
		if (base.db.cmd.Parameters["email_template"].Value != DBNull.Value) email_template = (String)base.db.cmd.Parameters["email_template"].Value;
		if (base.db.cmd.Parameters["hits"].Value != DBNull.Value) hits = (Int64)base.db.cmd.Parameters["hits"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_person_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_person_del() {

		db = new DB("usp_person_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_person_oauth_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_person_oauth_del() {

		db = new DB("usp_person_oauth_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_person_oauth_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_person_oauth_sel() {

		db = new DB("usp_person_oauth_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 person_id {get;set;}
		public String service_name {get;set;}
		public String token {get;set;}
		public Boolean? authorized {get;set;}

		public static ResultSet1[] Init(usp_person_oauth_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["person_id"] != DBNull.Value) rs1.person_id = (Int64)dal["person_id"];
				if (dal["service_name"] != DBNull.Value) rs1.service_name = (String)dal["service_name"];
				if (dal["token"] != DBNull.Value) rs1.token = (String)dal["token"];
				if (dal["authorized"] != DBNull.Value) rs1.authorized = (Boolean)dal["authorized"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_person_oauth_sel_by_parent_site  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_person_oauth_sel_by_parent_site() {

		db = new DB("usp_person_oauth_sel_by_parent_site");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 person_id {get;set;}
		public String service_name {get;set;}
		public String token {get;set;}
		public Boolean? authorized {get;set;}

		public static ResultSet1[] Init(usp_person_oauth_sel_by_parent_site dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["person_id"] != DBNull.Value) rs1.person_id = (Int64)dal["person_id"];
				if (dal["service_name"] != DBNull.Value) rs1.service_name = (String)dal["service_name"];
				if (dal["token"] != DBNull.Value) rs1.token = (String)dal["token"];
				if (dal["authorized"] != DBNull.Value) rs1.authorized = (Boolean)dal["authorized"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_person_oauth_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_person_oauth_sel_by_parent_user() {

		db = new DB("usp_person_oauth_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 person_id {get;set;}
		public String service_name {get;set;}
		public String token {get;set;}
		public Boolean? authorized {get;set;}

		public static ResultSet1[] Init(usp_person_oauth_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["person_id"] != DBNull.Value) rs1.person_id = (Int64)dal["person_id"];
				if (dal["service_name"] != DBNull.Value) rs1.service_name = (String)dal["service_name"];
				if (dal["token"] != DBNull.Value) rs1.token = (String)dal["token"];
				if (dal["authorized"] != DBNull.Value) rs1.authorized = (Boolean)dal["authorized"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_person_oauth_sel_by_person_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 person_id{get;set;}


	public usp_person_oauth_sel_by_person_id() {

		db = new DB("usp_person_oauth_sel_by_person_id");
	}

	private void preExecute() {
		db.NewParameter("person_id", SqlDbType.BigInt, 8, person_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["person_id"].Value != DBNull.Value) person_id = (Int64)base.db.cmd.Parameters["person_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 person_id {get;set;}
		public String service_name {get;set;}
		public String token {get;set;}
		public Boolean? authorized {get;set;}

		public static ResultSet1[] Init(usp_person_oauth_sel_by_person_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["person_id"] != DBNull.Value) rs1.person_id = (Int64)dal["person_id"];
				if (dal["service_name"] != DBNull.Value) rs1.service_name = (String)dal["service_name"];
				if (dal["token"] != DBNull.Value) rs1.token = (String)dal["token"];
				if (dal["authorized"] != DBNull.Value) rs1.authorized = (Boolean)dal["authorized"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_person_oauth_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 person_id{get;set;}

	///<summary>  50  </summary>
	public String service_name{get;set;}

	///<summary>  -1  </summary>
	public String token{get;set;}

	///<summary>  1  </summary>
	public Boolean? authorized{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_person_oauth_ups() {

		db = new DB("usp_person_oauth_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("person_id", SqlDbType.BigInt, 8, person_id, false); 
		if (service_name == null)  db.NewParameter("service_name", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("service_name", SqlDbType.VarChar, 50,Encode(service_name), false); 
		if (token == null)  db.NewParameter("token", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("token", SqlDbType.VarChar, -1,Encode(token), false); 
		if (!authorized.HasValue)  db.NewParameter("authorized", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("authorized", SqlDbType.Bit, 1, authorized, false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["person_id"].Value != DBNull.Value) person_id = (Int64)base.db.cmd.Parameters["person_id"].Value;
		if (base.db.cmd.Parameters["service_name"].Value != DBNull.Value) service_name = (String)base.db.cmd.Parameters["service_name"].Value;
		if (base.db.cmd.Parameters["token"].Value != DBNull.Value) token = (String)base.db.cmd.Parameters["token"].Value;
		if (base.db.cmd.Parameters["authorized"].Value != DBNull.Value) authorized = (Boolean)base.db.cmd.Parameters["authorized"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_person_payments_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_person_payments_del() {

		db = new DB("usp_person_payments_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_person_payments_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_person_payments_sel() {

		db = new DB("usp_person_payments_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 person_id {get;set;}
		public Double? Amount {get;set;}
		public DateTime? Cleared {get;set;}
		public String Description {get;set;}

		public static ResultSet1[] Init(usp_person_payments_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["person_id"] != DBNull.Value) rs1.person_id = (Int64)dal["person_id"];
				if (dal["Amount"] != DBNull.Value) rs1.Amount = (Double)dal["Amount"];
				if (dal["Cleared"] != DBNull.Value) rs1.Cleared = (DateTime)dal["Cleared"];
				if (dal["Description"] != DBNull.Value) rs1.Description = (String)dal["Description"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_person_payments_sel_by_parent_site  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_person_payments_sel_by_parent_site() {

		db = new DB("usp_person_payments_sel_by_parent_site");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 person_id {get;set;}
		public Double? Amount {get;set;}
		public DateTime? Cleared {get;set;}
		public String Description {get;set;}

		public static ResultSet1[] Init(usp_person_payments_sel_by_parent_site dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["person_id"] != DBNull.Value) rs1.person_id = (Int64)dal["person_id"];
				if (dal["Amount"] != DBNull.Value) rs1.Amount = (Double)dal["Amount"];
				if (dal["Cleared"] != DBNull.Value) rs1.Cleared = (DateTime)dal["Cleared"];
				if (dal["Description"] != DBNull.Value) rs1.Description = (String)dal["Description"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_person_payments_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_person_payments_sel_by_parent_user() {

		db = new DB("usp_person_payments_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 person_id {get;set;}
		public Double? Amount {get;set;}
		public DateTime? Cleared {get;set;}
		public String Description {get;set;}

		public static ResultSet1[] Init(usp_person_payments_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["person_id"] != DBNull.Value) rs1.person_id = (Int64)dal["person_id"];
				if (dal["Amount"] != DBNull.Value) rs1.Amount = (Double)dal["Amount"];
				if (dal["Cleared"] != DBNull.Value) rs1.Cleared = (DateTime)dal["Cleared"];
				if (dal["Description"] != DBNull.Value) rs1.Description = (String)dal["Description"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_person_payments_sel_by_person_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 person_id{get;set;}


	public usp_person_payments_sel_by_person_id() {

		db = new DB("usp_person_payments_sel_by_person_id");
	}

	private void preExecute() {
		db.NewParameter("person_id", SqlDbType.BigInt, 8, person_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["person_id"].Value != DBNull.Value) person_id = (Int64)base.db.cmd.Parameters["person_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 person_id {get;set;}
		public Double? Amount {get;set;}
		public DateTime? Cleared {get;set;}
		public String Description {get;set;}

		public static ResultSet1[] Init(usp_person_payments_sel_by_person_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["person_id"] != DBNull.Value) rs1.person_id = (Int64)dal["person_id"];
				if (dal["Amount"] != DBNull.Value) rs1.Amount = (Double)dal["Amount"];
				if (dal["Cleared"] != DBNull.Value) rs1.Cleared = (DateTime)dal["Cleared"];
				if (dal["Description"] != DBNull.Value) rs1.Description = (String)dal["Description"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_person_payments_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 person_id{get;set;}

	///<summary>  8  </summary>
	public Double? Amount{get;set;}

	///<summary>  8  </summary>
	public DateTime? Cleared{get;set;}

	///<summary>  -1  </summary>
	public String Description{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_person_payments_ups() {

		db = new DB("usp_person_payments_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("person_id", SqlDbType.BigInt, 8, person_id, false); 
		if (!Amount.HasValue)  db.NewParameter("Amount", SqlDbType.Float, 8, DBNull.Value, false); else  db.NewParameter("Amount", SqlDbType.Float, 8, Amount, false); 
		if (!Cleared.HasValue)  db.NewParameter("Cleared", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("Cleared", SqlDbType.DateTime, 8, Cleared, false); 
		if (Description == null)  db.NewParameter("Description", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("Description", SqlDbType.VarChar, -1,Encode(Description), false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["person_id"].Value != DBNull.Value) person_id = (Int64)base.db.cmd.Parameters["person_id"].Value;
		if (base.db.cmd.Parameters["Amount"].Value != DBNull.Value) Amount = (Double)base.db.cmd.Parameters["Amount"].Value;
		if (base.db.cmd.Parameters["Cleared"].Value != DBNull.Value) Cleared = (DateTime)base.db.cmd.Parameters["Cleared"].Value;
		if (base.db.cmd.Parameters["Description"].Value != DBNull.Value) Description = (String)base.db.cmd.Parameters["Description"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_person_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_person_sel() {

		db = new DB("usp_person_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public String email {get;set;}
		public String password {get;set;}
		public String ip {get;set;}
		public DateTime? last_authentication {get;set;}
		public Boolean? confirmed {get;set;}

		public static ResultSet1[] Init(usp_person_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["email"] != DBNull.Value) rs1.email = (String)dal["email"];
				if (dal["password"] != DBNull.Value) rs1.password = (String)dal["password"];
				if (dal["ip"] != DBNull.Value) rs1.ip = (String)dal["ip"];
				if (dal["last_authentication"] != DBNull.Value) rs1.last_authentication = (DateTime)dal["last_authentication"];
				if (dal["confirmed"] != DBNull.Value) rs1.confirmed = (Boolean)dal["confirmed"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_person_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_person_sel_by_parent_user() {

		db = new DB("usp_person_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public String email {get;set;}
		public String password {get;set;}
		public String ip {get;set;}
		public DateTime? last_authentication {get;set;}
		public Boolean? confirmed {get;set;}

		public static ResultSet1[] Init(usp_person_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["email"] != DBNull.Value) rs1.email = (String)dal["email"];
				if (dal["password"] != DBNull.Value) rs1.password = (String)dal["password"];
				if (dal["ip"] != DBNull.Value) rs1.ip = (String)dal["ip"];
				if (dal["last_authentication"] != DBNull.Value) rs1.last_authentication = (DateTime)dal["last_authentication"];
				if (dal["confirmed"] != DBNull.Value) rs1.confirmed = (Boolean)dal["confirmed"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_person_sel_by_site_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}


	public usp_person_sel_by_site_id() {

		db = new DB("usp_person_sel_by_site_id");
	}

	private void preExecute() {
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public String email {get;set;}
		public String password {get;set;}
		public String ip {get;set;}
		public DateTime? last_authentication {get;set;}
		public Boolean? confirmed {get;set;}

		public static ResultSet1[] Init(usp_person_sel_by_site_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["email"] != DBNull.Value) rs1.email = (String)dal["email"];
				if (dal["password"] != DBNull.Value) rs1.password = (String)dal["password"];
				if (dal["ip"] != DBNull.Value) rs1.ip = (String)dal["ip"];
				if (dal["last_authentication"] != DBNull.Value) rs1.last_authentication = (DateTime)dal["last_authentication"];
				if (dal["confirmed"] != DBNull.Value) rs1.confirmed = (Boolean)dal["confirmed"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_person_sel_sign_in  : SharpFusion.DAL  
{

	///<summary>  50  </summary>
	public String email{get;set;}

	///<summary>  8  </summary>
	public Int64? SiteID{get;set;}


	public usp_person_sel_sign_in() {

		db = new DB("usp_person_sel_sign_in");
	}

	private void preExecute() {
		if (email == null)  db.NewParameter("email", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("email", SqlDbType.VarChar, 50,Encode(email), false); 
		if (!SiteID.HasValue)  db.NewParameter("SiteID", SqlDbType.BigInt, 8, DBNull.Value, false); else  db.NewParameter("SiteID", SqlDbType.BigInt, 8, SiteID, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["email"].Value != DBNull.Value) email = (String)base.db.cmd.Parameters["email"].Value;
		if (base.db.cmd.Parameters["SiteID"].Value != DBNull.Value) SiteID = (Int64)base.db.cmd.Parameters["SiteID"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public String email {get;set;}
		public String password {get;set;}
		public String ip {get;set;}
		public DateTime? last_authentication {get;set;}
		public Boolean? confirmed {get;set;}

		public static ResultSet1[] Init(usp_person_sel_sign_in dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["email"] != DBNull.Value) rs1.email = (String)dal["email"];
				if (dal["password"] != DBNull.Value) rs1.password = (String)dal["password"];
				if (dal["ip"] != DBNull.Value) rs1.ip = (String)dal["ip"];
				if (dal["last_authentication"] != DBNull.Value) rs1.last_authentication = (DateTime)dal["last_authentication"];
				if (dal["confirmed"] != DBNull.Value) rs1.confirmed = (Boolean)dal["confirmed"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_person_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}

	///<summary>  50  </summary>
	public String name{get;set;}

	///<summary>  50  </summary>
	public String email{get;set;}

	///<summary>  -1  </summary>
	public String password{get;set;}

	///<summary>  50  </summary>
	public String ip{get;set;}

	///<summary>  8  </summary>
	public DateTime? last_authentication{get;set;}

	///<summary>  1  </summary>
	public Boolean? confirmed{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_person_ups() {

		db = new DB("usp_person_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
		if (name == null)  db.NewParameter("name", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("name", SqlDbType.VarChar, 50,Encode(name), false); 
		if (email == null)  db.NewParameter("email", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("email", SqlDbType.VarChar, 50,Encode(email), false); 
		if (password == null)  db.NewParameter("password", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("password", SqlDbType.VarChar, -1,Encode(password), false); 
		if (ip == null)  db.NewParameter("ip", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("ip", SqlDbType.VarChar, 50,Encode(ip), false); 
		if (!last_authentication.HasValue)  db.NewParameter("last_authentication", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("last_authentication", SqlDbType.DateTime, 8, last_authentication, false); 
		if (!confirmed.HasValue)  db.NewParameter("confirmed", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("confirmed", SqlDbType.Bit, 1, confirmed, false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
		if (base.db.cmd.Parameters["name"].Value != DBNull.Value) name = (String)base.db.cmd.Parameters["name"].Value;
		if (base.db.cmd.Parameters["email"].Value != DBNull.Value) email = (String)base.db.cmd.Parameters["email"].Value;
		if (base.db.cmd.Parameters["password"].Value != DBNull.Value) password = (String)base.db.cmd.Parameters["password"].Value;
		if (base.db.cmd.Parameters["ip"].Value != DBNull.Value) ip = (String)base.db.cmd.Parameters["ip"].Value;
		if (base.db.cmd.Parameters["last_authentication"].Value != DBNull.Value) last_authentication = (DateTime)base.db.cmd.Parameters["last_authentication"].Value;
		if (base.db.cmd.Parameters["confirmed"].Value != DBNull.Value) confirmed = (Boolean)base.db.cmd.Parameters["confirmed"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_api_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_proc_api_del() {

		db = new DB("usp_proc_api_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_api_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_api_sel() {

		db = new DB("usp_proc_api_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public String url {get;set;}
		public String useragent {get;set;}
		public String port {get;set;}
		public String return_type {get;set;}
		public String method {get;set;}
		public String accept {get;set;}
		public String content_type {get;set;}
		public String cookie {get;set;}

		public static ResultSet1[] Init(usp_proc_api_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["url"] != DBNull.Value) rs1.url = (String)dal["url"];
				if (dal["useragent"] != DBNull.Value) rs1.useragent = (String)dal["useragent"];
				if (dal["port"] != DBNull.Value) rs1.port = (String)dal["port"];
				if (dal["return_type"] != DBNull.Value) rs1.return_type = (String)dal["return_type"];
				if (dal["method"] != DBNull.Value) rs1.method = (String)dal["method"];
				if (dal["accept"] != DBNull.Value) rs1.accept = (String)dal["accept"];
				if (dal["content_type"] != DBNull.Value) rs1.content_type = (String)dal["content_type"];
				if (dal["cookie"] != DBNull.Value) rs1.cookie = (String)dal["cookie"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_api_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_api_sel_by_parent_user() {

		db = new DB("usp_proc_api_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public String url {get;set;}
		public String useragent {get;set;}
		public String port {get;set;}
		public String content_type {get;set;}
		public String accept {get;set;}
		public String method {get;set;}
		public String cookie {get;set;}
		public String return_type {get;set;}

		public static ResultSet1[] Init(usp_proc_api_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["url"] != DBNull.Value) rs1.url = (String)dal["url"];
				if (dal["useragent"] != DBNull.Value) rs1.useragent = (String)dal["useragent"];
				if (dal["port"] != DBNull.Value) rs1.port = (String)dal["port"];
				if (dal["content_type"] != DBNull.Value) rs1.content_type = (String)dal["content_type"];
				if (dal["accept"] != DBNull.Value) rs1.accept = (String)dal["accept"];
				if (dal["method"] != DBNull.Value) rs1.method = (String)dal["method"];
				if (dal["cookie"] != DBNull.Value) rs1.cookie = (String)dal["cookie"];
				if (dal["return_type"] != DBNull.Value) rs1.return_type = (String)dal["return_type"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_api_sel_by_site_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}


	public usp_proc_api_sel_by_site_id() {

		db = new DB("usp_proc_api_sel_by_site_id");
	}

	private void preExecute() {
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public String url {get;set;}
		public String useragent {get;set;}
		public String port {get;set;}
		public String return_type {get;set;}
		public String method {get;set;}
		public String accept {get;set;}
		public String content_type {get;set;}
		public String cookie {get;set;}

		public static ResultSet1[] Init(usp_proc_api_sel_by_site_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["url"] != DBNull.Value) rs1.url = (String)dal["url"];
				if (dal["useragent"] != DBNull.Value) rs1.useragent = (String)dal["useragent"];
				if (dal["port"] != DBNull.Value) rs1.port = (String)dal["port"];
				if (dal["return_type"] != DBNull.Value) rs1.return_type = (String)dal["return_type"];
				if (dal["method"] != DBNull.Value) rs1.method = (String)dal["method"];
				if (dal["accept"] != DBNull.Value) rs1.accept = (String)dal["accept"];
				if (dal["content_type"] != DBNull.Value) rs1.content_type = (String)dal["content_type"];
				if (dal["cookie"] != DBNull.Value) rs1.cookie = (String)dal["cookie"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_api_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}

	///<summary>  -1  </summary>
	public String name{get;set;}

	///<summary>  -1  </summary>
	public String url{get;set;}

	///<summary>  -1  </summary>
	public String useragent{get;set;}

	///<summary>  -1  </summary>
	public String port{get;set;}

	///<summary>  -1  </summary>
	public String return_type{get;set;}

	///<summary>  -1  </summary>
	public String method{get;set;}

	///<summary>  -1  </summary>
	public String accept{get;set;}

	///<summary>  -1  </summary>
	public String content_type{get;set;}

	///<summary>  -1  </summary>
	public String cookie{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_proc_api_ups() {

		db = new DB("usp_proc_api_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
		if (name == null)  db.NewParameter("name", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("name", SqlDbType.VarChar, -1,Encode(name), false); 
		if (url == null)  db.NewParameter("url", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("url", SqlDbType.VarChar, -1,Encode(url), false); 
		if (useragent == null)  db.NewParameter("useragent", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("useragent", SqlDbType.VarChar, -1,Encode(useragent), false); 
		if (port == null)  db.NewParameter("port", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("port", SqlDbType.VarChar, -1,Encode(port), false); 
		if (return_type == null)  db.NewParameter("return_type", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("return_type", SqlDbType.VarChar, -1,Encode(return_type), false); 
		if (method == null)  db.NewParameter("method", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("method", SqlDbType.VarChar, -1,Encode(method), false); 
		if (accept == null)  db.NewParameter("accept", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("accept", SqlDbType.VarChar, -1,Encode(accept), false); 
		if (content_type == null)  db.NewParameter("content_type", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("content_type", SqlDbType.VarChar, -1,Encode(content_type), false); 
		if (cookie == null)  db.NewParameter("cookie", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("cookie", SqlDbType.VarChar, -1,Encode(cookie), false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
		if (base.db.cmd.Parameters["name"].Value != DBNull.Value) name = (String)base.db.cmd.Parameters["name"].Value;
		if (base.db.cmd.Parameters["url"].Value != DBNull.Value) url = (String)base.db.cmd.Parameters["url"].Value;
		if (base.db.cmd.Parameters["useragent"].Value != DBNull.Value) useragent = (String)base.db.cmd.Parameters["useragent"].Value;
		if (base.db.cmd.Parameters["port"].Value != DBNull.Value) port = (String)base.db.cmd.Parameters["port"].Value;
		if (base.db.cmd.Parameters["return_type"].Value != DBNull.Value) return_type = (String)base.db.cmd.Parameters["return_type"].Value;
		if (base.db.cmd.Parameters["method"].Value != DBNull.Value) method = (String)base.db.cmd.Parameters["method"].Value;
		if (base.db.cmd.Parameters["accept"].Value != DBNull.Value) accept = (String)base.db.cmd.Parameters["accept"].Value;
		if (base.db.cmd.Parameters["content_type"].Value != DBNull.Value) content_type = (String)base.db.cmd.Parameters["content_type"].Value;
		if (base.db.cmd.Parameters["cookie"].Value != DBNull.Value) cookie = (String)base.db.cmd.Parameters["cookie"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_create_domain_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_proc_create_domain_del() {

		db = new DB("usp_proc_create_domain_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_create_domain_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_create_domain_sel() {

		db = new DB("usp_proc_create_domain_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}

		public static ResultSet1[] Init(usp_proc_create_domain_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_create_domain_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_create_domain_sel_by_parent_user() {

		db = new DB("usp_proc_create_domain_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}

		public static ResultSet1[] Init(usp_proc_create_domain_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_create_domain_sel_by_site_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}


	public usp_proc_create_domain_sel_by_site_id() {

		db = new DB("usp_proc_create_domain_sel_by_site_id");
	}

	private void preExecute() {
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}

		public static ResultSet1[] Init(usp_proc_create_domain_sel_by_site_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_create_domain_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}

	///<summary>  -1  </summary>
	public String name{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_proc_create_domain_ups() {

		db = new DB("usp_proc_create_domain_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
		if (name == null)  db.NewParameter("name", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("name", SqlDbType.VarChar, -1,Encode(name), false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
		if (base.db.cmd.Parameters["name"].Value != DBNull.Value) name = (String)base.db.cmd.Parameters["name"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_delete_domain_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_proc_delete_domain_del() {

		db = new DB("usp_proc_delete_domain_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_delete_domain_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_delete_domain_sel() {

		db = new DB("usp_proc_delete_domain_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String domain_name {get;set;}

		public static ResultSet1[] Init(usp_proc_delete_domain_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["domain_name"] != DBNull.Value) rs1.domain_name = (String)dal["domain_name"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_delete_domain_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_delete_domain_sel_by_parent_user() {

		db = new DB("usp_proc_delete_domain_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String domain_name {get;set;}

		public static ResultSet1[] Init(usp_proc_delete_domain_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["domain_name"] != DBNull.Value) rs1.domain_name = (String)dal["domain_name"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_delete_domain_sel_by_site_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}


	public usp_proc_delete_domain_sel_by_site_id() {

		db = new DB("usp_proc_delete_domain_sel_by_site_id");
	}

	private void preExecute() {
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String domain_name {get;set;}

		public static ResultSet1[] Init(usp_proc_delete_domain_sel_by_site_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["domain_name"] != DBNull.Value) rs1.domain_name = (String)dal["domain_name"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_delete_domain_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}

	///<summary>  -1  </summary>
	public String domain_name{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_proc_delete_domain_ups() {

		db = new DB("usp_proc_delete_domain_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
		if (domain_name == null)  db.NewParameter("domain_name", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("domain_name", SqlDbType.VarChar, -1,Encode(domain_name), false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
		if (base.db.cmd.Parameters["domain_name"].Value != DBNull.Value) domain_name = (String)base.db.cmd.Parameters["domain_name"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_get_attribute_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_proc_get_attribute_del() {

		db = new DB("usp_proc_get_attribute_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_get_attribute_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_get_attribute_sel() {

		db = new DB("usp_proc_get_attribute_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_get_id {get;set;}
		public String attribute_name {get;set;}

		public static ResultSet1[] Init(usp_proc_get_attribute_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_get_id"] != DBNull.Value) rs1.proc_get_id = (Int64)dal["proc_get_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_get_attribute_sel_by_parent_site  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_get_attribute_sel_by_parent_site() {

		db = new DB("usp_proc_get_attribute_sel_by_parent_site");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_get_id {get;set;}
		public String attribute_name {get;set;}

		public static ResultSet1[] Init(usp_proc_get_attribute_sel_by_parent_site dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_get_id"] != DBNull.Value) rs1.proc_get_id = (Int64)dal["proc_get_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_get_attribute_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_get_attribute_sel_by_parent_user() {

		db = new DB("usp_proc_get_attribute_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_get_id {get;set;}
		public String attribute_name {get;set;}

		public static ResultSet1[] Init(usp_proc_get_attribute_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_get_id"] != DBNull.Value) rs1.proc_get_id = (Int64)dal["proc_get_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_get_attribute_sel_by_proc_get_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 proc_get_id{get;set;}


	public usp_proc_get_attribute_sel_by_proc_get_id() {

		db = new DB("usp_proc_get_attribute_sel_by_proc_get_id");
	}

	private void preExecute() {
		db.NewParameter("proc_get_id", SqlDbType.BigInt, 8, proc_get_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["proc_get_id"].Value != DBNull.Value) proc_get_id = (Int64)base.db.cmd.Parameters["proc_get_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_get_id {get;set;}
		public String attribute_name {get;set;}

		public static ResultSet1[] Init(usp_proc_get_attribute_sel_by_proc_get_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_get_id"] != DBNull.Value) rs1.proc_get_id = (Int64)dal["proc_get_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_get_attribute_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 proc_get_id{get;set;}

	///<summary>  -1  </summary>
	public String attribute_name{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_proc_get_attribute_ups() {

		db = new DB("usp_proc_get_attribute_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("proc_get_id", SqlDbType.BigInt, 8, proc_get_id, false); 
		if (attribute_name == null)  db.NewParameter("attribute_name", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("attribute_name", SqlDbType.VarChar, -1,Encode(attribute_name), false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["proc_get_id"].Value != DBNull.Value) proc_get_id = (Int64)base.db.cmd.Parameters["proc_get_id"].Value;
		if (base.db.cmd.Parameters["attribute_name"].Value != DBNull.Value) attribute_name = (String)base.db.cmd.Parameters["attribute_name"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_get_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_proc_get_del() {

		db = new DB("usp_proc_get_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_get_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_get_sel() {

		db = new DB("usp_proc_get_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public String item_name {get;set;}
		public String domain_name {get;set;}
		public Boolean? consistent_read {get;set;}

		public static ResultSet1[] Init(usp_proc_get_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["item_name"] != DBNull.Value) rs1.item_name = (String)dal["item_name"];
				if (dal["domain_name"] != DBNull.Value) rs1.domain_name = (String)dal["domain_name"];
				if (dal["consistent_read"] != DBNull.Value) rs1.consistent_read = (Boolean)dal["consistent_read"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_get_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_get_sel_by_parent_user() {

		db = new DB("usp_proc_get_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String item_name {get;set;}
		public String domain_name {get;set;}
		public Boolean? consistent_read {get;set;}
		public String name {get;set;}

		public static ResultSet1[] Init(usp_proc_get_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["item_name"] != DBNull.Value) rs1.item_name = (String)dal["item_name"];
				if (dal["domain_name"] != DBNull.Value) rs1.domain_name = (String)dal["domain_name"];
				if (dal["consistent_read"] != DBNull.Value) rs1.consistent_read = (Boolean)dal["consistent_read"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_get_sel_by_site_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}


	public usp_proc_get_sel_by_site_id() {

		db = new DB("usp_proc_get_sel_by_site_id");
	}

	private void preExecute() {
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public String item_name {get;set;}
		public String domain_name {get;set;}
		public Boolean? consistent_read {get;set;}

		public static ResultSet1[] Init(usp_proc_get_sel_by_site_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["item_name"] != DBNull.Value) rs1.item_name = (String)dal["item_name"];
				if (dal["domain_name"] != DBNull.Value) rs1.domain_name = (String)dal["domain_name"];
				if (dal["consistent_read"] != DBNull.Value) rs1.consistent_read = (Boolean)dal["consistent_read"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_get_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}

	///<summary>  -1  </summary>
	public String name{get;set;}

	///<summary>  -1  </summary>
	public String item_name{get;set;}

	///<summary>  -1  </summary>
	public String domain_name{get;set;}

	///<summary>  1  </summary>
	public Boolean? consistent_read{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_proc_get_ups() {

		db = new DB("usp_proc_get_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
		if (name == null)  db.NewParameter("name", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("name", SqlDbType.VarChar, -1,Encode(name), false); 
		if (item_name == null)  db.NewParameter("item_name", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("item_name", SqlDbType.VarChar, -1,Encode(item_name), false); 
		if (domain_name == null)  db.NewParameter("domain_name", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("domain_name", SqlDbType.VarChar, -1,Encode(domain_name), false); 
		if (!consistent_read.HasValue)  db.NewParameter("consistent_read", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("consistent_read", SqlDbType.Bit, 1, consistent_read, false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
		if (base.db.cmd.Parameters["name"].Value != DBNull.Value) name = (String)base.db.cmd.Parameters["name"].Value;
		if (base.db.cmd.Parameters["item_name"].Value != DBNull.Value) item_name = (String)base.db.cmd.Parameters["item_name"].Value;
		if (base.db.cmd.Parameters["domain_name"].Value != DBNull.Value) domain_name = (String)base.db.cmd.Parameters["domain_name"].Value;
		if (base.db.cmd.Parameters["consistent_read"].Value != DBNull.Value) consistent_read = (Boolean)base.db.cmd.Parameters["consistent_read"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_list_domains_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_proc_list_domains_del() {

		db = new DB("usp_proc_list_domains_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_list_domains_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_list_domains_sel() {

		db = new DB("usp_proc_list_domains_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public Int32? maxresults {get;set;}

		public static ResultSet1[] Init(usp_proc_list_domains_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["maxresults"] != DBNull.Value) rs1.maxresults = (Int32)dal["maxresults"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_list_domains_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_list_domains_sel_by_parent_user() {

		db = new DB("usp_proc_list_domains_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public Int32? maxresults {get;set;}

		public static ResultSet1[] Init(usp_proc_list_domains_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["maxresults"] != DBNull.Value) rs1.maxresults = (Int32)dal["maxresults"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_list_domains_sel_by_site_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}


	public usp_proc_list_domains_sel_by_site_id() {

		db = new DB("usp_proc_list_domains_sel_by_site_id");
	}

	private void preExecute() {
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public Int32? maxresults {get;set;}

		public static ResultSet1[] Init(usp_proc_list_domains_sel_by_site_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["maxresults"] != DBNull.Value) rs1.maxresults = (Int32)dal["maxresults"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_list_domains_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}

	///<summary>  -1  </summary>
	public String name{get;set;}

	///<summary>  4  </summary>
	public Int32? maxresults{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_proc_list_domains_ups() {

		db = new DB("usp_proc_list_domains_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
		if (name == null)  db.NewParameter("name", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("name", SqlDbType.VarChar, -1,Encode(name), false); 
		if (!maxresults.HasValue)  db.NewParameter("maxresults", SqlDbType.Int, 4, DBNull.Value, false); else  db.NewParameter("maxresults", SqlDbType.Int, 4, maxresults, false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
		if (base.db.cmd.Parameters["name"].Value != DBNull.Value) name = (String)base.db.cmd.Parameters["name"].Value;
		if (base.db.cmd.Parameters["maxresults"].Value != DBNull.Value) maxresults = (Int32)base.db.cmd.Parameters["maxresults"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_modify_attribute_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_proc_modify_attribute_del() {

		db = new DB("usp_proc_modify_attribute_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_modify_attribute_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_modify_attribute_sel() {

		db = new DB("usp_proc_modify_attribute_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_modify_item_id {get;set;}
		public String attribute_name {get;set;}
		public String value {get;set;}
		public Boolean? replace {get;set;}

		public static ResultSet1[] Init(usp_proc_modify_attribute_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_modify_item_id"] != DBNull.Value) rs1.proc_modify_item_id = (Int64)dal["proc_modify_item_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["value"] != DBNull.Value) rs1.value = (String)dal["value"];
				if (dal["replace"] != DBNull.Value) rs1.replace = (Boolean)dal["replace"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_modify_attribute_sel_by_parent_proc_modify  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_modify_attribute_sel_by_parent_proc_modify() {

		db = new DB("usp_proc_modify_attribute_sel_by_parent_proc_modify");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_modify_item_id {get;set;}
		public String attribute_name {get;set;}
		public String value {get;set;}
		public Boolean? replace {get;set;}

		public static ResultSet1[] Init(usp_proc_modify_attribute_sel_by_parent_proc_modify dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_modify_item_id"] != DBNull.Value) rs1.proc_modify_item_id = (Int64)dal["proc_modify_item_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["value"] != DBNull.Value) rs1.value = (String)dal["value"];
				if (dal["replace"] != DBNull.Value) rs1.replace = (Boolean)dal["replace"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_modify_attribute_sel_by_parent_site  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_modify_attribute_sel_by_parent_site() {

		db = new DB("usp_proc_modify_attribute_sel_by_parent_site");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_modify_item_id {get;set;}
		public String attribute_name {get;set;}
		public String value {get;set;}
		public Boolean? replace {get;set;}

		public static ResultSet1[] Init(usp_proc_modify_attribute_sel_by_parent_site dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_modify_item_id"] != DBNull.Value) rs1.proc_modify_item_id = (Int64)dal["proc_modify_item_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["value"] != DBNull.Value) rs1.value = (String)dal["value"];
				if (dal["replace"] != DBNull.Value) rs1.replace = (Boolean)dal["replace"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_modify_attribute_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_modify_attribute_sel_by_parent_user() {

		db = new DB("usp_proc_modify_attribute_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_modify_item_id {get;set;}
		public String attribute_name {get;set;}
		public String value {get;set;}
		public Boolean? replace {get;set;}

		public static ResultSet1[] Init(usp_proc_modify_attribute_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_modify_item_id"] != DBNull.Value) rs1.proc_modify_item_id = (Int64)dal["proc_modify_item_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["value"] != DBNull.Value) rs1.value = (String)dal["value"];
				if (dal["replace"] != DBNull.Value) rs1.replace = (Boolean)dal["replace"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_modify_attribute_sel_by_proc_modify_item_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 proc_modify_item_id{get;set;}


	public usp_proc_modify_attribute_sel_by_proc_modify_item_id() {

		db = new DB("usp_proc_modify_attribute_sel_by_proc_modify_item_id");
	}

	private void preExecute() {
		db.NewParameter("proc_modify_item_id", SqlDbType.BigInt, 8, proc_modify_item_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["proc_modify_item_id"].Value != DBNull.Value) proc_modify_item_id = (Int64)base.db.cmd.Parameters["proc_modify_item_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_modify_item_id {get;set;}
		public String attribute_name {get;set;}
		public String value {get;set;}
		public Boolean? replace {get;set;}

		public static ResultSet1[] Init(usp_proc_modify_attribute_sel_by_proc_modify_item_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_modify_item_id"] != DBNull.Value) rs1.proc_modify_item_id = (Int64)dal["proc_modify_item_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["value"] != DBNull.Value) rs1.value = (String)dal["value"];
				if (dal["replace"] != DBNull.Value) rs1.replace = (Boolean)dal["replace"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_modify_attribute_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 proc_modify_item_id{get;set;}

	///<summary>  -1  </summary>
	public String attribute_name{get;set;}

	///<summary>  -1  </summary>
	public String value{get;set;}

	///<summary>  1  </summary>
	public Boolean? replace{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_proc_modify_attribute_ups() {

		db = new DB("usp_proc_modify_attribute_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("proc_modify_item_id", SqlDbType.BigInt, 8, proc_modify_item_id, false); 
		if (attribute_name == null)  db.NewParameter("attribute_name", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("attribute_name", SqlDbType.VarChar, -1,Encode(attribute_name), false); 
		if (value == null)  db.NewParameter("value", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("value", SqlDbType.VarChar, -1,Encode(value), false); 
		if (!replace.HasValue)  db.NewParameter("replace", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("replace", SqlDbType.Bit, 1, replace, false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["proc_modify_item_id"].Value != DBNull.Value) proc_modify_item_id = (Int64)base.db.cmd.Parameters["proc_modify_item_id"].Value;
		if (base.db.cmd.Parameters["attribute_name"].Value != DBNull.Value) attribute_name = (String)base.db.cmd.Parameters["attribute_name"].Value;
		if (base.db.cmd.Parameters["value"].Value != DBNull.Value) value = (String)base.db.cmd.Parameters["value"].Value;
		if (base.db.cmd.Parameters["replace"].Value != DBNull.Value) replace = (Boolean)base.db.cmd.Parameters["replace"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_modify_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_proc_modify_del() {

		db = new DB("usp_proc_modify_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_modify_expected_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_proc_modify_expected_del() {

		db = new DB("usp_proc_modify_expected_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_modify_expected_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_modify_expected_sel() {

		db = new DB("usp_proc_modify_expected_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_modify_item_id {get;set;}
		public String attribute_name {get;set;}
		public String value {get;set;}
		public Boolean? exists {get;set;}

		public static ResultSet1[] Init(usp_proc_modify_expected_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_modify_item_id"] != DBNull.Value) rs1.proc_modify_item_id = (Int64)dal["proc_modify_item_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["value"] != DBNull.Value) rs1.value = (String)dal["value"];
				if (dal["exists"] != DBNull.Value) rs1.exists = (Boolean)dal["exists"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_modify_expected_sel_by_parent_proc_modify  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_modify_expected_sel_by_parent_proc_modify() {

		db = new DB("usp_proc_modify_expected_sel_by_parent_proc_modify");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_modify_item_id {get;set;}
		public String attribute_name {get;set;}
		public String value {get;set;}
		public Boolean? exists {get;set;}

		public static ResultSet1[] Init(usp_proc_modify_expected_sel_by_parent_proc_modify dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_modify_item_id"] != DBNull.Value) rs1.proc_modify_item_id = (Int64)dal["proc_modify_item_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["value"] != DBNull.Value) rs1.value = (String)dal["value"];
				if (dal["exists"] != DBNull.Value) rs1.exists = (Boolean)dal["exists"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_modify_expected_sel_by_parent_site  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_modify_expected_sel_by_parent_site() {

		db = new DB("usp_proc_modify_expected_sel_by_parent_site");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_modify_item_id {get;set;}
		public String attribute_name {get;set;}
		public String value {get;set;}
		public Boolean? exists {get;set;}

		public static ResultSet1[] Init(usp_proc_modify_expected_sel_by_parent_site dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_modify_item_id"] != DBNull.Value) rs1.proc_modify_item_id = (Int64)dal["proc_modify_item_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["value"] != DBNull.Value) rs1.value = (String)dal["value"];
				if (dal["exists"] != DBNull.Value) rs1.exists = (Boolean)dal["exists"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_modify_expected_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_modify_expected_sel_by_parent_user() {

		db = new DB("usp_proc_modify_expected_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_modify_item_id {get;set;}
		public String attribute_name {get;set;}
		public String value {get;set;}
		public Boolean? exists {get;set;}

		public static ResultSet1[] Init(usp_proc_modify_expected_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_modify_item_id"] != DBNull.Value) rs1.proc_modify_item_id = (Int64)dal["proc_modify_item_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["value"] != DBNull.Value) rs1.value = (String)dal["value"];
				if (dal["exists"] != DBNull.Value) rs1.exists = (Boolean)dal["exists"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_modify_expected_sel_by_proc_modify_item_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 proc_modify_item_id{get;set;}


	public usp_proc_modify_expected_sel_by_proc_modify_item_id() {

		db = new DB("usp_proc_modify_expected_sel_by_proc_modify_item_id");
	}

	private void preExecute() {
		db.NewParameter("proc_modify_item_id", SqlDbType.BigInt, 8, proc_modify_item_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["proc_modify_item_id"].Value != DBNull.Value) proc_modify_item_id = (Int64)base.db.cmd.Parameters["proc_modify_item_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_modify_item_id {get;set;}
		public String attribute_name {get;set;}
		public String value {get;set;}
		public Boolean? exists {get;set;}

		public static ResultSet1[] Init(usp_proc_modify_expected_sel_by_proc_modify_item_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_modify_item_id"] != DBNull.Value) rs1.proc_modify_item_id = (Int64)dal["proc_modify_item_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["value"] != DBNull.Value) rs1.value = (String)dal["value"];
				if (dal["exists"] != DBNull.Value) rs1.exists = (Boolean)dal["exists"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_modify_expected_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 proc_modify_item_id{get;set;}

	///<summary>  -1  </summary>
	public String attribute_name{get;set;}

	///<summary>  -1  </summary>
	public String value{get;set;}

	///<summary>  1  </summary>
	public Boolean? exists{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_proc_modify_expected_ups() {

		db = new DB("usp_proc_modify_expected_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("proc_modify_item_id", SqlDbType.BigInt, 8, proc_modify_item_id, false); 
		if (attribute_name == null)  db.NewParameter("attribute_name", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("attribute_name", SqlDbType.VarChar, -1,Encode(attribute_name), false); 
		if (value == null)  db.NewParameter("value", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("value", SqlDbType.VarChar, -1,Encode(value), false); 
		if (!exists.HasValue)  db.NewParameter("exists", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("exists", SqlDbType.Bit, 1, exists, false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["proc_modify_item_id"].Value != DBNull.Value) proc_modify_item_id = (Int64)base.db.cmd.Parameters["proc_modify_item_id"].Value;
		if (base.db.cmd.Parameters["attribute_name"].Value != DBNull.Value) attribute_name = (String)base.db.cmd.Parameters["attribute_name"].Value;
		if (base.db.cmd.Parameters["value"].Value != DBNull.Value) value = (String)base.db.cmd.Parameters["value"].Value;
		if (base.db.cmd.Parameters["exists"].Value != DBNull.Value) exists = (Boolean)base.db.cmd.Parameters["exists"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_modify_increment  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8 output </summary>
	public Int64? newid{get;set;}


	public usp_proc_modify_increment() {

		db = new DB("usp_proc_modify_increment");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!newid.HasValue)  db.NewParameter("newid", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("newid", SqlDbType.BigInt, 8, newid, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["newid"].Value != DBNull.Value) newid = (Int64)base.db.cmd.Parameters["newid"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_modify_item_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_proc_modify_item_del() {

		db = new DB("usp_proc_modify_item_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_modify_item_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_modify_item_sel() {

		db = new DB("usp_proc_modify_item_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_modify_id {get;set;}
		public String item_name {get;set;}

		public static ResultSet1[] Init(usp_proc_modify_item_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_modify_id"] != DBNull.Value) rs1.proc_modify_id = (Int64)dal["proc_modify_id"];
				if (dal["item_name"] != DBNull.Value) rs1.item_name = (String)dal["item_name"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_modify_item_sel_by_parent_site  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_modify_item_sel_by_parent_site() {

		db = new DB("usp_proc_modify_item_sel_by_parent_site");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_modify_id {get;set;}
		public String item_name {get;set;}

		public static ResultSet1[] Init(usp_proc_modify_item_sel_by_parent_site dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_modify_id"] != DBNull.Value) rs1.proc_modify_id = (Int64)dal["proc_modify_id"];
				if (dal["item_name"] != DBNull.Value) rs1.item_name = (String)dal["item_name"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_modify_item_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_modify_item_sel_by_parent_user() {

		db = new DB("usp_proc_modify_item_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_modify_id {get;set;}
		public String item_name {get;set;}

		public static ResultSet1[] Init(usp_proc_modify_item_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_modify_id"] != DBNull.Value) rs1.proc_modify_id = (Int64)dal["proc_modify_id"];
				if (dal["item_name"] != DBNull.Value) rs1.item_name = (String)dal["item_name"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_modify_item_sel_by_proc_modify_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 proc_modify_id{get;set;}


	public usp_proc_modify_item_sel_by_proc_modify_id() {

		db = new DB("usp_proc_modify_item_sel_by_proc_modify_id");
	}

	private void preExecute() {
		db.NewParameter("proc_modify_id", SqlDbType.BigInt, 8, proc_modify_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["proc_modify_id"].Value != DBNull.Value) proc_modify_id = (Int64)base.db.cmd.Parameters["proc_modify_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_modify_id {get;set;}
		public String item_name {get;set;}

		public static ResultSet1[] Init(usp_proc_modify_item_sel_by_proc_modify_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_modify_id"] != DBNull.Value) rs1.proc_modify_id = (Int64)dal["proc_modify_id"];
				if (dal["item_name"] != DBNull.Value) rs1.item_name = (String)dal["item_name"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_modify_item_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 proc_modify_id{get;set;}

	///<summary>  -1  </summary>
	public String item_name{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_proc_modify_item_ups() {

		db = new DB("usp_proc_modify_item_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("proc_modify_id", SqlDbType.BigInt, 8, proc_modify_id, false); 
		if (item_name == null)  db.NewParameter("item_name", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("item_name", SqlDbType.VarChar, -1,Encode(item_name), false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["proc_modify_id"].Value != DBNull.Value) proc_modify_id = (Int64)base.db.cmd.Parameters["proc_modify_id"].Value;
		if (base.db.cmd.Parameters["item_name"].Value != DBNull.Value) item_name = (String)base.db.cmd.Parameters["item_name"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_modify_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_modify_sel() {

		db = new DB("usp_proc_modify_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String domain_name {get;set;}
		public Boolean? delete_put {get;set;}
		public String name {get;set;}
		public Boolean? batch {get;set;}
		public Int64? requests {get;set;}

		public static ResultSet1[] Init(usp_proc_modify_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["domain_name"] != DBNull.Value) rs1.domain_name = (String)dal["domain_name"];
				if (dal["delete_put"] != DBNull.Value) rs1.delete_put = (Boolean)dal["delete_put"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["batch"] != DBNull.Value) rs1.batch = (Boolean)dal["batch"];
				if (dal["requests"] != DBNull.Value) rs1.requests = (Int64)dal["requests"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_modify_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_modify_sel_by_parent_user() {

		db = new DB("usp_proc_modify_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String domain_name {get;set;}
		public Boolean? delete_put {get;set;}
		public Boolean? batch {get;set;}
		public String name {get;set;}
		public Int64? requests {get;set;}

		public static ResultSet1[] Init(usp_proc_modify_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["domain_name"] != DBNull.Value) rs1.domain_name = (String)dal["domain_name"];
				if (dal["delete_put"] != DBNull.Value) rs1.delete_put = (Boolean)dal["delete_put"];
				if (dal["batch"] != DBNull.Value) rs1.batch = (Boolean)dal["batch"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["requests"] != DBNull.Value) rs1.requests = (Int64)dal["requests"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_modify_sel_by_site_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}


	public usp_proc_modify_sel_by_site_id() {

		db = new DB("usp_proc_modify_sel_by_site_id");
	}

	private void preExecute() {
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String domain_name {get;set;}
		public Boolean? delete_put {get;set;}
		public String name {get;set;}
		public Boolean? batch {get;set;}
		public Int64? requests {get;set;}

		public static ResultSet1[] Init(usp_proc_modify_sel_by_site_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["domain_name"] != DBNull.Value) rs1.domain_name = (String)dal["domain_name"];
				if (dal["delete_put"] != DBNull.Value) rs1.delete_put = (Boolean)dal["delete_put"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["batch"] != DBNull.Value) rs1.batch = (Boolean)dal["batch"];
				if (dal["requests"] != DBNull.Value) rs1.requests = (Int64)dal["requests"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_modify_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}

	///<summary>  -1  </summary>
	public String domain_name{get;set;}

	///<summary>  1  </summary>
	public Boolean? delete_put{get;set;}

	///<summary>  -1  </summary>
	public String name{get;set;}

	///<summary>  1  </summary>
	public Boolean? batch{get;set;}

	///<summary>  8  </summary>
	public Int64? requests{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_proc_modify_ups() {

		db = new DB("usp_proc_modify_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
		if (domain_name == null)  db.NewParameter("domain_name", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("domain_name", SqlDbType.VarChar, -1,Encode(domain_name), false); 
		if (!delete_put.HasValue)  db.NewParameter("delete_put", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("delete_put", SqlDbType.Bit, 1, delete_put, false); 
		if (name == null)  db.NewParameter("name", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("name", SqlDbType.VarChar, -1,Encode(name), false); 
		if (!batch.HasValue)  db.NewParameter("batch", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("batch", SqlDbType.Bit, 1, batch, false); 
		if (!requests.HasValue)  db.NewParameter("requests", SqlDbType.BigInt, 8, DBNull.Value, false); else  db.NewParameter("requests", SqlDbType.BigInt, 8, requests, false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
		if (base.db.cmd.Parameters["domain_name"].Value != DBNull.Value) domain_name = (String)base.db.cmd.Parameters["domain_name"].Value;
		if (base.db.cmd.Parameters["delete_put"].Value != DBNull.Value) delete_put = (Boolean)base.db.cmd.Parameters["delete_put"].Value;
		if (base.db.cmd.Parameters["name"].Value != DBNull.Value) name = (String)base.db.cmd.Parameters["name"].Value;
		if (base.db.cmd.Parameters["batch"].Value != DBNull.Value) batch = (Boolean)base.db.cmd.Parameters["batch"].Value;
		if (base.db.cmd.Parameters["requests"].Value != DBNull.Value) requests = (Int64)base.db.cmd.Parameters["requests"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_select_condition_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_proc_select_condition_del() {

		db = new DB("usp_proc_select_condition_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_select_condition_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_select_condition_sel() {

		db = new DB("usp_proc_select_condition_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_select_id {get;set;}
		public String attribute_name {get;set;}
		public String comparison_operator {get;set;}
		public String or_and_intersect {get;set;}
		public Boolean? use_every {get;set;}
		public String param_name {get;set;}
		public String param_name_2 {get;set;}
		public String constant_value {get;set;}
		public String constant_value_2 {get;set;}

		public static ResultSet1[] Init(usp_proc_select_condition_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_select_id"] != DBNull.Value) rs1.proc_select_id = (Int64)dal["proc_select_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["comparison_operator"] != DBNull.Value) rs1.comparison_operator = (String)dal["comparison_operator"];
				if (dal["or_and_intersect"] != DBNull.Value) rs1.or_and_intersect = (String)dal["or_and_intersect"];
				if (dal["use_every"] != DBNull.Value) rs1.use_every = (Boolean)dal["use_every"];
				if (dal["param_name"] != DBNull.Value) rs1.param_name = (String)dal["param_name"];
				if (dal["param_name_2"] != DBNull.Value) rs1.param_name_2 = (String)dal["param_name_2"];
				if (dal["constant_value"] != DBNull.Value) rs1.constant_value = (String)dal["constant_value"];
				if (dal["constant_value_2"] != DBNull.Value) rs1.constant_value_2 = (String)dal["constant_value_2"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_select_condition_sel_by_parent_site  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_select_condition_sel_by_parent_site() {

		db = new DB("usp_proc_select_condition_sel_by_parent_site");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_select_id {get;set;}
		public String attribute_name {get;set;}
		public String comparison_operator {get;set;}
		public String or_and_intersect {get;set;}
		public Boolean? use_every {get;set;}
		public String param_name {get;set;}
		public String param_name_2 {get;set;}
		public String constant_value {get;set;}
		public String constant_value_2 {get;set;}

		public static ResultSet1[] Init(usp_proc_select_condition_sel_by_parent_site dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_select_id"] != DBNull.Value) rs1.proc_select_id = (Int64)dal["proc_select_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["comparison_operator"] != DBNull.Value) rs1.comparison_operator = (String)dal["comparison_operator"];
				if (dal["or_and_intersect"] != DBNull.Value) rs1.or_and_intersect = (String)dal["or_and_intersect"];
				if (dal["use_every"] != DBNull.Value) rs1.use_every = (Boolean)dal["use_every"];
				if (dal["param_name"] != DBNull.Value) rs1.param_name = (String)dal["param_name"];
				if (dal["param_name_2"] != DBNull.Value) rs1.param_name_2 = (String)dal["param_name_2"];
				if (dal["constant_value"] != DBNull.Value) rs1.constant_value = (String)dal["constant_value"];
				if (dal["constant_value_2"] != DBNull.Value) rs1.constant_value_2 = (String)dal["constant_value_2"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_select_condition_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_select_condition_sel_by_parent_user() {

		db = new DB("usp_proc_select_condition_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_select_id {get;set;}
		public String attribute_name {get;set;}
		public String comparison_operator {get;set;}
		public String or_and_intersect {get;set;}
		public Boolean? use_every {get;set;}
		public String param_name {get;set;}
		public String param_name_2 {get;set;}
		public String constant_value {get;set;}
		public String constant_value_2 {get;set;}

		public static ResultSet1[] Init(usp_proc_select_condition_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_select_id"] != DBNull.Value) rs1.proc_select_id = (Int64)dal["proc_select_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["comparison_operator"] != DBNull.Value) rs1.comparison_operator = (String)dal["comparison_operator"];
				if (dal["or_and_intersect"] != DBNull.Value) rs1.or_and_intersect = (String)dal["or_and_intersect"];
				if (dal["use_every"] != DBNull.Value) rs1.use_every = (Boolean)dal["use_every"];
				if (dal["param_name"] != DBNull.Value) rs1.param_name = (String)dal["param_name"];
				if (dal["param_name_2"] != DBNull.Value) rs1.param_name_2 = (String)dal["param_name_2"];
				if (dal["constant_value"] != DBNull.Value) rs1.constant_value = (String)dal["constant_value"];
				if (dal["constant_value_2"] != DBNull.Value) rs1.constant_value_2 = (String)dal["constant_value_2"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_select_condition_sel_by_proc_select_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 proc_select_id{get;set;}


	public usp_proc_select_condition_sel_by_proc_select_id() {

		db = new DB("usp_proc_select_condition_sel_by_proc_select_id");
	}

	private void preExecute() {
		db.NewParameter("proc_select_id", SqlDbType.BigInt, 8, proc_select_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["proc_select_id"].Value != DBNull.Value) proc_select_id = (Int64)base.db.cmd.Parameters["proc_select_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_select_id {get;set;}
		public String attribute_name {get;set;}
		public String comparison_operator {get;set;}
		public String or_and_intersect {get;set;}
		public Boolean? use_every {get;set;}
		public String param_name {get;set;}
		public String param_name_2 {get;set;}
		public String constant_value {get;set;}
		public String constant_value_2 {get;set;}

		public static ResultSet1[] Init(usp_proc_select_condition_sel_by_proc_select_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_select_id"] != DBNull.Value) rs1.proc_select_id = (Int64)dal["proc_select_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["comparison_operator"] != DBNull.Value) rs1.comparison_operator = (String)dal["comparison_operator"];
				if (dal["or_and_intersect"] != DBNull.Value) rs1.or_and_intersect = (String)dal["or_and_intersect"];
				if (dal["use_every"] != DBNull.Value) rs1.use_every = (Boolean)dal["use_every"];
				if (dal["param_name"] != DBNull.Value) rs1.param_name = (String)dal["param_name"];
				if (dal["param_name_2"] != DBNull.Value) rs1.param_name_2 = (String)dal["param_name_2"];
				if (dal["constant_value"] != DBNull.Value) rs1.constant_value = (String)dal["constant_value"];
				if (dal["constant_value_2"] != DBNull.Value) rs1.constant_value_2 = (String)dal["constant_value_2"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_select_condition_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 proc_select_id{get;set;}

	///<summary>  -1  </summary>
	public String attribute_name{get;set;}

	///<summary>  50  </summary>
	public String comparison_operator{get;set;}

	///<summary>  50  </summary>
	public String or_and_intersect{get;set;}

	///<summary>  1  </summary>
	public Boolean? use_every{get;set;}

	///<summary>  50  </summary>
	public String param_name{get;set;}

	///<summary>  50  </summary>
	public String param_name_2{get;set;}

	///<summary>  -1  </summary>
	public String constant_value{get;set;}

	///<summary>  -1  </summary>
	public String constant_value_2{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_proc_select_condition_ups() {

		db = new DB("usp_proc_select_condition_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("proc_select_id", SqlDbType.BigInt, 8, proc_select_id, false); 
		if (attribute_name == null)  db.NewParameter("attribute_name", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("attribute_name", SqlDbType.VarChar, -1,Encode(attribute_name), false); 
		if (comparison_operator == null)  db.NewParameter("comparison_operator", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("comparison_operator", SqlDbType.VarChar, 50,Encode(comparison_operator), false); 
		if (or_and_intersect == null)  db.NewParameter("or_and_intersect", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("or_and_intersect", SqlDbType.VarChar, 50,Encode(or_and_intersect), false); 
		if (!use_every.HasValue)  db.NewParameter("use_every", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("use_every", SqlDbType.Bit, 1, use_every, false); 
		if (param_name == null)  db.NewParameter("param_name", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("param_name", SqlDbType.VarChar, 50,Encode(param_name), false); 
		if (param_name_2 == null)  db.NewParameter("param_name_2", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("param_name_2", SqlDbType.VarChar, 50,Encode(param_name_2), false); 
		if (constant_value == null)  db.NewParameter("constant_value", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("constant_value", SqlDbType.VarChar, -1,Encode(constant_value), false); 
		if (constant_value_2 == null)  db.NewParameter("constant_value_2", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("constant_value_2", SqlDbType.VarChar, -1,Encode(constant_value_2), false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["proc_select_id"].Value != DBNull.Value) proc_select_id = (Int64)base.db.cmd.Parameters["proc_select_id"].Value;
		if (base.db.cmd.Parameters["attribute_name"].Value != DBNull.Value) attribute_name = (String)base.db.cmd.Parameters["attribute_name"].Value;
		if (base.db.cmd.Parameters["comparison_operator"].Value != DBNull.Value) comparison_operator = (String)base.db.cmd.Parameters["comparison_operator"].Value;
		if (base.db.cmd.Parameters["or_and_intersect"].Value != DBNull.Value) or_and_intersect = (String)base.db.cmd.Parameters["or_and_intersect"].Value;
		if (base.db.cmd.Parameters["use_every"].Value != DBNull.Value) use_every = (Boolean)base.db.cmd.Parameters["use_every"].Value;
		if (base.db.cmd.Parameters["param_name"].Value != DBNull.Value) param_name = (String)base.db.cmd.Parameters["param_name"].Value;
		if (base.db.cmd.Parameters["param_name_2"].Value != DBNull.Value) param_name_2 = (String)base.db.cmd.Parameters["param_name_2"].Value;
		if (base.db.cmd.Parameters["constant_value"].Value != DBNull.Value) constant_value = (String)base.db.cmd.Parameters["constant_value"].Value;
		if (base.db.cmd.Parameters["constant_value_2"].Value != DBNull.Value) constant_value_2 = (String)base.db.cmd.Parameters["constant_value_2"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_select_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_proc_select_del() {

		db = new DB("usp_proc_select_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_select_field_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_proc_select_field_del() {

		db = new DB("usp_proc_select_field_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_select_field_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_select_field_sel() {

		db = new DB("usp_proc_select_field_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_select_id {get;set;}
		public String attribute_name {get;set;}
		public Boolean? is_count {get;set;}

		public static ResultSet1[] Init(usp_proc_select_field_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_select_id"] != DBNull.Value) rs1.proc_select_id = (Int64)dal["proc_select_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["is_count"] != DBNull.Value) rs1.is_count = (Boolean)dal["is_count"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_select_field_sel_by_parent_site  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_select_field_sel_by_parent_site() {

		db = new DB("usp_proc_select_field_sel_by_parent_site");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_select_id {get;set;}
		public String attribute_name {get;set;}
		public Boolean? is_count {get;set;}

		public static ResultSet1[] Init(usp_proc_select_field_sel_by_parent_site dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_select_id"] != DBNull.Value) rs1.proc_select_id = (Int64)dal["proc_select_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["is_count"] != DBNull.Value) rs1.is_count = (Boolean)dal["is_count"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_select_field_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_select_field_sel_by_parent_user() {

		db = new DB("usp_proc_select_field_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_select_id {get;set;}
		public String attribute_name {get;set;}
		public Boolean? is_count {get;set;}

		public static ResultSet1[] Init(usp_proc_select_field_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_select_id"] != DBNull.Value) rs1.proc_select_id = (Int64)dal["proc_select_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["is_count"] != DBNull.Value) rs1.is_count = (Boolean)dal["is_count"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_select_field_sel_by_proc_select_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 proc_select_id{get;set;}


	public usp_proc_select_field_sel_by_proc_select_id() {

		db = new DB("usp_proc_select_field_sel_by_proc_select_id");
	}

	private void preExecute() {
		db.NewParameter("proc_select_id", SqlDbType.BigInt, 8, proc_select_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["proc_select_id"].Value != DBNull.Value) proc_select_id = (Int64)base.db.cmd.Parameters["proc_select_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 proc_select_id {get;set;}
		public String attribute_name {get;set;}
		public Boolean? is_count {get;set;}

		public static ResultSet1[] Init(usp_proc_select_field_sel_by_proc_select_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["proc_select_id"] != DBNull.Value) rs1.proc_select_id = (Int64)dal["proc_select_id"];
				if (dal["attribute_name"] != DBNull.Value) rs1.attribute_name = (String)dal["attribute_name"];
				if (dal["is_count"] != DBNull.Value) rs1.is_count = (Boolean)dal["is_count"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_select_field_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 proc_select_id{get;set;}

	///<summary>  -1  </summary>
	public String attribute_name{get;set;}

	///<summary>  1  </summary>
	public Boolean? is_count{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_proc_select_field_ups() {

		db = new DB("usp_proc_select_field_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("proc_select_id", SqlDbType.BigInt, 8, proc_select_id, false); 
		if (attribute_name == null)  db.NewParameter("attribute_name", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("attribute_name", SqlDbType.VarChar, -1,Encode(attribute_name), false); 
		if (!is_count.HasValue)  db.NewParameter("is_count", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("is_count", SqlDbType.Bit, 1, is_count, false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["proc_select_id"].Value != DBNull.Value) proc_select_id = (Int64)base.db.cmd.Parameters["proc_select_id"].Value;
		if (base.db.cmd.Parameters["attribute_name"].Value != DBNull.Value) attribute_name = (String)base.db.cmd.Parameters["attribute_name"].Value;
		if (base.db.cmd.Parameters["is_count"].Value != DBNull.Value) is_count = (Boolean)base.db.cmd.Parameters["is_count"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_proc_select_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_select_sel() {

		db = new DB("usp_proc_select_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public Int32? limit {get;set;}
		public String domain_name {get;set;}
		public String sort_by {get;set;}
		public String sort_order {get;set;}
		public Boolean? consistent_read {get;set;}
		public Int64? requests {get;set;}

		public static ResultSet1[] Init(usp_proc_select_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["limit"] != DBNull.Value) rs1.limit = (Int32)dal["limit"];
				if (dal["domain_name"] != DBNull.Value) rs1.domain_name = (String)dal["domain_name"];
				if (dal["sort_by"] != DBNull.Value) rs1.sort_by = (String)dal["sort_by"];
				if (dal["sort_order"] != DBNull.Value) rs1.sort_order = (String)dal["sort_order"];
				if (dal["consistent_read"] != DBNull.Value) rs1.consistent_read = (Boolean)dal["consistent_read"];
				if (dal["requests"] != DBNull.Value) rs1.requests = (Int64)dal["requests"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_select_sel_by_name  : SharpFusion.DAL  
{

	///<summary>  250  </summary>
	public String name{get;set;}


	public usp_proc_select_sel_by_name() {

		db = new DB("usp_proc_select_sel_by_name");
	}

	private void preExecute() {
		if (name == null)  db.NewParameter("name", SqlDbType.VarChar, 250, DBNull.Value, false); else  db.NewParameter("name", SqlDbType.VarChar, 250,Encode(name), false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["name"].Value != DBNull.Value) name = (String)base.db.cmd.Parameters["name"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public Int32? limit {get;set;}
		public String domain_name {get;set;}
		public String sort_by {get;set;}
		public String sort_order {get;set;}
		public Boolean? consistent_read {get;set;}
		public Int64? requests {get;set;}

		public static ResultSet1[] Init(usp_proc_select_sel_by_name dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["limit"] != DBNull.Value) rs1.limit = (Int32)dal["limit"];
				if (dal["domain_name"] != DBNull.Value) rs1.domain_name = (String)dal["domain_name"];
				if (dal["sort_by"] != DBNull.Value) rs1.sort_by = (String)dal["sort_by"];
				if (dal["sort_order"] != DBNull.Value) rs1.sort_order = (String)dal["sort_order"];
				if (dal["consistent_read"] != DBNull.Value) rs1.consistent_read = (Boolean)dal["consistent_read"];
				if (dal["requests"] != DBNull.Value) rs1.requests = (Int64)dal["requests"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_select_sel_by_parent_user  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_proc_select_sel_by_parent_user() {

		db = new DB("usp_proc_select_sel_by_parent_user");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public Int32? limit {get;set;}
		public String sort_by {get;set;}
		public String sort_order {get;set;}
		public Boolean? consistent_read {get;set;}
		public String domain_name {get;set;}
		public Int64? requests {get;set;}

		public static ResultSet1[] Init(usp_proc_select_sel_by_parent_user dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["limit"] != DBNull.Value) rs1.limit = (Int32)dal["limit"];
				if (dal["sort_by"] != DBNull.Value) rs1.sort_by = (String)dal["sort_by"];
				if (dal["sort_order"] != DBNull.Value) rs1.sort_order = (String)dal["sort_order"];
				if (dal["consistent_read"] != DBNull.Value) rs1.consistent_read = (Boolean)dal["consistent_read"];
				if (dal["domain_name"] != DBNull.Value) rs1.domain_name = (String)dal["domain_name"];
				if (dal["requests"] != DBNull.Value) rs1.requests = (Int64)dal["requests"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_select_sel_by_site_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}


	public usp_proc_select_sel_by_site_id() {

		db = new DB("usp_proc_select_sel_by_site_id");
	}

	private void preExecute() {
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 site_id {get;set;}
		public String name {get;set;}
		public Int32? limit {get;set;}
		public String domain_name {get;set;}
		public String sort_by {get;set;}
		public String sort_order {get;set;}
		public Boolean? consistent_read {get;set;}
		public Int64? requests {get;set;}

		public static ResultSet1[] Init(usp_proc_select_sel_by_site_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["site_id"] != DBNull.Value) rs1.site_id = (Int64)dal["site_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["limit"] != DBNull.Value) rs1.limit = (Int32)dal["limit"];
				if (dal["domain_name"] != DBNull.Value) rs1.domain_name = (String)dal["domain_name"];
				if (dal["sort_by"] != DBNull.Value) rs1.sort_by = (String)dal["sort_by"];
				if (dal["sort_order"] != DBNull.Value) rs1.sort_order = (String)dal["sort_order"];
				if (dal["consistent_read"] != DBNull.Value) rs1.consistent_read = (Boolean)dal["consistent_read"];
				if (dal["requests"] != DBNull.Value) rs1.requests = (Int64)dal["requests"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_proc_select_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 site_id{get;set;}

	///<summary>  250  </summary>
	public String name{get;set;}

	///<summary>  4  </summary>
	public Int32? limit{get;set;}

	///<summary>  -1  </summary>
	public String domain_name{get;set;}

	///<summary>  50  </summary>
	public String sort_by{get;set;}

	///<summary>  50  </summary>
	public String sort_order{get;set;}

	///<summary>  1  </summary>
	public Boolean? consistent_read{get;set;}

	///<summary>  8  </summary>
	public Int64? requests{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_proc_select_ups() {

		db = new DB("usp_proc_select_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("site_id", SqlDbType.BigInt, 8, site_id, false); 
		if (name == null)  db.NewParameter("name", SqlDbType.VarChar, 250, DBNull.Value, false); else  db.NewParameter("name", SqlDbType.VarChar, 250,Encode(name), false); 
		if (!limit.HasValue)  db.NewParameter("limit", SqlDbType.Int, 4, DBNull.Value, false); else  db.NewParameter("limit", SqlDbType.Int, 4, limit, false); 
		if (domain_name == null)  db.NewParameter("domain_name", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("domain_name", SqlDbType.VarChar, -1,Encode(domain_name), false); 
		if (sort_by == null)  db.NewParameter("sort_by", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("sort_by", SqlDbType.VarChar, 50,Encode(sort_by), false); 
		if (sort_order == null)  db.NewParameter("sort_order", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("sort_order", SqlDbType.VarChar, 50,Encode(sort_order), false); 
		if (!consistent_read.HasValue)  db.NewParameter("consistent_read", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("consistent_read", SqlDbType.Bit, 1, consistent_read, false); 
		if (!requests.HasValue)  db.NewParameter("requests", SqlDbType.BigInt, 8, DBNull.Value, false); else  db.NewParameter("requests", SqlDbType.BigInt, 8, requests, false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["site_id"].Value != DBNull.Value) site_id = (Int64)base.db.cmd.Parameters["site_id"].Value;
		if (base.db.cmd.Parameters["name"].Value != DBNull.Value) name = (String)base.db.cmd.Parameters["name"].Value;
		if (base.db.cmd.Parameters["limit"].Value != DBNull.Value) limit = (Int32)base.db.cmd.Parameters["limit"].Value;
		if (base.db.cmd.Parameters["domain_name"].Value != DBNull.Value) domain_name = (String)base.db.cmd.Parameters["domain_name"].Value;
		if (base.db.cmd.Parameters["sort_by"].Value != DBNull.Value) sort_by = (String)base.db.cmd.Parameters["sort_by"].Value;
		if (base.db.cmd.Parameters["sort_order"].Value != DBNull.Value) sort_order = (String)base.db.cmd.Parameters["sort_order"].Value;
		if (base.db.cmd.Parameters["consistent_read"].Value != DBNull.Value) consistent_read = (Boolean)base.db.cmd.Parameters["consistent_read"].Value;
		if (base.db.cmd.Parameters["requests"].Value != DBNull.Value) requests = (Int64)base.db.cmd.Parameters["requests"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_site_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_site_del() {

		db = new DB("usp_site_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_site_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_site_sel() {

		db = new DB("usp_site_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 user_id {get;set;}
		public String name {get;set;}
		public String url {get;set;}
		public String AmazonKey {get;set;}
		public String AmazonPassword {get;set;}
		public String FBKey {get;set;}
		public String FBPassword {get;set;}
		public String GoogleKey {get;set;}
		public String GooglePassword {get;set;}
		public Int64? Requests {get;set;}
		public Boolean? is_protected {get;set;}
		public String smtpserver {get;set;}
		public String smtpusername {get;set;}
		public String smtppassword {get;set;}
		public String supportemail {get;set;}
		public String supportemailname {get;set;}

		public static ResultSet1[] Init(usp_site_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["user_id"] != DBNull.Value) rs1.user_id = (Int64)dal["user_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["url"] != DBNull.Value) rs1.url = (String)dal["url"];
				if (dal["AmazonKey"] != DBNull.Value) rs1.AmazonKey = (String)dal["AmazonKey"];
				if (dal["AmazonPassword"] != DBNull.Value) rs1.AmazonPassword = (String)dal["AmazonPassword"];
				if (dal["FBKey"] != DBNull.Value) rs1.FBKey = (String)dal["FBKey"];
				if (dal["FBPassword"] != DBNull.Value) rs1.FBPassword = (String)dal["FBPassword"];
				if (dal["GoogleKey"] != DBNull.Value) rs1.GoogleKey = (String)dal["GoogleKey"];
				if (dal["GooglePassword"] != DBNull.Value) rs1.GooglePassword = (String)dal["GooglePassword"];
				if (dal["Requests"] != DBNull.Value) rs1.Requests = (Int64)dal["Requests"];
				if (dal["is_protected"] != DBNull.Value) rs1.is_protected = (Boolean)dal["is_protected"];
				if (dal["smtpserver"] != DBNull.Value) rs1.smtpserver = (String)dal["smtpserver"];
				if (dal["smtpusername"] != DBNull.Value) rs1.smtpusername = (String)dal["smtpusername"];
				if (dal["smtppassword"] != DBNull.Value) rs1.smtppassword = (String)dal["smtppassword"];
				if (dal["supportemail"] != DBNull.Value) rs1.supportemail = (String)dal["supportemail"];
				if (dal["supportemailname"] != DBNull.Value) rs1.supportemailname = (String)dal["supportemailname"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_site_sel_by_user_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 user_id{get;set;}


	public usp_site_sel_by_user_id() {

		db = new DB("usp_site_sel_by_user_id");
	}

	private void preExecute() {
		db.NewParameter("user_id", SqlDbType.BigInt, 8, user_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["user_id"].Value != DBNull.Value) user_id = (Int64)base.db.cmd.Parameters["user_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 user_id {get;set;}
		public String name {get;set;}
		public String url {get;set;}
		public String AmazonKey {get;set;}
		public String AmazonPassword {get;set;}
		public String FBKey {get;set;}
		public String FBPassword {get;set;}
		public String GoogleKey {get;set;}
		public String GooglePassword {get;set;}
		public Int64? Requests {get;set;}
		public Boolean? is_protected {get;set;}
		public String smtpserver {get;set;}
		public String smtpusername {get;set;}
		public String smtppassword {get;set;}
		public String supportemail {get;set;}
		public String supportemailname {get;set;}

		public static ResultSet1[] Init(usp_site_sel_by_user_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["user_id"] != DBNull.Value) rs1.user_id = (Int64)dal["user_id"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["url"] != DBNull.Value) rs1.url = (String)dal["url"];
				if (dal["AmazonKey"] != DBNull.Value) rs1.AmazonKey = (String)dal["AmazonKey"];
				if (dal["AmazonPassword"] != DBNull.Value) rs1.AmazonPassword = (String)dal["AmazonPassword"];
				if (dal["FBKey"] != DBNull.Value) rs1.FBKey = (String)dal["FBKey"];
				if (dal["FBPassword"] != DBNull.Value) rs1.FBPassword = (String)dal["FBPassword"];
				if (dal["GoogleKey"] != DBNull.Value) rs1.GoogleKey = (String)dal["GoogleKey"];
				if (dal["GooglePassword"] != DBNull.Value) rs1.GooglePassword = (String)dal["GooglePassword"];
				if (dal["Requests"] != DBNull.Value) rs1.Requests = (Int64)dal["Requests"];
				if (dal["is_protected"] != DBNull.Value) rs1.is_protected = (Boolean)dal["is_protected"];
				if (dal["smtpserver"] != DBNull.Value) rs1.smtpserver = (String)dal["smtpserver"];
				if (dal["smtpusername"] != DBNull.Value) rs1.smtpusername = (String)dal["smtpusername"];
				if (dal["smtppassword"] != DBNull.Value) rs1.smtppassword = (String)dal["smtppassword"];
				if (dal["supportemail"] != DBNull.Value) rs1.supportemail = (String)dal["supportemail"];
				if (dal["supportemailname"] != DBNull.Value) rs1.supportemailname = (String)dal["supportemailname"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_site_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 user_id{get;set;}

	///<summary>  50  </summary>
	public String name{get;set;}

	///<summary>  50  </summary>
	public String url{get;set;}

	///<summary>  50  </summary>
	public String AmazonKey{get;set;}

	///<summary>  50  </summary>
	public String AmazonPassword{get;set;}

	///<summary>  50  </summary>
	public String FBKey{get;set;}

	///<summary>  50  </summary>
	public String FBPassword{get;set;}

	///<summary>  50  </summary>
	public String GoogleKey{get;set;}

	///<summary>  50  </summary>
	public String GooglePassword{get;set;}

	///<summary>  8  </summary>
	public Int64? Requests{get;set;}

	///<summary>  1  </summary>
	public Boolean? is_protected{get;set;}

	///<summary>  -1  </summary>
	public String smtpserver{get;set;}

	///<summary>  -1  </summary>
	public String smtpusername{get;set;}

	///<summary>  -1  </summary>
	public String smtppassword{get;set;}

	///<summary>  50  </summary>
	public String supportemail{get;set;}

	///<summary>  50  </summary>
	public String supportemailname{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_site_ups() {

		db = new DB("usp_site_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("user_id", SqlDbType.BigInt, 8, user_id, false); 
		if (name == null)  db.NewParameter("name", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("name", SqlDbType.VarChar, 50,Encode(name), false); 
		if (url == null)  db.NewParameter("url", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("url", SqlDbType.VarChar, 50,Encode(url), false); 
		if (AmazonKey == null)  db.NewParameter("AmazonKey", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("AmazonKey", SqlDbType.VarChar, 50,Encode(AmazonKey), false); 
		if (AmazonPassword == null)  db.NewParameter("AmazonPassword", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("AmazonPassword", SqlDbType.VarChar, 50,Encode(AmazonPassword), false); 
		if (FBKey == null)  db.NewParameter("FBKey", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("FBKey", SqlDbType.VarChar, 50,Encode(FBKey), false); 
		if (FBPassword == null)  db.NewParameter("FBPassword", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("FBPassword", SqlDbType.VarChar, 50,Encode(FBPassword), false); 
		if (GoogleKey == null)  db.NewParameter("GoogleKey", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("GoogleKey", SqlDbType.VarChar, 50,Encode(GoogleKey), false); 
		if (GooglePassword == null)  db.NewParameter("GooglePassword", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("GooglePassword", SqlDbType.VarChar, 50,Encode(GooglePassword), false); 
		if (!Requests.HasValue)  db.NewParameter("Requests", SqlDbType.BigInt, 8, DBNull.Value, false); else  db.NewParameter("Requests", SqlDbType.BigInt, 8, Requests, false); 
		if (!is_protected.HasValue)  db.NewParameter("is_protected", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("is_protected", SqlDbType.Bit, 1, is_protected, false); 
		if (smtpserver == null)  db.NewParameter("smtpserver", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("smtpserver", SqlDbType.VarChar, -1,Encode(smtpserver), false); 
		if (smtpusername == null)  db.NewParameter("smtpusername", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("smtpusername", SqlDbType.VarChar, -1,Encode(smtpusername), false); 
		if (smtppassword == null)  db.NewParameter("smtppassword", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("smtppassword", SqlDbType.VarChar, -1,Encode(smtppassword), false); 
		if (supportemail == null)  db.NewParameter("supportemail", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("supportemail", SqlDbType.VarChar, 50,Encode(supportemail), false); 
		if (supportemailname == null)  db.NewParameter("supportemailname", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("supportemailname", SqlDbType.VarChar, 50,Encode(supportemailname), false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["user_id"].Value != DBNull.Value) user_id = (Int64)base.db.cmd.Parameters["user_id"].Value;
		if (base.db.cmd.Parameters["name"].Value != DBNull.Value) name = (String)base.db.cmd.Parameters["name"].Value;
		if (base.db.cmd.Parameters["url"].Value != DBNull.Value) url = (String)base.db.cmd.Parameters["url"].Value;
		if (base.db.cmd.Parameters["AmazonKey"].Value != DBNull.Value) AmazonKey = (String)base.db.cmd.Parameters["AmazonKey"].Value;
		if (base.db.cmd.Parameters["AmazonPassword"].Value != DBNull.Value) AmazonPassword = (String)base.db.cmd.Parameters["AmazonPassword"].Value;
		if (base.db.cmd.Parameters["FBKey"].Value != DBNull.Value) FBKey = (String)base.db.cmd.Parameters["FBKey"].Value;
		if (base.db.cmd.Parameters["FBPassword"].Value != DBNull.Value) FBPassword = (String)base.db.cmd.Parameters["FBPassword"].Value;
		if (base.db.cmd.Parameters["GoogleKey"].Value != DBNull.Value) GoogleKey = (String)base.db.cmd.Parameters["GoogleKey"].Value;
		if (base.db.cmd.Parameters["GooglePassword"].Value != DBNull.Value) GooglePassword = (String)base.db.cmd.Parameters["GooglePassword"].Value;
		if (base.db.cmd.Parameters["Requests"].Value != DBNull.Value) Requests = (Int64)base.db.cmd.Parameters["Requests"].Value;
		if (base.db.cmd.Parameters["is_protected"].Value != DBNull.Value) is_protected = (Boolean)base.db.cmd.Parameters["is_protected"].Value;
		if (base.db.cmd.Parameters["smtpserver"].Value != DBNull.Value) smtpserver = (String)base.db.cmd.Parameters["smtpserver"].Value;
		if (base.db.cmd.Parameters["smtpusername"].Value != DBNull.Value) smtpusername = (String)base.db.cmd.Parameters["smtpusername"].Value;
		if (base.db.cmd.Parameters["smtppassword"].Value != DBNull.Value) smtppassword = (String)base.db.cmd.Parameters["smtppassword"].Value;
		if (base.db.cmd.Parameters["supportemail"].Value != DBNull.Value) supportemail = (String)base.db.cmd.Parameters["supportemail"].Value;
		if (base.db.cmd.Parameters["supportemailname"].Value != DBNull.Value) supportemailname = (String)base.db.cmd.Parameters["supportemailname"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_user_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_user_del() {

		db = new DB("usp_user_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_user_payments_del  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  1  </summary>
	public Boolean? hard{get;set;}


	public usp_user_payments_del() {

		db = new DB("usp_user_payments_del");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!hard.HasValue)  db.NewParameter("hard", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("hard", SqlDbType.Bit, 1, hard, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["hard"].Value != DBNull.Value) hard = (Boolean)base.db.cmd.Parameters["hard"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_user_payments_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_user_payments_sel() {

		db = new DB("usp_user_payments_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 user_id {get;set;}
		public String txn_type {get;set;}
		public String txn_id {get;set;}
		public DateTime? effective_date {get;set;}
		public String subscr_id {get;set;}
		public String payer_email {get;set;}
		public Double? Amount {get;set;}
		public DateTime? txn_date {get;set;}
		public String Description {get;set;}

		public static ResultSet1[] Init(usp_user_payments_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["user_id"] != DBNull.Value) rs1.user_id = (Int64)dal["user_id"];
				if (dal["txn_type"] != DBNull.Value) rs1.txn_type = (String)dal["txn_type"];
				if (dal["txn_id"] != DBNull.Value) rs1.txn_id = (String)dal["txn_id"];
				if (dal["effective_date"] != DBNull.Value) rs1.effective_date = (DateTime)dal["effective_date"];
				if (dal["subscr_id"] != DBNull.Value) rs1.subscr_id = (String)dal["subscr_id"];
				if (dal["payer_email"] != DBNull.Value) rs1.payer_email = (String)dal["payer_email"];
				if (dal["Amount"] != DBNull.Value) rs1.Amount = (Double)dal["Amount"];
				if (dal["txn_date"] != DBNull.Value) rs1.txn_date = (DateTime)dal["txn_date"];
				if (dal["Description"] != DBNull.Value) rs1.Description = (String)dal["Description"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_user_payments_sel_by_user_id  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 user_id{get;set;}


	public usp_user_payments_sel_by_user_id() {

		db = new DB("usp_user_payments_sel_by_user_id");
	}

	private void preExecute() {
		db.NewParameter("user_id", SqlDbType.BigInt, 8, user_id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["user_id"].Value != DBNull.Value) user_id = (Int64)base.db.cmd.Parameters["user_id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public Int64 user_id {get;set;}
		public String txn_type {get;set;}
		public String txn_id {get;set;}
		public DateTime? effective_date {get;set;}
		public String subscr_id {get;set;}
		public String payer_email {get;set;}
		public Double? Amount {get;set;}
		public DateTime? txn_date {get;set;}
		public String Description {get;set;}

		public static ResultSet1[] Init(usp_user_payments_sel_by_user_id dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["user_id"] != DBNull.Value) rs1.user_id = (Int64)dal["user_id"];
				if (dal["txn_type"] != DBNull.Value) rs1.txn_type = (String)dal["txn_type"];
				if (dal["txn_id"] != DBNull.Value) rs1.txn_id = (String)dal["txn_id"];
				if (dal["effective_date"] != DBNull.Value) rs1.effective_date = (DateTime)dal["effective_date"];
				if (dal["subscr_id"] != DBNull.Value) rs1.subscr_id = (String)dal["subscr_id"];
				if (dal["payer_email"] != DBNull.Value) rs1.payer_email = (String)dal["payer_email"];
				if (dal["Amount"] != DBNull.Value) rs1.Amount = (Double)dal["Amount"];
				if (dal["txn_date"] != DBNull.Value) rs1.txn_date = (DateTime)dal["txn_date"];
				if (dal["Description"] != DBNull.Value) rs1.Description = (String)dal["Description"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_user_payments_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  8  </summary>
	public Int64 user_id{get;set;}

	///<summary>  50  </summary>
	public String txn_type{get;set;}

	///<summary>  50  </summary>
	public String txn_id{get;set;}

	///<summary>  8  </summary>
	public DateTime? effective_date{get;set;}

	///<summary>  50  </summary>
	public String subscr_id{get;set;}

	///<summary>  50  </summary>
	public String payer_email{get;set;}

	///<summary>  8  </summary>
	public Double? Amount{get;set;}

	///<summary>  8  </summary>
	public DateTime? txn_date{get;set;}

	///<summary>  -1  </summary>
	public String Description{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_user_payments_ups() {

		db = new DB("usp_user_payments_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		db.NewParameter("user_id", SqlDbType.BigInt, 8, user_id, false); 
		if (txn_type == null)  db.NewParameter("txn_type", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("txn_type", SqlDbType.VarChar, 50,Encode(txn_type), false); 
		if (txn_id == null)  db.NewParameter("txn_id", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("txn_id", SqlDbType.VarChar, 50,Encode(txn_id), false); 
		if (!effective_date.HasValue)  db.NewParameter("effective_date", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("effective_date", SqlDbType.DateTime, 8, effective_date, false); 
		if (subscr_id == null)  db.NewParameter("subscr_id", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("subscr_id", SqlDbType.VarChar, 50,Encode(subscr_id), false); 
		if (payer_email == null)  db.NewParameter("payer_email", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("payer_email", SqlDbType.VarChar, 50,Encode(payer_email), false); 
		if (!Amount.HasValue)  db.NewParameter("Amount", SqlDbType.Float, 8, DBNull.Value, false); else  db.NewParameter("Amount", SqlDbType.Float, 8, Amount, false); 
		if (!txn_date.HasValue)  db.NewParameter("txn_date", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("txn_date", SqlDbType.DateTime, 8, txn_date, false); 
		if (Description == null)  db.NewParameter("Description", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("Description", SqlDbType.VarChar, -1,Encode(Description), false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["user_id"].Value != DBNull.Value) user_id = (Int64)base.db.cmd.Parameters["user_id"].Value;
		if (base.db.cmd.Parameters["txn_type"].Value != DBNull.Value) txn_type = (String)base.db.cmd.Parameters["txn_type"].Value;
		if (base.db.cmd.Parameters["txn_id"].Value != DBNull.Value) txn_id = (String)base.db.cmd.Parameters["txn_id"].Value;
		if (base.db.cmd.Parameters["effective_date"].Value != DBNull.Value) effective_date = (DateTime)base.db.cmd.Parameters["effective_date"].Value;
		if (base.db.cmd.Parameters["subscr_id"].Value != DBNull.Value) subscr_id = (String)base.db.cmd.Parameters["subscr_id"].Value;
		if (base.db.cmd.Parameters["payer_email"].Value != DBNull.Value) payer_email = (String)base.db.cmd.Parameters["payer_email"].Value;
		if (base.db.cmd.Parameters["Amount"].Value != DBNull.Value) Amount = (Double)base.db.cmd.Parameters["Amount"].Value;
		if (base.db.cmd.Parameters["txn_date"].Value != DBNull.Value) txn_date = (DateTime)base.db.cmd.Parameters["txn_date"].Value;
		if (base.db.cmd.Parameters["Description"].Value != DBNull.Value) Description = (String)base.db.cmd.Parameters["Description"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 

public partial class usp_user_sel  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}


	public usp_user_sel() {

		db = new DB("usp_user_sel");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public String name {get;set;}
		public String email {get;set;}
		public String password {get;set;}
		public String ip {get;set;}
		public DateTime? last_authentication {get;set;}
		public Boolean? confirmed {get;set;}

		public static ResultSet1[] Init(usp_user_sel dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["email"] != DBNull.Value) rs1.email = (String)dal["email"];
				if (dal["password"] != DBNull.Value) rs1.password = (String)dal["password"];
				if (dal["ip"] != DBNull.Value) rs1.ip = (String)dal["ip"];
				if (dal["last_authentication"] != DBNull.Value) rs1.last_authentication = (DateTime)dal["last_authentication"];
				if (dal["confirmed"] != DBNull.Value) rs1.confirmed = (Boolean)dal["confirmed"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_user_sel_by_email  : SharpFusion.DAL  
{

	///<summary>  50  </summary>
	public String email{get;set;}


	public usp_user_sel_by_email() {

		db = new DB("usp_user_sel_by_email");
	}

	private void preExecute() {
		if (email == null)  db.NewParameter("email", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("email", SqlDbType.VarChar, 50,Encode(email), false); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["email"].Value != DBNull.Value) email = (String)base.db.cmd.Parameters["email"].Value;
	}

	public class ResultSet1 
	{
		public Int64 id {get;set;}
		public DateTime? created_dt {get;set;}
		public DateTime? updated_dt {get;set;}
		public DateTime? deleted_dt {get;set;}
		public Byte? is_deleted {get;set;}
		public String name {get;set;}
		public String email {get;set;}
		public String password {get;set;}
		public String ip {get;set;}
		public DateTime? last_authentication {get;set;}
		public Boolean? confirmed {get;set;}

		public static ResultSet1[] Init(usp_user_sel_by_email dal, Validate val) 
		{
			List<ResultSet1> rs1s = new List<ResultSet1>();
			while (dal.Read(val))
			{
				ResultSet1 rs1 = new ResultSet1();
				if (dal["id"] != DBNull.Value) rs1.id = (Int64)dal["id"];
				if (dal["created_dt"] != DBNull.Value) rs1.created_dt = (DateTime)dal["created_dt"];
				if (dal["updated_dt"] != DBNull.Value) rs1.updated_dt = (DateTime)dal["updated_dt"];
				if (dal["deleted_dt"] != DBNull.Value) rs1.deleted_dt = (DateTime)dal["deleted_dt"];
				if (dal["is_deleted"] != DBNull.Value) rs1.is_deleted = (Byte)dal["is_deleted"];
				if (dal["name"] != DBNull.Value) rs1.name = (String)dal["name"];
				if (dal["email"] != DBNull.Value) rs1.email = (String)dal["email"];
				if (dal["password"] != DBNull.Value) rs1.password = (String)dal["password"];
				if (dal["ip"] != DBNull.Value) rs1.ip = (String)dal["ip"];
				if (dal["last_authentication"] != DBNull.Value) rs1.last_authentication = (DateTime)dal["last_authentication"];
				if (dal["confirmed"] != DBNull.Value) rs1.confirmed = (Boolean)dal["confirmed"];
					rs1s.Add(rs1);;
			}
			return rs1s.ToArray();
		}
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
            RS1 = ResultSet1.Init(this, val);
			 

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
RS1 = new ResultSet1 [] {};
			 
        }
        return flag;
    }public ResultSet1[] RS1 { get; set; }
} 

public partial class usp_user_ups  : SharpFusion.DAL  
{

	///<summary>  8  </summary>
	public Int64 id{get;set;}

	///<summary>  8  </summary>
	public DateTime? created_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? updated_dt{get;set;}

	///<summary>  8  </summary>
	public DateTime? deleted_dt{get;set;}

	///<summary>  1  </summary>
	public Byte? is_deleted{get;set;}

	///<summary>  50  </summary>
	public String name{get;set;}

	///<summary>  50  </summary>
	public String email{get;set;}

	///<summary>  -1  </summary>
	public String password{get;set;}

	///<summary>  50  </summary>
	public String ip{get;set;}

	///<summary>  8  </summary>
	public DateTime? last_authentication{get;set;}

	///<summary>  1  </summary>
	public Boolean? confirmed{get;set;}

	///<summary>  8 output </summary>
	public Int64? InsertedID{get;set;}


	public usp_user_ups() {

		db = new DB("usp_user_ups");
	}

	private void preExecute() {
		db.NewParameter("id", SqlDbType.BigInt, 8, id, false); 
		if (!created_dt.HasValue)  db.NewParameter("created_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("created_dt", SqlDbType.DateTime, 8, created_dt, false); 
		if (!updated_dt.HasValue)  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("updated_dt", SqlDbType.DateTime, 8, updated_dt, false); 
		if (!deleted_dt.HasValue)  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("deleted_dt", SqlDbType.DateTime, 8, deleted_dt, false); 
		if (!is_deleted.HasValue)  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, DBNull.Value, false); else  db.NewParameter("is_deleted", SqlDbType.TinyInt, 1, is_deleted, false); 
		if (name == null)  db.NewParameter("name", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("name", SqlDbType.VarChar, 50,Encode(name), false); 
		if (email == null)  db.NewParameter("email", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("email", SqlDbType.VarChar, 50,Encode(email), false); 
		if (password == null)  db.NewParameter("password", SqlDbType.VarChar, -1, DBNull.Value, false); else  db.NewParameter("password", SqlDbType.VarChar, -1,Encode(password), false); 
		if (ip == null)  db.NewParameter("ip", SqlDbType.VarChar, 50, DBNull.Value, false); else  db.NewParameter("ip", SqlDbType.VarChar, 50,Encode(ip), false); 
		if (!last_authentication.HasValue)  db.NewParameter("last_authentication", SqlDbType.DateTime, 8, DBNull.Value, false); else  db.NewParameter("last_authentication", SqlDbType.DateTime, 8, last_authentication, false); 
		if (!confirmed.HasValue)  db.NewParameter("confirmed", SqlDbType.Bit, 1, DBNull.Value, false); else  db.NewParameter("confirmed", SqlDbType.Bit, 1, confirmed, false); 
		if (!InsertedID.HasValue)  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, DBNull.Value, true); else  db.NewParameter("InsertedID", SqlDbType.BigInt, 8, InsertedID, true); 
	}

	private void postExecute() {
		if (base.db.cmd.Parameters["id"].Value != DBNull.Value) id = (Int64)base.db.cmd.Parameters["id"].Value;
		if (base.db.cmd.Parameters["created_dt"].Value != DBNull.Value) created_dt = (DateTime)base.db.cmd.Parameters["created_dt"].Value;
		if (base.db.cmd.Parameters["updated_dt"].Value != DBNull.Value) updated_dt = (DateTime)base.db.cmd.Parameters["updated_dt"].Value;
		if (base.db.cmd.Parameters["deleted_dt"].Value != DBNull.Value) deleted_dt = (DateTime)base.db.cmd.Parameters["deleted_dt"].Value;
		if (base.db.cmd.Parameters["is_deleted"].Value != DBNull.Value) is_deleted = (Byte)base.db.cmd.Parameters["is_deleted"].Value;
		if (base.db.cmd.Parameters["name"].Value != DBNull.Value) name = (String)base.db.cmd.Parameters["name"].Value;
		if (base.db.cmd.Parameters["email"].Value != DBNull.Value) email = (String)base.db.cmd.Parameters["email"].Value;
		if (base.db.cmd.Parameters["password"].Value != DBNull.Value) password = (String)base.db.cmd.Parameters["password"].Value;
		if (base.db.cmd.Parameters["ip"].Value != DBNull.Value) ip = (String)base.db.cmd.Parameters["ip"].Value;
		if (base.db.cmd.Parameters["last_authentication"].Value != DBNull.Value) last_authentication = (DateTime)base.db.cmd.Parameters["last_authentication"].Value;
		if (base.db.cmd.Parameters["confirmed"].Value != DBNull.Value) confirmed = (Boolean)base.db.cmd.Parameters["confirmed"].Value;
		if (base.db.cmd.Parameters["InsertedID"].Value != DBNull.Value) InsertedID = (Int64)base.db.cmd.Parameters["InsertedID"].Value;
	}

    public new Boolean Execute(Validate val)
    {
        preExecute();
        bool flag = base.Execute(val);
        if (flag)
        {
            //build all result sets
             

            postExecute();
            if (base.db.cmd.Parameters["RetVal"].Value != DBNull.Value) Return = (int)base.db.cmd.Parameters["RetVal"].Value;

        }
        else
        {
            //just instantiate empty result sets 
 
        }
        return flag;
    }
} 
}