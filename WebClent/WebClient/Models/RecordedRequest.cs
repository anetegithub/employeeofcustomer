using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    public class RecordedRequest : Record
    {
        public string Refferer { get; set; }
        public string Url { get; set; }
        public string Device { get; set; }
        public string Browser { get; set; }
        public string Ip { get; set; }
        public string User { get; set; }
    }
}