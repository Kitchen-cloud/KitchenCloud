using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KitchenCloud.Models.Admin;
using KitchenCloud.Models.Helpers;
using KitchenCloud.Models.Recipes;
using KitchenCloudEntitiesHandler.Recipes;
using KitchenCloudEntitiesHandler.Users;
using KitchenCloudEntities.Recipes;
using KitchenCloudEntities.Users;

namespace KitchenCloud.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

            if (Session[WebUtil.ADMIN] != null)
            {
                List<MyRecipesModel> allRecipes = new List<MyRecipesModel>();
                foreach (Recipe recipe in new RecipeHandler().GetAll())
                {

                    allRecipes.Add(new MyRecipesModel()
                    {
                        Category = recipe.SubCategory.RecipeCategory.Name,
                        SubCategory = recipe.SubCategory.Name,
                        ImgUrl = recipe.RecipeImages.First().FolderPath,
                        Id = recipe.Id,
                        Price = recipe.Price.ToString(".00"),
                        Title = recipe.Title
                    });

                }

                

                ViewBag.AllRecipes = allRecipes;

                
                return View();

            }
            return RedirectToAction("LogIn");
        }
        public ActionResult LogIn(LoginModel admin)
        {
            if (admin == null) return View();
            if (admin.Password == "Admin" && admin.UserName == "Admin")
            {
                Session.Add(WebUtil.ADMIN,"Admin");
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult AllRecipes()
        {
            List<MyRecipesModel> allRecipes = new List<MyRecipesModel>();
            foreach (Recipe recipe in new RecipeHandler().GetAll())
            {

                allRecipes.Add(new MyRecipesModel()
                {
                    Category = recipe.SubCategory.RecipeCategory.Name,
                    SubCategory = recipe.SubCategory.Name,
                    ImgUrl = recipe.RecipeImages.First().FolderPath,
                    Id = recipe.Id,
                    Price = recipe.Price.ToString(".00"),
                    Title = recipe.Title
                });

            }



            ViewBag.AllRecipes = allRecipes;


             return PartialView("_AllRecipes");

         
        }
        public ActionResult AllSellers()
        {

            if (Session[WebUtil.ADMIN] != null)
            {
                List<SellerInfo> sellerInfos = null;
                List<Seller> sellers = new SellerHandler().GetAll();
                if (sellers != null)
                {
                    sellerInfos = new List<SellerInfo>();
                    foreach (var seller in sellers)
                    {
                        sellerInfos.Add(new SellerInfo()
                        {
                            Id = seller.Id,
                            ImgUrl = seller.ProfileImage.FolderPath + seller.ProfileImage.ImageName,
                            Location = seller.City.Name + ", " + seller.City.Country.Name,
                            Name = seller.FirstName + " " + seller.SecondName,
                            Rank = seller.Rank,
                            Recipes = new RecipeHandler().GetAllBySellerId(seller.Id).Count()
                        });
                    }
                    ViewBag.AllSellers = sellerInfos;
                }

            }
            return PartialView("_AllSellers");

         
        }
        public ActionResult AllBuyers()
        {

            //if (Session[WebUtil.ADMIN] != null)
            //{
            List<MyRecipesModel> allRecipes = new List<MyRecipesModel>();
            foreach (Recipe recipe in new RecipeHandler().GetAll())
            {

                allRecipes.Add(new MyRecipesModel()
                {
                    Category = recipe.SubCategory.RecipeCategory.Name,
                    SubCategory = recipe.SubCategory.Name,
                    ImgUrl = recipe.RecipeImages.First().FolderPath,
                    Id = recipe.Id,
                    Price = recipe.Price.ToString(".00"),
                    Title = recipe.Title
                });

            }



            ViewBag.AllRecipes = allRecipes;


            //  return PartialView("AllRecipes");

            //}
            return PartialView("_AllBuyers");
        }
        public ActionResult AllOrders()
        {

            //if (Session[WebUtil.ADMIN] != null)
            //{
            List<MyRecipesModel> allRecipes = new List<MyRecipesModel>();
            foreach (Recipe recipe in new RecipeHandler().GetAll())
            {

                allRecipes.Add(new MyRecipesModel()
                {
                    Category = recipe.SubCategory.RecipeCategory.Name,
                    SubCategory = recipe.SubCategory.Name,
                    ImgUrl = recipe.RecipeImages.First().FolderPath,
                    Id = recipe.Id,
                    Price = recipe.Price.ToString(".00"),
                    Title = recipe.Title
                });

            }



            ViewBag.AllRecipes = allRecipes;


            //  return PartialView("AllRecipes");

            //}
            return PartialView("_AllOrders");
        }

        public void DeleteSeller(int id)
        {
            new SellerHandler().DeleteById(id);


        }
    }
}