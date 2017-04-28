using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntities.Recipes;
using KitchenCloudEntitiesHandler.Common;

namespace KitchenCloudEntitiesHandler.Recipes
{
    class RecipeReviewHandler : IFunctionsHandler<RecipeReview>
    {
        public void Add(RecipeReview recipe)
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                context.RecipeReviews.Add(recipe);
                context.SaveChanges();
            }
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int Id)
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                context.RecipeReviews.Remove(context.RecipeReviews.Find(from mr in context.RecipeReviews select mr));
            }

        }

        public List<RecipeReview> GetAll()
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                return (from mr in context.RecipeReviews select mr).ToList();
            }
        }

        public RecipeReview GetById(int Id)
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                return (from mr in context.RecipeReviews where mr.Id == Id select mr).FirstOrDefault();
            }
        }

        public List<RecipeReview> GetAllByRecipeId(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from mr in context.RecipeReviews where mr.Id == Id select mr).ToList();
            }
        }

        public void Update(RecipeReview Object)
        {
            throw new NotImplementedException();
        }
    }

}
