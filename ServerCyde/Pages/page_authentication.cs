using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;
using ServerCydeData;

namespace ServerCyde.Pages
{
    [HttpHandler("/tos/")]
    public class page_tos : Handler
    {
        public page_tos()
            : base("/a/html/public/tos.html")
        { }
    }

    [HttpHandler("/logout/")]
    public class page_logout : Handler
    {
        public page_logout() 
        {
            CurrentUser.SignOut(context);
            context.Response.Redirect("/");
        }
    }


    [HttpHandler("/forgot/")]
    public class page_forgot : Handler
    {
        public page_forgot()
            : base("/a/html/public/forgot.html")
        {
            if (isPost)
            {
                User user = new User(User.GetUserID(val.TestPattern(Form["email"], StringType.Email, "Invalid email"), val), val);

                if (user != null)
                {
                    val.Test(user.id != 0, "Email not found");
                }

                if (val.Valid)
                {

                    Email msg = new Email();
                    msg.To.Add(new System.Net.Mail.MailAddress(user.email, user.Name));
                    msg.From = new System.Net.Mail.MailAddress("support@servercyde.com", "ServerCyde.com Team");
                    msg.Body = string.Format(@"Hello {0},

You requested your password to ServerCyde.com.

Your password is: {1}

Click here to login:
http://servercyde.com/signin/

If you have any questions please reply to this email.

Thanks,
The ServerCyde Minions: Riaz and Amir
support@servercyde.com", user.name, user.Password);
                    msg.Subject = "Password recovery";
                    msg.IsBodyHtml = false;
                    msg.Send(val);

                    template.Msg = "Recovery email has been sent.";

                }
            }
        }
    }

    [HttpHandler("/signin/")]
    public class page_signin : Handler
    {
        public page_signin()
            : base("/a/html/public/signin.html")
        {

            if (isPost)
            {
                template.Set("remember", Form["remember"].ToBool().ToChecked());


                User user = new User(User.GetUserID(val.TestPattern(Form["email"], StringType.Email, "Invalid email"), val), val);

                if (user.id != 0)
                {
                    val.Test(user.id != 0, "Email not found");
                    val.Test(user.Password == val.TestEmpty(Form["password"], "Please enter a password"), "Incorrect password");
                }
                else
                {
                    val.ErrorMsg = "Email not found, please register first.";
                }

                 

                if (val.Valid)
                {
                    CurrentUser = user;
                    CurrentUser.NewSession(context, Form["remember"].ToBool());
                    if (CurrentUser.confirmed ?? false)
                    {
                        if (Query["redirect"].NOE())
                            context.Response.Redirect("/dash/");
                        else
                            context.Response.Redirect(Query["redirect"]);
                    }
                    else
                    {
                        CurrentUser.SendConfirmationEmail();
                        //template = new Template("/a/html/public/CheckYourEmail.html");
                        context.Response.Redirect("/dash/");
                    }

                }
            }
        }
    }

    [HttpHandler("/register/")]
    public class page_signup : Handler
    {
        public page_signup()
            : base("/a/html/public/register.html")
        {
            
            template.Set("hidepassword", Query["hidepassword"].ToBool().ToCustom("password", "text"));
            template.Set("passwordhidden", Query["hidepassword"].ToBool().ToCustom("hidden", ""));

            if (isPost)
            {
                val.Test(User.GetUsersBy_email(Form["email"], val).Count == 0, "That email address is already in the system, try to login instead, or recover your password on the login page.");

                val.Test(Form["tos"].ToBool(), "Sorry you need to agree to the terms to play.");

                CurrentUser = new User(val);
                CurrentUser.email = val.TestPattern(Form["email"], StringType.Email, "Invalid email");
                CurrentUser.Password = val.TestEmpty(Form["password"], "Please enter a password");
                CurrentUser.name = val.TestEmpty(Form["name"], "Please enter a name");
                CurrentUser.ip = context.Request.UserHostAddress;
                CurrentUser.UpSert(CurrentUser);
                template.Set("remember", Form["remember"].ToBool().ToChecked());
                template.Set("password", "");
                if (val.Valid)
                {
                    CurrentUser.NewSession(context, Form["remember"].ToBool());
                    //send confirmation email
                    CurrentUser.SendConfirmationEmail();
                    template = new Template("/a/html/public/CheckYourEmail.html");
                    switch (Query["level"].ToLower())
                    {
                        case "1": context.Response.Redirect("/dash/"); break;
                        case "2": context.Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=4D7W84LDZKRSY"); break;
                        case "3": context.Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=L7WEPNBUHZJFA"); break;
                        case "4": context.Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=JEUKSV3K9D2S8"); break;
                        case "5": context.Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=MGHNCDHCN25LL"); break;
                        default: context.Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=4D7W84LDZKRSY"); break;
                    }
                }
            }
        }
    }


    [HttpHandler("/confirm/")]
    public class page_authentication : Handler
    {
        public page_authentication()
            : base("/a/html/public/confirm.html")
        {

            long id = User.DecryptConfirmationToken(Query["token"]);

            if (id != 0) //does token contain a valid ID
            {
                CurrentUser = new User(id, val);
                CurrentUser.confirmed = true;
                CurrentUser.UpSert(CurrentUser);
                CurrentUser.NewSession(context);
                context.Response.Redirect("/dash/?msg=2");
            }
            else
                template.Msg = "Invalid token. Account not confirmed";

        }
    }
}