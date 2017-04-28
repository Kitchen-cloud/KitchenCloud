using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KitchenCloudEntities.Messenger;

namespace KitchenCloud.Models.Messenger
{
    public class MessageModel
    {

        public int Id { get; set; }
        public string Body { get; set; }

        public string SentOn { get; set; }

        public int SenderId { get; set; }

        public string SenderImage { get; set; }
        public string SenderName { get; set; }

        public int RecieverId { get; set; }

        public MessageStatus Status { get; set; }
    }
}