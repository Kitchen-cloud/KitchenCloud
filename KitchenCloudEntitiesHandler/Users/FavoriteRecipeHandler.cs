using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntities.Users;
using KitchenCloudEntitiesHandler.Common;

namespace KitchenCloudEntitiesHandler.Users
{
    public class FavoriteRecipeHandler : IFunctionsHandler<FavoriteRecipe>
    {
        public void Add(FavoriteRecipe t)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.Entry(t.Recipe).State = EntityState.Unchanged;
                context.Entry(t.User).State = EntityState.Unchanged;
                context.FavoriteRecipes.Add(t);
                context.SaveChanges();
            }
        }

        public List<FavoriteRecipe> GetAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from f in context.FavoriteRecipes select f).ToList();
            }
        }

        public List<FavoriteRecipe> GetAllByUserId(int id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from f in context.FavoriteRecipes
                        .Include(x => x.User)
                        .Include(x => x.Recipe)
                        where f.User.Id == id
                        select f).ToList();
            }
        }

        public FavoriteRecipe GetById(int id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from f in context.FavoriteRecipes
                        .Include(x => x.User)
                        .Include(x => x.Recipe)
                        where f.Id == id
                        select f).FirstOrDefault();
            }
        }
    
        public void DeleteById(int id)
        {
            throw new NotImplementedException();

        }

        public void DeleteByUserId(FavoriteRecipe favrecipe)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                FavoriteRecipe fr = (from f in context.FavoriteRecipes
                                     .Include(x => x.User)
                                     .Include(x=>x.Recipe)
                                     where f.User.Id == favrecipe.User.Id
                                     &&
                                     f.Recipe.Id== favrecipe.Recipe.Id
                                     select f).FirstOrDefault();
                if (fr != null)
                {
                    context.Entry(fr).State = EntityState.Unchanged;
                    context.Entry(fr).State = EntityState.Unchanged;
                    context.FavoriteRecipes.Remove(fr);
                    context.SaveChanges();
                }
            }
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void Update(FavoriteRecipe t)
        {
            throw new NotImplementedException();
        }
    }
}
