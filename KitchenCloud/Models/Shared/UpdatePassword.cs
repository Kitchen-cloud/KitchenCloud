using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloud.Models.Shared
{
    public class UpdatePassword
    {




        [Required(ErrorMessage = "is Required")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "is Required")]
        public string NewPassword { get; set; }
        [Compare("New",ErrorMessage = "not Match")]
        public string ConfirmNewPassword { get; set; }

       

    }
}