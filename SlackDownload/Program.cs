// Run this at Project root: 'dotnet add package Mono.Options --version 5.3.0.1'

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Mono.Options;

namespace SlackDownload

{
    class Program {

        private static string SourceFolder = @"C:\Windows\Temp";

        public static int Main(string[] args) {
            // Set some variables to default values
            bool show_help = false;
            string instance_name = "";
            string user_name = "";
            string password = "";
            string channel_name = "";
            List<string> file_types = new List<string>();

            var p = new OptionSet() {
                { "h|help", "Show this message and exit.", v => show_help = (v != null) },
                { "r|remote=", "Inform the Slack instance name to connect.", v => instance_name = v },
                { "u|user=", "Inform the Slack user to authenticate.", v => user_name = v },
                { "p|password=", "Inform the Slack user password to authenticate.", v => password = v },
                { "c|channel=", "Inform the Slack channel to connect to.", v => channel_name = v },
                { "t|filetype=", "Inform the extensions to download.", v => file_types.Add(v) }
            };
            List<string> extraParms;
            try {
                extraParms = p.Parse(args);
            }
            catch (OptionException failure) {
                Console.Write("SlackDownload: ");
                Console.WriteLine(failure.Message);
                Console.WriteLine("Try 'SlackDownload --help' for more information.");
                return 1;
            }

            // Check for required parameters
            if (!show_help && (instance_name.Length == 0 || user_name.Length == 0 ||
                               password.Length == 0 || channel_name.Length == 0)) {
                Console.Write("SlackDownload: ");
                Console.WriteLine("Missing required parameters!");
                Console.WriteLine("Try 'SlackDownload --help' for more information.");
                return 1;
            }

            // If help requested, show it an exit
            if (show_help) {
                ShowHelp(p);
                return 0;
            }


            // If parameters were given, test them and collect its information
            // ... Perform the test of for -h and then call the method ShowHelp()
            // ... Other parameters could be added / tested later... ;-)

            // As the default

            // Execute the authentication (SlackAuthenticate)
            // Indicate the slack channel to access (ChooseChannel)
            // Collect the files to download (GetChannelFiles)
            // Effectively download the files to local "temp" (DownloadArchives)
            // Move files from local "temp" to final destination (CopyingArchives)
            // ... Don't forget to check exceptions on external / critical sections...
            // ... Hint:
            //     - Check for common operations on the methods below to possible isolation in
            //       standalone, generic and reusable methods

            // As a debug mesure, tries to print all received parameters
            Console.Write("Instance name: ");
            Console.WriteLine(instance_name);
            Console.Write("User name: ");
            Console.WriteLine(user_name);
            Console.Write("User password: ");
            Console.WriteLine(password);
            Console.Write("Channel name: ");
            Console.WriteLine(channel_name);
            return 0;
        }

        public static void ShowHelp(OptionSet p) {
            // This should print a full help, with all the supported parameters
            Console.WriteLine("Usage: SlackDownload [OPTIONS]+");
            Console.WriteLine("Tries to connect to given slack channel and download selected files");
            Console.WriteLine();
            Console.WriteLine("Valid options:");
            p.WriteOptionDescriptions(Console.Out);
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


// var slack_client_id = "345057989283.352648811969";
// var slack_client_secret = "bdfa71c098b41c9f26fc5ea0eb700af2"