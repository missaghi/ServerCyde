using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpFusion;

using Amazon;
using Amazon.SimpleDB;
using Amazon.SimpleDB.Model;

namespace ServerCyde.Pages
{
    public class SimpleDBPages : DashPages
    {
        public AmazonSimpleDB sdb { get { if (site.AmazonKey.NOE()) template.Warning = "You are using a demo DB account, do not store any sensitive data."; return AWSClientFactory.CreateAmazonSimpleDBClient(site.AmazonKey.Else("AKIAJLVIIXIIHCKMCVXQ"), site.AmazonPassword.Else("xstfFHFNhKlEN1dYfXOB1HR/WbqkfznK6oeseEH8")); } }
        [System.Runtime.Serialization.IgnoreDataMember]
        public List<string> Domains
        {
            get
            {
                try
                {
                    ListDomainsResponse sdbListDomainsResponse = sdb.ListDomains(new ListDomainsRequest());
                    if (sdbListDomainsResponse.IsSetListDomainsResult())
                    {
                        return sdbListDomainsResponse.ListDomainsResult.DomainName;
                    }
                    else return new List<string>();
                }
                catch (Exception e)
                { val.ErrorMsg = e.Message; return new List<string>(); }

            }
        }

        public SimpleDBPages(string templatepath) : base(templatepath) { }
        public SimpleDBPages() { }

    }
}