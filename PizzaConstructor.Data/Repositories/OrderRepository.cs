using System;
using PizzaConstructor.Data.Infrastucture;
using PizzaConstructor.Data.Interfaces;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Data.Repositories
{

	public class OrderRepository : BaseRepository<Order, Guid>, IOrderRepository
    {
        public OrderRepository(PizzaDataContext db) 
            : base(db)
        {
        }
    }
}
