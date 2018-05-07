using System;
using System.Collections.Generic;
using System.Linq;
using PizzaConstructor.Data.Infrastucture;
using PizzaConstructor.Data.Interfaces;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Data.Repositories
{
	public class IngredientRepository : BaseRepository<Ingredient, Guid>, IIngredientRepository
    {
        public IngredientRepository(PizzaDataContext db)
            : base(db)
        {
        }

        public IEnumerable<Ingredient> GetIngredientByCategory(Categories cat)
        {
            return this.GetList(ingr => ingr.Category == cat).ToList();
        }

    }
}
