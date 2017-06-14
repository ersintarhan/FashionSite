using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Seo
{
    public class Seo
    {
        public static string Translate(string phrase)
        {
            string trans = phrase.ToLower();

            trans = trans.Replace("ç", "c").Replace("ı", "i").Replace("ş", "s").Replace("ğ", "g").Replace("ö", "o").Replace("ü", "u");

            // invalid chars, make into spaces
            trans = Regex.Replace(trans, @"[^a-z0-9\s-]", "");
            // convert multiple spaces/hyphens into one space       
            trans = Regex.Replace(trans, @"[\s-]+", " ").Trim();
            // cut and trim it
            trans = trans.Substring(0, trans.Length <= 100 ? trans.Length : 100).Trim();
            // hyphens
            trans = Regex.Replace(trans, @"\s", "-");

            return trans;
        }
        
        
         public static string ToSeo(this string phrase)
        {
            var str = phrase.RemoveAccent().ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }
        
        public static string RemoveAccent(this string txt)
        {
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return Encoding.ASCII.GetString(bytes);
        }
        

        static Seo()
        {

        }
    }
}
