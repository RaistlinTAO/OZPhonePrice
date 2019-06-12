#region COPYRIGHT & CODE DESCRIPTION

// © 2006-2012 by D.E.M.O.N Studio. All rights reserved
// 
// D.E.M.O.N Studio: Decisively, Earnestly, Masterfully, Observantly, Naturally
// 
// SOLUTION: OZPhonePrice
// PROJECT:    OZWebSearch
// FILENAME:  clsMobileCiti.cs
// 
// CREATED IN 9:56 PM (11/02/2013)
// 
// LAST EDITED: 10:42 PM (12/02/2013)

#endregion

using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using OZPhoneDetail;

namespace OZWebSearch.NetSearch
{
    public class clsMobileCiti
    {
        public static List<clsPhone> CheckPrice(string SearchName)
        {
            var iList = new List<clsPhone>();
            //http://www.mobileciti.com.au/catalogsearch/result/?q=HTC+8X&search=Submit&order=price&dir=desc
            SearchName = SearchName.Replace(" ", "+");

            System.Net.WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Android 5.0");
            byte[] page =
                client.DownloadData("http://www.mobileciti.com.au/catalogsearch/result/?q=" + SearchName +
                                    "&search=Submit&order=price&dir=desc");
            string content = System.Text.Encoding.UTF8.GetString(page);
            content =
                Regex.Match(content, "<li class=\"item first\">.*?<div class=\"toolbar-bottom\">",
                            RegexOptions.Singleline).Value;

            Regex regexObj = new Regex("title=\".*?\" class=\"product-image\">");
            Regex regexObj2 = new Regex("<span class=\"price\">.*?</span>");
            Match matchResult = regexObj.Match(content);
            Match matchResult2 = regexObj2.Match(content);


            while (matchResult.Success && matchResult2.Success)
            {
                var iTemp = new OZPhoneDetail.clsPhone {PhoneName = matchResult.Value.Replace("title=\"", "")};

                //alt="iPhone 4S 64GB" /></a>
                iTemp.PhoneName = iTemp.PhoneName.Replace("\" class=\"product-image\">", "");
                iTemp.PhonePrice = matchResult2.Value.Replace("<span class=\"price\">", "");
                iTemp.PhonePrice = iTemp.PhonePrice.Replace("</span>", "").Trim().Replace("$", "");
                iTemp.PhoneSource = "MobileCiti";
                iList.Add(iTemp);

                matchResult = matchResult.NextMatch();
                matchResult2 = matchResult2.NextMatch();
            }

            return iList;
        }
    }
}