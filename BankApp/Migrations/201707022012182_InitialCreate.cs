namespace bankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountNumber = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        EmailAddress = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TypeOfAccount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountNumber);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        TransactionDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionType = c.Int(nullable: false),
                        AccountNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Accounts", t => t.AccountNumber, cascadeDelete: true)
                .Index(t => t.AccountNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "AccountNumber", "dbo.Accounts");
            DropIndex("dbo.Transactions", new[] { "AccountNumber" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Accounts");
        }
    }
}
