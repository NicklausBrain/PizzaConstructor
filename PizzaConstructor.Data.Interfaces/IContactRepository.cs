using System;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Data.Interfaces
{
    public interface IContactRepository: IRepository<Contact, Guid>
    {
    }
}
