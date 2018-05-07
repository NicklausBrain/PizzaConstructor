using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaConstructor.Core.DTO;
using PizzaConstructor.Data.Interfaces;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Core
{
   public  class UserList
    {
        private IUserRepository _userRepository;
      
        public UserList(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public List<User> GetUserList()
        {
            var users = this._userRepository.GetList().ToList();
            return users;
        }

        public User GetUserByEmail(string email)
        {
            var user = this._userRepository.GetById(email);
            return user;
        }
    }
}
