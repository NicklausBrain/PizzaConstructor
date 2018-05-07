using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using Microsoft.AspNet.Identity;
//using System.Web.Http;
using PizzaConstructor.WebApi.Configuration;

namespace PizzaConstructor.WebApi
{
    public class AdminAuthorize: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool allow = false;
            AdminSection adminSection = (AdminSection)WebConfigurationManager.GetSection("adminSection");
            AdminsCollection adminsCollection = adminSection.AdminEmails;

            for (int i = 0; i < adminsCollection.Count; i++)
            {
                if (httpContext.User.Identity.GetUserId() == adminsCollection[i].Email)
                {
                   return allow = true;
                }
                else
                {
                    allow = false;
                }
            }
            return allow;
            //return httpContext.Request.IsLocal || base.AuthorizeCore(httpContext);
        }
    }
}