using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using System.Windows.Documents;
using KitchenCloud.Models.Recipes;
using KitchenCloud.Models.Helpers;
using KitchenCloud.Models.Buyers;
using KitchenCloud.Models.Orders;
using KitchenCloud.Models.Shared;
using KitchenCloud.Models.Sellers;
using KitchenCloudEntities.Common;
using KitchenCloudEntities.Recipes;
using KitchenCloudEntities.Users;
using KitchenCloudEntitiesHandler.Common;
using KitchenCloudEntitiesHandler.Orders;
using KitchenCloudEntitiesHandler.Recipes;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloud.Controllers
{
    public class SellersController : Controller
    {
        public ActionResult Account()
        {
            if (Session[WebUtil.CURRENT_USER] != null)
            {
                List<BuyerReviewModel> Reviews = new List<BuyerReviewModel>
                {
                    new BuyerReviewModel
                    {
                        BuyerCompliments = "Awesome Experience ",
                        BuyerImage = "~/Content/Images/Users/Profile Img/person5.png",
                        BuyerLocation = "Lahore",
                        BuyerName = "Irshad Ahmed",
                        Id = 1,
                        OrderDeliveredDate = DateTime.Now,
                        Stars = 3.5
                    }
                };

                User u = (User)Session["User"];

                List<FavoriteRecipe> fr = new FavoriteRecipeHandler().GetAllByUserId(u.Id);
                if (fr != null)
                {
                    ViewBag.Favorites = fr;
                }
                else
                {
                    ViewBag.Favorites = new List<FavoriteRecipe>();
                }


                Seller s = new SellerHandler().GetById(u.Id);

                SellerProfile sp = new SellerProfile
                {
                    Id = s.Id,
                    Introduction = s.Description,
                    Location = s.City.Country,
                    Ratings = s.Rank,
                    ProfileImage = s.ProfileImage,
                    UserName = s.FirstName + " " + s.SecondName,
                    Reviews = s.Reviews,
                    Slogan = s.Slogan,
                    Visitors = s.Visitors
                };





                ViewBag.AllRecipes = TypeCaster.ToRecipeTemplateList(new RecipeHandler().GetAllBySellerId(sp.Id));
                ViewBag.SellerProfile = sp;
                ViewBag.SellerAcc = sp;
                ViewBag.Reviews = Reviews;
                ViewBag.Countries = TypeCaster.ToSelectListItem(new CountryHandler().GetAll());
                ViewBag.CategoryList = TypeCaster.ToSelectListItem(new RecipeCategoryHandler().GetAll());

                ViewBag.OrdersList = new OrderHandler().GetAllBySellerId(sp.Id);


                return View();
            }
            return RedirectToAction("Index", "Dashboard");
        }


        [HttpGet]
        public ActionResult AccountLoad(int id)
        {
            if (Session[WebUtil.CURRENT_USER] != null)
            {
                List<BuyerReviewModel> Reviews = new List<BuyerReviewModel>
                {
                    new BuyerReviewModel
                    {
                        BuyerCompliments = "Awesome Experience ",
                        BuyerImage = "~/Content/Images/Users/Profile Img/person5.png",
                        BuyerLocation = "Lahore",
                        BuyerName = "Irshad Ahmed",
                        Id = 1,
                        OrderDeliveredDate = DateTime.Now,
                        Stars = 3.5
                    }
                };

                User u = (User)Session["User"];

                List<FavoriteRecipe> fr = new FavoriteRecipeHandler().GetAllByUserId(u.Id);
                if (fr != null)
                {
                    ViewBag.Favorites = fr;
                }
                else
                {
                    ViewBag.Favorites = new List<FavoriteRecipe>();
                }


                Seller s = new SellerHandler().GetById(u.Id);

                SellerProfile sp = new SellerProfile
                {
                    Id = s.Id,
                    Introduction = s.Description,
                    Location = s.City.Country,
                    Ratings = s.Rank,
                    ProfileImage = s.ProfileImage,
                    UserName = s.FirstName + " " + s.SecondName,
                    Reviews = s.Reviews,
                    Slogan = s.Slogan,
                    Visitors = s.Visitors
                };





                ViewBag.AllRecipes = TypeCaster.ToRecipeTemplateList(new RecipeHandler().GetAllBySellerId(sp.Id));
                ViewBag.SellerProfile = sp;
                ViewBag.SellerAcc = sp;
                ViewBag.Reviews = Reviews;
                ViewBag.Countries = TypeCaster.ToSelectListItem(new CountryHandler().GetAll());
                ViewBag.CategoryList = TypeCaster.ToSelectListItem(new RecipeCategoryHandler().GetAll());

                ViewBag.OrdersList = new OrderHandler().GetAllBySellerId(sp.Id);

                ViewBag.LoadPage = id;

                return View("Account");
            }
            return RedirectToAction("Index", "Dashboard");


        }


        public ActionResult CitiesList(int id)
        {

            DDListModel model = new DDListModel
            {
                Name = "City",
                Caption = "- Select City -",
                Values = TypeCaster.ToSelectListItem(new CityHandler().GetByCountryId(id))
            };

            return PartialView("_DDListView", model);
        }
        public ActionResult FoodSubCategoryList(int id)
        {

            DDListModel model = new DDListModel()
            {
                Caption = "- Sub Category -",
                Name = "SubCategory",
                Values = TypeCaster.ToSelectListItem(new RecipeSubCategoryHandler().GetAllByCategoryId(id))
            };
            return PartialView("_DDListView", model);
        }

        public ActionResult AccountSettings()
        {

            if (Session[WebUtil.CURRENT_USER] != null)
            {

                User user = (User)Session["User"];
                Seller seller = new SellerHandler().GetById(user.Id);

                FormCollection formCollection = new FormCollection
                {
                    {"IB", seller.InstantBake.ToString()},
                    {"FD", seller.FastDelivery.ToString()},
                    {"AJ", seller.AvailableForJob.ToString()}
                };


                SellerProfileSettings settings = new SellerProfileSettings()
                {
                    Id = seller.Id,
                    Introduction = seller.Description,

                    ProfileImage = seller.ProfileImage,
                    AJ = seller.AvailableForJob,
                    FD = seller.FastDelivery,
                    IA = seller.InstantBake,
                    Slogan = seller.Slogan
                };

                UpdatePassword password = new UpdatePassword();
                ViewBag.UpdatePassword = password;
                @ViewBag.MessageSuccess = "";
                @ViewBag.MessageFailed = "";
                return PartialView("_AccountSettings", settings);
            }
            return RedirectToAction("Index", "Dashboard");
        }

        public ActionResult AccountStatistics()
        {


            return PartialView("_AccountStatistics");
        }
        public ActionResult AccountOrders()
        {


            return PartialView("_AccountOrders");
        }
        public ActionResult MyRecipes()
        {
            if (Session[WebUtil.CURRENT_USER] != null)
            {


                User u = (User)Session["User"];
                List<MyRecipesModel> myRecipes = new List<MyRecipesModel>();
                foreach (Recipe recipe in new RecipeHandler().GetAllBySellerId(u.Id))
                {

                    myRecipes.Add(new MyRecipesModel()
                    {
                        Category = recipe.SubCategory.RecipeCategory.Name,
                        SubCategory = recipe.SubCategory.Name,
                        ImgUrl = recipe.RecipeImages.First().FolderPath,
                        Id = recipe.Id,
                        Price = recipe.Price.ToString(".00"),
                        Title = recipe.Title
                    });

                }



                ViewBag.MyRecipes = myRecipes;

                return PartialView("_MyRecipes");
            }
            return RedirectToAction("Account");
        }

        public ActionResult MyTrayView()
        {

            return RedirectToAction("TrayView", "Dashboard");



        }


        ////public ActionResult MyTray()
        //{
        //    if (Session[WebUtil.CURRENT_USER] != null)
        //    {
        //        List<BuyerReviewModel> Reviews = new List<BuyerReviewModel>
        //        {
        //            new BuyerReviewModel
        //            {
        //                BuyerCompliments = "Awesome Experience ",
        //                BuyerImage = "~/Content/Images/Users/Profile Img/person5.png",
        //                BuyerLocation = "Lahore",
        //                BuyerName = "Irshad Ahmed",
        //                Id = 1,
        //                OrderDeliveredDate = DateTime.Now,
        //                Stars = 3.5
        //            }
        //        };

        //        User u = (User)Session["User"];
        //        Seller s = new SellerHandler().GetById(u.Id);

        //        SellerProfile sp = new SellerProfile();
        //        sp.Id = s.Id;


        //        sp.Introduction = s.Description;
        //        sp.Location = s.Country;
        //        sp.Ratings = s.Rank;

        //        sp.ProfileImage = s.ProfileImage;


        //        sp.UserName = s.FirstName + " " + s.SecondName;
        //        sp.Reviews = s.Reviews;
        //        sp.Slogan = s.Slogan;
        //        sp.Visitors = s.Visitors;
        //        ViewBag.AllRecipes = TypeCaster.ToRecipeTemplateList(new RecipeHandler().GetAllBySellerId(sp.Id));
        //        ViewBag.SellerProfile = sp;
        //        ViewBag.SellerAcc = sp;
        //        ViewBag.Reviews = Reviews;
        //        ViewBag.Countries = TypeCaster.ToSelectListItem(new CountryHandler().GetAll());
        //        ViewBag.CategoryList = TypeCaster.ToSelectListItem(new RecipeCategoryHandler().GetAll());

        //        return View();
        //    }
        //    return RedirectToAction("Index", "Dashboard");
        //}




        [HttpPost]
        public ActionResult AddRecipe(CreateNewRecipe newRecipe, FormCollection formCollection)
        {

            User user = (User)Session[WebUtil.CURRENT_USER];

            Seller seller = new SellerHandler().GetById(user.Id);


            RecipeCategory rc = new RecipeCategory()
            {
                Id = Convert.ToInt32(formCollection["FoodCategoryList"])
            };

            ServingFor serving = ServingFor.Single;
            if (formCollection["PersonsFor"] == "Single")
            {
                serving = ServingFor.Single;
            }
            if (formCollection["PersonsFor"] == "Double")
            {
                serving = ServingFor.Double;
            }
            if (formCollection["PersonsFor"] == "Party")
            {
                serving = ServingFor.Party;
            }

            Country country = seller.City.Country;
            City city = seller.City;


            List<RecipeImage> ImageList = new List<RecipeImage>();

            int a = 0;
            Priority p = Priority.High;
            foreach (string f in Request.Files)
            {
                if (a == 0)
                {
                    p = Priority.Low;
                }
                if (a == 2)
                {
                    p = Priority.Medium;
                }
                if (a == 1)
                {
                    p = Priority.High;
                }


                HttpPostedFileBase file = Request.Files[f];
                if (!string.IsNullOrEmpty(file.FileName))
                {
                    RecipeImage img = new RecipeImage()
                    {
                        Caption = file.FileName,
                        FolderPath = "~/Content/Images/Users/Recipe Images/" + file.FileName,
                        ImageName = file.FileName,
                        ImagePriority = p
                    };
                    ImageList.Add(img);

                    file.SaveAs(Request.MapPath(img.FolderPath));


                }
                a++;
            }

            if (ImageList.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        p = Priority.High;
                    }
                    if (i == 1)
                    {
                        p = Priority.Medium;
                    }
                    if (i == 2)
                    {
                        p = Priority.Low;
                    }





                    RecipeImage img = new RecipeImage()
                    {
                        Id = i++,
                        Caption = "Kitchen Cloud",
                        FolderPath = "~/Content/Images/Users/Recipe Images/",
                        ImageName = "default.png",
                        ImagePriority = p
                    };
                }


            }




            List<RecipeTag> taglList = new List<RecipeTag>();
            foreach (RecipeTagListModel tag in RecipeTagListModel.Tags)
            {
                taglList.Add(new RecipeTag() { Id = tag.Id, Name = tag.Name });
            }








            Recipe m = new Recipe
            {

                SubCategory = new RecipeSubCategory()
                {
                    Id = Convert.ToInt32(formCollection["SubCategory"]),
                    RecipeCategory = rc
                },

                PersonsFor = serving,
                City = city,

                RecipeImages = ImageList,

                RecipeReviews = null,
                RecipeTags = taglList,
                Price = Convert.ToSingle(newRecipe.Price),
                Description = newRecipe.Description,
                Seller = seller,
                StreeAddress = newRecipe.StreetAddress,
                Title = newRecipe.Title





            };
            RecipeTagListModel.Tags = new List<RecipeTagListModel>();

            new RecipeHandler().Add(m);







            return RedirectToAction("Account");
        }
        private int count = 0;
        public void AddTag(string Tag)
        {
            new RecipeTagListModel(count, Tag);
            count++;
        }
        public ActionResult DeleteRecipe(int Id)
        {

            new RecipeHandler().DeleteById(Id);


            return RedirectToAction("Account");
        }


        [HttpPost]
        public ActionResult ProfileSettings(SellerProfileSettings settings, FormCollection collection)
        {


            ProfileImage profileImage = null;

            foreach (string f in Request.Files)
            {
                profileImage = new ProfileImage();
                HttpPostedFileBase file = Request.Files[f];
                if (file != null)
                {
                    try
                    {
                        profileImage.Id = settings.ProfileImage.Id;
                        profileImage.ImageName = file.FileName;
                        profileImage.FolderPath = "~/Content/Images/Users/Profile Img/";
                        profileImage.Caption = file.FileName;
                        file.SaveAs(Request.MapPath(profileImage.FolderPath + profileImage.ImageName));
                    }
                    catch
                    {

                        profileImage = new ProfileImageHandler().GetById(settings.ProfileImage.Id);
                    }

                }
                else
                {
                    profileImage = new ProfileImageHandler().GetById(settings.ProfileImage.Id);
                }
            }


            Seller seller = new SellerHandler().GetById(settings.Id);



            seller.Slogan = settings.Slogan;
            seller.Id = settings.Id;






            seller.Description = settings.Introduction;
            seller.InstantBake = settings.IA;
            seller.AvailableForJob = settings.AJ;
            seller.FastDelivery = settings.FD;
            seller.ProfileImage = profileImage;

            new SellerHandler().Update(seller);

            return RedirectToAction("Account");
        }


        // [HttpGet]
        //public ActionResult ChangeProfileImage(string tempImg)
        //{

        //    User user = (User) Session[WebUtil.CURRENT_USER];
        //    Seller seller=new SellerHandler().GetById(user.Id);
        //    string tempImgUrl = seller.ProfileImage.FolderPath+seller.ProfileImage.ImageName;
        //    foreach (string file in Request.Files)
        //    {
        //        HttpPostedFileBase f = Request.Files[file];
        //        if (f!=null)
        //        {
        //            tempImgUrl = "~/Content/TemporaryFiles/" + f.FileName;
        //            f.SaveAs(Request.MapPath(tempImgUrl));
        //        }
        //    }

        //    return Json(tempImgUrl);
        //}



        public ActionResult MyOrders()
        {
            User user = (User)Session[WebUtil.CURRENT_USER];
            List<OrderModel> OrdersList = new List<OrderModel>();
            foreach (var order in new OrderHandler().GetAllBySellerId(user.Id))
            {
                OrdersList.Add(new OrderModel()
                {
                    Status = order.OrderStatus,
                    Id = order.Id,
                    Seller = order.Recipe.Seller,
                    Recipe = order.Recipe,
                    Time = order.OrderTime,
                    Buyer = new SellerHandler().GetById(order.BuyerId),
                    DueDate = order.DueDate,
                    OrderDate = order.OrderDate

                });

            }

            ViewBag.MyOrdersList = OrdersList;
            return PartialView("_MyOrders");
        }






    }
}