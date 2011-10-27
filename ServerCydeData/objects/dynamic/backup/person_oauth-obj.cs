using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using SharpFusion;

namespace ServerCydeData
{
    public partial class Person_Oauth  : GenObjects
    {

        //Properties 
		public Int64 id { get; set; }
		public DateTime? created_dt { get; set; }
		public DateTime? updated_dt { get; set; }
		public DateTime? deleted_dt { get; set; }
		public Byte? is_deleted { get; set; }
		public Int64 person_id { get; set; }
		public String service_name { get; set; }
		public String token { get; set; }
		public Boolean? authorized { get; set; }
        
        //Parents          
        public Person parent_person_person_id { get { if (_parent_person_person_id == null || _parent_person_person_id.id == 0) _parent_person_person_id = new Person(person_id, val); return _parent_person_person_id; } set { _parent_person_person_id = value; } }
        private Person _parent_person_person_id { get; set; }
        
        //Children 

        //default
        public Person_Oauth(Validate val)
        {
            this.val = val;
        }

        //select one
        public Person_Oauth(long ID, Validate val)
        {
            this.val = val;

            //select
            using (DAL.Procs.usp_person_oauth_sel dal = new DAL.Procs.usp_person_oauth_sel())
            {
                dal.id = ID;
                dal.Execute(val);

                foreach (DAL.Procs.usp_person_oauth_sel.ResultSet1 rs1 in dal.RS1)
                {
                     

					this.id = rs1.id;
					if (rs1.created_dt.HasValue) this.created_dt = rs1.created_dt.Value;;
					if (rs1.updated_dt.HasValue) this.updated_dt = rs1.updated_dt.Value;;
					if (rs1.deleted_dt.HasValue) this.deleted_dt = rs1.deleted_dt.Value;;
					if (rs1.is_deleted.HasValue) this.is_deleted = rs1.is_deleted.Value;;
					this.person_id = rs1.person_id;
					this.service_name = rs1.service_name;
					this.token = rs1.token;
					if (rs1.authorized.HasValue) this.authorized = rs1.authorized.Value;;
                }
            }
        }

#region Lists        
        //get Person_Oauths by Person person_id
        public static IList<Person_Oauth> GetPerson_OauthsByPerson_person_id(Int64 person_id, Validate val)
        {

            List<Person_Oauth> _Person_Oauths = new List<Person_Oauth>();
            using (DAL.Procs.usp_person_oauth_sel_by_person_id dal = new DAL.Procs.usp_person_oauth_sel_by_person_id())
            {
                dal.person_id = person_id; 
                dal.Execute(val);
                foreach (DAL.Procs.usp_person_oauth_sel_by_person_id.ResultSet1 rs1 in dal.RS1)
                {
                    Person_Oauth _Person_Oauth = new Person_Oauth(val);
                    
					_Person_Oauth.id = rs1.id;
					if (rs1.created_dt.HasValue) _Person_Oauth.created_dt = rs1.created_dt.Value;
					if (rs1.updated_dt.HasValue) _Person_Oauth.updated_dt = rs1.updated_dt.Value;
					if (rs1.deleted_dt.HasValue) _Person_Oauth.deleted_dt = rs1.deleted_dt.Value;
					if (rs1.is_deleted.HasValue) _Person_Oauth.is_deleted = rs1.is_deleted.Value;
					_Person_Oauth.person_id = rs1.person_id;
					_Person_Oauth.service_name = rs1.service_name;
					_Person_Oauth.token = rs1.token;
					if (rs1.authorized.HasValue) _Person_Oauth.authorized = rs1.authorized.Value;
                    _Person_Oauths.Add(_Person_Oauth);
                }

            }
            return _Person_Oauths;
        }   
#endregion

        public Person_Oauth UpSert(GenObjects executinguser) 
        {
            val.Test(executinguser.AuthorizedLevel == AuthLevel.Write, "You are not authorized perform this action");

            preUpsertEvent(val);

            using (DAL.Procs.usp_person_oauth_ups dal = new DAL.Procs.usp_person_oauth_ups())
            {

					dal.id = this.id;
					dal.created_dt = this.created_dt;
					dal.updated_dt = this.updated_dt;
					dal.deleted_dt = this.deleted_dt;
					dal.is_deleted = this.is_deleted;
					dal.person_id = this.person_id;
					dal.service_name = this.service_name;
					dal.token = this.token;
					dal.authorized = this.authorized;
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

            using (DAL.Procs.usp_person_oauth_del dal = new DAL.Procs.usp_person_oauth_del())
            {
                dal.id = this.id;
                dal.hard = HardDelete;
                dal.Execute(val);
            }
        }


    }
}