using System.Collections.Generic;

namespace PizzaConstructor.Core.DTO
{
    public class TemplateDto
    {
        public TemplateDto()
        {
            this.Ingredients = new List<IngredientDto>();
        }

        public TemplateDto(string name, decimal totalCost, string imageUrl, List<IngredientDto> ingredients)
        {
            this.Name = name;
            this.TotalCost = totalCost;
            this.ImageUrl = imageUrl;
            this.Ingredients = ingredients;
        }

        public string Name { get;  set; }

        public decimal TotalCost { get;  set; }

        public string ImageUrl { get;  set; }

        public ICollection<IngredientDto> Ingredients { get;  set; }
    }
    
}
