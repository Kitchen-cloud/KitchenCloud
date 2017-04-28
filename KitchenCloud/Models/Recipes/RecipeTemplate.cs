using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloud.Models.Recipes
{
    public class RecipeTemplate
    {

        public int Id { get; set; }

        public string Title{ get; set; }
        public float Ratings{ get; set; }
        public int TotalOrders{ get; set; }
        public string Image{ get; set; }
        public string[] Services{ get; set; }
        public string[] Tags{ get; set; }
        public string PersonsFor { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
        public RecipeSeller Seller { get; set; }




    }
}