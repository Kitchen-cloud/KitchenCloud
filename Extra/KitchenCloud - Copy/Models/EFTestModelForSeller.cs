using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloud.Models
{
    public class EFTestModelForSeller
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ProfileImage {get; set; }
        public int Reviews { get; set; }

        public int Visitors { get; set; }
        public float Ratings { get; set; }

        public string Description { get; set; }
        public List<Service> Services { get; set; }
       
    }

}