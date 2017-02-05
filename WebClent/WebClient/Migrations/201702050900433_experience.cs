namespace WebClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class experience : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Created = c.DateTime(nullable: false),
                        Changed = c.DateTime(nullable: false),
                        Employee_Id = c.Int(),
                        Language_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.ProgrammingLanguages", t => t.Language_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Language_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Experiences", "Language_Id", "dbo.ProgrammingLanguages");
            DropForeignKey("dbo.Experiences", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Experiences", new[] { "Language_Id" });
            DropIndex("dbo.Experiences", new[] { "Employee_Id" });
            DropTable("dbo.Experiences");
        }
    }
}
