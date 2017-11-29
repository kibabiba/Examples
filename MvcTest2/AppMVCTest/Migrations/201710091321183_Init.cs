namespace AppMVCTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostTime = c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"),
                        MsgText = c.String(),
                        NameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.NameId, cascadeDelete: true)
                .Index(t => t.NameId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "NameId", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "NameId" });
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
        }
    }
}
