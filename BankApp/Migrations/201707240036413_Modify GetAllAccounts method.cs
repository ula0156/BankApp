namespace bankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyGetAllAccountsmethod : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "AccountName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Accounts", "EmailAddress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "EmailAddress", c => c.String());
            AlterColumn("dbo.Accounts", "AccountName", c => c.String());
        }
    }
}
