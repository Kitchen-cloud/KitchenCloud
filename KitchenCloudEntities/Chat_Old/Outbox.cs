using System.Collections.Generic;

namespace KitchenCloudEntities.Chat
{
  public  class Outbox
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

       
        private List<Message> messages;

        public List<Message> Messages
        {
            get { return messages; }
            set { messages = value; }
        }



    }
}
