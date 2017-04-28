using KitchenCloud.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using KitchenCloud.Models.Orders;
using KitchenCloud.Models.Recipes;
using KitchenCloud.Models.Sellers;
using KitchenCloud.Models.Shared;
using KitchenCloudEntities.Common;
using KitchenCloudEntities.Orders;
using KitchenCloudEntitiesHandler.Recipes;
using KitchenCloudEntitiesHandler.Users;
using System.Web.ModelBinding;
using KitchenCloudEntities.Recipes;
using KitchenCloudEntities.Users;

namespace KitchenCloudAPI.Controllers
{
    public class DashboardController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Index()
        {
          
            try
            {
                return Ok(TypeCaster.ToRecipeTemplateList(new RecipeHandler().GetAll()));

            }
            catch 
            {
                

                return NotFound();
            }
        }
        [HttpGet]
        public IHttpActionResult Guest()
        {
            try
            {
                return Ok(TypeCaster.ToRecipeTemplateList(new RecipeHandler().GetAll()));

            }
            catch (Exception)
            {
                
                return NotFound();
            }
        }
        [HttpGet]
        public IHttpActionResult RecipeDescription(int id)
        {

          
            try
            {
                Recipe recipe = new RecipeHandler().GetById(id);

                List<RecipeTemplate> recipesList =
                TypeCaster.ToRecipeTemplateList(new RecipeHandler().GetAllBySellerId(recipe.Seller.Id));



                RecipeDescription rc = new RecipeDescription()
                {
                    Id = recipe.Id,
                    Seller = new RecipeSeller()
                    {
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

                return Ok(rc);
            }
            catch (Exception)
            {

                return NotFound();
            }
           
        }
        [HttpGet]
        public IHttpActionResult LogIn(string userName,string password)
        {
            try
            {

                User user = new User
                {
                    UserName = userName,
                    Password = password
                };

                User us = new UserHandler().UserLogin(user);

                if (us != null)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                return NotFound();
            }
        }
        [HttpGet]
        public IHttpActionResult Search(string key)
        {
            try
            {
                if (!key.Equals(String.Empty))
                {
                    var recipeTemplates = TypeCaster.ToRecipeTemplateList(new RecipeHandler().GetAll());                  
                    return Ok(recipeTemplates.Where(x => x.Tags.Any(s => s.Contains(key))).ToList());
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

    }
}
