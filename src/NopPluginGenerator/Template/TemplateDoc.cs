using System.Collections.Generic;

namespace NopPluginGenerator.Template
{
    public class TemplateDoc
    {
        private string _template;

        public TemplateDoc(string filePath)
        {
            _template = System.IO.File.ReadAllText(filePath);
        }

        public static string ReplaceToken(string template, string tokenName, string value)
        {
            return template.Replace("{{" + tokenName + "}}", value);
        }

        public static string ReplaceTokens(Dictionary<string, string> tokens, string template)
        {
            while (ContainsTokens(tokens, template))
            {
                foreach (var kvp in tokens)
                {
                    template = ReplaceToken(template, kvp.Key, kvp.Value);
                }
            }
            return template;
        }

        
        public void ReplaceTokens(Dictionary<string, string> tokens)
        {
            while (ContainsTokens(tokens, _template))
            {
                foreach (var kvp in tokens)
                {
                    _template = ReplaceToken(_template, kvp.Key, kvp.Value);
                }
            }
        }

        public string GetTemplateText()
        {
            return _template;
        }

        private static bool ContainsTokens(Dictionary<string, string> tokens, string template)
        {
            foreach (var token in tokens)
            {
                if (template.Contains("{{"+token.Key+"}}"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
