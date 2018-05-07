using PizzaConstructor.Core.DTO;
using System.Collections.Generic;

namespace PizzaConstructor.WebApi.Models
{
    public class CategoryIngredients
    {
        public CategoryDto Category { get; set; }

        public IEnumerable<IngredientDto> Ingredients { get; set; }
    }
}