﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KitchenCloud.Models.Messenger;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace KitchenCloud.Hubs
{
    [HubName("KitchenCloud")]
    public class MessengerHub : Hub
    {
        public Task Connect(string id)
        {
          return Groups.Add(Context.ConnectionId, id);
        }
        public Task SendMessage(MessageModel message)
        {

           
            var msg = new MessageModel()
            {
                Status = message.Status,
                Body = message.Body,
                SentOn = message.SentOn,
                SenderImage = message.SenderImage,
                SenderName = message.SenderName,
                SenderId = message.SenderId,
                RecieverId = message.RecieverId

            };

            return this.Clients.Group(message.RecieverId.ToString()).Recieved(msg);

        }

    }
}
