using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenCloud.Models.Chat
{
    public class InboxModel
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string SenderImage { get; set; }
        public string MessagePreview { get; set; }
        public DateTime RecievedOn { get; set; }
    }
}