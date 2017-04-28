using System.ComponentModel.DataAnnotations;
namespace KitchenCloud.Models.Admin
{
    public class LoginModel
    {
        [Required(ErrorMessage = "is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "is required")]
        public string Password { get; set; }
    }
}