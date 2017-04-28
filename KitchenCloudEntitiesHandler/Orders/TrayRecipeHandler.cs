using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KitchenCloudEntities.Orders;
using KitchenCloudEntitiesHandler.Common;

namespace KitchenCloudEntitiesHandler.Orders
{
    public class TrayRecipeHandler : IFunctionsHandler<TrayRecipe>
    {
        public void Add(TrayRecipe Object)
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                context.Entry(Object.Seller).State=EntityState.Unchanged;
                context.TrayRecipes.Add(Object);
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

        public List<TrayRecipe> GetAll()
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                return (from t in context.TrayRecipes
                        .Include(i=>i.Seller)
                        select t).ToList();
            }
        }

        public TrayRecipe GetById(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from t in context.TrayRecipes
                        .Include(i => i.Seller)
                        where t.Id==Id
                        select t).FirstOrDefault();
            }
        }



        public TrayRecipe GetAllBySellerId(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from t in context.TrayRecipes
                        .Include(i => i.Seller)
                        where t.Id == Id
                        select t).FirstOrDefault();
            }
        }



        public void Update(TrayRecipe Object)
        {
            throw new NotImplementedException();
        }
    }
}