namespace WebClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class program_lang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProgrammingLanguages",
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
            DropTable("dbo.ProgrammingLanguages");
        }
    }
}
