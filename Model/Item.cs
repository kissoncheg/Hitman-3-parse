using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hitman_3_parse.Model
{
    [Serializable]
    public class Item
    {
        
        public List<string> IdList;
        public List<string> LineBreaks;
        public Dictionary<long, Translate>  SubStrings;

        public void Parse(string source, ref long id)
        {
            
            Regex r = new Regex(@"[A-Z0-9]{8}");
            string sss = source.Remove(source.IndexOf('\t'));
            var matches = r.Matches(sss);
            IdList = new List<string>();
            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    
                    IdList.Add(match.Value);
                    
                }
            }
            r = new Regex(@"\/\/\(\d{1,}\.?\d{0,}\,\d{1,}\.?\d{1,}\)\\\\");
            matches = r.Matches(source);
            LineBreaks = new List<string>();
            foreach (Match match in matches)
            {
                if (match.Success)

                {
                    LineBreaks.Add(match.Value);

                }
            }

            string str = IdList.Aggregate("", (current, s) => current + (s + ","));
            str = str.Remove(str.Length - 1);
            str += "\t";
            source = source.Replace(str,"");
            
            source = LineBreaks.Aggregate(source, (current, s) => current.Replace(s, "\n"));
            StringReader sr = new StringReader(source);
            if (LineBreaks.Count > 0)
            {
                str = sr.ReadLine(); 
            }
            
            str = sr.ReadLine();
            SubStrings =  new Dictionary<long, Translate>();
            while (str!=null)
            {
                SubStrings.Add(id++,new Translate{English = str,Russian = String.Empty});
                str = sr.ReadLine();
            }
        }

        public string GetString()
        {
            string str = IdList.Aggregate("", (current, s) => current + (s + ","));
            str = str.Remove(str.Length - 1)+"\t";
            if (LineBreaks.Count > 0)
            {
                int i = 0;
                foreach (KeyValuePair<long, Translate> pair in SubStrings)
                {
                    str += $"{LineBreaks[i++]}{(string.IsNullOrEmpty(pair.Value.Russian) ? pair.Value.English:pair.Value.Russian)}";
                }
            }
            else
            {
                foreach (KeyValuePair<long, Translate> pair in SubStrings)
                {
                    str += $"{(string.IsNullOrEmpty(pair.Value.Russian) ? pair.Value.English : pair.Value.Russian)}";
                }
            }

            return str;
        }
    }
    [Serializable]
    public class Translate
    {
        public string English { get; set; }
        public string Russian { get; set; }
    }
}
