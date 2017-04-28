using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntitiesHandler.Common;

namespace KitchenCloudEntitiesHandler.Chat
{
    public class MessageHandler : IFunctionsHandler<Message>
    {
        public void Add(Message t)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.Entry(t.From).State=EntityState.Unchanged;
                context.Messages.Add(t);
                context.SaveChanges();
            }
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                Message message = (from m in context.Messages where m.Id == id select m).FirstOrDefault();
                if (message != null)
                {
                    context.Messages.Remove(message);
                    context.SaveChanges();
                }
            }
        }

        public List<Message> GetAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from m in context.Messages select m).ToList();
            }
        }

        public Message GetById(int id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from m in context.Messages where m.Id == id select m).FirstOrDefault();
            }
        }

        public void Update(Message t)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.Entry(t.From).State = EntityState.Unchanged;
                context.Entry(t).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
