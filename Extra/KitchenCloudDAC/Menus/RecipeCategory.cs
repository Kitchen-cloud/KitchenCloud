using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenCloudDAC.Menus
{
    class RecipeCategory:Recipe
    {

        private RecipeSubCategory recipeSubCategory;

        public RecipeSubCategory RecipeSubCategory
        {
            get { return recipeSubCategory; }
            set { recipeSubCategory = value; }
        }





    }
}
