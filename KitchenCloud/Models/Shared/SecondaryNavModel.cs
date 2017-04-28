using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenCloud.Models.Shared
{
    public class SecondaryNavModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<String> Subcategories { get; set; }
     }
}