namespace KitchenCloudEntities.Recipes
{
  public  class RecipeSubCategory
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private RecipeCategory recipeCategory;

        public RecipeCategory RecipeCategory
        {
            get { return recipeCategory; }
            set { recipeCategory = value; }
        }


    }
}
