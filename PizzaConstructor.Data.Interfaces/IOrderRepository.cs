using System;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Data.Interfaces
{
    public interface IOrderRepository: IRepository<Order, Guid>
    {
    }
}
