using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntities.Recipes;
using KitchenCloudEntitiesHandler.Common;

namespace KitchenCloudEntitiesHandler.Recipes
{
  public  class RecipeSubCategoryHandler : IFunctionsHandler<RecipeSubCategory>
    {
        public void Add(RecipeSubCategory recipe)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.Entry(recipe.RecipeCategory).State=EntityState.Unchanged;
                context.RecipeSubCategories.Add(recipe);
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

        public List<RecipeSubCategory> GetAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from rsc in context.RecipeSubCategories select rsc).ToList();

            }
        }
public List<RecipeSubCategory> GetAllByCategoryId(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from rsc in context.RecipeSubCategories.Include("RecipeCategory")
                        where rsc.RecipeCategory.Id==Id select rsc).ToList();

            }
        }

        public RecipeSubCategory GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(RecipeSubCategory Object)
        {
            throw new NotImplementedException();
        }
    }
}
