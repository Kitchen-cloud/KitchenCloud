using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KitchenCloud.Models.Helpers;
using KitchenCloud.Models.Messenger;
using KitchenCloudEntities.Messenger;
using KitchenCloudEntities.Users;
using KitchenCloudEntitiesHandler.Messenger;
using KitchenCloudEntitiesHandler.Users;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace KitchenCloud.Hubs
{
    [HubName("KitchenCloud")]
    public class MessengerHub : Hub
    {
        //private static int count = 0;
        //private static string UserOne = "";
        //private static string UserTwo = "";

        //private static Dictionary<int, string>dictionary=new Dictionary<int, string>();



        public Task Connect(string id)
        {
            //if (dictionary.ContainsKey(id))
            //{
            //    dictionary[id] = Context.ConnectionId;
            //}
            //else
            //{
            //    dictionary.Add(id,Context.ConnectionId);
            //}






            return Groups.Add(Context.ConnectionId, id);




















            //if (count == 0)
            //{
            //    UserOne = Context.ConnectionId;
            //    count++;
            //}
            //else if (count == 1)
            //{
            //    UserTwo = Context.ConnectionId;
            //    count++;
            //}
            //else if (count == 2)
            //{
            //    count++;
            //}


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
