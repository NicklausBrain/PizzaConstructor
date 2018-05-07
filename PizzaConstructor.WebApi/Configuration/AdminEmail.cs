using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaConstructor.WebApi.Configuration
{
    using System.Configuration;

    public class AdminEmail: ConfigurationElement
    {
        [ConfigurationProperty("email", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Email
        {
            get { return ((string)(base["email"])); }
            set { base["email"] = value; }
        }

        [ConfigurationProperty("name", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Name
        {
            get { return ((string)(base["name"])); }
            set { base["name"] = value; }
        }
    }
}