namespace KitchenCloudEntitiesHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRecipeIdinTrayRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrayRecipes", "RecipeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrayRecipes", "RecipeId");
        }
    }
}
