namespace KitchenCloudEntitiesHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderRecipeName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrayRecipes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrayRecipes", "Name");
        }
    }
}
