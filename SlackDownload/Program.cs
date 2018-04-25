using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace SlackDownload

{
    class Program {

        private static string SourceFolder = @"C:\Windows\Temp";

        public static void Main(string[] args) {
            // First check if any parameter is given, if none, show summary help
            if (args.Length == 0 || args == null) {
                ShowInfo();
            }
            else {
                // If parameters were given, test them and collect its information
                // ... Perform the test of for -h and then call the method ShowHelp()
                // ... Other parameters could be added / tested later... ;-)
            }
            // Execute the authentication (SlackAuthenticate)
            // Indicate the slack channel to access (ChooseChannel)
            // Collect the files to download (GetChannelFiles)
            // Effectively download the files to local "temp" (DownloadArchives)
            // Move files from local "temp" to final destination (CopyingArchives)
            // ... Don't forget to check exceptions on external / critical sections...
            // ... Hint:
            //     - Check for common operations on the methods below to possible isolation in
            //       standalone, generic and reusable methods
        }

        public static void ShowInfo() {
            // Show information about the application, including the -h parameter for a full help
            Console.WriteLine("Error 404, Parameters Not Found");
            Console.WriteLine("Type 'help' for more information");
        }

        public static void ShowHelp() {
            // This should print a full help, with all the supported parameters
            Console.WriteLine("\nParameters Accepted:\n\nFor user token, use xoxp-\n\nFor bot user token, use xoxb-\n\nFor workspace token, use xoxa- ");
        }
        
        public static async void SlackAuthenticate() {
            // Prepare the client HTTP request
            // Perform the call to the final URI entry point to validate your tokens
            // Serialize the JSON returned
        }

        public static async void ChooseChannel() {
            // Prepare the client HTTP request
            // Perform the call to the final URI entry point to get channel ID
            // Serialize the JSON returned
        }

        public static async void GetChannelFiles() {
            // Prepare the client HTTP request
            // Perform the call to the final URI entry point to get available files
            // Serialize the JSON returned
        }

        public static async void DownloadArchives() {
            // Prepare the client HTTP request
            // Perform the call to the final URI entry point to get the file
            // Serialize the JSON returned
            // Accept the file and save it to local "temp"
        }

        public static void CopyingArchives() {
            // Move the downloaded files to the final destination
        }
    }
}
