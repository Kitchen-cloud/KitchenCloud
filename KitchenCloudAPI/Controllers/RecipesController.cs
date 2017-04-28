
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KitchenCloud.Models.Helpers;
using KitchenCloudEntitiesHandler.Recipes;

namespace KitchenCloudAPI.Controllers
{
    public class RecipesController : ApiController
    {
        public IHttpActionResult Get()
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
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(TypeCaster.ToRecipeTemplateList(new RecipeHandler().GetAllBySellerId(id)));
            }
            catch
            {
                return NotFound();
            }
        }

         public IHttpActionResult Delete(int id)
        {
            try
            {
                new RecipeHandler().DeleteById(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}