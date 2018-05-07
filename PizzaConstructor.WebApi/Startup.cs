using System.Web.Configuration;
using Microsoft.Owin;
using PizzaConstructor.WebApi.Configuration;

[assembly: OwinStartupAttribute(typeof(PizzaConstructor.WebApi.Startup))]
namespace PizzaConstructor.WebApi
{
    using Owin;
    using PizzaConstructor.WebApi.IdenityModels;
    using Microsoft.Owin.Security.Google;
    using Microsoft.AspNet.Identity;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Register  UserManager for OWIN
            app.CreatePerOwinContext<IdentityUserManager>(IdentityUserManager.Create);

            // Use cookies for authentication and authorization
            // LoginPath - path to redirect unauthenticated user            
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            // Receive settings about google application
            GoogleSection section = (GoogleSection)WebConfigurationManager.GetSection("googleSection");
            GoogleElement elem = section.GoogleElement;

            AdminSection adminSection = (AdminSection) WebConfigurationManager.GetSection("adminSection");
            AdminsCollection adminsCollection = adminSection.AdminEmails;

            for (int i = 0; i < adminsCollection.Count; i++)
            {
                var uuu = adminsCollection[i];
            }

           // Use external cookies
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            // Google authentication
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = elem.ClientId,
                ClientSecret = elem.ClientSecret,
                CallbackPath = new PathString("/Account/LoginCallback/")
            });
        }
    }
}