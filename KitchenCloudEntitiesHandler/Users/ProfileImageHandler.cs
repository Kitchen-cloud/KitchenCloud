using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntities.Users;
using KitchenCloudEntitiesHandler.Common;

namespace KitchenCloudEntitiesHandler.Users
{
   public class ProfileImageHandler : IFunctionsHandler<ProfileImage>
    {
        public void Add(ProfileImage recipe)
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                context.ProfileImages.Add(recipe);
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

        public List<ProfileImage> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProfileImage GetById(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from p in context.ProfileImages where p.Id == Id select p).FirstOrDefault();
            }
        }
//        public ProfileImage GetByUserId(int Id)
//        {
//            KitchenCloudContext context = new KitchenCloudContext();
//            using (context)
//            {
//                return (from p in context.ProfileImages 
//where p.Id == Id select p).FirstOrDefault();
//            }
//        }

        public void Update(ProfileImage Object)
        {
            throw new NotImplementedException();
        }
    }
}
