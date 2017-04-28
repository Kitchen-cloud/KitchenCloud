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
    public class OutboxHandler : IFunctionsHandler<Outbox>
    {
        public void Add(Outbox t)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                //context.Entry(t.Message.From).State = EntityState.Unchanged;
                //context.Entry(t.To).State = EntityState.Unchanged;
                context.Outboxes.Add(t);
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
                Outbox inbox = (from i in context.Outboxes where i.Id == id select i).FirstOrDefault();
                if (inbox != null)
                {
                    context.Outboxes.Remove(inbox);
                    context.SaveChanges();
                }
            }
        }

        public List<Outbox> GetAll()
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from i in context.Outboxes
                        //.Include(x => x.To)
                        //.Include(x => x.Message)
                        select i).ToList();
            }
        }

        public List<Outbox> GetAllByToId(int id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from i in context.Outboxes
                        //.Include(x => x.Message)
                        //.Include(x => x.To)
                        //where i.To.Id == id
                        select i).ToList();

            }
        }

        public Outbox GetById(int id)
        {
            KitchenCloudContext context = new KitchenCloudContext();
            using (context)
            {
                return (from i in context.Outboxes where i.Id == id select i).FirstOrDefault();

            }
        }

        public void Update(Outbox t)
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
