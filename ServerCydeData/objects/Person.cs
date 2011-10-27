using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Runtime.Serialization;
using SharpFusion;



namespace ServerCydeData
{    
    [DataContract]
    public partial class Person  
    {
        [DataMember]
        public String Name { get { return this.name; }  set { } }
        [DataMember]
        public long ID { get { return id; } set { } }
        public String PublicID { get { return EncryptUserID(this.id); }  set { } }
        [DataMember]
        public Boolean IsAuthenticated { get { return (this.last_authentication ?? DateTime.Now.AddYears(-1)).AddHours(23) > DateTime.Now; }  set { } }
        public String Password { get { return new SimpleAES().DecryptString(this.password); } set { this.password = new SimpleAES().EncryptToString(value); } }

        [DataMember]
        public Boolean isConfirmed { get { return this.confirmed ?? false; } set { } }

        [DataMember]
        public int FlaggedCount { get { return (FlaggedBy ?? new HashSet<String>()).Count; } set { } }

        public HashSet<string> FlaggedBy { get; set; }
        
        //public Comet.AsyncRequestState CometState { get; set; }

        public static string EncryptUserID(long id)
        {
            return new SimpleAES().EncryptToString(DateTime.Now.Ticks + "-" + id);
        }
        public static long DecryptUserID(string id)
        {
            string token = new SimpleAES().DecryptString(id);
            string[] tokens = token.Split("-");
            return (tokens.Length > 1 ? tokens[1] : "").ToLong(0);
        }

        private string CreateConfirmationToken()
        {
            return PublicID;
        }
        public static long DecryptConfirmationToken(string id)
        {
            return DecryptUserID(id);
        }

        public void SendConfirmationEmail(Site site)
        {
            Email msg = site.SiteEmail(); ;
            msg.To.Add(new MailAddress(this.email, this.Name));
            msg.From = new MailAddress(site.supportemail, site.supportemailname);
            msg.Body = string.Format(@"Hello {0},

In order to use your account you must confirm the email address.

Activate your account by clicking this link:
http://api.servercyde.com/confirm/{3}/?token={1}

If you have any questions please reply to this email.

Thanks,
The {2} Team", this.Name, this.CreateConfirmationToken(), site.name, site.id);
            msg.Subject = "Please confirm your "+site.name+" account";
            msg.IsBodyHtml = false;
            msg.Send(val);
        }

        public static long GetUserID(string email, long siteid, Validate val)
        {
            long userid = 0;
            using (DAL.Procs.usp_person_sel_sign_in dal = new DAL.Procs.usp_person_sel_sign_in())
            {
                dal.email = email;
                dal.SiteID = siteid;
                dal.Execute(val);
                if (dal.RS1.Length > 0)
                    userid = dal.RS1[0].id;
            }
            return userid;
        }

        public static Person GetUser(HttpContext context, long siteid, Validate val)
        {
            bool has_session = context.Request.Cookies["Identity" + siteid] != null;
           
            string cookie = has_session ? context.Request.Cookies["Identity" + siteid].Value : null;

            Person user = (Person)(cookie == null ? new Person(val) : (HttpRuntime.Cache[cookie] ?? new Person(DecryptUserID(cookie), val)));  
             
            if (user.id != 0)
            {
                if (HttpRuntime.Cache[user.PublicID] == null)
                {
                    user.postUpsertEvents +=new postUpsert(delegate(Validate validate) {
                        if (HttpRuntime.Cache[user.PublicID] != null)
                            HttpRuntime.Cache.Remove(user.PublicID);

                        HttpRuntime.Cache.Add(user.PublicID, user, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0, 0), System.Web.Caching.CacheItemPriority.BelowNormal, null);
                    });
                    user.postUpsertEvent(val);
                }

                //update DB if session is getting old but still valid
                if (((user.last_authentication ?? DateTime.MinValue).AddHours(12) < DateTime.Now || cookie == null) && (user.last_authentication ?? DateTime.MinValue).AddHours(24) > DateTime.Now)
                {
                    user.NewSession(context);
                }  
            }
            else user.AuthorizedLevel = AuthLevel.Read;
 
            return user;
        }

        public void NewSession(HttpContext context, bool rememberme)
        {
            HttpCookie cookie = new HttpCookie("Identity" + this.site_id, this.PublicID);
            cookie.Expires = DateTime.Now.AddDays(rememberme ? 365 : 24);
            context.Response.Cookies.Add(cookie);
            cookie = new HttpCookie("RememberMe", "true");
            cookie.Expires = DateTime.Now.AddDays(rememberme ? 365 : 24);
            context.Response.Cookies.Add(cookie);
            this.last_authentication = DateTime.Now.AddDays(rememberme ? 365 : 0);
            this.UpSert(this);
        }

        public void NewSession(HttpContext context)
        {
            bool rememberme = (context.Request.Cookies["RememberMe"] ?? new HttpCookie("rm", "false")).Value.ToBool();
            NewSession(context, rememberme);
        }

        public void SignOut(HttpContext context)
        {
            this.last_authentication = DateTime.Now.AddDays(-366);
            this.UpSert(this);

            HttpCookie cookie = new HttpCookie("Identity" + this.site_id, this.PublicID);
            cookie.Expires = DateTime.Now.AddDays(-1D);
            context.Response.Cookies.Add(cookie);
        }
         
    }
}
