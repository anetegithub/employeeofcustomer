using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebClient.Models;

namespace WebClient.ViewModels
{
    [NotMapped]
    public class EmployeeCreateViewModel : Employee
    {
        public int Sex { get; set; }
        public int Department { get; set; }
        public int Language { get; set; }
    }
}