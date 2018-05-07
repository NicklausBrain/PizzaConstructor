using PizzaConstructor.Entities;
using System;

namespace PizzaConstructor.Data.Interfaces
{
    public interface IPizzaRepository: IRepository<PizzaItem, Guid>
    {
    }
}
