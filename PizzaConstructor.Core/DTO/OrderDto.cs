using System;
using System.Collections.Generic;

namespace PizzaConstructor.Core.DTO
{
    public class OrderDto
    {
        public OrderDto()
        {
           this.Pizzas = new List<PizzaItemDto>();
        }

        public OrderDto(decimal totalPrice, DateTime date, ContactDto contact, UserDto user, List<PizzaItemDto> pizzas)
        {
            this.TotalPrice = totalPrice;
            this.Date = date;
            this.Contact = contact;
            this.User = user;
            this.Pizzas = pizzas;
        }

        public decimal TotalPrice { get;  set; }

        public DateTime Date { get;  set; }

        public ContactDto Contact { get;  set; }

        public ICollection<PizzaItemDto> Pizzas { get;  set; }

        public UserDto User { get;  set; }

        public OrderStatusDto OrderStatus { get; set; }

        public Guid Id { get; set; }
    }
}
