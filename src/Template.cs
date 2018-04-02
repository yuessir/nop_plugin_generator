using System.Collections.Generic;

namespace NopPluginTemplator
{  
    public class Template{
        private string _template;

        public Template(string template){
            _template=template;
        }
        public void ReplaceToken(string tokenName, string value){
            var token = "{{"+tokenName+"}}";
            _template = _template.Replace(token,value);
        }

        public void ReplaceTokens(Dictionary<string,string> tokens){
            while(ContainsTokens(tokens)){
                foreach(var kvp in tokens){
                    ReplaceToken(kvp.Key,kvp.Value);
                }
            }
        }

        public string GetTemplateText(){
            return _template;
        }

        private bool ContainsTokens(Dictionary<string,string> tokens){
            foreach(var token in tokens){
                if(_template.Contains(token.Key)){
                    return true;
                }
            }
            return false;
        }
    }
}
