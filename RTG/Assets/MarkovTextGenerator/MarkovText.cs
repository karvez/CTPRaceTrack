using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;

namespace MarkovText
{
    /// <summary>
    /// Markov Text generator.
    /// Kerem KAT
    /// </summary>
    public class MarkovText
    {
        private List<string> lstPrefix = new List<string>();
        private Hashtable htPrefix = new Hashtable();

        private string path;
        private const int prefixKelimeSayısı = 4;
        private const int outputKelimeSayısı = 200;

        private List<string> prefixler = new List<string>(prefixKelimeSayısı + 1);

        public MarkovText(string path)
        {
            this.path = path;
            InitHashtable();
        }

        private void InitHashtable()
        {
            string text = File.ReadAllText(path);

            int start = 0;
            int window = 1;

            while (start < text.Length - 1)
            {
                if (char.IsWhiteSpace(text.Substring(start, 1), 0))
                {
                    start++;
                    continue;
                }
                else
                {
                    if (!char.IsLetterOrDigit(text.Substring(start, 1), 0))
                    {
                        start++;
                        continue;
                    }

                    while ((text.Length > start + window) && !char.IsWhiteSpace(text[start + window]))
                        window++;
                    prefixler.Add(text.Substring(start, window));
                    if (prefixler.Count == prefixKelimeSayısı + 1)
                    {
                        string concat = "";
                        int i;
                        for (i = 0; i < prefixKelimeSayısı; i++)
                            concat += prefixler[i] + ' ';
                        if (htPrefix.ContainsKey(concat))
                            ((List<string>)(htPrefix[concat])).Add(prefixler[i]);
                        else
                        {
                            htPrefix.Add(concat, new List<string>(new string[] { prefixler[i] }));
                            lstPrefix.Add(concat);
                        }
                        prefixler.RemoveAt(0);
                    }
                    start += window;
                    window = 1;
                    continue;
                }
            }
        }

        public string GetMarkovText()
        {
            StringBuilder ret = new StringBuilder();
            string prefix;
            string nextPrefix;
            prefix = GetRandomPrefix();

            for (int i = 0; i < outputKelimeSayısı; i++)
            {
                while (!htPrefix.ContainsKey(prefix))
                    prefix = GetRandomPrefix();

                //ret.Append(prefix);
                string s = GetNextSuffix(prefix, out nextPrefix);
                if (s.Length > 0)
                {
                    prefix = nextPrefix;
                    ret.Append(s.Trim());
                    ret.Append(" ");
                }
            }
            return ret.ToString();
        }

        Random rnd = new Random();
        private string GetRandomPrefix()
        {
            return lstPrefix[rnd.Next(0, lstPrefix.Count - 1)];
        }

        private string GetNextSuffix(string prefix, out string nextPrefix)
        {
            if (htPrefix.ContainsKey(prefix))
            {
                List<string> lst = (List<string>)htPrefix[prefix];
                string suffix = lst[rnd.Next(0, lst.Count - 1)];
                List<string> lstpr = new List<string>((prefix + suffix).Split(new char[] { ' ' }));
                lstpr.RemoveAt(0);
                StringBuilder sbRet = new StringBuilder();
                foreach (string s in lstpr)
                    sbRet.Append(s + ' ');
                nextPrefix = sbRet.ToString();
                return suffix;
            }
            else
            {
                nextPrefix = "";
                return "";
            }
        }
    }

}
