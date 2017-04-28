namespace KitchenCloudEntitiesHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRecipeCategoryRedendancy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "Category_Id", "dbo.RecipeCategories");
            DropIndex("dbo.Recipes", new[] { "Category_Id" });
            DropColumn("dbo.Recipes", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "Category_Id", c => c.Int());
            CreateIndex("dbo.Recipes", "Category_Id");
            AddForeignKey("dbo.Recipes", "Category_Id", "dbo.RecipeCategories", "Id");
        }
    }
}
