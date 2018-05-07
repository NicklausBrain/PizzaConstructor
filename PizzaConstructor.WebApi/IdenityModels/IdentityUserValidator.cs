using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace PizzaConstructor.WebApi.IdenityModels
{
    public class IdentityUserValidator : IIdentityValidator<IdentityUser>
    {
        public Task<IdentityResult> ValidateAsync(IdentityUser item)
        {
            return Task.Factory.StartNew(() => IdentityResult.Success);
        }
    }
}