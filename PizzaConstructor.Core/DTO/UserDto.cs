using System.Collections.Generic;

namespace PizzaConstructor.Core.DTO
{
    public class UserDto
    {
        public UserDto()
        {
            this.Orders = new List<OrderDto>();
        }

        public UserDto(string name, string email, List<OrderDto> orders)
        {
            this.Name = name;
            this.Email = email;
            this.Orders = orders;
        }

        public string Name { get;  set; }

        public string Email { get;  set; }

        public ICollection<OrderDto> Orders { get;  set; }
    }
}
