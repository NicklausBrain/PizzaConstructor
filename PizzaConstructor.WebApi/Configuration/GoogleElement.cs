
namespace PizzaConstructor.WebApi.Configuration
{
    using System.Configuration;

    /// <summary>
    /// Element to discribe google authentication information in configuration file
    /// </summary>
    public class GoogleElement : ConfigurationElement
    {
        private const string CLIENT_ID = "clientId";

        private const string CLIENT_SECRET = "clientSecret";

        [ConfigurationProperty(GoogleElement.CLIENT_ID, DefaultValue = "", IsKey = true, IsRequired = true)]
        public string ClientId
        {
            get
            {
                return base[GoogleElement.CLIENT_ID].ToString();
            }
        }

        [ConfigurationProperty(GoogleElement.CLIENT_SECRET, DefaultValue = "", IsKey = false, IsRequired = true)]
        public string ClientSecret
        {
            get
            {
                return base[GoogleElement.CLIENT_SECRET].ToString();
            }
        }
    }
}