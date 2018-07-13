using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NopPluginGenerator.Utility;
using NopPluginGenerator.Template;

namespace NopPluginGenerator
{
    class Program
    {        

        static void Main(string[] args)
        {
            
            // Check arguments
            if (args.Length != 5)
            {
                DisplayHelp();
                return;
            }

            // Get Parameters
            var templateName = args[0];
            var templateType= args[1];
            var templateVersion= args[2];
            var tokenFile = args[3];
            var outputFolder = args[4];

            Processor.Process(templateName, templateType, templateVersion, tokenFile, outputFolder);
        }
           

            // Customize file contents
           
        private static void DisplayHelp()
        {
            Console.WriteLine("Usage: {template_name} {template_type} {template_version} {token_file} {output_folder}");
            Console.WriteLine();
        }

        private static void DisplayError(string msg)
        {
            Console.WriteLine();
            Console.WriteLine($"[ERROR] {msg}");
        }



    }
}
