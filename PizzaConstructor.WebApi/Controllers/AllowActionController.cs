using Microsoft.AspNet.Identity;
using PizzaConstructor.WebApi.Configuration;
using PizzaConstructor.WebApi.Models;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace PizzaConstructor.WebApi.Controllers
{
    public class AllowActionController : Controller
    {
        private IIdentity _identity;

        public AllowActionController(IIdentity identityUser)
        {
            this._identity = identityUser;
        }

        [AllowAnonymous]
        public IEnumerable<AllowedAction> GetAllowedActions()
        {
            List<AllowedAction> allowedActions = new List<AllowedAction>();
            allowedActions.Add(new AllowedAction("Templates", "Templates", "Home"));
            if (this._identity.IsAuthenticated)
            {
                allowedActions.Add(new AllowedAction("Create your pizza", "PizzaConstructor", "Home"));
                allowedActions.Add(new AllowedAction("Your pizzas", "OrdersHistory", "Home"));

                string userId = this._identity.GetUserId();

                AdminSection adminSection = (AdminSection)WebConfigurationManager.GetSection("adminSection");
                AdminsCollection adminsCollection = adminSection.AdminEmails;
                for (int i = 0; i < adminsCollection.Count; i++)
                {
                    if (adminsCollection[i].Email == userId)
                    {
                        allowedActions.Add(new AllowedAction("Admin panel", "Index", "AdminPage"));
                        break;
                    }
                }
            }

            return allowedActions;
        }
    }
}