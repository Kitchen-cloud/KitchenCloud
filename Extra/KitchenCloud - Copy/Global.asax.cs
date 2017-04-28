using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using KitchenCloudEntitiesHandler.Common;
using KitchenCloudEntitiesHandler.Menus;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloud
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

           
           // new MenuHandler().DeleteById(1);



            /////////////////////Buyer 

            //Buyer buyer = new Buyer();
            //City city = new City();
            //city.Name = "Lahore";
            //city.Id = 1;
            //Country country = new Country();
            //country.City = city;
            //country.Code = 92;
            //country.Name = "Pakistan";
            //country.Id = 1;
            //ProfileImage image = new ProfileImage();
            //image.Caption = "Irshad";

            //image.ImageName = "myimg.png";
            //image.FolderPath = string.Format("~/Content/Images/Users/Profile Img/{0}", image.ImageName);
            //buyer.Id = 4;


            //buyer.Country = country;

            //buyer.Description = "Hi, I'm Irshad Ahmed. Working as developer and designer at Code Bakers Inc.";
            //buyer.FirstName = "Irshad";
            //buyer.SecondName = "Ahmed";
            //buyer.Email = "Irshadahmed31@yahoo.com";
            //buyer.ProfileImage = image;
            //new BuyerHandler().Add(buyer);

            ///////////////////

            /////////Seller



            //RecipeSubCategory rc = new RecipeSubCategory()
            //{
            //    Id = 1,
            //    Name = "Soup"
            //};

            //RecipeCategory c = new RecipeCategory()
            //{
            //    Id = 1,
            //    Name = "Chinese",
            //    RecipeSubCategory = rc

            //};

            //List<MenuImage> menuimages = new List<MenuImage>()
            //{
            //    new MenuImage()
            //    {
            //        Id = 1,
            //        Caption = "MenuImg",
            //        FolderPath = "~/Content/Images/Users/Menu Images/MenuImg (1).jpg",
            //        ImageName = "MenuName"


            //    }

            //};





            //Menu menu =new Menu(){
            //    Category = c,
            //    Id = 1,
            //    MenuImages = menuimages,
            //    PersonsFor = "Party",
            //    Price = 610.00F,
            //    Ratings = 3.5F,
            //    Title = "Special",
            //    TotalOrders = 402

            //};



            //City city=new City()
            //{
            //    Id = 1,
            //    Name = "Karachi"
            //};
            //Country country=new Country()
            //{
            //    Id = 1,
            //    Name = "Pakitan",
            //    City = city,
            //    Code = 92
            //};





            //ProfileImage pf=new ProfileImage()
            //{
            //    Caption = "seller",
            //    FolderPath = "~/Content/Images/Users/Profile Img/Seller.jpg",
            //    Id = 1,
            //    ImageName = "seller"
            //};


            //Service service=new Service()
            //{
            //    Id = 1,
            //    Name = "Live"
            //};





            //Seller seller=new Seller()
            //{Country = country,
            //Description = "The central processing unit or (CPU) is the 'brain of your computer. It contains the electronic circuits that cause the computer to follow instructions from memory.",
            //Email = "KitchenCloud@yahoo.com",
            //FirstName = "Faizan",
            //Id = 1,
            //Menus = new List<Menu>() {menu},
            //Password = "11225",
            //ProfileImage =pf,
            //Rank = 4.2F,
            //Reviews = 53,
            //SecondName = "Elahi",
            //Services = new List<Service>() { service},
            //TotalOrders = 1445,
            //Slogan = "Best Service Ever !!! ",
            //Visitors = 22004
            //};


            //new SellerHandler().Add(seller);



            ///////////////////


            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
