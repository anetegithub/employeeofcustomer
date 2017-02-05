namespace WebClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employees : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Age = c.Int(nullable: false),
                        UserId = c.String(),
                        Created = c.DateTime(nullable: false),
                        Changed = c.DateTime(nullable: false),
                        Department_Id = c.Int(),
                        Sex_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .ForeignKey("dbo.Sexes", t => t.Sex_Id)
                .Index(t => t.Department_Id)
                .Index(t => t.Sex_Id);
            
            CreateTable(
                "dbo.Sexes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        UserId = c.String(),
                        Created = c.DateTime(nullable: false),
                        Changed = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Sex_Id", "dbo.Sexes");
            DropForeignKey("dbo.Employees", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Sex_Id" });
            DropIndex("dbo.Employees", new[] { "Department_Id" });
            DropTable("dbo.Sexes");
            DropTable("dbo.Employees");
        }
    }
}
