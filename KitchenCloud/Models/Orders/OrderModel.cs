using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using KitchenCloudEntities.Orders;
using KitchenCloudEntities.Users;
using KitchenCloudEntitiesHandler.Orders;
using KitchenCloudEntitiesHandler.Recipes;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloud.Models.Orders
{
    public class OrderModel
    {
        public int Id { get; set; }
        public Status Status { get; set; }


        public Seller Seller { get; set; }

        public Seller Buyer { get; set; }

        public TrayRecipe Recipe { get; set; }

        public string OrderDate { get; set; }

        [Required(ErrorMessage = "is Required")]
        public string DueDate { get; set; }
        public Time Time { get; set; }


    }
}