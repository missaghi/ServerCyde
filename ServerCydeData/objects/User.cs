using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Runtime.Serialization; 
using SharpFusion;
using ServerCyde;

namespace ServerCydeData
{    
    public partial class User  
    { 

        [DataMember]
        public String Name { get { return this.name; } }
        [DataMember]
        public Boolean IsAuthenticated { get { return (this.last_authentication ?? DateTime.Now.AddYears(-1)).AddHours(23) > DateTime.Now; } }
        [DataMember]
        public String PublicID { get { return EncryptUserID(this.id); } }
        public Comet.AsyncRequestState CometState { get; set; }

        public String Password { get { return new SimpleAES().DecryptString(this.password); } set { this.password = new SimpleAES().EncryptToString(value); } }

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

        public void SendConfirmationEmail()
        {
            Email msg = new Email();
            msg.To.Add(new MailAddress(this.email, this.Name));
            msg.From = new MailAddress("support@servercyde.com", "ServerCyde.com Team");
            msg.Body = string.Format(@"Hello {0},

In order to use your account you must confirm the email address.

Activate your account by clicking this link:
http://servercyde.com/confirm/?token={1}

If you have any questions please reply to this email.

Thanks,
The ServerCyde Minions: Riaz and Amir
support@servercyde.com", this.Name, this.CreateConfirmationToken());
            msg.Subject = "Please confirm your account";
            msg.IsBodyHtml = false;
            msg.Send(val);
        }


        public static long GetUserID(string email, Validate val)
        {
            long userid = 0;
            using (DAL.Procs.usp_user_sel_by_email dal = new DAL.Procs.usp_user_sel_by_email())
            {
                dal.email = email;
                dal.Execute(val);
                if (dal.RS1.Length > 0)
                    userid = dal.RS1[0].id;
            }
            return userid;
        }


        public static User GetUser(HttpContext context, Validate val)
        {
            bool has_session = context.Request.Cookies["Identity"] != null;

            string cookie = has_session ? context.Request.Cookies["Identity"].Value : null;

            User user = (User)(cookie == null ? new User(val) : (HttpRuntime.Cache[cookie] ?? new User(DecryptUserID(cookie), val)));

            if (user.id != 0)
            {
                if (HttpRuntime.Cache[user.PublicID] == null)
                    HttpRuntime.Cache.Add(user.PublicID, user, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0, 0), System.Web.Caching.CacheItemPriority.BelowNormal, null);

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
            HttpCookie cookie = new HttpCookie("Identity", this.PublicID);
            cookie.Expires = DateTime.Now.AddDays(rememberme ? 365 : 1);
            context.Response.Cookies.Add(cookie);
            cookie = new HttpCookie("RememberMe", "true");
            cookie.Expires = DateTime.Now.AddDays(rememberme ? 365 : 1);
            context.Response.Cookies.Add(cookie);
            this.last_authentication = DateTime.Now.AddDays(rememberme ? 365 : 0);
            this.UpSert(this);
        }

        public void NewSession(HttpContext context)
        {
            bool rememberme = (context.Request.Cookies["RememberMe"] ?? new HttpCookie("null", "false")).Value.ToBool();
            NewSession(context, rememberme);
        }

        public void SignOut(HttpContext context)
        {
            this.last_authentication = DateTime.Now.AddDays(-366);
            this.UpSert(this);

            HttpCookie cookie = new HttpCookie("Identity", this.PublicID);
            cookie.Expires = DateTime.Now.AddDays(-1D);
            context.Response.Cookies.Add(cookie);
        }
    }
}
