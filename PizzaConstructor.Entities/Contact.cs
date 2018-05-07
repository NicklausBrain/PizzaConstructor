using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaConstructor.Entities
{
    public class Contact
    {
        public Contact()
        {
        }

        public Contact(Guid id, string name, string phone, string deliveryAddress)
        {
            this.Id = id;
            this.Phone = phone;
            this.Name = name;
            this.DeliveryAddress = deliveryAddress;
        }

        [Key]
        public Guid Id { get; protected set; }

        public string Phone { get; protected set; }
        
        public string Name { get; protected set; }
        
        public string DeliveryAddress { get; protected set; }
    }
}
