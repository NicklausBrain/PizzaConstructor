using System;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Data.Interfaces
{
    public interface ITemplateRepository: IRepository<PizzaTemplate, Guid>
    {
    }
}
