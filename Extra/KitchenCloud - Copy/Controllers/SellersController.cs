using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitchenCloud.Models;
using KitchenCloudEntitiesHandler.Menus;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloud.Controllers
{
    public class SellersController : Controller
    {
        private List<MenuTemplate> MenuList = new List<MenuTemplate>();

        
        public ActionResult Account()
        {
            List<BuyerReviewModel> Reviews=new List<BuyerReviewModel>();
            Reviews.Add(
                

                new BuyerReviewModel
                {
                    BuyerCompliments = "Awesome Experience ",
                    BuyerImage = "~/Content/Images/Users/Profile Img/myimg.png",
                    BuyerLocation = "Lahore",
                    BuyerName = "Irshad Ahmed",
                    Id = 1,
                    OrderDeliveredDate = DateTime.Now,
                    Stars = 3.5
                });


            Seller s=new SellerHandler().GetById(1);
            SellerProfile sp=new SellerProfile();
            sp.Id = s.Id;
            sp.Introduction = s.Description;
            sp.Location = s.Country;
            sp.Ratings = s.Rank;
            sp.ProfileImage = s.ProfileImage;
            sp.UserName = s.FirstName+" "+s.SecondName;
            sp.Reviews = s.Reviews;
            sp.Slogan = s.Slogan;
            sp.Visitors = s.Visitors;



            ViewBag.SellerProfile = sp;
            ViewBag.SellerAcc = sp;


            ViewBag.Reviews = Reviews;

            return View();
        }

        private int a = 0;
        public ActionResult SellerMenu(int data)
        {

            for (int i = 1; i < 10; i++)
            {

                MenuList.Add(new MenuTemplate
                {
                    Id = i,
                    Title = "Pakistani",
                    Image = string.Format("~/Content/Images/Users/Menu Images/MenuImg ({0}).jpg", i),
                    PersonsFor = "Single",
                    Ratings = 3.5F,
                    Services = new string[] { "Chinese", "Soup", "Fast Food", "Desi" },
                    TotalOrders = 150 + i
                });

                if (i == 9 && a == 0)
                {
                    i = 1;
                    a++;
                }

            }
            ViewBag.MenuLists = MenuList.GetRange(1, data);

            return PartialView("_GlobalMenuTemplate");

        }


        [HttpGet]
        public ActionResult NewMenu(Menu newMenu)
        {



            new MenuHandler().Add(newMenu);



            return PartialView("_NewMenu");

        }

        [HttpPost]

        public ActionResult AddMenu(Menu createNewMenu)
        {

            //Menu menu=new Menu();
            //menu.Id = createNewMenu.Id;
            //menu.Location=createNewMenu.


            new MenuHandler().Add(createNewMenu);


            return RedirectToAction("Account");
        }

        [HttpGet]
        public ActionResult AccountStats()
        {
            return PartialView("_AccountStats");
        }
    }
}