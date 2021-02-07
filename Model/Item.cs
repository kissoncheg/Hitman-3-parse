using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hitman_3_parse.Model
{
    [Serializable]
    public class Item
    {
        public List<string> IdList;
        public List<string> LineBreaks;
        public Dictionary<long, Translate> SubStrings;

        public void Parse(string source, ref long id)
        {
            var r = new Regex(@"[A-Z0-9]{8}");
            var sss = source.Remove(source.IndexOf('\t'));
            var matches = r.Matches(sss);
            IdList = new List<string>();
            foreach (Match match in matches)
                if (match.Success)
                    IdList.Add(match.Value);
            r = new Regex(@"\/\/\(\d{1,}\.?\d{0,}\,\d{1,}\.?\d{1,}\)\\\\");
            matches = r.Matches(source);
            LineBreaks = new List<string>();
            foreach (Match match in matches)
                if (match.Success)
                    LineBreaks.Add(match.Value);

            var str = IdList.Aggregate("", (current, s) => current + s + ",");
            str = str.Remove(str.Length - 1);
            str += "\t";
            source = source.Replace(str, "");

            source = LineBreaks.Aggregate(source, (current, s) => current.Replace(s, "\n"));
            var sr = new StringReader(source);
            if (LineBreaks.Count > 0) str = sr.ReadLine();

            str = sr.ReadLine();
            SubStrings = new Dictionary<long, Translate>();
            while (str != null)
            {
                SubStrings.Add(id++, new Translate {English = str, Russian = string.Empty});
                str = sr.ReadLine();
            }
        }

        public string GetString()
        {
            var str = IdList.Aggregate("", (current, s) => current + s + ",");
            str = str.Remove(str.Length - 1) + "\t";
            if (LineBreaks.Count > 0)
            {
                var i = 0;
                return SubStrings.Aggregate(str, (current, pair) => current + $"{LineBreaks[i++]}{(string.IsNullOrEmpty(pair.Value.Russian) ? pair.Value.English : pair.Value.Russian)}");
            }
            return SubStrings.Aggregate(str, (current, pair) => current + $"{(string.IsNullOrEmpty(pair.Value.Russian) ? pair.Value.English : pair.Value.Russian)}");
            
        }
    }

    [Serializable]
    public class Translate
    {
        public string English { get; set; }
        public string Russian { get; set; }
    }
}