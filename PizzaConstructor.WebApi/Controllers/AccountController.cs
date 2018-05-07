using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PizzaConstructor.WebApi.IdenityModels;

namespace PizzaConstructor.WebApi.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private IdentityUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IdentityUserManager>();
            }
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            const int ACCESS_DENIDED = 0;

            ViewBag.returnUrl = returnUrl;
            return RedirectToAction("Index", "Home", new {message = ACCESS_DENIDED,isDanger=true});
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult GoogleLogin(string returnUrl)
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("LoginCallback", new { returnUrl = returnUrl })
            };

            HttpContext.GetOwinContext().Authentication.Challenge(properties, "Google");
            return new HttpUnauthorizedResult();
        }

        [AllowAnonymous]
        public async Task<ActionResult> LoginCallback(string returnUrl)
        {
            // Get info about user from external web site
            ExternalLoginInfo loginInfo = await this.AuthenticationManager.GetExternalLoginInfoAsync();

            // Search user in our store by email
            IdentityUser user = await this.UserManager.FindByIdAsync(loginInfo.Email);
            
            if (user == null)
            {
                // Create user and save him
                user = new IdentityUser()
                {
                    Id = loginInfo.Email,
                    UserName = loginInfo.DefaultUserName
                };
                IdentityResult result = await UserManager.CreateAsync(user);
                if (!result.Succeeded)
                {
                    return View("Error", result.Errors);
                }
            }

            // Use authentication with our cookies
            ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                DefaultAuthenticationTypes.ApplicationCookie);

            // Sign in
            AuthenticationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = false
            }, ident);

            return Redirect(returnUrl ?? "/");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            this.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            this.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            this.AuthenticationManager.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}