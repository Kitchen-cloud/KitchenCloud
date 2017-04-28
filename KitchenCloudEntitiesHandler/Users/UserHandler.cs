using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntities.Users;
using KitchenCloudEntitiesHandler.Common;
using Omu.Encrypto;

namespace KitchenCloudEntitiesHandler.Users
{
    public class UserHandler : IFunctionsHandler<User>
    {
        public void Add(User user)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                if (user.Type == UserType.Seller) context.Entry(user.Seller).State = EntityState.Unchanged;
                if (user.Type == UserType.Buyer) context.Entry(user.Buyer).State = EntityState.Unchanged;


                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public List<User> GetAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from u in context.Users select u).ToList();
            }
        }

        public User GetById(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from u in context.Users where u.Id == Id select u).FirstOrDefault();

            }
        }

        public void DeleteById(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.Users.Remove(context.Users.Find(Id));
                context.SaveChanges();
            }
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }



        public User UserLogin(User user)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return(from u in context.Users.Include(x => x.Seller)
                        where u.UserName == user.UserName
                        select u
                        ).FirstOrDefault();
            }
        }

        public void Update(User Object)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.Entry(Object.Seller).State = EntityState.Modified;
                context.Entry(Object).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
