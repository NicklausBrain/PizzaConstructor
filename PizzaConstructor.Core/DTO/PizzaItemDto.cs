using System.Collections.Generic;

namespace PizzaConstructor.Core.DTO
{
    using System;

    public class PizzaItemDto
    {
        public PizzaItemDto()
        {
            this.Ingredients = new List<IngredientDto>();
        }

        public PizzaItemDto(string name, decimal totalCost, string imageUrl, DateTime date, List<IngredientDto> ingredients)
        {
            this.Name = name;
            this.TotalCost = totalCost;
            this.ImageUrl = imageUrl;
            this.Date = date;
            this.Ingredients = ingredients;
        }

        public string Name { get;  set; }

        public decimal TotalCost { get;  set; }

        public string ImageUrl { get;  set; }

        public DateTime Date { get; set; }

        public  ICollection<IngredientDto> Ingredients { get;  set; }

    }
}
