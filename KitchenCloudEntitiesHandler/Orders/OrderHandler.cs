using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntities.Orders;
using KitchenCloudEntitiesHandler.Common;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloudEntitiesHandler.Orders
{
    public class OrderHandler : IFunctionsHandler<Order>
    {
        




        public void Add(Order Object)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.Entry(Object.Recipe.Seller).State = EntityState.Unchanged;
                context.Entry(Object.Recipe).State = EntityState.Unchanged;
                context.Orders.Add(Object);
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
                context.Orders.Remove(context.Orders.Find(Id));
            }
        }

        public List<Order> GetAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from o in context.Orders
                        .Include(o => o.Recipe)
                        .Include(o => o.Recipe.Seller)
                        select o).ToList();
            }
        }


        public Order GetById(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from o in context.Orders

                        .Include(o => o.Recipe)
                        .Include(o => o.Recipe.Seller)
                        where o.Id == Id
                        select o).FirstOrDefault();
            }
        }
        public List<Order> GetAllBySellerId(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from o in context.Orders
                        .Include(o => o.Recipe)
                        .Include(o => o.Recipe.Seller)
                        where o.Recipe.Seller.Id == Id
                        select o).ToList();
            }
        }
        public List<Order> GetAllByBuyerId(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from o in context.Orders
                        .Include(o => o.Recipe)
                        .Include(o => o.Recipe.Seller)
                        where o.BuyerId == Id
                        select o).ToList();
            }
        }





        public void Update(Order Object)
        {
            throw new NotImplementedException();
        }


    }
}
