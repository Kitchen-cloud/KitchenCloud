using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using KitchenCloud.Models.Shared;
using KitchenCloudEntities.Users;
using KitchenCloudEntitiesHandler.Common;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloud.Models.Sellers
{
    public class SellerProfileSettings
    {

        public int Id { get; set; }
        public ProfileImage ProfileImage { get; set; }
        public string Slogan { get; set; }

        public string Introduction { get; set; }
        public bool IA { get; set; }
        public bool AJ { get; set; }
        public bool FD { get; set; }



        [Required(ErrorMessage = "is Required")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "is Required")]
        public string NewPassword { get; set; }
        [Compare("NewPassword", ErrorMessage = "not Match")]
        public string ConfirmNewPassword { get; set; }

    }
}