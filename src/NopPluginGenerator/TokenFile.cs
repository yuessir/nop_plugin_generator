using System;
using System.Collections.Generic;
using System.IO;

namespace NopPluginGenerator
{
    public class TokenFile
    {

        public Dictionary<string, string> Tokens { get; private set; }

        public TokenFile(string file)
        {
            var lines = File.ReadAllLines(file);

            Tokens = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                string[] kvp;
                if (TryParse(line, out kvp))
                {
                    Tokens.Add(kvp[0], kvp[1]);
                }
                else
                {
                    Console.WriteLine($"Could not parse: {line}");
                }
            }
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