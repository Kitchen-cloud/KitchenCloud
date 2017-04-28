namespace KitchenCloudEntitiesHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedContryRedendancy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Buyers", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Recipes", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Sellers", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Buyers", new[] { "Country_Id" });
            DropIndex("dbo.Recipes", new[] { "Country_Id" });
            DropIndex("dbo.Sellers", new[] { "Country_Id" });
            DropColumn("dbo.Buyers", "Country_Id");
            DropColumn("dbo.Recipes", "Country_Id");
            DropColumn("dbo.Sellers", "Country_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sellers", "Country_Id", c => c.Int());
            AddColumn("dbo.Recipes", "Country_Id", c => c.Int());
            AddColumn("dbo.Buyers", "Country_Id", c => c.Int());
            CreateIndex("dbo.Sellers", "Country_Id");
            CreateIndex("dbo.Recipes", "Country_Id");
            CreateIndex("dbo.Buyers", "Country_Id");
            AddForeignKey("dbo.Sellers", "Country_Id", "dbo.Countries", "Id");
            AddForeignKey("dbo.Recipes", "Country_Id", "dbo.Countries", "Id");
            AddForeignKey("dbo.Buyers", "Country_Id", "dbo.Countries", "Id");
        }
    }
}
