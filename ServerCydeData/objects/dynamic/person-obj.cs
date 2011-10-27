using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Person  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 site_id { get; set; }
		public String name { get; set; }
		public String email { get; set; }
		public String password { get; set; }
		public String ip { get; set; }
		public DateTime? last_authentication { get; set; }
		public Boolean? confirmed { get; set; }
        
        //Parents          
        public Site parent_site_site_id { get { if (_parent_site_site_id == null || _parent_site_site_id.id == 0) _parent_site_site_id = new Site(site_id, val); return _parent_site_site_id; } set { _parent_site_site_id = value; } }
        private Site _parent_site_site_id { get; set; }
        
        //Children          
        public IList<Person_Oauth> get_children_person_oauth_person_ids { get { if (_person_oauth_person_ids == null || _person_oauth_person_ids.Count == 0) _person_oauth_person_ids = Person_Oauth.GetPerson_OauthsByPerson_person_id(id ,val); return _person_oauth_person_ids; } set { _person_oauth_person_ids = value; } }
        private IList<Person_Oauth> _person_oauth_person_ids ;         
        public IList<Person_Payments> get_children_person_payments_person_ids { get { if (_person_payments_person_ids == null || _person_payments_person_ids.Count == 0) _person_payments_person_ids = Person_Payments.GetPerson_PaymentssByPerson_person_id(id ,val); return _person_payments_person_ids; } set { _person_payments_person_ids = value; } }
        private IList<Person_Payments> _person_payments_person_ids ;

        //default
        public Person(Validate val)
        {
            this.val = val;
        }

        //select one
        public Person(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_person_sel dal = new DAL.Procs.usp_person_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_person_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.site_id = rs1.site_id;
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
        //get Persons by Site site_id
        public static IList<Person> GetPersonsBySite_site_id(Int64 site_id, Validate val)
        {

            List<Person> _Persons = new List<Person>();
            using (DAL.Procs.usp_person_sel_by_site_id dal = new DAL.Procs.usp_person_sel_by_site_id())
            {
                dal.site_id = site_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_person_sel_by_site_id.ResultSet1 rs1 in dal.RS1)
                {
                    Person _Person = new Person(val);
                    
					_Person.id = rs1.id;
					if (rs1.created_dt.HasValue) _Person.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Person.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Person.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Person.is_deleted = rs1.is_deleted.Value;
					_Person.site_id = rs1.site_id;
					_Person.name = rs1.name;
					_Person.email = rs1.email;
					_Person.password = rs1.password;
					_Person.ip = rs1.ip;
					if (rs1.last_authentication.HasValue) _Person.last_authentication = rs1.last_authentication.Value;
					if (rs1.confirmed.HasValue) _Person.confirmed = rs1.confirmed.Value;
                    _Persons.Add(_Person);
                }

            }
            return _Persons;
        }   
#endregion

        public Person UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_person_ups dal = new DAL.Procs.usp_person_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.site_id = this.site_id;
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

            using (DAL.Procs.usp_person_del dal = new DAL.Procs.usp_person_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}