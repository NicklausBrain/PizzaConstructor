using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaConstructor.Entities
{
    public class Order
    {
        public Order()
        {
            this.Pizzas = new List<PizzaItem>();
            this.OrderStatus = OrderStatus.New;
        }

        public Order(Guid id, decimal totalPrice, Contact contact, User user = null)
        {
            this.Id = id;
            this.TotalPrice = totalPrice;
            this.Contact = contact;
            this.User = user;
            this.Date = DateTime.Now;
            this.Pizzas = new List<PizzaItem>();
            this.OrderStatus = OrderStatus.New;
        }

        [Key]
        public Guid Id { get; protected set; }

        public decimal TotalPrice { get; protected set; }

        public DateTime Date { get; protected set; }

        public virtual Contact Contact { get; protected set; }
        
        public virtual ICollection<PizzaItem> Pizzas { get; set; }

        public OrderStatus OrderStatus { get; protected set; }

        [Required]
        public virtual User User { get; set; }

        public void ChangeStatus(OrderStatus status)
        {
            this.OrderStatus = status;
        }
    }
}
