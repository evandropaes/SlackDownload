using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Globalization;

//id, name, filetype and url_private_download
namespace SlackDownload
{
    [DataContract(Name = "files")]
    public class Files
    {
        [DataMember(Name = "id")]
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        private string _id;

        [DataMember(Name = "name")]
        public string FileName { get; set; }

        [DataMember(Name = "filetype")]
        public string Filetype { get; set; }

        [DataMember(Name = "url_private_download")]
        public string Url { get; set; }
        
    }
}