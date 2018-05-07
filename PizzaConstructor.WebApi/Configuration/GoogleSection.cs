
namespace PizzaConstructor.WebApi.Configuration
{
    using System.Configuration;

    public class GoogleSection : ConfigurationSection
    {
        private const string GOOGLE_ELEMENT = "googleApplication";

        [ConfigurationProperty(GoogleSection.GOOGLE_ELEMENT)]
        public GoogleElement GoogleElement
        {
            get { return (GoogleElement) base[GoogleSection.GOOGLE_ELEMENT]; }
        }
    }
}