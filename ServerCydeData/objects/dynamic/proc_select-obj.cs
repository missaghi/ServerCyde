using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Proc_Select  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 site_id { get; set; }
		public String name { get; set; }
		public Int32? limit { get; set; }
		public String sort_by { get; set; }
		public String sort_order { get; set; }
		public Boolean? consistent_read { get; set; }
		public String domain_name { get; set; }
		public Int64? requests { get; set; }
        
        //Parents          
        public Site parent_site_site_id { get { if (_parent_site_site_id == null || _parent_site_site_id.id == 0) _parent_site_site_id = new Site(site_id, val); return _parent_site_site_id; } set { _parent_site_site_id = value; } }
        private Site _parent_site_site_id { get; set; }
        
        //Children          
        public IList<Proc_Select_Condition> get_children_proc_select_condition_proc_select_ids { get { if (_proc_select_condition_proc_select_ids == null || _proc_select_condition_proc_select_ids.Count == 0) _proc_select_condition_proc_select_ids = Proc_Select_Condition.GetProc_Select_ConditionsByProc_Select_proc_select_id(id ,val); return _proc_select_condition_proc_select_ids; } set { _proc_select_condition_proc_select_ids = value; } }
        private IList<Proc_Select_Condition> _proc_select_condition_proc_select_ids ;         
        public IList<Proc_Select_Field> get_children_proc_select_field_proc_select_ids { get { if (_proc_select_field_proc_select_ids == null || _proc_select_field_proc_select_ids.Count == 0) _proc_select_field_proc_select_ids = Proc_Select_Field.GetProc_Select_FieldsByProc_Select_proc_select_id(id ,val); return _proc_select_field_proc_select_ids; } set { _proc_select_field_proc_select_ids = value; } }
        private IList<Proc_Select_Field> _proc_select_field_proc_select_ids ;

        //default
        public Proc_Select(Validate val)
        {
            this.val = val;
        }

        //select one
        public Proc_Select(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_proc_select_sel dal = new DAL.Procs.usp_proc_select_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_proc_select_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.site_id = rs1.site_id;
					this.name = rs1.name;
					if (rs1.limit.HasValue) this.limit = rs1.limit.Value;;
					this.sort_by = rs1.sort_by;
					this.sort_order = rs1.sort_order;
					if (rs1.consistent_read.HasValue) this.consistent_read = rs1.consistent_read.Value;;
					this.domain_name = rs1.domain_name;
					if (rs1.requests.HasValue) this.requests = rs1.requests.Value;;
                }
            }
        }

#region Lists        
        //get Proc_Selects by  name
        public static IList<Proc_Select> GetProc_SelectsBy_name(String name, Validate val)
        {

            List<Proc_Select> _Proc_Selects = new List<Proc_Select>();
            using (DAL.Procs.usp_proc_select_sel_by_name dal = new DAL.Procs.usp_proc_select_sel_by_name())
            {
                dal.name = name; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_proc_select_sel_by_name.ResultSet1 rs1 in dal.RS1)
                {
                    Proc_Select _Proc_Select = new Proc_Select(val);
                    
                    _Proc_Selects.Add(_Proc_Select);
                }

            }
            return _Proc_Selects;
        }           //get Proc_Selects by Site site_id
        public static IList<Proc_Select> GetProc_SelectsBySite_site_id(Int64 site_id, Validate val)
        {

            List<Proc_Select> _Proc_Selects = new List<Proc_Select>();
            using (DAL.Procs.usp_proc_select_sel_by_site_id dal = new DAL.Procs.usp_proc_select_sel_by_site_id())
            {
                dal.site_id = site_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_proc_select_sel_by_site_id.ResultSet1 rs1 in dal.RS1)
                {
                    Proc_Select _Proc_Select = new Proc_Select(val);
                    
					_Proc_Select.id = rs1.id;
					if (rs1.created_dt.HasValue) _Proc_Select.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Proc_Select.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Proc_Select.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Proc_Select.is_deleted = rs1.is_deleted.Value;
					_Proc_Select.site_id = rs1.site_id;
					_Proc_Select.name = rs1.name;
					if (rs1.limit.HasValue) _Proc_Select.limit = rs1.limit.Value;
					_Proc_Select.sort_by = rs1.sort_by;
					_Proc_Select.sort_order = rs1.sort_order;
					if (rs1.consistent_read.HasValue) _Proc_Select.consistent_read = rs1.consistent_read.Value;
					_Proc_Select.domain_name = rs1.domain_name;
					if (rs1.requests.HasValue) _Proc_Select.requests = rs1.requests.Value;
                    _Proc_Selects.Add(_Proc_Select);
                }

            }
            return _Proc_Selects;
        }   
#endregion

        public Proc_Select UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_proc_select_ups dal = new DAL.Procs.usp_proc_select_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.site_id = this.site_id;
					dal.name = this.name;
					dal.limit = this.limit;
					dal.domain_name = this.domain_name;
					dal.sort_by = this.sort_by;
					dal.sort_order = this.sort_order;
					dal.consistent_read = this.consistent_read;
					dal.requests = this.requests;
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

            using (DAL.Procs.usp_proc_select_del dal = new DAL.Procs.usp_proc_select_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}