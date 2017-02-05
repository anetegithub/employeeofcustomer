using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebClient.Models;

namespace WebClient.Contexts
{
    public class SiteDbContext : DbContext
    {
        public SiteDbContext()
            : base("name=Site")
        {
        }

        public static SiteDbContext Create()
        {
            return new SiteDbContext();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ProgrammingLanguage> Languages { get; set; }
        public DbSet<Sex> Sex { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<RecordedRequest> Requests { get; set; }
    }
}