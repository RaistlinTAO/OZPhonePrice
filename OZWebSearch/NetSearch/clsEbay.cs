#region COPYRIGHT & CODE DESCRIPTION

// © 2006-2012 by D.E.M.O.N Studio. All rights reserved
// 
// D.E.M.O.N Studio: Decisively, Earnestly, Masterfully, Observantly, Naturally
// 
// SOLUTION: OZPhonePrice
// PROJECT:    OZWebSearch
// FILENAME:  clsEbay.cs
// 
// CREATED IN 9:58 PM (11/02/2013)
// 
// LAST EDITED: 10:42 PM (12/02/2013)

#endregion

using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using OZPhoneDetail;

namespace OZWebSearch.NetSearch
{
    public class clsEbay
    {
        public static List<clsPhone> CheckPrice(string SearchName)
        {
            var iList = new List<clsPhone>();
            //http://www.ebay.com.au/sch/Mobile-Phones-/9355/i.html?_sop=15&Carrier=Unlocked&_from=R40&_dmpt=AU_Mobile_Phones&_nkw=Iphone%205&LH_PrefLoc=1&rt=nc&LH_BIN=1
            SearchName = SearchName.Replace(" ", "+");
            var client = new WebClient();
            client.Headers.Add("user-agent", "Android 5.0");
            byte[] page =
                client.DownloadData(
                    "http://www.ebay.com.au/sch/Mobile-Phones-/9355/i.html?_sop=15&Carrier=Unlocked&_from=R40&_dmpt=AU_Mobile_Phones&_nkw=" +
                    SearchName + "&LH_PrefLoc=1&rt=nc&LH_BIN=1");
            string content = System.Text.Encoding.UTF8.GetString(page);
            content =
                Regex.Match(content, "<div id=\"ResultSetItems.*<div class=\"topRatedContent g-hdn\">",
                            RegexOptions.Singleline).Value;

            Regex regexObj = new Regex("itemprop=\"name\">.*?</a>", RegexOptions.Singleline);
            Regex regexObj2 = new Regex("<div  class=\"g-b\" itemprop=\"price\">.*?</div>", RegexOptions.Singleline);
            Match matchResult = regexObj.Match(content);
            Match matchResult2 = regexObj2.Match(content);

            int i = 0;

            while (matchResult.Success && matchResult2.Success && i < 9)
            {
                var iTemp = new OZPhoneDetail.clsPhone {PhoneName = matchResult.Value.Replace("itemprop=\"name\">", "")};

                //alt="iPhone 4S 64GB" /></a>
                iTemp.PhoneName = iTemp.PhoneName.Replace("</a>", "");
                iTemp.PhonePrice = matchResult2.Value.Replace("<div  class=\"g-b\" itemprop=\"price\">", "");
                iTemp.PhonePrice = iTemp.PhonePrice.Replace("</div>", "").Replace("AU $", "");
                iTemp.PhoneSource = "Ebay";
                iList.Add(iTemp);
                i++;
                matchResult = matchResult.NextMatch();
                matchResult2 = matchResult2.NextMatch();
            }

            return iList;
        }
    }
}