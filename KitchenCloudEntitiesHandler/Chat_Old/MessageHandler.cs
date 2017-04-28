using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntities.Chat;
using KitchenCloudEntitiesHandler;
using KitchenCloudEntitiesHandler.Chat;
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
                //context.Entry(t.From).State=EntityState.Unchanged;
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
        public List<Message> GetAllBySenderId(int id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from m in context.Messages
                        select m).ToList();
            }
        }


        public List<Message> GetAllBySenderAndRecieverId(int sender, int reciever)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from m in context.Messages
                         .Include(x => x.Reciever)
                        .Include(x => x.Sender)
                        where m.Sender.Id == sender &&
                        m.Reciever.Id == reciever

                        select m).ToList();
            }
        }

        public List<Message> GetAllByRecieverId(int id)
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
              //  context.Entry(t.From).State = EntityState.Unchanged;
                context.Entry(t).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
