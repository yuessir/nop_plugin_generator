using NopPluginGenerator.Utility;
using System;
using System.IO;

namespace NopPluginGenerator.Template
{
    public class TemplateFolder
    {
        public static string GetFolder(string template, string type, string version)
        {
            return Path.Combine(template, version, type);
        }

        public static void CopyTemplateToTarget(string templateFolder, string outputFolder)
        {
            Console.WriteLine($"Copying {templateFolder} to {outputFolder}");
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }
            FileHelper.ProcessXcopy(templateFolder, outputFolder);
        }
    }
}
