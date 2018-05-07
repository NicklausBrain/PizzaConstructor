using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaConstructor.Core.DTO
{
    public class OrderStatusDto
    {
        public OrderStatusDto()
        {
        }

        public OrderStatusDto(string name)
        {
            this.Status = name;
        }

        public string Status { get; set; }
    }
}
