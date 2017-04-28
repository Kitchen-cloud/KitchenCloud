using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitchenCloud.Models.Shared
{
    public class DDListModel
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public List<SelectListItem> Values { get; set; }
    }
}