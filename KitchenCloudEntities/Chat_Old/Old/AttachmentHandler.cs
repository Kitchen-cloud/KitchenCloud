using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntitiesHandler.Common;

namespace KitchenCloudEntitiesHandler.Chat
{
   public class AttachmentHandler : IFunctionsHandler<Attachment>
    {
        public void Add(Attachment t)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.Entry(t.Message).State = EntityState.Unchanged;
                context.Attachments.Add(t);
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
                Attachment attachment = (from a in context.Attachments
                                         where a.Id == id
                                         select a).FirstOrDefault();
                if (attachment != null)
                {
                    context.Attachments.Remove(attachment);
                    context.SaveChanges();
                }
            }
        }

        public List<Attachment> GetAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from a in context.Attachments select a).ToList();

            }
        }

        public Attachment GetById(int id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from a in context.Attachments
                        where a.Id == id
                        select a).FirstOrDefault();
            }
        }

        public void Update(Attachment t)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                context.Entry(t).State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
