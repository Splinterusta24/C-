namespace DBWebForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kaan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            AddColumn("dbo.Products", "Category_Id1", c => c.Int());
            AlterColumn("dbo.Products", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Category_Id1");
            AddForeignKey("dbo.Products", "Category_Id1", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_Id1", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_Id1" });
            AlterColumn("dbo.Products", "Category_Id", c => c.Int());
            DropColumn("dbo.Products", "Category_Id1");
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
