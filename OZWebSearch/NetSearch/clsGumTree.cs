#region COPYRIGHT & CODE DESCRIPTION

// © 2006-2012 by D.E.M.O.N Studio. All rights reserved
// 
// D.E.M.O.N Studio: Decisively, Earnestly, Masterfully, Observantly, Naturally
// 
// SOLUTION: OZPhonePrice
// PROJECT:    OZWebSearch
// FILENAME:  clsGumTree.cs
// 
// CREATED IN 9:04 PM (12/02/2013)
// 
// LAST EDITED: 10:42 PM (12/02/2013)

#endregion

using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using OZPhoneDetail;

namespace OZWebSearch.NetSearch
{
    public class clsGumTree
    {
        public static List<clsPhone> CheckPrice(string SearchName)
        {
            var iList = new List<clsPhone>();
            //http://www.gumtree.com.au/s-mobile-phones/box-hill-melbourne/iphone+5/k0c18597l3001721r500?sort=price_desc&ad=offering&price-type=fixed
            SearchName = SearchName.Replace(" ", "+");
            System.Net.WebClient client = new WebClient();
            //client.Headers.Add("user-agent", "Android 5.0");
            byte[] page =
                client.DownloadData("http://www.gumtree.com.au/s-mobile-phones/box-hill-melbourne/" + SearchName +
                                    "/k0c18597l3001721r500?sort=price_desc&ad=offering&price-type=fixed");
            string content = System.Text.Encoding.UTF8.GetString(page);
            content =
                Regex.Match(content, "<ul id=\"srchrslt-adtable\".*<div class=\"rs-paginator rounded-bottom-corners3\">",
                            RegexOptions.Singleline).Value;

            Regex regexObj = new Regex("class=\"rs-ad-title h-elips\" href=.*?</a>", RegexOptions.Singleline);
            Regex regexObj2 = new Regex("<div class=\"h-elips \">.*?</div>", RegexOptions.Singleline);
            Match matchResult = regexObj.Match(content);
            Match matchResult2 = regexObj2.Match(content);

            int i = 0;

            while (matchResult.Success && matchResult2.Success && i < 8)
            {
                var iTemp = new OZPhoneDetail.clsPhone
                    {
                        PhoneName = matchResult.Value.Replace("class=\"rs-ad-title h-elips\" href=", "")
                    };

                //alt="iPhone 4S 64GB" /></a>
                iTemp.PhoneName = iTemp.PhoneName.Replace("</a>", "");
                var iTempArr = iTemp.PhoneName.Split('>');
                iTemp.PhoneName = iTempArr[1];
                iTemp.PhonePrice = matchResult2.Value.Replace("<div class=\"h-elips \">", "");
                iTemp.PhonePrice = iTemp.PhonePrice.Replace("</div>", "").Trim().Replace("$", "").Replace(",", "");
                iTemp.PhoneSource = "GumTree";

                try
                {
                    Convert.ToDouble(iTemp.PhonePrice);
                    iList.Add(iTemp);
                }
                catch
                {
                }

                i++;
                matchResult = matchResult.NextMatch();
                matchResult2 = matchResult2.NextMatch();
            }

            return iList;
        }
    }
}