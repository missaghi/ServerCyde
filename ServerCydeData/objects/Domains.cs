using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon;
using Amazon.SimpleDB;
using Amazon.SimpleDB.Model;

namespace ServerCyde
{
    public class Domains
    {
        public String DomainName { get; set; }
        public Domains() { }

        public static HashSet<string> GetFields(string Domain,  AmazonSimpleDB sdb)
        {
            HashSet<string> attributeNames = new HashSet<string>();

            var getRequest = new SelectRequest
            {
                SelectExpression = "select * from `" + Domain + "` limit  100"
            };
            var getResponse = sdb.Select(getRequest);

            foreach (Amazon.SimpleDB.Model.Item item in getResponse.SelectResult.Item)
            {
                foreach (Amazon.SimpleDB.Model.Attribute attribute in item.Attribute)
                {
                    if (attribute.IsSetName())
                    {
                        if (!attributeNames.Contains(attribute.Name))
                            attributeNames.Add(attribute.Name);
                    }
                }
            }
            return attributeNames;
        }

    }
}