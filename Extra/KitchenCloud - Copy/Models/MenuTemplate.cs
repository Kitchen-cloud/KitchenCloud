using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenCloud.Models
{
    public class MenuTemplate
    {
        public int Id { get; set; }
        public string Title{ get; set; }
        public float Ratings{ get; set; }
        public int TotalOrders{ get; set; }
        public string Image{ get; set; }
        public string[] Services{ get; set; }
        public string PersonsFor { get; set; }
        public string Location { get; set; }




    }
}