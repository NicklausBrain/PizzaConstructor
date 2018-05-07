using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaConstructor.Entities
{
    /// <summary>
    /// User with IUser Identity implementation
    /// </summary>
    public class User
    {
        public User()
        {
                Orders = new List<Order>();
        }

        public User(string name, string email)
        {
            this.Email = email;
            this.Name = name;
            Orders = new List<Order>();
        }

        /// <summary>
        /// Email. Is used as Primary Key
        /// </summary>
        [Key]
        public string Email { get; protected set; }
        
        public string Name { get; protected set; }

        public virtual ICollection<Order> Orders { get; protected set; }
        
    }
}
