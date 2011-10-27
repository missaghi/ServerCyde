using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Net;
using SharpFusion;
using ServerCydeData;

namespace ServerCyde
{
    [HttpHandler("/ipn/")]
    public class IPNHandler : Handler
    {
        public IPNHandler()
        {
            //Post back to either sandbox or live
            string strSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
            string strLive = "https://www.paypal.com/cgi-bin/webscr";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strLive);

            //Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] param = context.Request.BinaryRead(HttpContext.Current.Request.ContentLength);
            string strRequest = Encoding.ASCII.GetString(param);
            string strResponse_copy = strRequest;  //Save a copy of the initial info sent by PayPal
            strRequest += "&cmd=_notify-validate";
            req.ContentLength = strRequest.Length;

            //Send the request to PayPal and get the response
            StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            streamOut.Write(strRequest);
            streamOut.Close();
            StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = streamIn.ReadToEnd();
            streamIn.Close();

            if (strResponse == "VERIFIED")
            {
                //check the payment_status is Completed
                //check that txn_id has not been previously processed
                //check that receiver_email is your Primary PayPal email
                //check that payment_amount/payment_currency are correct
                //process payment

                NameValueCollection args = HttpUtility.ParseQueryString(strResponse_copy);

                //payment
                if (args["subscr_id"] != null)
                {
                    User_Payments up = new User_Payments(val);
                    up.Amount = (args["settle_amount"] ?? "0").ToDbl(0);
                    up.Description = "Subscription";
                    DateTime effdate = DateTime.Now;
                    string date = args["subscr_date"] ?? args["subscr_effective"] ?? args["payment_date"] ?? "";
                    DateTime.TryParse(date.Substring(0, date.Length - 4), out effdate);
                    up.effective_date = effdate.AddHours(2);
                    up.payer_email = args["payer_email"];
                    up.subscr_id = args["subscr_id"];
                    up.txn_date = DateTime.Now;
                    up.txn_id = args["txn_id"];
                    up.txn_type = args["txn_type"];
                    up.user_id = User.GetUserID(up.payer_email, val);
                    up.UpSert(CurrentUser);

                    if (up.Amount > 0)
                    {
                        CurrentUser.confirmed = true;
                        CurrentUser.UpSert(CurrentUser);
                    }

                }
            }
            else if (strResponse == "INVALID")
            {
                //log for manual investigation
            }
            else
            {
                //log response/ipn data for manual investigation
            }

            File.AppendAllText(context.Server.MapPath("/ipn.txt"), strResponse + " " + strResponse_copy);
        }


    }
}