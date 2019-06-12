#region COPYRIGHT & CODE DESCRIPTION

// © 2006-2012 by D.E.M.O.N Studio. All rights reserved
// 
// D.E.M.O.N Studio: Decisively, Earnestly, Masterfully, Observantly, Naturally
// 
// SOLUTION: OZPhonePrice
// PROJECT:    OZWebSearch
// FILENAME:  clsKogan.cs
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
    public class clsKogan
    {
        public static List<clsPhone> CheckPrice(string SearchName)
        {
            var iList = new List<clsPhone>();
            //http://www.kogan.com/au/search/?keywords=HTC%208X&department=phones
            //SearchName = SearchName.Replace(" ", "+");

            System.Net.WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Android 5.0");
            byte[] page =
                client.DownloadData("http://www.kogan.com/au/search/?keywords=" + SearchName + "&department=phones");
            string content = System.Text.Encoding.UTF8.GetString(page);
            content =
                Regex.Match(content, "class=\"products list-view one-column graduated-border.*id=\"product-list-end\"",
                            RegexOptions.Singleline).Value;
            //class="products list-view one-column graduated-border
            //id="product-list-end"

            Regex regexObj = new Regex("itemprop=\"url\">.*?</a></h3>", RegexOptions.Singleline);
            Regex regexObj2 = new Regex("<li itemprop=\"price\">.*?</li>", RegexOptions.Singleline);
            Match matchResult = regexObj.Match(content);
            Match matchResult2 = regexObj2.Match(content);

            int i = 0;

            while (matchResult.Success && matchResult2.Success && i < 4)
            {
                var iTemp = new OZPhoneDetail.clsPhone {PhoneName = matchResult.Value.Replace("itemprop=\"url\">", "")};

                //alt="iPhone 4S 64GB" /></a>
                iTemp.PhoneName = iTemp.PhoneName.Replace("</a></h3>", "");
                iTemp.PhonePrice = matchResult2.Value.Replace("<li itemprop=\"price\">", "");
                iTemp.PhonePrice = iTemp.PhonePrice.Replace("</li>", "").Replace("$", "");
                iTemp.PhoneSource = "Kogan";
                iList.Add(iTemp);
                i++;
                matchResult = matchResult.NextMatch();
                matchResult2 = matchResult2.NextMatch();
            }

            return iList;
        }
    }
}