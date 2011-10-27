using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using SharpFusion;
using ServerCydeData;

namespace ServerCydeAPI.API
{

    [HttpHandler("/API/*/Person/GetPersonByID/", Type = HttpHandler.ContentType.JSON, Verb = HttpHandler.HTTPVerb.POST, Parameters = new string[] { "id" })]
    [DataContract]
    public class APIPersonInfo : ServerCydeAPI.APICall
    {
        [DataMember]
        public Person Person { get; set; }

        public APIPersonInfo()
        {
            this.Person = new Person(Form["id"].ToLong(0), val);
            val.Test(this.Person.id > 0, "User not found");
        }
    }

    [HttpHandler("/API/*/Person/GetCurrentPerson/", Type = HttpHandler.ContentType.JSON, Verb = HttpHandler.HTTPVerb.POST)]
    [DataContract]
    public class APICurrentPersonInfo : ServerCydeAPI.APICall
    {
        [DataMember]
        public Person Person { get; set; }

        public APICurrentPersonInfo()
        { 
            //val.Test(base.person.id > 0, "User not signed in");
            this.Person = base.person;
        }
    }

    [HttpHandler("/API/*/Person/SignUp/", Type = HttpHandler.ContentType.JSON, Verb = HttpHandler.HTTPVerb.POST, Parameters = new string[] { "email", "name", "password", "rememberme" })]
    [DataContract]
    public class APIPersonSignup : ServerCydeAPI.APICall
    {
        public APIPersonSignup()
        {

            if (isPost)
            {
                Person user = new Person(Person.GetUserID(val.TestPattern(Form["email"], StringType.Email, "Email is required"), SiteID, val), val);
                if (user.id != 0)
                {
                    if ((user.Password != Form["password"]))
                    val.ErrorMsg = "Email already exists, and that was the incorrect password.";
                    else
                    {   //member exists and password matches, just sign them in.
                        person = user;
                        person.NewSession(context, Form["RememberMe"].ToBool());
                        if (!(person.confirmed ?? false))
                            person.SendConfirmationEmail(site);

                    }

                }
                else
                {

                    person = new Person(val);

                    person.name = val.TestEmpty(Form["name"], "Name is required");
                    person.email = val.TestPattern(Form["email"], StringType.Email, "Email is required");
                    person.Password = (val.TestEmpty(Form["password"], "Password is required")); //store encrypted password
                    person.site_id = SiteID;
                    person.ip = context.Request.UserHostAddress;
                    person.AuthorizedLevel = GenObjects.AuthLevel.Write;
                    person.UpSert(person);

                    if (val.Valid)
                    {
                        person.NewSession(context, Form["RememberMe"].ToBool());
                        person.SendConfirmationEmail(site);
                    }
                }
            }
        }
    }



    [HttpHandler("/API/*/Person/SignIn/", Type = HttpHandler.ContentType.JSON, Verb = HttpHandler.HTTPVerb.POST, Parameters = new string[] { "email", "password", "rememberme" })]
    [DataContract]
    public class APIPersonSignIn : ServerCydeAPI.APICall
    {
        public APIPersonSignIn()
        {
            if (isPost)
            {
                Person user = new Person(Person.GetUserID(val.TestPattern(Form["email"], StringType.Email, "Email is required"), SiteID, val), val);
                val.Test(user.id > 0, "User not found");
                val.Test(user.Password == Form["password"], "Incorrect Password");

                //TODO limit attempts

                //TODO Remeber user

                if (val.Valid)
                    person = new Person(user.id, val);
                person.NewSession(context, Form["RememberMe"].ToBool());
            }
        }
    }

    [HttpHandler("/API/*/Person/SendConfirmation/", Type = HttpHandler.ContentType.JSON, Verb = HttpHandler.HTTPVerb.POST)]
    [DataContract]
    public class APISendConfirmation : ServerCydeAPI.APICall
    {
        public APISendConfirmation()
        {
            val.Test(person.id != 0, "Please sign in first");
            if (val.Valid)
                person.SendConfirmationEmail(site);
        }
    }

