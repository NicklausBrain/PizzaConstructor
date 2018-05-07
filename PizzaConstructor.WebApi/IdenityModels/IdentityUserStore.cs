using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PizzaConstructor.Data.Repositories;
using PizzaConstructor.Entities;

namespace PizzaConstructor.WebApi.IdenityModels
{
    public class IdentityUserStore : IUserStore<IdentityUser>
    {
        private UserRepository _repository;

        public IdentityUserStore(UserRepository repository)
        {
            this._repository = repository;
        }

        public Task CreateAsync(IdentityUser user)
        {
            return Task.Factory.StartNew(() =>
            {
                User domainUser = user.ConvertToUser();
                _repository.Add(domainUser);
                _repository.SaveChanges();
            });
        }

        public Task DeleteAsync(IdentityUser user)
        {
            return Task.Factory.StartNew(() =>
            {
                User domainUser = user.ConvertToUser();
                _repository.Delete(domainUser);
                _repository.SaveChanges();
            });
        }

        public Task<IdentityUser> FindByIdAsync(string userId)
        {
            return Task.Factory.StartNew(() =>
            {
                IdentityUser user = null;
                User domainUser = _repository.GetById(userId);
                if (domainUser != null)
                {
                    user = new IdentityUser(domainUser);
                }
                return user;
            });
        }

        public Task<IdentityUser> FindByNameAsync(string userName)
        {
            return Task.Factory.StartNew(() =>
            {
                IdentityUser user = null;
                User domainUser = _repository.GetList(u => u.Name == userName).FirstOrDefault();
                if (domainUser != null)
                {
                    user = new IdentityUser(domainUser);
                }
                return user;
            });
        }

        public Task UpdateAsync(IdentityUser user)
        {
            return Task.Factory.StartNew(() =>
            {
                User domainUser = user.ConvertToUser();
                _repository.Update(domainUser);
                _repository.SaveChanges();
            });
        }
        
        
        public void Dispose()
        {
            _repository.Dispose();
        }
        
    }
}