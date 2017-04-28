using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenCloud.Models.Chat
{
    public class ChatModel
    {
        public int Id { get; set; }
        public string Receiver { get; set; }
        public string ReceiverImage { get; set; }
        public string Message { get; set; }

    }
}