using PizzaConstructor.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaConstructor.WebApi.Models
{
    public class OrderModel
    {
        public OrderModel()
        {
            this.Pizzas = new List<PizzaItemDto>();
            this.StatusItems = new List<SelectListItem>();

            IEnumerable<Status> values = Enum.GetValues(typeof(Status)).Cast<Status>();
            foreach (var value in values)
            {
                this.StatusItems.Add(
                    new SelectListItem
                    {
                        Text = value.ToString()
                      , Value = value.ToString()
                    }
                );
            }
        }

        public decimal TotalPrice { get; set; }

        public DateTime Date { get; set; }

        public ContactDto Contact { get; set; }

        public ICollection<PizzaItemDto> Pizzas { get; set; }

        public UserDto User { get; set; }

        public OrderStatusDto OrderStatus { get; set; }

        public Guid Id { get; set; }

        public ICollection<SelectListItem> StatusItems { get; }

        public string StatusId { get; set; }
    }
}