using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using PizzaConstructor.Data;
using PizzaConstructor.Data.Repositories;

namespace PizzaConstructor.WebApi.IdenityModels
{
    public class IdentityUserManager : UserManager<IdentityUser>
    {
        public IdentityUserManager(IUserStore<IdentityUser> store) : base(store)
        {
        }

        public static IdentityUserManager Create(IdentityFactoryOptions<IdentityUserManager> options,
            IOwinContext context)
        {
            PizzaDataContext dbContext = new PizzaDataContext();
            UserRepository userRepository = new UserRepository(dbContext);
            IdentityUserStore userStore = new IdentityUserStore(userRepository);
            IdentityUserManager userManager = new IdentityUserManager(userStore);
            userManager.UserValidator = new IdentityUserValidator();

            return userManager;
        }
    }
}