    [HttpHandler("/confirm/*/")]
    public class page_authentication : ServerCydeAPI.APICall
    {
        public page_authentication() {

            long id = User.DecryptConfirmationToken(Query["token"]);
            context.Response.ContentType = "text/html";
            if (id != 0) //does token contain a valid ID
            {
                person = new Person(id, val);
                person.confirmed = true;
                person.UpSert(person);
                person.NewSession(context);
                context.Response.Write("Thank you for confirming your account.<br /><br/> You may close this window or visit <a href='http://" + site.url + "'>" + site.url + "</a>");
            }
            else
                context.Response.Write("Invalid token. Account not confirmed");

            context.Response.End();

        }
    }

    [HttpHandler("/API/*/Person/SignOut/", Type = HttpHandler.ContentType.JSON, Verb = HttpHandler.HTTPVerb.POST)]
    [DataContract]
    public class APIPersonSignOut : ServerCydeAPI.APICall
    {
        public APIPersonSignOut()
        {
            if (isPost)
                person.SignOut(context);
        }
    }

    [HttpHandler("/API/*/Person/ChangePassword/", Type = HttpHandler.ContentType.JSON, Verb = HttpHandler.HTTPVerb.POST, Parameters = new string[] { "oldpassword", "newpassword" })]
    [DataContract]
    public class APIPersonChangePassword : ServerCydeAPI.APICall
    {
        public APIPersonChangePassword()
        {
            val.Test(person.id != 0, "Please sign in first");
            if (val.Valid)
            {
                val.Test(person.Password == Form["oldpassword"], "Incorrect password");
                person.Password = Form["newpassword"];
                person.UpSert(person);
            }
        }
    }

    [HttpHandler("/API/*/Person/ChangeName/", Type = HttpHandler.ContentType.JSON, Verb = HttpHandler.HTTPVerb.POST, Parameters = new string[] { "name", "password" })]
    [DataContract]
    public class APIChangeName : ServerCydeAPI.APICall
    {
        public APIChangeName()
        {
            val.Test(person.id != 0, "Please sign in first");
            if (val.Valid)
            {
                val.Test(person.Password == Form["password"], "Incorrect password");
                person.name = Form["name"];
                person.UpSert(person);
            }
        }
    }

    [HttpHandler("/API/*/Person/ChangeEmail/", Type = HttpHandler.ContentType.JSON, Verb = HttpHandler.HTTPVerb.POST, Parameters = new string[] { "email", "password" })]
    [DataContract]
    public class APIChangeEmail : ServerCydeAPI.APICall
    {
        public APIChangeEmail()
        {
            if (isPost)
            {
                val.Test(person.id != 0, "Please sign in first");
                if (Person.GetUserID(Form["email"], SiteID, val) != 0)
                {
                    val.ErrorMsg = "Email already exists, please try signing in instead.";
                }
                else
                {
                    if (val.Valid)
                    {
                        val.Test(person.Password == Form["password"], "Incorrect password");
                        person.email = Form["email"];
                        person.confirmed = false;
                        person.UpSert(person);
                        person.SendConfirmationEmail(site);
                    }
                }
            }
        }
    }


    [HttpHandler("/API/*/Person/ResetPassword/", Type = HttpHandler.ContentType.JSON, Verb = HttpHandler.HTTPVerb.POST, Parameters = new string[] { "email" })]
    [DataContract]
    public class APIPersonResetPassword : ServerCydeAPI.APICall
    {
        public APIPersonResetPassword()
        {
            if (isPost)
            {
                Person user = new Person(Person.GetUserID(val.TestPattern(Form["email"], StringType.Email, "Email is required"), SiteID, val), val);
                val.Test(user.id > 0, "User not found");

                if (val.Valid)
                {
                    Email email = new Email(site.smtpserver, site.smtpusername, site.smtppassword);
                    email.From = new MailAddress(site.supportemail, site.supportemailname);
                    email.To.Add(new MailAddress(person.email, person.Name));
                    email.Subject = "Password Recovery";
                    email.IsBodyHtml = false;
                    email.Body = String.Format(@"{0}
You requested that your password for {1} be sent to you.

It is: {2}

Thanks
The {3} Team
", person.Name, site.name, person.Password, site.name);
                    email.Send(val);
                }
            }
        }
    }

}