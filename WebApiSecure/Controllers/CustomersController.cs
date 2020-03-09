using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace WebApiSecure.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        
       
		[HttpGet]
		public IHttpActionResult GetId(int id)
		{
            var identity = User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var name = claims.Where(p => p.Type == "name").FirstOrDefault()?.Value;
               
            }
            var customerFake = "customer-fake";
			return Ok(customerFake);
		}

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var customersFake = new string[] { "customer-1", "customer-2", "customer-3" };
            return Ok(customersFake);
        }
    }
}
