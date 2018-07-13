using NopPluginGenerator.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NopPluginGenerator.Template
{
    public class Processor
    {
        static List<string> ignore = new List<string> { ".jpg", ".jpeg", ".svg", ".gif", ".png", ".ico" };
        static string templateFolder = System.Configuration.ConfigurationManager.AppSettings["TemplateFolder"];

        public static void Process(string templateName, string type, string version, string tokenFile, string outputFolder)
        {
            Dictionary<string, string> tokens = TokenFile.Load(tokenFile);
            AddSystemTokens(tokens);

            // Duplicate Template            
            Step1_DuplicateFolder(templateName, type, version, outputFolder);

            // Rename Files
            Step2_RenameFoldersAndFiles(tokens, outputFolder);

            // Customize file contents
            Step3_CustomizeTemplate(tokens, outputFolder);
        }

        private static void AddSystemTokens(Dictionary<string, string> tokens)
        {
            // Insert Project Guid to tokens
            if (!tokens.ContainsKey("PROJECT_GUID"))
            {
                var projectGuid = $"__{Guid.NewGuid().ToString()}__";
                tokens.Add("PROJECT_GUID", projectGuid);
            }
        }
        private static void Step1_DuplicateFolder(string template, string type, string version, string outputFolder)
        {
            var templateFolderName = Path.Combine(templateFolder, TemplateFolder.GetFolder(template, type, version));
            TemplateFolder.CopyTemplateToTarget(templateFolderName, outputFolder);
        }

        private static void Step2_RenameFoldersAndFiles(Dictionary<string, string> tokens, string outputFolder)
        {
            Console.Write("Renaming files & folders...");
            TokenizeFolders(outputFolder, tokens);
            TokenizeFiles(outputFolder, tokens);
            Console.WriteLine("done.");
        }


        private static void Step3_CustomizeTemplate(Dictionary<string, string> tokens, string outputFolder)
        {
            string[] files = FileHelper.GetFiles(outputFolder);

            foreach ( var file in files)
            {

                var fi = new FileInfo(file);

                if (ignore.Contains(fi.Extension))
                {
                    continue;
                }

                TemplateDoc template = new TemplateDoc(file);
                template.ReplaceTokens(tokens);

                string fileContents = template.GetTemplateText();                

                File.WriteAllText(file, fileContents);
            }
        }

        public static void TokenizeFolders(string outputFolder, Dictionary<string, string> tokens)
        {
            var folders = Directory.GetDirectories(outputFolder, "*.*", SearchOption.AllDirectories);
            foreach (var folder in folders)
            {
                var newFolderName = TemplateDoc.ReplaceTokens(tokens, folder);
                if (folder == newFolderName)
                {
                    continue;
                }
                Directory.Move(folder, newFolderName);
            }
        }

        public static void TokenizeFiles(string outputFolder, Dictionary<string, string> tokens)
        {
            var files = Directory.GetFiles(outputFolder, "*.*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var newFileName = TemplateDoc.ReplaceTokens(tokens, file);
                if (file == newFileName)
                {
                    continue;
                }
                if (File.Exists(newFileName)) File.Delete(newFileName);
                File.Move(file, newFileName);
            }

        }
    }
}
