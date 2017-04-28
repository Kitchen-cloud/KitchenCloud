using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using KitchenCloud.Models.Shared;
using KitchenCloud.Models.Recipes;
using KitchenCloud.Models.Helpers;
using KitchenCloud.Models.Orders;
using KitchenCloud.Models.Sellers;
using KitchenCloudEntities.Common;
using KitchenCloudEntities.Orders;
using KitchenCloudEntities.Recipes;
using KitchenCloudEntities.Users;
using KitchenCloudEntitiesHandler.Common;
using KitchenCloudEntitiesHandler.Orders;
using KitchenCloudEntitiesHandler.Recipes;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloud.Controllers
{
    public class DashboardController : Controller
    {

        private static int _trayCount = 0;
        //private int RangeStart=1, RangeEnd;
        public ActionResult Index()
        {


            var data = Session[WebUtil.CURRENT_USER];

            if (data != null)
            {
                User user = (User)data;
                ViewBag.Favorites = new FavoriteRecipeHandler().GetAllByUserId(user.Id);
            }
            else
            {
                ViewBag.Favorites = new List<FavoriteRecipe>();
            }
            //CatogariesList

            List<SecondaryNavModel> c = new List<SecondaryNavModel>()
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


            //int pg = (new RecipeHandler().GetAll().Count()>30? new RecipeHandler().GetAll().Count() * 60: new RecipeHandler().GetAll().Count() * 30);


            //if (pg > 10)
            //{
            //    RangeEnd
            //}


            // ViewBag.Pagination = new RecipeHandler().GetRange(1, 20).Count();
            ViewBag.Pagination = 1;
            ViewBag.CatogariesList = c;
            ViewBag.Countries = TypeCaster.ToSelectListItem(new CountryHandler().GetAll());
            ViewBag.Cities = TypeCaster.ToSelectListItem(new CityHandler().GetAll());
            ViewBag.Allrecipes = TypeCaster.ToRecipeTemplateList(new RecipeHandler().GetAll());








            return View();
        }
        public ActionResult Guest()
        {
            return View();
        }
        public ActionResult RecipeDescription(int id)
        {
            Recipe recipe = new RecipeHandler().GetById(id);

            List<RecipeTemplate> recipesList =
            TypeCaster.ToRecipeTemplateList(new RecipeHandler().GetAllBySellerId(recipe.Seller.Id));



            RecipeDescription rc = new RecipeDescription()
            {
                Id = recipe.Id,
                Seller = new RecipeSeller()
                {
                    Id=recipe.Seller.Id,
                    FullName = recipe.Seller.FirstName + " " + recipe.Seller.SecondName,
                    Description = recipe.Seller.Description,
                    ProfileImage = recipe.Seller.ProfileImage.FolderPath + recipe.Seller.ProfileImage.ImageName
                },
                Country = recipe.City.Country,
                City = recipe.City,
                Category = recipe.SubCategory.RecipeCategory.Name,
                MenuImages = recipe.RecipeImages,
                Title = recipe.Title,
                PersonsFor = recipe.PersonsFor.ToString(),
                Price = recipe.Price,
                Description = recipe.Description,
                Tags = recipe.RecipeTags,
                StreetAddress = recipe.StreeAddress,
                SubCatrory = recipe.SubCategory.Name,
                Recipes = recipesList



            };



            List<SecondaryNavModel> c = new List<SecondaryNavModel>()
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



            var data = Session[WebUtil.CURRENT_USER];

            if (data != null)
            {
                User user = (User)data;
                ViewBag.Favorites = new FavoriteRecipeHandler().GetAllByUserId(user.Id);
            }
            else
            {
                ViewBag.Favorites = new List<FavoriteRecipe>();
            }
            ViewBag.CatogariesList = c;



            List<SelectListItem> countryList = TypeCaster.ToSelectListItem(new CountryHandler().GetAll());
            ViewBag.Countries = countryList;


            ViewBag.RecipeDescription = rc;
            return View("_RecipeDescription");
        }
        public ActionResult CitiesList(int id)
        {

            //DDListModel model = new DDListModel
            //{
            //    Name = "City",
            //    Caption = "- Select City -",
            //    Values = TypeCaster.ToSelectListItem(new CityHandler().GetByCountryId(id))
            //};

            ViewBag.Cities = TypeCaster.ToSelectListItem(new CityHandler().GetByCountryId(id));

            return PartialView("_CityList", new SignupSellerModel() { });
        }
        [HttpPost]
        public ActionResult SignUp(FormCollection newUser)
        {
            Country country = new Country { Id = Convert.ToInt32(newUser["Country"]) };
            City city = new City
            {
                Id = Convert.ToInt32(newUser["City"]),
                Country = country
            };


            ProfileImage pi = new ProfileImage()
            {
                Caption = "Default",
                FolderPath = "~/Content/Images/Users/Profile Img/",
                ImageName = "default.png"
            };
            new ProfileImageHandler().Add(pi);


            Seller seller = new Seller
            {
                FirstName = newUser["FirstName"],
                SecondName = newUser["SecondName"],
                City = city,
                Email = newUser["Email"],
                Password = Crypto.HashPassword(newUser["Password"]),
                Gender = newUser["Gender"],
                ProfileImage = pi,
                Description = "Introduce Yourself in a Paragraph",
                TotalOrders = 0,
                Visitors = 0,
                Rank = 1.0F,
                Reviews = 0,
                Slogan = "Here is your Slogan",

            };








            new SellerHandler().Add(seller);

            User us = new User
            {
                Seller = seller,
                Type = UserType.Seller,
                UserName = seller.Email,
                City = new CityHandler().GetById(city.Id).Name,
                Country = new CountryHandler().GetById(country.Id).Name,
                Password = seller.Password
            };

            new UserHandler().Add(us);


            string msg = "Success Welcome " + seller.FirstName + " " + seller.SecondName;
            Session.Add(WebUtil.ALERT_MESSAGE, msg);

            return RedirectToAction("Account", "Sellers");
        }
        [HttpPost]
        public ActionResult LogIn(LoginUserModel u)
        {

            User user = new User
            {
                UserName = u.UserName,
                Password = u.Password
            };

            User us = new UserHandler().UserLogin(user);



            if (us != null)
            {
                if (Crypto.VerifyHashedPassword(us.Password, user.Password))
                {
                    if (us.Type.Equals(UserType.Seller))
                    {
                        Session.Add(WebUtil.CURRENT_USER, us);
                        Session.Add(WebUtil.TRAY_COUNT, _trayCount);


                        Session.Add(WebUtil.ALERT_MESSAGE, null);


                        return RedirectToAction("Account", "Sellers");
                    }
                }


            }





            string Msg = "User Name or Password Invalid";
            Session.Add(WebUtil.ALERT_MESSAGE, Msg);


            return RedirectToAction("Index");
        }
        public ActionResult SignOut()
        {

            _trayCount = 0;
            Session.Abandon();

            return RedirectToAction("Index");

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
        [HttpPost]
        public ActionResult Search(SearchKeys keys)
        {
            var recipeTemplates = TypeCaster.ToRecipeTemplateList(new RecipeHandler().GetAll());
            List<RecipeTemplate> searchResults = new List<RecipeTemplate>();
            if (recipeTemplates != null)
            {
                if (keys.ByName != null)
                {
                    searchResults.AddRange(recipeTemplates.Where(x => x.Tags.Any(s => s.Contains(keys.ByName))).ToList());
                }
                if (keys.ByPrice != null)
                {
                    searchResults.AddRange(recipeTemplates.Where(x => x.Price <= Convert.ToDouble(keys.ByPrice)));
                }
                searchResults.AddRange(recipeTemplates.Where(x => x.Location.Equals(keys.ByLocation)));
                if (keys.ByOnlineSellers != null)
                {
                    foreach (var ouh in new OnlineUserHandler().GetAll())
                    {
                        searchResults.AddRange(TypeCaster.ToRecipeTemplateList(new RecipeHandler().GetAllBySellerId(ouh.User.Id)));
                    }
                }
                if (keys.ByMealFor != null)
                {
                    searchResults.AddRange(recipeTemplates.Where(x => x.PersonsFor == keys.ByMealFor));
                }
            }
            var data = Session[WebUtil.CURRENT_USER];

            if (data != null)
            {

                    User user = (User)data;
                    ViewBag.Favorites = new FavoriteRecipeHandler().GetAllByUserId(user.Id);
            }
            else
            {
                ViewBag.Favorites = new List<FavoriteRecipe>();
            }
            ViewBag.AllRecipes = searchResults;
            return PartialView("_GlobalRecipeTemplate");
        }
        //public ActionResult Search(int price)
        //{

        //    var recipeTemplates = TypeCaster.ToRecipeTemplateList(new RecipeHandler().GetAll());


        //    ViewBag.AllRecipes = recipeTemplates.Where(x => x.Price <= price).ToList();

        //    return PartialView("_GlobalRecipeTemplate");

        //}
        [HttpPost]
        public ActionResult ChangePassword(SellerProfileSettings updatePassword)
        {

            User user = (User)Session[WebUtil.CURRENT_USER];


            if (user.Type == UserType.Seller)
            {

                if (user.Password == updatePassword.OldPassword)
                {
                    Seller seller = new SellerHandler().GetById(user.Id);

                    user.Password = updatePassword.NewPassword;
                    seller.Password = updatePassword.NewPassword;
                    user.Seller = seller;
                    new UserHandler().Update(user);
                    return Json(true);
                }

            }
            else if (user.Type == UserType.Buyer)
            {

            }

            return Json(false);

        }
        public ActionResult TrayView()
        {
            return PartialView("_MyTrayView");
        }
        [HttpPost]
        public ActionResult AddToTray(MyTrayRecipe trayRecipe)
        {
            try
            {
                var b = (MyTray)Session[WebUtil.MY_TRAY];


                if (b == null) { b = new MyTray(); }







                b.Add(trayRecipe);
                Session.Add(WebUtil.MY_TRAY, b);
                _trayCount++;


                Session.Add(WebUtil.TRAY_COUNT, _trayCount);

                return Json(_trayCount.ToString());
            }
            catch
            {
                return Json(false);
            }
        }
        [HttpPost]
        public ActionResult RemoveRecipeTray(int Id)
        {

            var myTray = (MyTray)Session[WebUtil.MY_TRAY];
            int temp = (from m in myTray.Items where m.Id == Id select m.Quantity).FirstOrDefault();
            myTray.Items.Remove(myTray.Items.Find(x => x.Id == Id));


            _trayCount = _trayCount - temp;



            Session.Add(WebUtil.TRAY_COUNT, _trayCount);

            return RedirectToAction("MyTrayView", "Sellers");
        }
        public ActionResult RemoveRecipeTrayTwo(int Id)
        {

            try
            {
                var myTray = (MyTray)Session[WebUtil.MY_TRAY];
                int temp = (from m in myTray.Items where m.Id == Id select m.Quantity).FirstOrDefault();
                myTray.Items.Remove(myTray.Items.Find(x => x.Id == Id));


                _trayCount = _trayCount - temp;



                Session.Add(WebUtil.TRAY_COUNT, _trayCount);
                return Json(true);

            }
            catch (Exception)
            {

                return Json(false);
            }

        }
        public ActionResult QuatityChange(int id, int value)
        {
            try
            {
                MyTray list = new MyTray();
                var myTray = (MyTray)Session[WebUtil.MY_TRAY];

                foreach (var item in myTray.Items)
                {
                    if (item.Id == id)
                    {

                        if (item.Quantity > value)
                        {
                            int diff = item.Quantity - value;
                            _trayCount = _trayCount - diff;
                        }
                        else if (item.Quantity < value)
                        {
                            int diff = value - item.Quantity;

                            _trayCount = _trayCount + diff;
                        }


                        item.Quantity = value;

                    }
                    list.Add(item);

                }


                Session.Add(WebUtil.MY_TRAY, list);
                Session.Add(WebUtil.TRAY_COUNT, _trayCount);
                return Json(_trayCount);


            }
            catch (Exception)
            {

                return Json(false);
            }





        }
        public ActionResult ConfirmOrder(OrderModel orderModel)
        {

            User user = (User)Session[WebUtil.CURRENT_USER];
            if (user.Type == UserType.Seller)
            {

                Seller seller = new SellerHandler().GetById(user.Id);
                MyTray myTray = (MyTray)Session[WebUtil.MY_TRAY];
                Recipe recipes = recipes = new Recipe();
                foreach (MyTrayRecipe recipe in myTray.Items)
                {
                    recipes = new RecipeHandler().GetById(recipe.Id);

                    TrayRecipe trayRecipe = new TrayRecipe()
                    {
                        Category = recipe.Category,
                        ImageUrl = recipe.ImgUrl,
                        Price = recipe.Amount,
                        Quantity = recipe.Quantity,
                        Seller = recipes.Seller,
                        SubCategory = recipe.SubCategory
                    };
                    new TrayRecipeHandler().Add(trayRecipe);

                    new OrderHandler().Add(new Order()
                    {
                        BuyerId = user.Id,
                        OrderDate = System.DateTime.Now.ToShortDateString(),
                        OrderStatus = Status.Pending,
                        OrderTime = orderModel.Time,
                        DueDate = orderModel.DueDate,
                        Recipe = trayRecipe


                    });
                }


                string AlertMsg = "Order Successfully Placed ";
                _trayCount = 0;

                MyTray Tray = new MyTray();
                Session.Add(WebUtil.MY_TRAY, Tray);
                Session.Add(WebUtil.TRAY_COUNT, _trayCount);

                Session.Add(WebUtil.ALERT_MESSAGE, AlertMsg);

                return RedirectToAction("Account", "Sellers");

            }
            return RedirectToAction("Index");
        }
        public ActionResult RemoveAlertBar()
        {
            try
            {
                Session.Add(WebUtil.ALERT_MESSAGE, null);
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public ActionResult AddFavorite(int id)
        {
            try
            {

                User user = (User)Session[WebUtil.CURRENT_USER];
                if (user != null)
                {
                    Recipe recipe = new RecipeHandler().GetById(id);

                    new FavoriteRecipeHandler().Add(new FavoriteRecipe()
                    {
                        User = user,
                        Recipe = recipe

                    });


                }
                ViewBag.Notification = new NotificationModel()
                {
                    Text = "Marked as favorite ... ",
                    BackgroundColor = "bg-warning",
                    Icon = "glyphicon glyphicon-star"
                };
                return PartialView("_Notification");
            }
            catch
            {
                return Json("Error");
            }


        }
        [HttpPost]
        public ActionResult RemoveFavorite(int id)
        {
            try
            {
                User user = (User)Session[WebUtil.CURRENT_USER];
                if (user != null)
                {
                    new FavoriteRecipeHandler().DeleteByUserId(new FavoriteRecipe()
                    {
                        User = user,
                        Recipe = new RecipeHandler().GetById(id)
                    });


                }


                return Json("Done");
            }
            catch
            {
                return Json("Error");
            }


        }



    }
}