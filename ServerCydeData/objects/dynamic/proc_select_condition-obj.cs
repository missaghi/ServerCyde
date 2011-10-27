using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Proc_Select_Condition  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 proc_select_id { get; set; }
		public String attribute_name { get; set; }
		public String comparison_operator { get; set; }
		public String or_and_intersect { get; set; }
		public Boolean? use_every { get; set; }
		public String param_name { get; set; }
		public String param_name_2 { get; set; }
		public String constant_value { get; set; }
		public String constant_value_2 { get; set; }
        
        //Parents          
        public Proc_Select parent_proc_select_proc_select_id { get { if (_parent_proc_select_proc_select_id == null || _parent_proc_select_proc_select_id.id == 0) _parent_proc_select_proc_select_id = new Proc_Select(proc_select_id, val); return _parent_proc_select_proc_select_id; } set { _parent_proc_select_proc_select_id = value; } }
        private Proc_Select _parent_proc_select_proc_select_id { get; set; }
        
        //Children 

        //default
        public Proc_Select_Condition(Validate val)
        {
            this.val = val;
        }

        //select one
        public Proc_Select_Condition(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_proc_select_condition_sel dal = new DAL.Procs.usp_proc_select_condition_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_proc_select_condition_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.proc_select_id = rs1.proc_select_id;
					this.attribute_name = rs1.attribute_name;
					this.comparison_operator = rs1.comparison_operator;
					this.or_and_intersect = rs1.or_and_intersect;
					if (rs1.use_every.HasValue) this.use_every = rs1.use_every.Value;;
					this.param_name = rs1.param_name;
					this.param_name_2 = rs1.param_name_2;
					this.constant_value = rs1.constant_value;
					this.constant_value_2 = rs1.constant_value_2;
                }
            }
        }

#region Lists        
        //get Proc_Select_Conditions by Proc_Select proc_select_id
        public static IList<Proc_Select_Condition> GetProc_Select_ConditionsByProc_Select_proc_select_id(Int64 proc_select_id, Validate val)
        {

            List<Proc_Select_Condition> _Proc_Select_Conditions = new List<Proc_Select_Condition>();
            using (DAL.Procs.usp_proc_select_condition_sel_by_proc_select_id dal = new DAL.Procs.usp_proc_select_condition_sel_by_proc_select_id())
            {
                dal.proc_select_id = proc_select_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_proc_select_condition_sel_by_proc_select_id.ResultSet1 rs1 in dal.RS1)
                {
                    Proc_Select_Condition _Proc_Select_Condition = new Proc_Select_Condition(val);
                    
					_Proc_Select_Condition.id = rs1.id;
					if (rs1.created_dt.HasValue) _Proc_Select_Condition.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Proc_Select_Condition.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Proc_Select_Condition.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Proc_Select_Condition.is_deleted = rs1.is_deleted.Value;
					_Proc_Select_Condition.proc_select_id = rs1.proc_select_id;
					_Proc_Select_Condition.attribute_name = rs1.attribute_name;
					_Proc_Select_Condition.comparison_operator = rs1.comparison_operator;
					_Proc_Select_Condition.or_and_intersect = rs1.or_and_intersect;
					if (rs1.use_every.HasValue) _Proc_Select_Condition.use_every = rs1.use_every.Value;
					_Proc_Select_Condition.param_name = rs1.param_name;
					_Proc_Select_Condition.param_name_2 = rs1.param_name_2;
					_Proc_Select_Condition.constant_value = rs1.constant_value;
					_Proc_Select_Condition.constant_value_2 = rs1.constant_value_2;
                    _Proc_Select_Conditions.Add(_Proc_Select_Condition);
                }

            }
            return _Proc_Select_Conditions;
        }   
#endregion

        public Proc_Select_Condition UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_proc_select_condition_ups dal = new DAL.Procs.usp_proc_select_condition_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.proc_select_id = this.proc_select_id;
					dal.attribute_name = this.attribute_name;
					dal.comparison_operator = this.comparison_operator;
					dal.or_and_intersect = this.or_and_intersect;
					dal.use_every = this.use_every;
					dal.param_name = this.param_name;
					dal.param_name_2 = this.param_name_2;
					dal.constant_value = this.constant_value;
					dal.constant_value_2 = this.constant_value_2;
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

            using (DAL.Procs.usp_proc_select_condition_del dal = new DAL.Procs.usp_proc_select_condition_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}