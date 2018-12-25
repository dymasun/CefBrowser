using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExamBrowser.utils
{
    class IniKit
    {
        private Dictionary<string, Dictionary<string, string>> ini;
        public IniKit(string path)
        {
            ini = new Dictionary<string, Dictionary<string, string>>();
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            line = sr.ReadLine();
            while (true)
            {
                if (line == null) break;
                if (line.Length == 0 || line == "")
                {
                    continue;
                }
                if (Regex.Matches(line, @"(?<=\[).+(?=\])").Count > 0)
                {
                    string temp = Regex.Matches(line, @"(?<=\[).+(?=\])")[0].Value;
                    //temp = temp.Substring(0, temp.Length - 1);
                    this.addSetion(temp);
                    while ((line = sr.ReadLine()) != null && (Regex.Matches(line, @"(?<=\[).+(?=\])").Count == 0))
                    {
                        if (line.Length == 0 || line == "")
                        {
                            continue;
                        }
                        string[] strs = line.Split('=');
                        string value = "";
                        for(int i=1;i<strs.Length;i++)
                        {
                            value += "="+strs[i] ;
                        }
                        value = value.Substring(1);
                        this.addItem(temp, strs[0], value);
                    }
                }
            }
        }
       
        
        public void addSetion(string setion)
        {
            ini.Add(setion, new Dictionary<string, string>());
        }
       
        
        public void addItem(string setion, string key, string value)
        {
            ini[setion].Add(key, value);
        }
      
        public Dictionary<string, Dictionary<string, string>>.KeyCollection getSetions()
        {
            return ini.Keys;
        }
        
        
        public string getValue(string setion, params string[] keys)
        {
            string str = "";
            foreach (string _str in keys)
            {
                str += ini[setion][_str];
            }
            return str;
        }
       
        public string getVal(string setion, string key)
        {
            return ini[setion][key];
        }
     
        
        public Dictionary<string, string> this[string key]
        {
            get
            {
                return ini[key];
            }
            set
            {
                ini[key] = value;
            }
        }
    }
}
