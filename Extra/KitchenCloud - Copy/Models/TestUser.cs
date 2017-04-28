using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace KitchenCloud.Models
{
    public class TestUser
    {


        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email  { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]




        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }



    }
}