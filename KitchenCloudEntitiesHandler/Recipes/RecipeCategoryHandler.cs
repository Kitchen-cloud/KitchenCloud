using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntities.Recipes;
using KitchenCloudEntitiesHandler.Common;

namespace KitchenCloudEntitiesHandler.Recipes
{
   public class RecipeCategoryHandler:IFunctionsHandler<RecipeCategory>
    {
        public void Add(RecipeCategory recipe)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.RecipeCategories.Add(recipe);
                context.SaveChanges();
            }
          
        }

  
        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<RecipeCategory> GetAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return context.RecipeCategories.ToList();
            }
        }

        public RecipeCategory GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(RecipeCategory Object)
        {
            throw new NotImplementedException();
        }

     

    }
}
