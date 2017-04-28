using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenCloud.Models.Recipes
{
    public class MyRecipesModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ImgUrl { get; set; }
        public string Price { get; set; }

    }
}