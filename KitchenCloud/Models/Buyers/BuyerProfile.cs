using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KitchenCloudEntities.Common;
using KitchenCloudEntities.Users;
using KitchenCloudEntitiesHandler.Common;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloud.Models.Buyers
{
    public class BuyerProfile
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Introduction { get; set; }
        public ProfileImage ProfileImage { get; set; }

        public Country Country { get; set; }

    }
}