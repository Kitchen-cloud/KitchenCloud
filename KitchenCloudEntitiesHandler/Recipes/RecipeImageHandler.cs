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
 public  class RecipeImageHandler : IFunctionsHandler<RecipeImage>
    {
        public void Add(RecipeImage recipe)
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                //context.Entry(recipe.Recipe).State=EntityState.Unchanged;
                context.RecipeImages.Add(recipe);
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

        public List<RecipeImage> GetAll()
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                return (from im in context.RecipeImages select im).ToList();
            }
        }

        public RecipeImage GetById(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from im in context.RecipeImages where im.Id==Id select im).FirstOrDefault();
            }
        }

        public void Update(RecipeImage Object)
        {
            throw new NotImplementedException();
        }
        //public List<RecipeImage> GetAllByRecipeId(int Id)
        //{
        //    KitchenCloudContext context = new KitchenCloudContext();
        //    using (context)
        //    {
        //        return (from im in context.RecipeImages.Include("Recipe") where im.Recipe.Id==Id select im).ToList();
        //    }
        //}
    }
}
