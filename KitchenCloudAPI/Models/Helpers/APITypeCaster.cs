using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KitchenCloudEntities.Users;
using KitchenCloudEntitiesHandler.Users;
using User = KitchenCloudAPI.Models.Users.User;


namespace KitchenCloudAPI.Models.Helpers
{
    public class APITypeCaster
    {
        public static List<User> SellerListToApiUserList(List<Seller> Sellers)
        {
            List<User> users = null;
            if (Sellers != null)
            {
                users=new List<User>();

                foreach (var seller in Sellers)
                {
                    users.Add(new User
                    {
                        Id = seller.Id,
                        Email = seller.Email,
                        Name = seller.FirstName+" "+seller.SecondName

                    });
                }
            }
            return users;

        } 

        public static User SellerToApiUser(Seller Seller)
        {
            User user = null;
            if (Seller != null)
            {
                user = new User
                {
                    Id = Seller.Id,
                    Email = Seller.Email,
                    Name = Seller.FirstName + " " + Seller.SecondName

                };
            }
            
            return user;

        } 



    }

}