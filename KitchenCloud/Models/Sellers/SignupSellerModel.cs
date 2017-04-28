using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace KitchenCloud.Models.Sellers
{
    public class SignupSellerModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "is Required")]

        public string SecondName { get; set; }


        [Required(ErrorMessage = "is Required")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }


        [Required(ErrorMessage = "is Required")]

        public string Password { get; set; }

        [Compare("Password",ErrorMessage = "not Match")]

        public string ConfirmPassword { get; set; }


        public string Country { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }

    }
}