using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntitiesHandler.Common;
using KitchenCloudEntities.Messenger;

namespace KitchenCloudEntitiesHandler.Messenger
{
  public  class MessageHandler : IFunctionsHandler<Message>
    {
        public void Add(Message t)
        {
           KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                context.Entry(t.Reciever).State=EntityState.Unchanged;
                context.Entry(t.Sender).State=EntityState.Unchanged;
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
            throw new NotImplementedException();
        }

        public List<Message> GetAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from m in context.Messages
                        .Include(x => x.Reciever)
                        .Include(x => x.Sender)
                        select m).ToList();
            }
        }
        public List<Message> GetAllBySenderId(int id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from m in context.Messages
                        .Include(x => x.Reciever)
                        .Include(x => x.Sender)
                        where m.Sender.Id==id
                        select m).ToList();
            }
        }

        public List<Message> GetAllByRecieverId(int id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from m in context.Messages
                        .Include(x => x.Reciever)
                        .Include(x => x.Sender)
                        where m.Reciever.Id==id
                        select m).ToList();
            }
        }
        //public List<Message> GetAllPrieviewsByRecieverId(int id)
        //{
        //    List<Message> messages = GetAllByRecieverId(id);

        //    List< int > result = messages.Select(o => o.Reciever.Id).Distinct().ToList();
        //    return messages;
        //}
        public List<Message> GetAllBySenderAndRecieverId(int sender,int reciever)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from m in context.Messages
                        .Include(x => x.Reciever)
                        .Include(x => x.Sender)
                        where m.Reciever.Id==reciever && m.Sender.Id==sender||
                        m.Reciever.Id == sender && m.Sender.Id == reciever
                        select m).ToList();
            }
        }








        public Message GetById(int id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from m in context.Messages
                        .Include(x => x.Reciever)
                        .Include(x => x.Sender)
                        where m.Id==id
                        select m).FirstOrDefault();
            }
        }
        public void Update(Message t)
        {
            throw new NotImplementedException();
        }
    }
}
