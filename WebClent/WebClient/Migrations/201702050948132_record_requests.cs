namespace WebClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class record_requests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecordedRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Refferer = c.String(),
                        Url = c.String(),
                        Device = c.String(),
                        Browser = c.String(),
                        Ip = c.String(),
                        User = c.String(),
                        UserId = c.String(),
                        Created = c.DateTime(nullable: false),
                        Changed = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RecordedRequests");
        }
    }
}
