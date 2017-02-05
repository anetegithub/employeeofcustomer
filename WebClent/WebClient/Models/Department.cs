using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    public class Department : Record
    {
        public string Title { get; set; }
        public int Tier { get; set; }
    }
}