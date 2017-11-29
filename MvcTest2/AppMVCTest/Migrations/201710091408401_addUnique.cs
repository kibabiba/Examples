namespace AppMVCTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Name", c => c.String(maxLength: 25));
            CreateIndex("dbo.Users", "Name", unique: true, name: "UserNameIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", "UserNameIndex");
            AlterColumn("dbo.Users", "Name", c => c.String());
        }
    }
}
