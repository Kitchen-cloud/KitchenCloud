using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntities.Users;
using KitchenCloudEntitiesHandler.Common;

namespace KitchenCloudEntitiesHandler.Users
{
    class UserHistoryHandler : IFunctionsHandler<UserHistory>
    {
        public void Add(UserHistory userHistory)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.UserHistories.Add(userHistory);
                context.SaveChanges();
            }
        }

        public void DeleteAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.UserHistories.RemoveRange(from uh in context.UserHistories select uh);
                context.SaveChanges();
            }
        }

        public void DeleteById(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.UserHistories.Remove(context.UserHistories.Find(Id));
                context.SaveChanges();
            }
        }

        public List<UserHistory> GetAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from uh in context.UserHistories select uh).ToList();
            }
        }

        public UserHistory GetById(int Id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from uh in context.UserHistories select uh).FirstOrDefault();
            }
        }

        public void Update(UserHistory userHistory)
        {
            throw new NotImplementedException();
        }
    }
}
