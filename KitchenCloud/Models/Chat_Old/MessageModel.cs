using KitchenCloudEntities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KitchenCloudEntities.Chat;

namespace KitchenCloud.Models.Chat
{
    public class MessageModel
    {
        public int Id { get; set; }
        public User Sender { get; set; }
        public User Reciever { get; set; }
        public string SentOn { get; set; }
        public string RecievedOn { get; set; }
        public string MessageBody { get; set; }
        public string[] MessageAttachement { get; set; }
        public MessageStatus Status { get; set; }
        

    }
}