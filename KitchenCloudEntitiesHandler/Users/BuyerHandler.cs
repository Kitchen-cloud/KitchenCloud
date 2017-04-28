using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntities.Users;
using KitchenCloudEntitiesHandler.Common;

namespace KitchenCloudEntitiesHandler.Users
{
   public class BuyerHandler:IFunctionsHandler<Buyer>
    {
        public void Add(Buyer recipe)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.Buyers.Add(recipe);
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

        public List<Buyer> GetAll()
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                return (from b in context.Buyers select b).ToList();
            }
        }

        public Buyer GetById(int Id)
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                
                return (from b in context.Buyers
                            .Include("Country")
                            .Include("ProfileImage")
                        where b.Id == Id select b).FirstOrDefault();
            }
        }

        public void Update(Buyer Object)
        {
            throw new NotImplementedException();
        }
    }
}
