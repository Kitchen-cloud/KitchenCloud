using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages.Html;
using KitchenCloudEntitiesHandler.Common;
using KitchenCloudEntitiesHandler.Recipes;
using KitchenCloudEntities.Common;
using KitchenCloudEntities.Recipes;

namespace KitchenCloud.Models.Recipes
{
    public class CreateNewRecipe
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }
        [Required]
        public string SubCatrory { get; set; }
        public string PersonsFor { get; set; }

        [Required]
        public string Description { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        [Required]
        public string StreetAddress { get; set;}
         [Required]

        public List<RecipeImage> MenuImages { get; set; }
        [Required]

        public List<RecipeTag> Tags { get; set; }

        [Required]
        public string Price { get; set; }
    }
}