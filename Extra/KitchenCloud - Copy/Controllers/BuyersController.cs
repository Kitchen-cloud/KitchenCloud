using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitchenCloud.Models;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloud.Controllers
{
    public class BuyersController : Controller
    {
        // GET: Buyers
        public ActionResult Account()
        {
            Buyer b=new Buyer();
            BuyerProfile bp=new BuyerProfile();
            b = new BuyerHandler().GetById(1);
            bp.Id = b.Id;
            bp.Country = b.Country;
            bp.ProfileImage = b.ProfileImage;
            bp.UserName = b.FirstName+" "+b.SecondName;
            bp.Introduction = b.Description;


            ViewBag.Buyer = bp;
            ViewBag.BuyerIntro = b.Description;

            return View();
        }
    }
}