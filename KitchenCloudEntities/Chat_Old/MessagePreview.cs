using System;
using KitchenCloudEntities.Common;

namespace KitchenCloudEntities.Chat
{
  public  class MessagePreview
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string preview;

        public string Preview
        {
            get { return preview; }
            set { preview = value; }
        }

        private Person sender;

        public Person Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        private Person reciever;

        public Person Reciever
        {
            get { return reciever; }
            set { reciever = value; }
        }

        private DateTime recievedDateTime;

        public DateTime RecievedDateTime
        {
            get { return recievedDateTime; }
            set { recievedDateTime = value; }
        }


    }
}
