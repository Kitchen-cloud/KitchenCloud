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
    class RecipeTagHandler : IFunctionsHandler<RecipeTag>
    {
        public void Add(RecipeTag recipe)
        {
           KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                //context.Entry(recipe.Recipe).State=EntityState.Unchanged;
                context.RecipeTags.Add(recipe);

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

        public List<RecipeTag> GetAll()
        {
            throw new NotImplementedException();
        }

        public RecipeTag GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(RecipeTag Object)
        {
            throw new NotImplementedException();
        }

        //public List<RecipeTag> GetAllByRecipeId(int Id)
        //{

        //    KitchenCloudContext context=new KitchenCloudContext();
        //    using (context)
        //    {
        //        return (from t in context.RecipeTags
        //                .Include("Recipe")
        //                where t.Recipe.Id==Id 
        //                select t).ToList();
        //    }

        //}

    }
}
