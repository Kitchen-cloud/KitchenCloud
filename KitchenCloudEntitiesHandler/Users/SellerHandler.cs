using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntities.Users;
using KitchenCloudEntitiesHandler.Common;
using KitchenCloudEntitiesHandler.Recipes;

namespace KitchenCloudEntitiesHandler.Users
{
    public class SellerHandler : IFunctionsHandler<Seller>
    {
        public void Add(Seller recipe)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.Entry(recipe.City.Country).State = EntityState.Unchanged;
                context.Entry(recipe.City).State = EntityState.Unchanged;
                context.Sellers.Add(recipe);
                context.SaveChanges();
            }
        }
        public void DeleteAll()
        {
            throw new NotImplementedException();
        }
        public void DeleteById(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                Seller seller = context.Sellers.Find(Id);
                if (seller != null)
                {
                    User user = context.Users.Find(Id);
                    if (user != null)
                    {
                        foreach (var recipe in new RecipeHandler().GetAllBySellerId(Id))
                        {
                            new RecipeHandler().DeleteById(recipe.Id);
                        }
                        context.Users.Remove(user);
                        context.Sellers.Remove(seller);
                        context.SaveChanges();
                    }

                }
            }
        }
        public List<Seller> GetAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from s in context.Sellers
                        .Include(x => x.ProfileImage)
                        .Include(x => x.City.Country)
                        select s).ToList();
            }
        }
        public Seller GetById(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from s in context.Sellers
                        .Include(x => x.ProfileImage)
                        .Include(x => x.City.Country)
                        where s.Id == Id
                        select s).FirstOrDefault();
            }
        }
        public void Update(Seller Object)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.Entry(Object.ProfileImage).State = EntityState.Modified;
                context.Entry(Object).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
