using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitchenCloud.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using KitchenCloudEntitiesHandler.Menus;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloud.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {

            ////IEnumerable<EFTestModelForSeller> sellerList=new List<EFTestModelForSeller>();

            ////foreach (var s in new SellerHandler().GetAllSellers())
            ////{
            ////    EFTestModelForSeller seller=new EFTestModelForSeller();
            ////    seller.Id = s.Id;
            ////    seller.UserName = s.Name+" "+s.SecondName;
            ////    seller.ProfileImage = s.ProfileImage;
            ////    seller.Ratings = s.Rank;
            ////    seller.Reviews = s.Reviews;
            ////    seller.Visitors = s.Visitors;



            ////}

            ////EFTestModelForSeller a = sellerList.FirstOrDefault();
            ////var Model = a;

            var s = new SellerHandler().GetSeller(1);



            EFTestModelForSeller seller = new EFTestModelForSeller();
            seller.Id = s.Id;
            seller.UserName = s.Name + " " + s.SecondName;
            seller.ProfileImage = s.ProfileImage;
            seller.Ratings = s.Rank;
            seller.Reviews = s.Reviews;
            seller.Visitors = s.Visitors;
            seller.Description = s.Description;
            return View(seller);
        }

        [HttpPost]
        public ActionResult IndexForm(TestUser NewUser)
        {


             
            

            return View("Index");
        }
        [HttpPost]
        public ActionResult NewMenu(Menu createNewMenu)
        {


            new MenuHandler().AddMenu(createNewMenu);


            return RedirectToAction("Index");
        }

    }
}