namespace RecipeRobber.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Almost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Recipes", new[] { "Category_CategoryId" });
            DropColumn("dbo.Recipes", "Category_CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "Category_CategoryId", c => c.Int());
            CreateIndex("dbo.Recipes", "Category_CategoryId");
            AddForeignKey("dbo.Recipes", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
