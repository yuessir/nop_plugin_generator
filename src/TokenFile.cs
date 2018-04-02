using System.Collections.Generic;
using System.IO;

namespace NopPluginTemplator
{
    public class TokenFile {

        public Dictionary<string,string> Tokens {get; private set;}

        public TokenFile(string file){

            var lines = File.ReadAllLines(file);
            
            Tokens=new Dictionary<string, string>();
            foreach(var line in lines){
                var items = line.Split('=');
                var key = items[0].Trim();
                var value = items[1].Trim();
                Tokens.Add(key,value);
            }
        }

    }


}