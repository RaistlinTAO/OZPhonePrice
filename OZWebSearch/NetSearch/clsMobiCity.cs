#region COPYRIGHT & CODE DESCRIPTION

// © 2006-2012 by D.E.M.O.N Studio. All rights reserved
// 
// D.E.M.O.N Studio: Decisively, Earnestly, Masterfully, Observantly, Naturally
// 
// SOLUTION: OZPhonePrice
// PROJECT:    OZWebSearch
// FILENAME:  clsMobiCity.cs
// 
// CREATED IN 9:53 PM (11/02/2013)
// 
// LAST EDITED: 10:42 PM (12/02/2013)

#endregion

using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using OZPhoneDetail;

namespace OZWebSearch.NetSearch
{
    public class clsMobiCity
    {
        public static List<clsPhone> CheckPrice(string SearchName)
        {
            //http://www.mobicity.com.au/catalogsearch/result/?q=iphone+4s+16
            //http://www.mobicity.com.au/catalogsearch/result/?product_type=115&q=iphone+4s+16
            var iList = new List<clsPhone>();
            SearchName = SearchName.Replace(" ", "+");

            System.Net.WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Android 5.0");
            byte[] page =
                client.DownloadData("http://www.mobicity.com.au/catalogsearch/result/?product_type=115&q=" + SearchName);
            string content = System.Text.Encoding.UTF8.GetString(page);
            content =
                Regex.Match(content, "<ul class=\"products-grid\">.*<div class=\"clearfix\"></div>",
                            RegexOptions.Singleline).Value;

            Regex regexObj = new Regex("alt=\".*? /></a>", RegexOptions.Singleline);
            Regex regexObj2 = new Regex("<div class=\"price\">.*?</div>", RegexOptions.Singleline);
            Match matchResult = regexObj.Match(content);
            Match matchResult2 = regexObj2.Match(content);


            while (matchResult.Success && matchResult2.Success)
            {
                var iTemp = new OZPhoneDetail.clsPhone {PhoneName = matchResult.Value.Replace("alt=\"", "")};

                //alt="iPhone 4S 64GB" /></a>
                iTemp.PhoneName = iTemp.PhoneName.Replace("\" /></a>", "");
                iTemp.PhonePrice = matchResult2.Value.Replace("<div class=\"price\">", "");
                iTemp.PhonePrice = iTemp.PhonePrice.Replace("</div>", "").Trim().Replace("$", "");
                iTemp.PhoneSource = "MobiCity";
                iList.Add(iTemp);

                matchResult = matchResult.NextMatch();
                matchResult2 = matchResult2.NextMatch();
            }


            return iList;
        }
    }
}