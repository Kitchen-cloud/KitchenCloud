using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntities.Chat;
using KitchenCloudEntitiesHandler.Common;

namespace KitchenCloudEntitiesHandler.Chat
{
   public class MessagePreviewHandler:IFunctionsHandler<MessagePreview>
    {
        public void Add(MessagePreview t)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.Entry(t.Reciever).State=EntityState.Unchanged;
                context.Entry(t.Sender).State=EntityState.Unchanged;
                context.MessagePreviews.Add(t);
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
                MessagePreview messagePreview = (from m in context.MessagePreviews where m.Id == id select m).FirstOrDefault();
                if (messagePreview != null)
                {
                    context.Entry(messagePreview.Reciever).State = EntityState.Unchanged;
                    context.Entry(messagePreview.Sender).State = EntityState.Unchanged;
                    context.MessagePreviews.Remove(messagePreview);
                    context.SaveChanges();
                }
            }
        }

        public List<MessagePreview> GetAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {

                return (from m in context.MessagePreviews
                        .Include(x=>x.Reciever)
                        .Include(x=>x.Sender)
                        select m).ToList();
            }
        }
      
        public List<MessagePreview> GetAllBySenderId(int id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from m in context.MessagePreviews
                         .Include(x => x.Reciever)
                        .Include(x => x.Sender)
                        where m.Sender.Id==id
                        select m).ToList();
            }
        }
        public List<MessagePreview> GetAllByRecieverId(int id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from m in context.MessagePreviews
                           .Include(x => x.Reciever)
                        .Include(x => x.Sender)
                        where m.Reciever.Id == id
                        select m).ToList();
            }
        }

        public MessagePreview GetById(int id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from m in context.MessagePreviews
                           .Include(x => x.Reciever)
                        .Include(x => x.Sender)
                        where m.Id == id select m).FirstOrDefault();
            }
        }

        public void Update(MessagePreview t)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.Entry(t.Reciever).State = EntityState.Unchanged;
                context.Entry(t.Sender).State = EntityState.Unchanged;
                context.Entry(t).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
