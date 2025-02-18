namespace DBWebForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsa : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "Category_Id1" });
            DropColumn("dbo.Products", "Category_Id");
            RenameColumn(table: "dbo.Products", name: "Category_Id1", newName: "Category_Id");
            AlterColumn("dbo.Products", "Category_Id", c => c.Int());
            CreateIndex("dbo.Products", "Category_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "Category_Id" });
            AlterColumn("dbo.Products", "Category_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "Category_Id1");
            AddColumn("dbo.Products", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Category_Id1");
        }
    }
}
