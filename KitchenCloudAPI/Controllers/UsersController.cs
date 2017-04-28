using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KitchenCloud.Models.Helpers;
using KitchenCloudAPI.Models.Helpers;
using KitchenCloudEntitiesHandler.Recipes;
using KitchenCloudEntitiesHandler.Users;

namespace KitchenCloudAPI.Controllers
{
    public class UsersController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {


                return Ok(APITypeCaster.SellerListToApiUserList(new SellerHandler().GetAll()));
            }
            catch
            {
                return NotFound();
            }
        }
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(APITypeCaster.SellerToApiUser(new SellerHandler().GetById(id)));
            }
            catch
            {
                return NotFound();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                new SellerHandler().DeleteById(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
