using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Jade.Model;

namespace Jade
{
    public static class ExtensionMethods
    {
        public const string HostUrlMath = "[^//]*?\\.(com|cn|net|org|biz|info|cc|tv)";

        //public static List<ItemRule> FindItemRule(this List<SiteRule> siteRuleList, string url)
        //{
        //    List<ItemRule> rule = new List<ItemRule>();

        //    string lastUrl = null;
        //    int lastIndex = 0;
        //    for (int i = 0; i < siteRuleList.Count; i++)
        //    {
        //        if (url.Approximation(lastUrl, siteRuleList[i].ForTestUrl) == ApproximationValue.BThanA)
        //        {
        //            lastUrl = siteRuleList[i].ForTestUrl;
        //            lastIndex = i;
        //        }
        //    }

        //    rule = siteRuleList[lastIndex].ItemRules;
        //    //int appValue = url.ApproximationLength(lastUrl);

        //    return rule;
        //}

        /// <summary>
        /// 返回与当前字符串最接近的字符串索
        /// </summary>
        /// <param name="baseStr"></param>
        /// <param name="strA"></param>
        /// <param name="strB"></param>
        /// <returns></returns>
        public static ApproximationValue Approximation(this string baseStr, string strA, string strB)
        {
            if (string.IsNullOrEmpty(baseStr))
                return ApproximationValue.Unequal;

            if (string.IsNullOrEmpty(strA))
                strA = string.Empty;

            if (string.IsNullOrEmpty(strB))
                strB = string.Empty;

            baseStr = baseStr.Trim();
            strA = strA.Trim();
            strB = strB.Trim();

            int appA = 0;
            int appB = 0;

            bool appAstop = false;
            bool appBstop = false;

            for (int i = 0; i < baseStr.Length; i++)
            {
                if (appA != appB)
                {
                    return appA > appB ? ApproximationValue.AThanB : ApproximationValue.BThanA;
                }

                if (!appAstop && strA.Length > i)
                {
                    if (strA[i] == baseStr[i])
                        appA++;
                    else
                        appAstop = true;

                }

                if (!appBstop && strB.Length > i)
                {
                    if (strB[i] == baseStr[i])
                        appB++;
                    else
                        appBstop = true;
                }
            }

            if (appA == appB && appA == 0)
            {
                return ApproximationValue.Unequal;
            }

            if (appA == appB && appA == baseStr.Length && baseStr.Length == strA.Length && baseStr.Length == strB.Length)
            {
                return ApproximationValue.AllEqual;
            }

            return ApproximationValue.Unequal;
        }

        /// <summary>
        /// 返回两个字符串的相等长度
        /// </summary>
        /// <param name="baseStr"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ApproximationLength(this string baseStr, string str)
        {
            if (string.IsNullOrEmpty(baseStr))
                return 0;
            if (string.IsNullOrEmpty(str))
                return 0;

            baseStr = baseStr.Trim();
            str = str.Trim();

            int appValue = 0;

            for (int i = 0; i < baseStr.Length; i++)
            {
                if (str.Length > i)
                {
                    if (baseStr[i] == str[i])
                    {
                        appValue++;
                    }
                }
                else
                    break;
            }
            return appValue;
        }
    }


    public enum ApproximationValue
    {
        /// <summary>
        /// 三个字符串相等
        /// </summary>
        AllEqual,

        /// <summary>
        /// A大于B
        /// </summary>
        AThanB,

        /// <summary>
        /// B大于A
        /// </summary>
        BThanA,

        /// <summary>
        /// 全都不相关
        /// </summary>
        Unequal
    }
}
