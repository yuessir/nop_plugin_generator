using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NopPluginTemplator.Utility;

namespace NopPluginTemplator
{
    class Program
    {
        private const string TemplateConfigFile = "templates.xml";

        static void Main(string[] args)
        {
            // Check arguments
            if (args.Length < 3)
            {
                DisplayHelp();
                return;
            }

            // Get Parameters
            var templateName = args[0];
            var tokenfile = args[1];
            var outputFolder = args[2];

            // Load Template Config
            var templateConfig = XmlSerializationHelper.Load<TemplateConfig>(TemplateConfigFile);
            var templateMap = templateConfig.Templates.FirstOrDefault(t => String.Equals(t.TemplateName, templateName, StringComparison.CurrentCultureIgnoreCase));
            if (templateMap == null)
            {
                DisplayHelp();
                DisplayError($"Template mapping '{templateName}' does not exist.");
                return;
            }
            if (!Directory.Exists(templateMap.TemplateFolder))
            {
                DisplayHelp();
                DisplayError($"{templateMap.TemplateFolder} does not exist.");
                return;
            }
            var templateFolder = templateMap.TemplateFolder;

            // Load Tokens from file
            if (!File.Exists(tokenfile))
            {
                DisplayHelp();
                DisplayError($"Token file '{tokenfile}' does not exist.");
                return;
            }
            Dictionary<string, string> tokens;
            try
            {
                tokens = new TokenFile(tokenfile).Tokens;
            }
            catch
            {
                DisplayHelp();
                DisplayError("Invalid token file");
                return;
            }

            // Insert Project Guid to tokens
            if (!tokens.ContainsKey("PROJECT_GUID"))
            {
                var projectGuid = $"{{{Guid.NewGuid().ToString()}}}";
                tokens.Add("PROJECT_GUID", projectGuid);
            }

            // Duplicate Template
            outputFolder = Path.Combine(outputFolder, $"{tokens["NAMESPACE_PREFIX"]}.{tokens["PROJECT_NAME"]}");
            CopyTemplateToTarget(templateFolder, outputFolder);

            // Rename Files
            TokenizeFolders(outputFolder, tokens);
            TokenizeFiles(outputFolder, tokens);

            // Customize file contents
            CustomizeTemplate(outputFolder, tokens);
        }


        private static void CopyTemplateToTarget(string templateFolder, string outputFolder)
        {
            FileHelper.ProcessXcopy(templateFolder, outputFolder);
        }

        private static void CustomizeTemplate(string folder, Dictionary<string, string> tokens)
        {
            var ignore = new List<string> { ".jpg", ".jpeg", ".svg", ".gif", ".png", ".ico" };
            // var template = new TemplateFolder().GetTemplate(templateName);
            // template.ReplaceTokens(tokens);
            // var finalTemplate = template.GetTemplateText();
            var files = FileHelper.GetFiles(folder);
            foreach (var file in files)
            {
                var fi = new FileInfo(file);

                if (ignore.Contains(fi.Extension))
                {
                    continue;
                }

                var fileText = File.ReadAllText(file);
                var template = new Template(fileText);
                template.ReplaceTokens(tokens);
                fileText = template.GetTemplateText();

                var fileTemplate = new Template(file);
                fileTemplate.ReplaceTokens(tokens);
                var newFilename = fileTemplate.GetTemplateText();
                if (file == newFilename)
                {
                    File.WriteAllText(file, fileText);
                }
                else
                {
                    File.WriteAllText(newFilename, fileText);
                    File.Delete(file);
                }
            }
        }

        private static void TokenizeFolders(string outputFolder, Dictionary<string, string> tokens)
        {
            var folders = Directory.GetDirectories(outputFolder, "*.*", SearchOption.AllDirectories);
            foreach (var folder in folders)
            {
                var template = new Template(folder);
                template.ReplaceTokens(tokens);
                var newFolder = template.GetTemplateText();
                if (folder == newFolder)
                {
                    continue;
                }
                Directory.Move(folder, newFolder);
            }

        }

        private static void TokenizeFiles(string outputFolder, Dictionary<string, string> tokens)
        {
            var files = Directory.GetFiles(outputFolder, "*.*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var template = new Template(file);
                template.ReplaceTokens(tokens);
                var newFile = template.GetTemplateText();
                newFile = newFile.Replace(".cstemplate", ".cs");
                newFile = newFile.Replace(".csprojtemplate", ".csproj");
                if (file == newFile)
                {
                    continue;
                }
                File.Move(file, newFile);
            }

        }


        private static void DisplayHelp()
        {
            Console.WriteLine("Usage: {template name} {token file} {output folder}");
            Console.WriteLine();
            Console.WriteLine("  Templates:");
            Console.WriteLine();
            var cfg = LoadTemplateConfig();
            foreach (var map in cfg.Templates)
            {
                Console.WriteLine($"   {map.TemplateName}");
            }

            if (cfg.Templates.Count == 0)
            {
                Console.WriteLine("  {No template mappings exist}");
            }
        }

        private static void DisplayError(string msg)
        {
            Console.WriteLine();
            Console.WriteLine($"[ERROR] {msg}");
        }

        private static TemplateConfig LoadTemplateConfig()
        {
            if (File.Exists(TemplateConfigFile)) return XmlSerializationHelper.Load<TemplateConfig>(TemplateConfigFile);
            var tc = new TemplateConfig();
            tc.Templates.Add(new TemplateMapping() { TemplateName = "example", TemplateFolder = "templates\\example" });
            XmlSerializationHelper.Save(TemplateConfigFile, tc);
            return LoadTemplateConfig();
        }


    }
}
