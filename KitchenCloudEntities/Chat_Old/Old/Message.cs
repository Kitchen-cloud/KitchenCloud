using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloudEntitiesHandler.Chat
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





        private User from;

        public User From
        {
            get { return from; }
            set { from = value; }
        }

        private User to;

        public User To
        {
            get { return to; }
            set { to = value; }
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


    }
}
