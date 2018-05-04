using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Globalization;
using Newtonsoft.Json;

//id, name, filetype and url_private_download
namespace SlackDownload
{
    public class Files
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string FileName { get; set; }

        [JsonProperty("filetype")]
        public int Filetype { get; set; }

        [JsonProperty("url_private_download")]
        public string Url { get; set; }
    }
}