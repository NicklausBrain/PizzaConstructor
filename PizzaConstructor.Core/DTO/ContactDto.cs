namespace PizzaConstructor.Core.DTO
{
    public class ContactDto 
    {
        public ContactDto()
        {
        }
        public ContactDto(string name, string phone, string deliveryAddress)
        {
            this.Name = name;
            this.Phone = phone;
            this.DeliveryAddress = deliveryAddress;
        }
        public string Phone { get;  set; }

        public string Name { get;  set; }

        public string DeliveryAddress { get;  set; }
    }
}
