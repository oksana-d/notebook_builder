using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace notebook
{
    public class RtfReader//director
    {
        public static string rtftext;

        public RtfReader(string str)
        {
            rtftext = str;
        }

        public string Read(HtmlConverter htmlConverter)
        {
           htmlConverter.htmlText = htmlConverter.ConvertBold(rtftext);
           htmlConverter.htmlText = htmlConverter.ConvertItalic(htmlConverter.htmlText);
           htmlConverter.htmlText = htmlConverter.ConvertUnderLine(htmlConverter.htmlText);
           htmlConverter.htmlText = htmlConverter.ConvertPar(htmlConverter.htmlText);
           htmlConverter.htmlText = htmlConverter.ConvertText(htmlConverter.htmlText);
           htmlConverter.htmlText = htmlConverter.ConvertHead(htmlConverter.htmlText);

            return htmlConverter.htmlText; 
        }

        public string RtfShow(PlainTextConverter plainTextConverter)
        {
            plainTextConverter.rtfText = plainTextConverter.ConvertBold(rtftext);
            plainTextConverter.rtfText = plainTextConverter.ConvertItalic(plainTextConverter.rtfText);
            plainTextConverter.rtfText = plainTextConverter.ConvertUnderLine(plainTextConverter.rtfText);
            plainTextConverter.rtfText = plainTextConverter.ConvertPar(plainTextConverter.rtfText);
            plainTextConverter.rtfText = plainTextConverter.ConvertText(plainTextConverter.rtfText);
            plainTextConverter.rtfText = plainTextConverter.ConvertHead(plainTextConverter.rtfText);

            return plainTextConverter.rtfText;
        }
    }


    public class HtmlText//produkt
    {
        public static string htmltext;
    }

    public class RtfText//produkt
    {
        public static string rtftext;
    }

    public abstract class TextConverter//abstract builder
    {
        public abstract string ConvertBold(string rtftext);//b
        public abstract string ConvertItalic(string rtftext);//i
        public abstract string ConvertUnderLine(string rtftext);//ul
        public abstract string ConvertPar(string rtftext);//par
        public abstract string ConvertText(string rtftext);
        public abstract string ConvertHead(string rtftext);
    }

    public class PlainTextConverter: TextConverter
    {
        public string rtfText = RtfText.rtftext;


        public void PlainTextConverterShow()
        {
            new Text("RTF без форматирования", RtfReader.rtftext).Show();
        }

        public override string ConvertBold(string rtftext)
        {
            string regex = @"({\\b)(.*)(})";
            string result = "";
            foreach (Match match in Regex.Matches(rtftext, regex))
            {
                result = match.Value;
                result = result.Replace("{\\b", null);
                result = result.Replace("}", null);
                rtftext = rtftext.Replace(match.Value, result);
            }
            return rtftext;
        }
        public override string ConvertItalic(string rtftext)
        {
            string regex = @"({\\i)(.*)(})";
            string result = "";
            foreach (Match match in Regex.Matches(rtftext, regex))
            {
                result = match.Value;
                result = result.Replace("{\\i", null);
                result = result.Replace("}", null);
                rtftext = rtftext.Replace(match.Value, result);
            }
            return rtftext;
        }
        public override string ConvertUnderLine(string rtftext)
        {
            string regex = @"({\\ul)(.*)(})";
            string result = "";
            foreach (Match match in Regex.Matches(rtftext, regex))
            {
                result = match.Value;
                result = result.Replace("{\\ul", null);
                result = result.Replace("}", null);
                rtftext = rtftext.Replace(match.Value, result);
            }
            return rtftext;
        }

        public override string ConvertPar(string rtftext)
        {
            string regex = @"\\par";
            foreach (Match match in Regex.Matches(rtftext, regex))
            {
                rtftext = rtftext.Replace("\\par" + System.Environment.NewLine, null);
            }
            return rtftext;
        }
        public override string ConvertText(string rtftext)
        {
            return rtftext;
        }
        public override string ConvertHead(string rtftext)
        {

            rtftext = rtftext.Replace("{\\rtf1" + System.Environment.NewLine, null);
            rtftext = rtftext.Replace("}" , null);

            return rtftext;
        }
    }

    public class HtmlConverter : TextConverter//concrete builder
    {
        public string htmlText = HtmlText.htmltext;
        public override string ConvertBold(string rtftext)
        {
            string regex = @"({\\b)(.*)(})";
            string result = "";
            foreach (Match match in Regex.Matches(rtftext, regex))
            {
                result = match.Value;
                result = result.Replace("{\\b", "<b>");
                result = result.Replace("}", "</b>");
                rtftext = rtftext.Replace(match.Value, result);
            }
            return rtftext;
        }
        public override string ConvertItalic(string rtftext)
        {
            string regex = @"({\\i)(.*)(})";
            string result = "";
            foreach (Match match in Regex.Matches(rtftext, regex))
            {
                result = match.Value;
                result = result.Replace("{\\i", "<i>");
                result = result.Replace("}", "</i>");
                rtftext = rtftext.Replace(match.Value, result);
            }
            return rtftext;
        }
        public override string ConvertUnderLine(string rtftext)
        {
            string regex = @"({\\ul)(.*)(})";
            string result = "";
            foreach (Match match in Regex.Matches(rtftext, regex))
            {
                result = match.Value;
                result = result.Replace("{\\ul", "<ins>");
                result = result.Replace("}", "</ins>");
                rtftext = rtftext.Replace(match.Value, result);
            }
            return rtftext;
        }
        public override string ConvertPar(string rtftext)
        {
            string regex = @"\\par";
            string result = "";
            foreach (Match match in Regex.Matches(rtftext, regex))
            {
                result = match.Value;
                result = result.Replace("\\par", "<br />");
                rtftext = rtftext.Replace(match.Value, result);
            }
            return rtftext;
        }
        public override string ConvertText(string rtftext)
        {
            return rtftext;
        }
        public override string ConvertHead(string rtftext)
        {
        
            rtftext = rtftext.Replace("{\\rtf1", "<html>");
            rtftext = rtftext.Replace("}", " <html/>");

            return rtftext;
        }
    }
}