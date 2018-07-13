using System;
using System.Collections.Generic;
using System.IO;

namespace NopPluginGenerator.Template
{
    public class TokenFile
    {        

        public static Dictionary<string, string> Load(string file)
        {   
            var tokens = new Dictionary<string, string>();
            var lines = System.IO.File.ReadAllLines(file);
            foreach (var line in lines)
            {
                string[] kvp;
                if (TryParse(line, out kvp))
                {
                    tokens.Add(kvp[0], kvp[1]);
                }
                else
                {
                    Console.WriteLine($"Could not parse: {line}");
                }
            }
            return tokens;
        }

        private static bool TryParse(string line, out string[] kvp)
        {
            var items = line.Split('=');
            if (items.Length != 2)
            {
                kvp = new string[] {};
                return false;
            }
            var key = items[0].Trim();
            var value = items[1].Trim();

            kvp = new[] { key, value };
            return true;
        }

    }


}