using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitchenCloud.Models;

namespace KitchenCloud.Controllers
{
    public class DashboardController : Controller
    {
        private List<MenuTemplate> MenuList = new List<MenuTemplate>();
        public ActionResult Index()
        {

            //CatogariesList

            List<SecondaryNavModel>C=new List<SecondaryNavModel>()
            {
                new SecondaryNavModel{CategoryName = "Pakistani",Id=0,Subcategories = new List<String>{"Soup","Fast Food","Soup","Fast Food"}}   ,
                new SecondaryNavModel{CategoryName = "Chinese",Id=0,Subcategories = new List<String>{"Soup","Fast Food","Soup","Fast Food"}}   ,
                new SecondaryNavModel{CategoryName = "Continental",Id=0,Subcategories = new List<String>{"Soup","Fast Food","Soup","Fast Food"}}   ,
                new SecondaryNavModel{CategoryName = "Italian",Id=0,Subcategories = new List<String>{"Soup","Fast Food","Soup","Fast Food"}}   ,
                new SecondaryNavModel{CategoryName = "Fast Food",Id=0,Subcategories = new List<String>{"Soup","Fast Food","Soup","Fast Food"}}   ,
                new SecondaryNavModel{CategoryName = "Desi",Id=0,Subcategories = new List<String>{"Soup","Fast Food","Soup","Fast Food"}}   ,
                new SecondaryNavModel{CategoryName = "Lite",Id=0,Subcategories = new List<String>{"Soup","Fast Food","Soup","Fast Food"}}   ,
                new SecondaryNavModel{CategoryName = "Others",Id=0,Subcategories = new List<String>{"Soup","Fast Food","Soup","Fast Food"}}   ,
                   
            };


            ViewBag.CatogariesList = C;
            return View();
        }

        public ActionResult Guest()
        {
            return View();
        }


        public ActionResult AllMenus(int data)
        {
            for (int i = 1; i < 25; i++)
            {
                MenuList.Add(new MenuTemplate
                {
                    Id = i,
                    Title = "Pakistani",
                    Image = string.Format("~/Content/Images/All Menus/MenuImg ({0}).jpg", i),
                    PersonsFor = "Single",
                    Ratings = 3.5F,
                    Services = new string[] { "Chinese", "Soup", "Fast Food", "Desi" },
                    TotalOrders = 150 + i
                });

            }

                ViewBag.MenuLists = MenuList.GetRange(1, data);

            return PartialView("_GlobalMenuTemplate");

        }








        [HttpGet]
        public ActionResult SignUp()
        {

            return PartialView("_SignUp");
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return PartialView("_LogIn");
        }


        [HttpGet]

        public ActionResult RecoverPassword()
        {
            return PartialView("_RecoverPassword");
        }

        [HttpGet]

        public ActionResult FeedBack()
        {
            return PartialView("_GlobalFeedback");
        }

    }
}
