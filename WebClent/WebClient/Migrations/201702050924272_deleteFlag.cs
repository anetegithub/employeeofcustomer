namespace WebClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sexes", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Experiences", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProgrammingLanguages", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Deleted");
            DropColumn("dbo.ProgrammingLanguages", "Deleted");
            DropColumn("dbo.Experiences", "Deleted");
            DropColumn("dbo.Sexes", "Deleted");
            DropColumn("dbo.Employees", "Deleted");
            DropColumn("dbo.Departments", "Deleted");
        }
    }
}
