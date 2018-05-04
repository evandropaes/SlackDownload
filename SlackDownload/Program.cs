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

        

        private static string DestinationFolder = @"C:\SlackArchives";
        private static readonly HttpClient client = new HttpClient();


        public static int Main(string[] args) {
            
            bool show_help = false;
            string instance_name = "";
            string token = "";
            string channel_name = "";
            List<string> file_types = new List<string>();

            var p = new OptionSet() {
                { "h|help", "Show this message and exit.", v => show_help = (v != null) },
                { "r|remote=", "Inform the Slack instance name to connect.", v => instance_name = v },
                { "i|id=", "Inform the Slack user token to authenticate.", v => token = v },
                { "c|channel=", "Inform the Slack channel to connect to.", v => channel_name = v },
                { "t|filetype=", "Inform the extensions to download.", v => file_types.Add(v) }
            };
            List<string> parsedValues;
            try {
                parsedValues = p.Parse(args);
            }
            catch (OptionException failure) {
                Console.Write("SlackDownload: ");
                Console.WriteLine(failure.Message);
                Console.WriteLine("Try 'SlackDownload --help' for more information.");
                return 1;
            }

            // Check for required parameters
            if (!show_help && (instance_name.Length == 0 || token.Length == 0 ||
                               channel_name.Length == 0)) {
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
                      
            Console.Write("Instance name: ");
            Console.WriteLine(instance_name);
            Console.Write("User token: ");
            Console.WriteLine(token);
            Console.Write("Channel name: ");
            Console.WriteLine(channel_name);
            Console.Write("File Types: ");
            foreach(var type in file_types)
            {
                Console.WriteLine(type);
            }
            var files = GetChannelFiles(token, channel_name).Result;

            foreach (var file in files)
            {
                Console.WriteLine(file.Id);
                Console.WriteLine(file.FileName);
                Console.WriteLine(file.Filetype);
                Console.WriteLine(file.Url);         
                Console.WriteLine();
            }
        

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

        private static async Task<List<Files>> GetChannelFiles(string token, string channel)
        {
            var serializer = new DataContractJsonSerializer(typeof(List<Files>));

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync("https://slack.com/api/files.list" +  "?token=" + token + "&channel=" + channel);
            var streamTask = client.GetStreamAsync("https://slack.com/api/files.list" +  "?token=" + token + "&channel=" + channel);
            var files = serializer.ReadObject(await streamTask) as List<Files>;
            Console.Write(files);
            return files;
        }

        public static async void DownloadArchives() {
            // Prepare the client HTTP request
            // Perform the call to the final URI entry point to get the file
            // Serialize the JSON returned
            // Accept the file and save it to local "temp"
        }
        public static void CreateFolder()
        {
            if (!Directory.Exists(DestinationFolder))
            {
                System.IO.Directory.CreateDirectory(DestinationFolder);
            }
            
        }
        public static void CopyingArchives() {

            // Move the downloaded files to the final destination
        }
    }
}
//string token = "xoxp-345057989283-346045397718-359698302215-7287ca3e557ed8aa505181a497f2882c";
//string channel = "CA61C9H7Y";
//var slack_client_id = "345057989283.352648811969";
//var slack_client_secret = "bdfa71c098b41c9f26fc5ea0eb700af2"