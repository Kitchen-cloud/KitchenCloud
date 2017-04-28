﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloudEntitiesHandler.Chat
{
  public  class Outbox
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private User to;

        public User To
        {
            get { return to; }
            set { to = value; }
        }
        private Message message;

        public Message Message
        {
            get { return message; }
            set { message = value; }
        }



    }
}
