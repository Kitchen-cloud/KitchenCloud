using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntities.Common;

namespace KitchenCloudEntitiesHandler.Common
{
   public class CountryHandler : IFunctionsHandler<Country>
    {
        public void Add(Country recipe)
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                context.Countries.Add(recipe);
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
                context.Countries.Remove(context.Countries.Find(Id));
                context.SaveChanges();
            }
        }

        public List<Country> GetAll()
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                return (from c in context.Countries select c).ToList();
            }
        }

        public Country GetById(int Id)
        {
           KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                return (from c in context.Countries where c.Id == Id select c).FirstOrDefault();
            }
        }

        public void Update(Country Object)
        {
            throw new NotImplementedException();
        }
    }
}
