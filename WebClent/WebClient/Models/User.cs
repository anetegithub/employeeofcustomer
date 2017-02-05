using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    public class User : Record
    {
        public string Login { get; set; }
        public string Pwd { get; set; }
    }
}