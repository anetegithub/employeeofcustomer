using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    public class Employee : Record
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public int Department { get; set; }
        [NotMapped]
        public int Language { get; set; }
        [NotMapped]
        public int Experience { get; set; }
    }
}