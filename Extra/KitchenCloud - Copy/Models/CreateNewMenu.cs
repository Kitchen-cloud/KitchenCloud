using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages.Html;

namespace KitchenCloud.Models
{
    public class CreateNewMenu
    {
        public int Id { get; set; }

        [Required]
        public string Category { get; set; }
        [Required]
        public string SubCatrory { get; set; }
        public string PersonsFor { get; set; }

        [Required]
        public string Description { get; set; }
        public SelectListItem Location { get; set; }
        [Required]
        public string StreetAddress { get; set;}
        [Required]

        public string[] Media { get; set; }
        [Required]

        public string[] Tags { get; set; }
    }
}