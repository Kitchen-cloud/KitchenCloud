using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KitchenCloudEntities.Messenger;

namespace KitchenCloud.Models.Messenger
{
    public class MessagePreviewModel
    {
        public int Id { get; set; }
        public string SenderName { get; set; }
        public string SenderImage { get; set; }
        public DateTime RecievedOn { get; set; }
        public MessageStatus Status { get; set; }
        public string Preview { get; set; }
    }
}