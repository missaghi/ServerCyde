using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Person_Payments  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 person_id { get; set; }
		public Double? Amount { get; set; }
		public DateTime? Cleared { get; set; }
		public String Description { get; set; }
        
        //Parents          
        public Person parent_person_person_id { get { if (_parent_person_person_id == null || _parent_person_person_id.id == 0) _parent_person_person_id = new Person(person_id, val); return _parent_person_person_id; } set { _parent_person_person_id = value; } }
        private Person _parent_person_person_id { get; set; }
        
        //Children 

        //default
        public Person_Payments(Validate val)
        {
            this.val = val;
        }

        //select one
        public Person_Payments(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_person_payments_sel dal = new DAL.Procs.usp_person_payments_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_person_payments_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.person_id = rs1.person_id;
					if (rs1.Amount.HasValue) this.Amount = rs1.Amount.Value;;
					if (rs1.Cleared.HasValue) this.Cleared = rs1.Cleared.Value;;
					this.Description = rs1.Description;
                }
            }
        }

#region Lists        
        //get Person_Paymentss by Person person_id
        public static IList<Person_Payments> GetPerson_PaymentssByPerson_person_id(Int64 person_id, Validate val)
        {

            List<Person_Payments> _Person_Paymentss = new List<Person_Payments>();
            using (DAL.Procs.usp_person_payments_sel_by_person_id dal = new DAL.Procs.usp_person_payments_sel_by_person_id())
            {
                dal.person_id = person_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_person_payments_sel_by_person_id.ResultSet1 rs1 in dal.RS1)
                {
                    Person_Payments _Person_Payments = new Person_Payments(val);
                    
					_Person_Payments.id = rs1.id;
					if (rs1.created_dt.HasValue) _Person_Payments.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Person_Payments.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Person_Payments.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Person_Payments.is_deleted = rs1.is_deleted.Value;
					_Person_Payments.person_id = rs1.person_id;
					if (rs1.Amount.HasValue) _Person_Payments.Amount = rs1.Amount.Value;
					if (rs1.Cleared.HasValue) _Person_Payments.Cleared = rs1.Cleared.Value;
					_Person_Payments.Description = rs1.Description;
                    _Person_Paymentss.Add(_Person_Payments);
                }

            }
            return _Person_Paymentss;
        }   
#endregion

        public Person_Payments UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_person_payments_ups dal = new DAL.Procs.usp_person_payments_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.person_id = this.person_id;
					dal.Amount = this.Amount;
					dal.Cleared = this.Cleared;
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

            using (DAL.Procs.usp_person_payments_del dal = new DAL.Procs.usp_person_payments_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}