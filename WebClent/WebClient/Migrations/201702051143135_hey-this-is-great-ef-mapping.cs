namespace WebClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class heythisisgreatefmapping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Employees", "Sex_Id", "dbo.Sexes");
            DropForeignKey("dbo.Experiences", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Experiences", "Language_Id", "dbo.ProgrammingLanguages");
            DropIndex("dbo.Employees", new[] { "Department_Id" });
            DropIndex("dbo.Employees", new[] { "Sex_Id" });
            DropIndex("dbo.Experiences", new[] { "Employee_Id" });
            DropIndex("dbo.Experiences", new[] { "Language_Id" });
            AddColumn("dbo.Employees", "Sex", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Department", c => c.Int(nullable: false));
            AddColumn("dbo.Experiences", "Employee", c => c.Int(nullable: false));
            AddColumn("dbo.Experiences", "Language", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "Department_Id");
            DropColumn("dbo.Employees", "Sex_Id");
            DropColumn("dbo.Experiences", "Employee_Id");
            DropColumn("dbo.Experiences", "Language_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Experiences", "Language_Id", c => c.Int());
            AddColumn("dbo.Experiences", "Employee_Id", c => c.Int());
            AddColumn("dbo.Employees", "Sex_Id", c => c.Int());
            AddColumn("dbo.Employees", "Department_Id", c => c.Int());
            DropColumn("dbo.Experiences", "Language");
            DropColumn("dbo.Experiences", "Employee");
            DropColumn("dbo.Employees", "Department");
            DropColumn("dbo.Employees", "Sex");
            CreateIndex("dbo.Experiences", "Language_Id");
            CreateIndex("dbo.Experiences", "Employee_Id");
            CreateIndex("dbo.Employees", "Sex_Id");
            CreateIndex("dbo.Employees", "Department_Id");
            AddForeignKey("dbo.Experiences", "Language_Id", "dbo.ProgrammingLanguages", "Id");
            AddForeignKey("dbo.Experiences", "Employee_Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.Employees", "Sex_Id", "dbo.Sexes", "Id");
            AddForeignKey("dbo.Employees", "Department_Id", "dbo.Departments", "Id");
        }
    }
}
