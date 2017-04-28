using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenCloudEntitiesHandler.Recipes;

namespace KitchenCloud.Models.Shared
{
  public  class MyTrayRecipe
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public string Title { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ImgUrl { get; set; }
        public int Price { get; set; }

        public int Amount
        {
            get { return Price * Quantity; }
        }


    }
}
