using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloud.Models.Shared
{
    public class LoginUserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "is Required")]
        public string Password { get; set; }

       

    }
}