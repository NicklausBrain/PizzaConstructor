using PizzaConstructor.Entities;
using System;
using System.Collections.Generic;

namespace PizzaConstructor.Data.Interfaces
{
    public interface IIngredientRepository: IRepository<Ingredient, Guid>
    {
        IEnumerable<Ingredient> GetIngredientByCategory(Categories cat);
    }
}
