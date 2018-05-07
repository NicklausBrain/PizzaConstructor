using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace PizzaConstructor.WebApi.Controllers
{
    public class AuthenticationController : ApiController
    {
        // GET api/values
        [HttpGet]
        public bool IsAuthenticated()
        {
            return User.Identity.IsAuthenticated;
        }
    }
}
