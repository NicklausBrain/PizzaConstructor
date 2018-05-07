namespace PizzaConstructor.Core.DTO
{
    public class IngredientDto
    {
        public IngredientDto()
        {
        }

        public IngredientDto(string name, decimal price, string imageUrl, string imageUrlMain, CategoryDto category, int index)
        {
            this.Name = name;
            this.Price = price;
            this.ImageUrl = imageUrl;
            this.ImageUrlMain = imageUrlMain;
            this.Category = category;
            this.Index = index;
        }

        public string Name { get;  set; }

        public decimal Price { get;  set; }

        public string ImageUrl { get;  set; }

        public string ImageUrlMain { get; set; }

        public CategoryDto Category { get;  set; }

        public int Index { get; set; }
    }
}
