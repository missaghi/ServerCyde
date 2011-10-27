using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class User_Payments  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 user_id { get; set; }
		public String txn_type { get; set; }
		public String txn_id { get; set; }
		public DateTime? effective_date { get; set; }
		public String subscr_id { get; set; }
		public String payer_email { get; set; }
		public Double? Amount { get; set; }
		public DateTime? txn_date { get; set; }
		public String Description { get; set; }
        
        //Parents          
        public User parent_user_user_id { get { if (_parent_user_user_id == null || _parent_user_user_id.id == 0) _parent_user_user_id = new User(user_id, val); return _parent_user_user_id; } set { _parent_user_user_id = value; } }
        private User _parent_user_user_id { get; set; }
        
        //Children 

        //default
        public User_Payments(Validate val)
        {
            this.val = val;
        }

        //select one
        public User_Payments(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_user_payments_sel dal = new DAL.Procs.usp_user_payments_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_user_payments_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.user_id = rs1.user_id;
					this.txn_type = rs1.txn_type;
					this.txn_id = rs1.txn_id;
					if (rs1.effective_date.HasValue) this.effective_date = rs1.effective_date.Value;;
					this.subscr_id = rs1.subscr_id;
					this.payer_email = rs1.payer_email;
					if (rs1.Amount.HasValue) this.Amount = rs1.Amount.Value;;
					if (rs1.txn_date.HasValue) this.txn_date = rs1.txn_date.Value;;
					this.Description = rs1.Description;
                }
            }
        }

#region Lists        
        //get User_Paymentss by User user_id
        public static IList<User_Payments> GetUser_PaymentssByUser_user_id(Int64 user_id, Validate val)
        {

            List<User_Payments> _User_Paymentss = new List<User_Payments>();
            using (DAL.Procs.usp_user_payments_sel_by_user_id dal = new DAL.Procs.usp_user_payments_sel_by_user_id())
            {
                dal.user_id = user_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_user_payments_sel_by_user_id.ResultSet1 rs1 in dal.RS1)
                {
                    User_Payments _User_Payments = new User_Payments(val);
                    
					_User_Payments.id = rs1.id;
					if (rs1.created_dt.HasValue) _User_Payments.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _User_Payments.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _User_Payments.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _User_Payments.is_deleted = rs1.is_deleted.Value;
					_User_Payments.user_id = rs1.user_id;
					_User_Payments.txn_type = rs1.txn_type;
					_User_Payments.txn_id = rs1.txn_id;
					if (rs1.effective_date.HasValue) _User_Payments.effective_date = rs1.effective_date.Value;
					_User_Payments.subscr_id = rs1.subscr_id;
					_User_Payments.payer_email = rs1.payer_email;
					if (rs1.Amount.HasValue) _User_Payments.Amount = rs1.Amount.Value;
					if (rs1.txn_date.HasValue) _User_Payments.txn_date = rs1.txn_date.Value;
					_User_Payments.Description = rs1.Description;
                    _User_Paymentss.Add(_User_Payments);
                }

            }
            return _User_Paymentss;
        }   
#endregion

        public User_Payments UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_user_payments_ups dal = new DAL.Procs.usp_user_payments_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.user_id = this.user_id;
					dal.txn_type = this.txn_type;
					dal.txn_id = this.txn_id;
					dal.effective_date = this.effective_date;
					dal.subscr_id = this.subscr_id;
					dal.payer_email = this.payer_email;
					dal.Amount = this.Amount;
					dal.txn_date = this.txn_date;
					dal.Description = this.Description;
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

            using (DAL.Procs.usp_user_payments_del dal = new DAL.Procs.usp_user_payments_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}