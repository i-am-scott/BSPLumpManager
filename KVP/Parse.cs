using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BSPLumpManager.KVP
{
    public class KeyValueGroup
    {
        public int id;
        public string raw;
        public bool enabled = true;
        public Dictionary<string, string> keys = new Dictionary<string, string>();
    }

    class Parser
    {
        static private string kvp_c = @"{[^}]+}";
        static private string kvp_g = "^(\".+\") (\".+\")$";

        public static List<KeyValueGroup> Parse(string contents)
        {
            List<KeyValueGroup> kvp_groups = new List<KeyValueGroup>();

            Regex r      = new Regex(kvp_c, RegexOptions.Singleline);
            Regex pair_r = new Regex(kvp_g, RegexOptions.Multiline);

            foreach (Match match in r.Matches(contents))
            {
                string content         = match.ToString();
                KeyValueGroup kv_group = new KeyValueGroup() {
                    id  = kvp_groups.Count,
                    raw = content
                };

                foreach (Match tuple in pair_r.Matches(content))
                {
                    string key = tuple.Groups[1].Value;
                    string val = tuple.Groups[2].Value;

                    key = key.Substring(1, key.Length - 2);
                    val = val.Substring(1, val.Length - 2);

                    if (!kv_group.keys.ContainsKey(key))
                        kv_group.keys.Add(key, val);
                }

                kvp_groups.Add(kv_group);
            }
            return kvp_groups;
        }
    }
}