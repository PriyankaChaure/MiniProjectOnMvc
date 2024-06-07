namespace MiniProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminId = c.Long(nullable: false, identity: true),
                        FristName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        AuthorId = c.Long(nullable: false, identity: true),
                        AuthorName = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Long(nullable: false, identity: true),
                        BookName = c.String(),
                        BookDesc = c.String(),
                        AuthorId = c.Long(nullable: false),
                        SubjectId = c.Long(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Author", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SalesId = c.Long(nullable: false, identity: true),
                        CustomerId = c.Long(nullable: false),
                        SalesDate = c.DateTime(nullable: false),
                        BookId = c.Long(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SalesId)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectId = c.Long(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Long(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerAddress = c.String(),
                        CustomerEmail = c.String(),
                        CustomerPhone = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Sales", "BookId", "dbo.Book");
            DropForeignKey("dbo.Book", "AuthorId", "dbo.Author");
            DropIndex("dbo.Sales", new[] { "BookId" });
            DropIndex("dbo.Book", new[] { "SubjectId" });
            DropIndex("dbo.Book", new[] { "AuthorId" });
            DropTable("dbo.Customer");
            DropTable("dbo.Subject");
            DropTable("dbo.Sales");
            DropTable("dbo.Book");
            DropTable("dbo.Author");
            DropTable("dbo.Admin");
        }
    }
}
