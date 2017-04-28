using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntities.Common;

namespace KitchenCloudEntitiesHandler.Common
{
  public  class CityHandler : IFunctionsHandler<City>
    {
        public void Add(City city)
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                context.Entry(city.Country).State=EntityState.Unchanged;
                context.Cities.Add(city);
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
                context.Cities.Remove(context.Cities.Find(Id));
                context.SaveChanges();
            }
        }

        public List<City> GetAll()
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                return (from c in context.Cities select c).ToList();
            }
        }

        public City GetById(int Id)
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                return (from c in context.Cities where c.Id == Id select c).FirstOrDefault();
            }
        }

        public List<City> GetByCountryId(int Id)
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {

                return (from c in context.Cities.Include("Country") where c.Country.Id == Id select c).ToList();
            }
        }

        public void Update(City Object)
        {
            throw new NotImplementedException();
        }
    }
}
