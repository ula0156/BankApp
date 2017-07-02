namespace bankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "CreatedDate");
        }
    }
}
