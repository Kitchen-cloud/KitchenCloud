using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntities.Users;

namespace KitchenCloudEntities.Messenger
{
  public class Message
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string body;

        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        private DateTime sentDateTime;

        public DateTime SentDateTime
        {
            get { return sentDateTime; }
            set { sentDateTime = value; }
        }

        private User sender;

        public User Sender
        {
            get { return sender; }
            set { sender = value; }
        }
        private User reciever;

        public User Reciever
        {
            get { return reciever; }
            set { reciever = value; }
        }

        private MessageStatus status;

        public MessageStatus Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
