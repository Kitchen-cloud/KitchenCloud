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
    public class InboxHandler : IFunctionsHandler<Inbox>
    {
        public void Add(Inbox t)
        {
            KitchenCloudContext context=new KitchenCloudContext();
            using (context)
            {
                //context.Entry(t.Message.From).State=EntityState.Unchanged;
                //context.Entry(t.From).State=EntityState.Unchanged;
                //context.Inboxes.Add(t);
                //context.SaveChanges();
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
                Inbox inbox = (from i in context.Inboxes where i.Id == id select i).FirstOrDefault();
                if (inbox != null)
                {
                    context.Inboxes.Remove(inbox);
                    context.SaveChanges();
                }
            }
        }

        public List<Inbox> GetAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from i in context.Inboxes
                        //.Include(x=>x.From)
                        //.Include(x=>x.Message)
                        select i).ToList();
            }
        }

        public List<Inbox> GetAllByToId(int id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from i in context.Inboxes
                      //  .Include(x => x.Message)
                        //.Include(x => x.From)
                        //where i.From.Id == id
                        select i).ToList();

            }
        }

        public Inbox GetById(int id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from i in context.Inboxes where i.Id == id select i).FirstOrDefault();
                
            }
        }
      
        public void Update(Inbox t)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {

                context.Entry(t).State=EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
