namespace bankApp
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BankModel : DbContext
    {
        // Your context has been configured to use a 'BankModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'bankApp.BankModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BankModel' 
        // connection string in the application configuration file.
        public BankModel()
            : base("name=BankModel") // location of the dataBase, see app.config
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Account> Accounts { get; set; } // by this line of code, i'm telling EF to create a new table for the called account, looking at the scheme of the account class
        // 
        public virtual DbSet<Transaction> Transactions { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}