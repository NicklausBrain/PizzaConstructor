using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaConstructor.WebApi.Configuration
{
    using System.Configuration;

   
    public class AdminSection : ConfigurationSection
    {
        [ConfigurationProperty("AdminEmails")]
        public AdminsCollection AdminEmails
        {
            get { return (AdminsCollection) (base["AdminEmails"]); }
        }
    }
}