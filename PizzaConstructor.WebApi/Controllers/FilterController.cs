using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using PizzaConstructor.Core;
using PizzaConstructor.Data;
using PizzaConstructor.Entities;
using PizzaConstructor.Core.DTO;
using PizzaConstructor.Data.Interfaces;

namespace PizzaConstructor.WebApi.Controllers
{
    public class FilterController : ApiController
    {
        private IIngredientRepository ingredientRepository;

        public FilterController()
        {
            this.ingredientRepository = DependencyResolver.Current.GetService<IIngredientRepository>();
        }

        public IEnumerable<IngredientDto> GetIngredients()
        {
            List<Ingredient> ingredientList;
                
            ingredientList = this.ingredientRepository.GetList().ToList();

            List<IngredientDto> ingredientDtoList = new List<IngredientDto>();

                foreach (Ingredient ingredient in ingredientList)
                {
                    ingredientDtoList.Add(new IngredientDto
                    {
                        ImageUrl = ingredient.ImageUrl,
                        Name = ingredient.Name,
                        Price = ingredient.Price,
                        Category = new CategoryDto(ingredient.Category.ToString())
                });
            }

            return ingredientDtoList;
            }
        

        public IEnumerable<IngredientDto> GetIngredientByCategory(string name)
            {
                IngridientsList l = new IngridientsList(this.ingredientRepository);
                var f = l.GetIngridientsByCategory(name);
                return f;
            }
        }
    }
