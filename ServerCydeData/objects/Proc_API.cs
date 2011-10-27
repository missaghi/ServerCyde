using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using SharpFusion;

namespace ServerCydeData
{
    public partial class Proc_Api
    {
        private Person person { get; set; }
        private Web web { get; set; }

        public string[] ReturnFields()
        {
            this.person = person;
            this.web = web;
            List<string> list = new List<string>();
            
            if (url.NNOE())
            {
                //tokens (including ads)
                Regex reg = new Regex(SharpFusion.Template.TokenRegex, RegexOptions.IgnoreCase); //@"\[%(\w+)%\]|token=""(\w+)""|(""~/)|[%ad:(.*?)%\]";
                MatchEvaluator replaceCallback = new MatchEvaluator(ReplaceTokenHandler);
                foreach (Match token in reg.Matches(url, 0))
                {
                    String value = token.Groups[1].ToString().ToLower();
                    value = value.Trim().NOE() ? token.Groups[2].ToString().ToLower() : value;
                    value = value.Trim().NOE() ? token.Groups[3].ToString().ToLower() : value;
                    value = value.Trim().NOE() ? token.Groups[4].ToString().ToLower() : value;

                    list.Add(value);
                }
            }
            return list.ToArray();
        }

        public string[] ReturnSampleFields(Person person, Web web)
        {
            this.person = person;
            this.web = web;
            List<string> list = new List<string>();

            if (url.NNOE())
            {
                //tokens (including ads)
                Regex reg = new Regex(SharpFusion.Template.TokenRegex, RegexOptions.IgnoreCase); //@"\[%(\w+)%\]|token=""(\w+)""|(""~/)|[%ad:(.*?)%\]";
                MatchEvaluator replaceCallback = new MatchEvaluator(ReplaceTokenHandler);
                foreach (Match token in reg.Matches(url, 0))
                {
                    long parseid = 0;
                    String value = token.Groups[1].ToString().ToLower();
                    value = value.Trim().NOE() ? token.Groups[2].ToString().ToLower() : value;
                    value = value.Trim().NOE() ? token.Groups[3].ToString().ToLower() : value;
                    value = value.Trim().NOE() ? token.Groups[4].ToString().ToLower() : value;

                    //if (value.Like("ipaddress"))
                    //{
                        
                    //}
                    //else if (value.Like("currentuserid"))
                    //{   }
                    //else if (value.Like("currentusername"))
                    //{   }
                    //else if (value.Like("guid"))
                    //{   }
                    if (value.StartsWith("username") && long.TryParse(value.Replace("username", ""), out parseid))
                    {
                        list.Add("\"" + value + "\" : \"" + new Random().Next(200) + "\"");
                    }
                    else  list.Add("\"" + value + "\" : \"" + value + "value\"");
                }
            }
            return list.ToArray();
        }

        public string ParseTags(Person person, Web web)
        { 
            this.person = person;
            this.web = web;
            string result = url;
            if (url.NNOE())
            {
                //tokens  
                Regex reg = new Regex(SharpFusion.Template.TokenRegex, RegexOptions.IgnoreCase); //@"\[%(\w+)%\]|token=""(\w+)""|(""~/)|[%ad:(.*?)%\]";
                MatchEvaluator replaceCallback = new MatchEvaluator(ReplaceTokenHandler);
                result = reg.Replace(url, replaceCallback); //replace tokens with any matching tags or string.Empty
            }
            return result;
        }


        /// <summary>Replaces the token Tag with the token Value.</summary> 
        /// <param name="token">Token.</param> 
        private string ReplaceTokenHandler(Match token)
        {
            //first group match is the original match
            String value = token.Groups[1].ToString().ToLower();
            value = value.Trim().NOE() ? token.Groups[2].ToString().ToLower() : value;
            value = value.Trim().NOE() ? token.Groups[3].ToString().ToLower() : value;
            value = value.Trim().NOE() ? token.Groups[4].ToString().ToLower() : value;

            long parseid = 0;

            if (value.Like("ipaddress"))
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            else if (value.Like("currentuserid"))
            { return person.id.ToString(); }
            else if (value.Like("currentusername"))
            { return person.Name; }
            else if (value.Like("guid"))
            { return new Guid().ToString(); }
            else if (value.StartsWith("username") && long.TryParse(value.Replace("username", ""), out parseid))
            {
                return new Person(web.Form[value].ToLong(0), val).Name;
            }
            else if (web.Form[value].NNOE())
            {
                return web.Form[value].ToHTMLEnc();
            }
            else if (web.Query[value].NNOE())
            {
                return web.Query[value].ToHTMLEnc();
            }
            else return "";
        }

    }
}