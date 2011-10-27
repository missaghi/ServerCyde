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
    [HttpHandler("/dash/*/comet/")]
    public class page_comet : DashPages
    {
        public page_comet()
            : base("/a/html/dash/comet/comet.htm")
        {

        }


    }
}