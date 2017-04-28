using System.Data.Entity;
using KitchenCloudEntities.Common;
using KitchenCloudEntities.Messenger;
using KitchenCloudEntities.Orders;
using KitchenCloudEntities.Recipes;
using KitchenCloudEntities.Users;


namespace KitchenCloudEntitiesHandler
{
    sealed class KitchenCloudContext:DbContext
    {
        public KitchenCloudContext() : base("name=KCEFDB")
        {
            
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<OnlineUser> OnlineUsers { get; set; }
        public DbSet<UserHistory> UserHistories { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeImage> RecipeImages { get; set; }
        public DbSet<ProfileImage> ProfileImages { get; set; } 
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<RecipeSubCategory> RecipeSubCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<RecipeReview> RecipeReviews { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<RecipeTag> RecipeTags { get; set; }
        public DbSet<TrayRecipe> TrayRecipes { get; set; }
        public DbSet<FavoriteRecipe> FavoriteRecipes { get; set; }
        public DbSet<Message> Messages { get; set; }

        //public DbSet<Inbox> Inboxes { get; set; }
        //public DbSet<Outbox> Outboxes { get; set; }
        //public DbSet<Attachment> Attachments { get; set; }
        //public DbSet<MessagePreview> MessagePreviews { get; set; }
    }

}
