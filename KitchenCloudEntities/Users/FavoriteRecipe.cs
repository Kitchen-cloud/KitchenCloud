using KitchenCloudEntities.Recipes;

namespace KitchenCloudEntities.Users
{
   public class FavoriteRecipe
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private Recipe recipe;

        public Recipe Recipe
        {
            get { return recipe; }
            set { recipe = value; }
        }

        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }




    }
}
