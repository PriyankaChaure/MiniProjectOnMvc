namespace MiniProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesNavigation : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Sales", "CustomerId");
            AddForeignKey("dbo.Sales", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Sales", new[] { "CustomerId" });
        }
    }
}
