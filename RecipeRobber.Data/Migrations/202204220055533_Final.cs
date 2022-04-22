namespace RecipeRobber.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feedbacks", "Recipe_RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Ingredients", "Recipe_RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Steps", "Recipe_RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Recipes", new[] { "CategoryId" });
            DropIndex("dbo.Feedbacks", new[] { "Recipe_RecipeId" });
            DropIndex("dbo.Ingredients", new[] { "Recipe_RecipeId" });
            DropIndex("dbo.Steps", new[] { "Recipe_RecipeId" });
            RenameColumn(table: "dbo.Recipes", name: "CategoryId", newName: "Category_CategoryId");
            AlterColumn("dbo.Recipes", "Category_CategoryId", c => c.Int());
            CreateIndex("dbo.Recipes", "Category_CategoryId");
            AddForeignKey("dbo.Recipes", "Category_CategoryId", "dbo.Categories", "CategoryId");
            DropColumn("dbo.Recipes", "CategoryType");
            DropColumn("dbo.Feedbacks", "Recipe_RecipeId");
            DropColumn("dbo.Ingredients", "Recipe_RecipeId");
            DropColumn("dbo.Steps", "Recipe_RecipeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Steps", "Recipe_RecipeId", c => c.Int());
            AddColumn("dbo.Ingredients", "Recipe_RecipeId", c => c.Int());
            AddColumn("dbo.Feedbacks", "Recipe_RecipeId", c => c.Int());
            AddColumn("dbo.Recipes", "CategoryType", c => c.String());
            DropForeignKey("dbo.Recipes", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Recipes", new[] { "Category_CategoryId" });
            AlterColumn("dbo.Recipes", "Category_CategoryId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Recipes", name: "Category_CategoryId", newName: "CategoryId");
            CreateIndex("dbo.Steps", "Recipe_RecipeId");
            CreateIndex("dbo.Ingredients", "Recipe_RecipeId");
            CreateIndex("dbo.Feedbacks", "Recipe_RecipeId");
            CreateIndex("dbo.Recipes", "CategoryId");
            AddForeignKey("dbo.Recipes", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Steps", "Recipe_RecipeId", "dbo.Recipes", "RecipeId");
            AddForeignKey("dbo.Ingredients", "Recipe_RecipeId", "dbo.Recipes", "RecipeId");
            AddForeignKey("dbo.Feedbacks", "Recipe_RecipeId", "dbo.Recipes", "RecipeId");
        }
    }
}
