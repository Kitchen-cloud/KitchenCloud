using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using KitchenCloudEntitiesHandler.Common;
using KitchenCloudEntitiesHandler.Recipes;
using KitchenCloudEntities.Common;
using KitchenCloudEntities.Recipes;

namespace KitchenCloud.Models.Recipes
{
    public class RecipeDescription
    {
    
            public int Id { get; set; }

            public RecipeSeller Seller { get; set; }

        public List<RecipeTemplate> Recipes { get; set; }

            public string Title { get; set; }

           
            public string Category { get; set; }
         
            public string SubCatrory { get; set; }
            public string PersonsFor { get; set; }

           
            public string Description { get; set; }
            public Country Country { get; set; }
            public City City { get; set; }
     
            public string StreetAddress { get; set; }
           
       

            public List<RecipeImage> MenuImages { get; set; }
       

            public List<RecipeTag> Tags { get; set; }

        
            public float Price { get; set; }
        }
    }
