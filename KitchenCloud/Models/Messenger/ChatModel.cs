using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KitchenCloudEntities.Messenger;
using KitchenCloudEntities.Users;

namespace KitchenCloud.Models.Messenger
{
    public class ChatModel
    {

        public int Id { get; set; }

        public string Body { get; set; }
       
        public DateTime SentDateTime{get ;set;}

        public string SenderName{get;set; }
        public string SenderImage{get;set; }
      
        public string RecieverName{get;set; }
        
        public MessageStatus Status { get; set; }

    }
}