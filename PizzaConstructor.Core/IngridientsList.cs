using System.Collections.Generic;
using System.Linq;
using PizzaConstructor.Core.DTO;
using PizzaConstructor.Data.Interfaces;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Core
{
    public class IngridientsList
    {
        //private IRepository<Ingredient, Guid> _ingredientRepository;
        private IIngredientRepository _ingredientRepository;
        //public IngridientsList(BaseRepository<Ingredient, Guid> pizzaRepository)
        //{
        //    this._ingredientRepository = pizzaRepository;
        //}
        public IngridientsList(IIngredientRepository ingRep)
        {
            this._ingredientRepository = ingRep;

            
        }
        //Get all ingredients
        public List<IngredientDto> GetIngridientsList()
        {
            var ingredients = this._ingredientRepository.GetList().ToList();
            var ingredientsListDto = new List<IngredientDto>();
            foreach (var ingredient in ingredients)
            {
                ingredientsListDto.Add(DtoBuilder.ToDto(ingredient));
            }
            return ingredientsListDto;
        }

        //Get categorized ingredients
        public List<IngredientDto> GetIngridientsByCategory(string categoryName)
        {
            var ingredients = this._ingredientRepository.GetList(i => i.Category.ToString() == categoryName).ToList();
            var ingredientsListDto = new List<IngredientDto>();
            foreach (var ingredient in ingredients)
            {
                ingredientsListDto.Add(DtoBuilder.ToDto(ingredient));
            }
            return ingredientsListDto;
        }

        
        public List<CategoryDto> GetIngredientCategories()
        {
            List<CategoryDto> categories = new List<CategoryDto>();
            categories.Add(
                new CategoryDto(Categories.Dough.ToString())
            );
            categories.Add(
                new CategoryDto(Categories.Souses.ToString())
            );
            categories.Add(
                new CategoryDto(Categories.Cheese.ToString())
            );
            categories.Add(
                new CategoryDto(Categories.Meat.ToString())
            );
            categories.Add(
                new CategoryDto(Categories.Vegetables.ToString())
            );
            categories.Add(
                new CategoryDto(Categories.SeaFood.ToString())
            );

            return categories;
        }
    }
}
