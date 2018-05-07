using Microsoft.AspNet.Identity;
using PizzaConstructor.Entities;

namespace PizzaConstructor.WebApi.IdenityModels
{
    /// <summary>
    /// User that is used for authentication
    /// </summary>
    public class IdentityUser : IUser
    {
        public IdentityUser()
        {
        }

        public IdentityUser(User user)
        {
            this.Id = user.Email;
            this.UserName = user.Name;
        }

        public string Id { get; set; }

        public string UserName { get; set; }

        public User ConvertToUser()
        {
            User user = new User(this.UserName, this.Id);
            //user.Email = this.Id;
            //user.Name = this.UserName;
            return user;
        }
    }
}