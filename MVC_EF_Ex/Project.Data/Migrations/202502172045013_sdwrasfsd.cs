namespace Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdwrasfsd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "IsDeleted", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "IsDeleted", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "IsDeleted", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "IsDeleted", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsDeleted");
            DropColumn("dbo.Orders", "IsDeleted");
            DropColumn("dbo.Products", "IsDeleted");
            DropColumn("dbo.Categories", "IsDeleted");
        }
    }
}
