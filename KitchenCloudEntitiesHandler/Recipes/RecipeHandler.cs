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
    public class RecipeHandler : IFunctionsHandler<Recipe>
    {
        public void Add(Recipe Object)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.Entry(Object.SubCategory).State = EntityState.Unchanged;

                context.Entry(Object.Seller).State = EntityState.Unchanged;

                context.Recipes.Add(Object);
                context.SaveChanges();
            }
        }
        public void DeleteAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {


            }
        }
        public void DeleteById(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {

                try
                {
                    Recipe r =
                    (from m in context.Recipes
                        .Include(x => x.RecipeImages)
                        .Include(x => x.City.Country)
                        .Include(x => x.SubCategory.RecipeCategory)

                        .Include(x => x.Seller)
                        .Include(x => x.RecipeTags)
                     where m.Id == Id
                     select m).FirstOrDefault();
                    if (r != null)
                    {

                        context.RecipeImages.RemoveRange(r.RecipeImages);
                        context.RecipeTags.RemoveRange(r.RecipeTags);
                        context.Recipes.Remove(r);
                        context.SaveChanges();
                    }

                }
                catch (Exception e)
                {

                    string ex = e.Message;
                }


            }
        }
        public Recipe GetById(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from m in context.Recipes
                         .Include(x => x.RecipeImages)
                        .Include(x => x.City.Country)
                        .Include(x => x.SubCategory.RecipeCategory)

                        .Include(x => x.Seller)
                        .Include(x => x.Seller.ProfileImage)
                        .Include(x => x.RecipeTags)
                        where m.Id == Id
                        select m).FirstOrDefault();
            }
        }
        public List<Recipe> GetAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {

                return (from m in context.Recipes

                        .Include(x => x.RecipeImages)
                        .Include(x => x.City.Country)
                        .Include(x => x.SubCategory.RecipeCategory)
                        .Include(x => x.Seller)
                        .Include(x => x.Seller.ProfileImage)

                        .Include(x => x.RecipeTags)
                        select m).ToList();
            }
        }
        public List<Recipe> GetRange(int from, int to)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {

                return (from m in context.Recipes

                        .Include(x => x.RecipeImages)
                        .Include(x => x.City.Country)
                        .Include(x => x.SubCategory.RecipeCategory)
                        .Include(x => x.Seller)
                        .Include(x => x.Seller.ProfileImage)

                        .Include(x => x.RecipeTags)
                        select m).ToList().GetRange(from, to);
            }
        }
        public List<Recipe> GetAllBySellerId(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from m in context.Recipes
                        .Include(x => x.RecipeImages)
                        .Include(x => x.City.Country)
                        .Include(x => x.SubCategory.RecipeCategory)
                        .Include(x => x.Seller)
                        .Include(x => x.Seller.ProfileImage)
                        .Include(x => x.RecipeTags)
                        .Include(x => x.Seller)
                        where m.Seller.Id == Id
                        select m).ToList();
            }
        }
        public void Update(Recipe Object)
        {
            throw new NotImplementedException();
        }
    }
}
