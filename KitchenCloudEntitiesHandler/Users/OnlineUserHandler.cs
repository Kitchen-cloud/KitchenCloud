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
   public class OnlineUserHandler : IFunctionsHandler<OnlineUser>
    {
        public void Add(OnlineUser onlineUsers)
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                context.Entry(onlineUsers.User).State = EntityState.Unchanged;
                context.OnlineUsers.Add(onlineUsers);
                context.SaveChanges();
            }
        }

        public void DeleteAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.OnlineUsers.RemoveRange(from ou in context.OnlineUsers select ou);
                context.SaveChanges();
            }
        }

        public void DeleteById(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.OnlineUsers.Remove(context.OnlineUsers.Find(Id));
                context.SaveChanges();
            }
        }

        public List<OnlineUser> GetAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from ou in context.OnlineUsers.Include(x => x.User)
                        select ou).ToList();
            }
        }

        public OnlineUser GetById(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from ou in context.OnlineUsers.Include(x => x.User)
                        where ou.User.Id==Id
                        select ou).FirstOrDefault();
            }
        }

        public void Update(OnlineUser Object)
        {
            throw new NotImplementedException();
        }
    }
}
