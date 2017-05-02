using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitchenCloud.Models.Helpers;
using KitchenCloud.Models.Messenger;
using KitchenCloudEntities.Messenger;
using KitchenCloudEntities.Users;
using KitchenCloudEntitiesHandler.Messenger;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloud.Controllers
{
    public class MessengerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexLoadChat(int id)
        {
            ViewBag.ChatWith = id;
            return View("Index");
        }
        public ActionResult InboxData()
        {
            User user = (User)Session[WebUtil.CURRENT_USER];
            if (user != null)
            {
                List<MessagePreviewModel> messagePreviews =
                TypeCaster.MessageModelListToMessagePreviewList(
                    TypeCaster.MessageListToMessageModelList(new MessageHandler().GetAllByRecieverId(user.Id)));

                var list = (from mp in messagePreviews
                            group mp by mp.SenderName
                            into gp
                            select gp).ToList();

                messagePreviews = new List<MessagePreviewModel>();
                foreach (var l in list)
                {
                    messagePreviews.Add(
                        (from i in l
                         orderby i.RecievedOn descending
                         select i).FirstOrDefault()
                           );
                }
                return PartialView("_InboxData", messagePreviews);
            }
            return Json(false);
        }

        [HttpGet]
        public ActionResult Chat(int id)
        {
            ViewBag.ChatId = id;

            ViewBag.SenderID = 0;
            User user = (User)Session[WebUtil.CURRENT_USER];
            if (user != null)
            {
                ViewBag.SenderID = user.Id;
            }

            return PartialView("_ChatFrame", new MessageModel()
            {
                RecieverId = id,

            });
        }

        [HttpGet]
        public ActionResult ChatInInbox(int id)
        {
            ViewBag.SenderID = 0;
            User user = (User)Session[WebUtil.CURRENT_USER];
            if (user != null)
            {
                ViewBag.SenderID = user.Id;
            }

            Message message = new MessageHandler().GetById(id);
            ViewBag.ChatId = message.Sender.Id;
            return PartialView("_ChatFrame", new MessageModel()
            {
                RecieverId = message.Sender.Id
            });
        }


        [HttpGet]
        public ActionResult ChatEmptyData()
        {
            return PartialView("_ChatData");
        }

        public ActionResult ChatData(int id)
        {
            User user = (User)Session[WebUtil.CURRENT_USER];
            if (user != null)
            {
                List<MessageModel> messages = TypeCaster.MessageListToMessageModelList(new MessageHandler().GetAllBySenderAndRecieverId(id, user.Id));
                ViewBag.ChatList = messages;
            }
            else
            {
                List<MessageModel> chatList = new List<MessageModel>()
                {
                    new MessageModel()
                    {
                        Id = 1,
                        Body = "Hello Kitchen Cloud",
                        Status = MessageStatus.UnRead,
                        SentOn = DateTime.Now.ToString(),
                        SenderImage = "dad",
                        SenderName = "Kitchen Cloud"

                    },
                    new MessageModel()
                    {
                        Id = 1,
                        Body = "Hello Kitchen Cloud",
                        Status = MessageStatus.UnRead,
                        SentOn = DateTime.Now.ToString(),
                        SenderImage = "dad",
                        SenderName = "Kitchen Cloud"

                    },
                    new MessageModel()
                    {
                        Id = 1,
                        Body = "Hello Kitchen Cloud",
                        Status = MessageStatus.UnRead,
                        SentOn = DateTime.Now.ToString(),
                        SenderImage = "dad",
                        SenderName = "Kitchen Cloud"

                    },
                    new MessageModel()
                    {
                        Id = 1,
                        Body = "Hello Kitchen Cloud",
                        Status = MessageStatus.UnRead,
                        SentOn = DateTime.Now.ToString(),
                        SenderImage = "dad",
                        SenderName = "Kitchen Cloud"

                    },
                };
                ViewBag.ChatList = chatList;
            }
            return PartialView("_ChatData");
        }

        [HttpGet]
        public ActionResult SendMessage(MessageModel message)
        {
            try
            {
                User sender = (User)Session[WebUtil.CURRENT_USER];
                User reciever = new UserHandler().GetById(message.RecieverId);
                Message m = new Message()
                {
                    Body = message.Body,
                    Reciever = reciever,
                    Sender = sender,
                    SentDateTime = DateTime.Now,
                    Status = MessageStatus.UnRead
                };
                new MessageHandler().Add(m);
                ProfileImage image = new SellerHandler().GetById(message.SenderId).ProfileImage;
                var msg = new MessageModel()
                {
                    Status = MessageStatus.UnSeen,
                    Body = message.Body,
                    SentOn = DateTime.Now.ToString(),
                    SenderImage = image.FolderPath.Replace('~', ' ') + image.ImageName,
                    SenderName = new SellerHandler().GetById(sender.Id).FirstName,
                    SenderId = sender.Id,
                    RecieverId = reciever.Id

                };
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                string a = e.Message;
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
    }
}