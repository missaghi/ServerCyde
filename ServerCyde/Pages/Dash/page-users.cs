using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SharpFusion;
using ServerCydeData;


using Amazon;
using Amazon.SimpleDB;
using Amazon.SimpleDB.Model;

namespace ServerCyde.Pages
{
    [HttpHandler("/dash/*/users/")]
    public class page_users : DashPages
    {
        public page_users()
            : base("/a/html/dash/users/users.htm")
        {

        }


    }
}