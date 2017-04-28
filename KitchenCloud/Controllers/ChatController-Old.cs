using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitchenCloud.Models.Chat;
using KitchenCloud.Models.Helpers;
using KitchenCloudEntities.Users;
using KitchenCloudEntitiesHandler.Chat;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloud.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            User user = (User)Session[WebUtil.CURRENT_USER];
            if (user != null)
            {

                return PartialView("MessageApp");
            }
            return RedirectToAction("Index", "Dashboard");
        }

        public ActionResult InboxData()
        {
            User user = (User)Session[WebUtil.CURRENT_USER];
            List<MessagePreviewModal> inbox = TypeCaster.MessagePreviewListToMessagePreviewModalList(new MessagePreviewHandler().GetAllByRecieverId(user.Id));

            return PartialView("_InboxData", inbox);
        }




        public ActionResult Inbox()
        {
            return PartialView("_InboxFrame");
        }

        private static int a = 0;

        [HttpGet]
        public ActionResult ChatWith(int id)
        {


            a = id;
           
            return PartialView("_ChatFrame");
        }
        [HttpGet]
        public ActionResult ChatWithData(int id)
        {

            #region TempMessages

            List<MessageModel> chatList = new List<MessageModel>()
            {
                new MessageModel()
                {
                    Id = 1,
                    MessageBody = "Hello Kitchen Cloud",
                    MessageAttachement = new[] {"Attach1"},
                    
                },
               
            };

            #endregion


            User user = (User) Session[WebUtil.CURRENT_USER];
            if (user!=null)
            {
               List<MessageModel>list= TypeCaster.MessageListToMessageModelList(new MessageHandler().GetAllBySenderAndRecieverId(id,user.Id));
                if (list != null && list.Count > 0)
                {
                    ViewBag.ChatWithList = list;
                }
                else
                {
                    ViewBag.ChatWithList = chatList;
                }
                
                return PartialView("_ChatData");
            }

            return Json(false);

        }

        [HttpPost]
        public ActionResult SendMessage(MessageModel message)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];

            ProfileImage image = new ProfileImageHandler().GetById(user.Id);
            return Json(new MessageModel()
            {
                Id = message.Id,
                MessageBody = message.MessageBody,
                Sender = message.Sender,
                Reciever = message.Reciever,
                MessageAttachement = new[] { "Attachement1" },
                SentOn = DateTime.Now.ToString(),
                Status = 



            });
            //return PartialView("_Inbox");
        }
    }
}