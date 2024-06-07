namespace MiniProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sales", "SalesDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sales", "SalesDate", c => c.DateTime(nullable: false));
        }
    }
}
