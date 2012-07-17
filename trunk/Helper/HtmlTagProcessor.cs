using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Jade
{
    public interface IHtmlTagCleaner
    {
        string CleanHtmlTag(string originalHtml);
    }

    public interface IHtmlCleanerGenerator
    {
        IHtmlTagCleaner GenerateCleaner(HtmlTagType htmlTag);
    }

    public interface IHtmlTagTypeExplainer
    {
        string Explain(HtmlTagType htmlTagType);
    }

    public enum HtmlTagType
    {
        A = 1,
        Table = 2,
        Tr = 3,
        Td = 4,
        P = 5,
        Font = 6,
        Div = 7,
        Span = 8,
        Tbody = 9,
        Img = 10,
        Script = 11,
        B = 12,
        Br = 13,
        Nbsp = 14,
        Group = 15,
        Style = 16
    }

    public class HtmlTagTypeExplainer : IHtmlTagTypeExplainer
    {
        public string Explain(HtmlTagType htmlTagType)
        {
            switch (htmlTagType)
            {
                case HtmlTagType.A:
                    return "Link <a";
                case HtmlTagType.Table:
                    return "Table <table";
                case HtmlTagType.Tr:
                    return "TableRow <tr";
                case HtmlTagType.Td:
                    return "TableCell <td";
                case HtmlTagType.P:
                    return "Paragraph <p";
                case HtmlTagType.Font:
                    return "Font <font";
                case HtmlTagType.Div:
                    return "Layer <div";
                case HtmlTagType.Span:
                    return "Span <span";
                case HtmlTagType.Tbody:
                    return "TBody <tbody";
                case HtmlTagType.Img:
                    return "Image <img";
                case HtmlTagType.Script:
                    return "Script <script";
                case HtmlTagType.B:
                    return "Bold <b";
                case HtmlTagType.Br:
                    return "BR <br";
                case HtmlTagType.Nbsp:
                    return "Blank &nbsp;";
                case HtmlTagType.Group:
                    return "Group <group";
                case HtmlTagType.Style:
                    return "Style <style";
                default:
                    return string.Empty;
            }
        }
    }

    public class HtmlCleanerGenerator : IHtmlCleanerGenerator
    {
        public IHtmlTagCleaner GenerateCleaner(HtmlTagType htmlTag)
        {
            switch (htmlTag)
            {
                case HtmlTagType.A:
                    return new HtmlTagACleaner();
                case HtmlTagType.Table:
                    return new HtmlTagTableCleaner();
                case HtmlTagType.Tr:
                    return new HtmlTagTrCleaner();
                case HtmlTagType.Td:
                    return new HtmlTagTdCleaner();
                case HtmlTagType.P:
                    return new HtmlTagPCleaner();
                case HtmlTagType.Font:
                    return new HtmlTagFontCleaner();
                case HtmlTagType.Div:
                    return new HtmlTagDivCleaner();
                case HtmlTagType.Span:
                    return new HtmlTagSpanCleaner();
                case HtmlTagType.Tbody:
                    return new HtmlTagTbodyCleaner();
                case HtmlTagType.Img:
                    return new HtmlTagImgCleaner();
                case HtmlTagType.Script:
                    return new HtmlTagScriptCleaner();
                case HtmlTagType.B:
                    return new HtmlTagBCleaner();
                case HtmlTagType.Br:
                    return new HtmlTagBrCleaner();
                case HtmlTagType.Nbsp:
                    return new HtmlTagNbspCleaner();
                case HtmlTagType.Group:
                    return new HtmlTagGroupCleaner();
                case HtmlTagType.Style:
                    return new HtmlTagStyleCleaner();           
                default:
                    return null;
            }
        }
    }

    public class HtmlTagTypeCreater
    {
        public static bool TryCreate(string tagName, ref HtmlTagType tagType)
        {
            foreach (HtmlTagType htmlTagType in Enum.GetValues(typeof(HtmlTagType)))
            {
                if (htmlTagType.ToString().ToLower().Equals(tagName.ToLower()))
                {
                    tagType = htmlTagType;
                    return true;
                }
            }
            return false;
        }

        public static bool TryCreate(int tagValue, ref HtmlTagType tagType)
        {
            foreach (HtmlTagType htmlTagType in Enum.GetValues(typeof(HtmlTagType)))
            {
                if ((int)htmlTagType == tagValue)
                {
                    tagType = htmlTagType;
                    return true;
                }
            }
            return false;
        }
    }
    #region Html Cleaner
    public class HtmlTagACleaner : IHtmlTagCleaner
    {
        public string CleanHtmlTag(string originalHtml)
        {
            Regex regex = new Regex(@"<a\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            regex = new Regex(@"</a\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            return originalHtml;
        }
    }

    public class HtmlTagTableCleaner : IHtmlTagCleaner
    {
        public string CleanHtmlTag(string originalHtml)
        {
            Regex regex = new Regex(@"<table\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            regex = new Regex(@"</table\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            return originalHtml;
        }
    }

    public class HtmlTagTrCleaner : IHtmlTagCleaner
    {
        public string CleanHtmlTag(string originalHtml)
        {
            Regex regex = new Regex(@"<tr\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            regex = new Regex(@"</tr\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            return originalHtml;
        }
    }

    public class HtmlTagTdCleaner : IHtmlTagCleaner
    {
        public string CleanHtmlTag(string originalHtml)
        {
            Regex regex = new Regex(@"<td\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            regex = new Regex(@"</td\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            return originalHtml;
        }
    }

    public class HtmlTagPCleaner : IHtmlTagCleaner
    {
        public string CleanHtmlTag(string originalHtml)
        {
            Regex regex = new Regex(@"<p\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            regex = new Regex(@"</p\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            return originalHtml;
        }
    }

    public class HtmlTagFontCleaner : IHtmlTagCleaner
    {
        public string CleanHtmlTag(string originalHtml)
        {
            Regex regex = new Regex(@"<font\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            regex = new Regex(@"</font\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            return originalHtml;
        }
    }
    
    public class HtmlTagDivCleaner : IHtmlTagCleaner
    {
        public string CleanHtmlTag(string originalHtml)
        {
            Regex regex = new Regex(@"<div\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            regex = new Regex(@"</div\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            return originalHtml;
        }
    }
    
    public class HtmlTagSpanCleaner : IHtmlTagCleaner
    {
        public string CleanHtmlTag(string originalHtml)
        {
            Regex regex = new Regex(@"<span[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            regex = new Regex(@"</span[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            return originalHtml;
        }
    }
    
    public class HtmlTagTbodyCleaner : IHtmlTagCleaner
    {
        public string CleanHtmlTag(string originalHtml)
        {
            Regex regex = new Regex(@"<tbody\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            regex = new Regex(@"</tbody\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            return originalHtml;
        }
    }
    
    public class HtmlTagImgCleaner : IHtmlTagCleaner
    {
        public string CleanHtmlTag(string originalHtml)
        {
            Regex regex = new Regex(@"<img\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            return originalHtml;
        }
    }

    public class HtmlTagScriptCleaner : IHtmlTagCleaner
    {
        public string CleanHtmlTag(string originalHtml)
        {
            Regex regex = new Regex(@"(?is)<script.*?>.*?</script>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            return originalHtml;
        }
    }
    
    public class HtmlTagBCleaner : IHtmlTagCleaner
    {
        public string CleanHtmlTag(string originalHtml)
        {
            Regex regex = new Regex(@"<b\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            regex = new Regex(@"</b\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            return originalHtml;
        }
    }
    
    public class HtmlTagBrCleaner : IHtmlTagCleaner
    {
        public string CleanHtmlTag(string originalHtml)
        {
            Regex regex = new Regex(@"<br\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            return originalHtml;
        }
    }

    public class HtmlTagNbspCleaner : IHtmlTagCleaner
    {
        public string CleanHtmlTag(string originalHtml)
        {
            Regex regex = new Regex(@"nbsp;\b", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            return originalHtml;
        }
    }

    public class HtmlTagGroupCleaner : IHtmlTagCleaner
    {
        public string CleanHtmlTag(string originalHtml)
        {
            Regex regex = new Regex(@"<group\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            regex = new Regex(@"</group\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            originalHtml = regex.Replace(originalHtml, string.Empty);
            return originalHtml;
        }
    }

    public class HtmlTagStyleCleaner : IHtmlTagCleaner
    {
        public string CleanHtmlTag(string originalHtml)
        {
            var str = originalHtml;
            //str = Regex.Replace(str, "<[\\s]*p[^>]*>?>", "");
            //str = Regex.Replace(str, "</[\\s]*p[\\s]*?>", "\r\n");
            str = Regex.Replace(str, "<[\\s]*br[\\s]*/[\\s]*[^>]*>?>", "\r\n");
            str = Regex.Replace(str, "<[\\s]*br[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*br[^>]*>?>", "\r\n");

            str = Regex.Replace(str, "<[\\s]*script[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*script[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "<[\\s]*iframe[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*iframe[\\s]*[^>]*>?>", "");

            str = Regex.Replace(str, "<[\\s]*style[\\s]*[^>]*>?>", "");
            str = Regex.Replace(str, "</[\\s]*style[\\s]*[^>]*>?>", "");

            str = str.Replace("&rdquo;", "\"");
            str = str.Replace("&ldquo;", "\"");
            str = str.Replace("&lsquo;", "'");
            str = str.Replace("&rsquo;", "'");
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("&hellip;", "¡­");
            str = str.Replace("&ndash;", "-");
            str = str.Replace("&mdash;", "¡ª");
            return str;
        }
    }
    #endregion
}