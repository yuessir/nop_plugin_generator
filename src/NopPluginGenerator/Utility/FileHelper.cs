using System;
using System.Diagnostics;
using System.IO;

namespace NopPluginGenerator.Utility
{
    public class FileHelper{      
    /// <summary>
        /// Method to Perform Xcopy to copy files/folders from Source machine to Target Machine
        /// </summary>
        /// <param name="SolutionDirectory"></param>
        /// <param name="TargetDirectory"></param>
       public static void ProcessXcopy(string solutionDirectory, string targetDirectory)
        {            
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            //Give the name as Xcopy
            startInfo.FileName = "xcopy";
            //make the window Hidden
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //Send the Source and destination as Arguments to the process
            startInfo.Arguments = "\"" + solutionDirectory + ".\" \"" + targetDirectory + "\"" + @" /e /y /I";
            
            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch (Exception exp)
            {
               throw exp;
            }
            System.Console.WriteLine("copied");
        }

        public static string[] GetFiles(string folder){

            return Directory.GetFiles(folder,"*.*",SearchOption.AllDirectories);

        }


}
}