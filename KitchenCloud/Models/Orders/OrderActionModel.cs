using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KitchenCloudEntities.Orders;

namespace KitchenCloud.Models.Orders
{
    public class OrderActionModel
    {
        public Status Action { get; set; }
        public string Description { get; set; }

    }
}