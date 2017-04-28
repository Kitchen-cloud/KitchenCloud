using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenCloud.Models.Chat
{
    public class MessagePreviewModal
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public string Preview { get; set; }
        public string SenderImg { get; set; }
        public string RecievedOn { get; set; }
    }
}