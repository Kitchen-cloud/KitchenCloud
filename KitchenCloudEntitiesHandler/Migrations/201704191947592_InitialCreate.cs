namespace KitchenCloudEntitiesHandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Email = c.String(),
                        Description = c.String(),
                        Password = c.String(),
                        Gender = c.String(),
                        City_Id = c.Int(),
                        Country_Id = c.Int(),
                        ProfileImage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.ProfileImages", t => t.ProfileImage_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.ProfileImage_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfileImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FolderPath = c.String(),
                        ImageName = c.String(),
                        Caption = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FavoriteRecipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Recipe_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Recipe_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Ratings = c.Single(nullable: false),
                        TotalOrders = c.Int(nullable: false),
                        Description = c.String(),
                        PersonsFor = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        StreeAddress = c.String(),
                        Category_Id = c.Int(),
                        City_Id = c.Int(),
                        Country_Id = c.Int(),
                        Seller_Id = c.Int(),
                        SubCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecipeCategories", t => t.Category_Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.Sellers", t => t.Seller_Id)
                .ForeignKey("dbo.RecipeSubCategories", t => t.SubCategory_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.Seller_Id)
                .Index(t => t.SubCategory_Id);
            
            CreateTable(
                "dbo.RecipeCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipeImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FolderPath = c.String(),
                        ImageName = c.String(),
                        Caption = c.String(),
                        ImagePriority = c.Int(nullable: false),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.RecipeReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stars = c.Double(nullable: false),
                        FeedBack = c.String(),
                        Order_Id = c.Int(),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderStatus = c.Int(nullable: false),
                        BuyerId = c.Int(nullable: false),
                        OrderDate = c.String(),
                        DueDate = c.String(),
                        OrderTime = c.Int(nullable: false),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrayRecipes", t => t.Recipe_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.TrayRecipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Category = c.String(),
                        ImageUrl = c.String(),
                        SubCategory = c.String(),
                        Price = c.Single(nullable: false),
                        Seller_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sellers", t => t.Seller_Id)
                .Index(t => t.Seller_Id);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rank = c.Single(nullable: false),
                        TotalOrders = c.Int(nullable: false),
                        InstantBake = c.Boolean(nullable: false),
                        FastDelivery = c.Boolean(nullable: false),
                        AvailableForJob = c.Boolean(nullable: false),
                        Reviews = c.Int(nullable: false),
                        Visitors = c.Int(nullable: false),
                        Slogan = c.String(),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Email = c.String(),
                        Description = c.String(),
                        Password = c.String(),
                        Gender = c.String(),
                        City_Id = c.Int(),
                        Country_Id = c.Int(),
                        ProfileImage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.ProfileImages", t => t.ProfileImage_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.ProfileImage_Id);
            
            CreateTable(
                "dbo.RecipeTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.RecipeSubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RecipeCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecipeCategories", t => t.RecipeCategory_Id)
                .Index(t => t.RecipeCategory_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Password = c.String(),
                        Type = c.Int(nullable: false),
                        Buyer_Id = c.Int(),
                        Seller_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buyers", t => t.Buyer_Id)
                .ForeignKey("dbo.Sellers", t => t.Seller_Id)
                .Index(t => t.Buyer_Id)
                .Index(t => t.Seller_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        SentDateTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Reciever_Id = c.Int(),
                        Sender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Reciever_Id)
                .ForeignKey("dbo.Users", t => t.Sender_Id)
                .Index(t => t.Reciever_Id)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "dbo.OnlineUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        LoginTime = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginTime = c.String(),
                        LogoutTime = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OnlineUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Reciever_Id", "dbo.Users");
            DropForeignKey("dbo.FavoriteRecipes", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Seller_Id", "dbo.Sellers");
            DropForeignKey("dbo.Users", "Buyer_Id", "dbo.Buyers");
            DropForeignKey("dbo.FavoriteRecipes", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "SubCategory_Id", "dbo.RecipeSubCategories");
            DropForeignKey("dbo.RecipeSubCategories", "RecipeCategory_Id", "dbo.RecipeCategories");
            DropForeignKey("dbo.Recipes", "Seller_Id", "dbo.Sellers");
            DropForeignKey("dbo.RecipeTags", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.RecipeReviews", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.RecipeReviews", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Recipe_Id", "dbo.TrayRecipes");
            DropForeignKey("dbo.TrayRecipes", "Seller_Id", "dbo.Sellers");
            DropForeignKey("dbo.Sellers", "ProfileImage_Id", "dbo.ProfileImages");
            DropForeignKey("dbo.Sellers", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Sellers", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.RecipeImages", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Recipes", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Recipes", "Category_Id", "dbo.RecipeCategories");
            DropForeignKey("dbo.Buyers", "ProfileImage_Id", "dbo.ProfileImages");
            DropForeignKey("dbo.Buyers", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Buyers", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropIndex("dbo.OnlineUsers", new[] { "User_Id" });
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropIndex("dbo.Messages", new[] { "Reciever_Id" });
            DropIndex("dbo.Users", new[] { "Seller_Id" });
            DropIndex("dbo.Users", new[] { "Buyer_Id" });
            DropIndex("dbo.RecipeSubCategories", new[] { "RecipeCategory_Id" });
            DropIndex("dbo.RecipeTags", new[] { "Recipe_Id" });
            DropIndex("dbo.Sellers", new[] { "ProfileImage_Id" });
            DropIndex("dbo.Sellers", new[] { "Country_Id" });
            DropIndex("dbo.Sellers", new[] { "City_Id" });
            DropIndex("dbo.TrayRecipes", new[] { "Seller_Id" });
            DropIndex("dbo.Orders", new[] { "Recipe_Id" });
            DropIndex("dbo.RecipeReviews", new[] { "Recipe_Id" });
            DropIndex("dbo.RecipeReviews", new[] { "Order_Id" });
            DropIndex("dbo.RecipeImages", new[] { "Recipe_Id" });
            DropIndex("dbo.Recipes", new[] { "SubCategory_Id" });
            DropIndex("dbo.Recipes", new[] { "Seller_Id" });
            DropIndex("dbo.Recipes", new[] { "Country_Id" });
            DropIndex("dbo.Recipes", new[] { "City_Id" });
            DropIndex("dbo.Recipes", new[] { "Category_Id" });
            DropIndex("dbo.FavoriteRecipes", new[] { "User_Id" });
            DropIndex("dbo.FavoriteRecipes", new[] { "Recipe_Id" });
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            DropIndex("dbo.Buyers", new[] { "ProfileImage_Id" });
            DropIndex("dbo.Buyers", new[] { "Country_Id" });
            DropIndex("dbo.Buyers", new[] { "City_Id" });
            DropTable("dbo.UserHistories");
            DropTable("dbo.OnlineUsers");
            DropTable("dbo.Messages");
            DropTable("dbo.Users");
            DropTable("dbo.RecipeSubCategories");
            DropTable("dbo.RecipeTags");
            DropTable("dbo.Sellers");
            DropTable("dbo.TrayRecipes");
            DropTable("dbo.Orders");
            DropTable("dbo.RecipeReviews");
            DropTable("dbo.RecipeImages");
            DropTable("dbo.RecipeCategories");
            DropTable("dbo.Recipes");
            DropTable("dbo.FavoriteRecipes");
            DropTable("dbo.ProfileImages");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Buyers");
        }
    }
}
