using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaConstructor.WebApi.Configuration
{
    using System.Configuration;
    [ConfigurationCollection(typeof(AdminEmail), AddItemName = "Email")]
    public class AdminsCollection: ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new AdminEmail();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((AdminEmail)(element)).Email;
        }

        public AdminEmail this[int idx]
        {
            get { return (AdminEmail)BaseGet(idx); }
        }
    }
}