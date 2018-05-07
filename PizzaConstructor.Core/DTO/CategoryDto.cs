namespace PizzaConstructor.Core.DTO
{
    public class CategoryDto
    {
        public CategoryDto()
        {
        }
        public CategoryDto(string name)
        {
            this.Name = name;
        }
        public string Name { get;  set; }      
    }
}
