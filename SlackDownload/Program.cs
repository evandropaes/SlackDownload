using System;
using System.IO;

namespace SlackDownload

{
    class Program
    {

        string SourceFolder = @"C:\Windows\Temp";

        static void Main(string[] args)
        {
            if (args.Length == 0 || args == null)
            {
                ShowError();
            }
            
            string help = Console.ReadLine().ToLower();
            if (help == "help")
            {
                ShowFullHelp();
            }
            Console.ReadKey();
        }

        public static void ShowError()
        {
            Console.WriteLine("Error 404, Parameters Not Found");
            Console.WriteLine("Type 'help' for more information");
        }

        public static void ShowFullHelp()
        {
            Console.WriteLine("\nParameters Accepted:\n\nFor user token, use xoxp-\n\nFor bot user token, use xoxb-\n\nFor workspace token, use xoxa- ");
        }
        
        public static void SlackAutenticate()
        {

        }

        public static void ChooseChannel()
        {

        }

        public static void DownloadArchives()
        {
            
        }

        public static void CopyingArchives()
        {
            
        }
        
    }
}