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

    [HttpHandler("/dash/*/SimpleDB/Domains/")]
    public class page_domains : SimpleDBPages
    {
        public page_domains()
            : base("/a/html/dash/simpledb/domains.htm")
        {

            //Create Domain
            if (isPost)
            {
                String domainName = val.TestEmpty(Form["domain"], "need a name");
                if (val.Valid)
                {
                    CreateDomainRequest createDomain = (new CreateDomainRequest()).WithDomainName(domainName);
                    try { sdb.CreateDomain(createDomain); }
                    catch (Exception e)
                    {
                        val.ErrorMsg = "Error creating domain: " +  e.Message;
                    }
                }
            }
            
            //List Domains 
            if (Domains.Count > 0)
            { 
                foreach (String domain in Domains)
                {
                    template.Append("domains", string.Format("<li>{0}</li>", domain));
                }
            }
            else
            {
                template.Append("domains", "No domains yet. Create a domain");
            }
        }
    }
}