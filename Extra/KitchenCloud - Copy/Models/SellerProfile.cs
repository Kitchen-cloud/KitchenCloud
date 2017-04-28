﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KitchenCloudEntitiesHandler.Common;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloud.Models
{
    public class SellerProfile
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public ProfileImage ProfileImage { get; set; }
        public string Slogan { get; set; }
        public int Reviews { get; set; }
        public double Ratings { get; set; }

        public int Visitors { get; set; }
        public Country Location { get; set; }
        public string Introduction { get; set; }
        public List<Service> Services { get; set; }
         
    }
}