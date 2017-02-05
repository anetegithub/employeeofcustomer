using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClient.Models;

namespace WebClient.ViewModels
{
    public class EmployeeViewModel
    {
        public List<ProgrammingLanguage> Languages { get; set; }
        public List<Department> Departments { get; set; }
        public List<Sex> Sexs { get; set; }
    }
}