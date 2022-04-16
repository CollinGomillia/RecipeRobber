namespace RecipeRobber.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "MakeTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "MakeTime", c => c.Int(nullable: false));
        }
    }
}
