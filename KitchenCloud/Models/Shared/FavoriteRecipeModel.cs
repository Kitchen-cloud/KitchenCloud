using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KitchenCloud.Models.Recipes;

namespace KitchenCloud.Models.Shared
{
    public class FavoriteRecipeModel
    {
        private static List<RecipeTemplate> FavoritList;

        public static void AddFavorite(RecipeTemplate recipe)
        {
            if (recipe!=null)
            {
                FavoritList = new List<RecipeTemplate> {recipe};
            }
            
        }


    }
}