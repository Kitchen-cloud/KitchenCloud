using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenCloud.Models.Shared
{

    public class SearchKeys
    {
        public string ByName { get; set; }
        public string ByPrice { get; set; }
        public string ByLocation { get; set; }
        public string ByOnlineSellers { get; set; }
        public string ByMealFor { get; set; }
    }
}