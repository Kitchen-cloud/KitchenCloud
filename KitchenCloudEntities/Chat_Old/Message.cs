using System;
using KitchenCloudEntities.Users;

namespace KitchenCloudEntities.Chat
{
    public class Message
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private DateTime sentDateTime;

        public DateTime SentDateTime
        {
            get { return sentDateTime; }
            set { sentDateTime = value; }
        }
        private DateTime recieveDateTime;

        public DateTime RecieveDateTime
        {
            get { return recieveDateTime; }
            set { recieveDateTime = value; }
        }






        private string body;

        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        private MessageStatus status;

        public MessageStatus Status
        {
            get { return status; }
            set { status = value; }
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




    }
}
