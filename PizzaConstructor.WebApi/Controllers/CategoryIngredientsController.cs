using PizzaConstructor.Core;
using PizzaConstructor.Core.DTO;
using PizzaConstructor.Data.Interfaces;
using PizzaConstructor.WebApi.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace PizzaConstructor.WebApi.Controllers
{
    public class CategoryIngredientsController : ApiController
    {
        private IIngredientRepository _ingredientRepository;

        public CategoryIngredientsController()
        {
            _ingredientRepository = DependencyResolver.Current.GetService<IIngredientRepository>();
        }

        [ResponseType(typeof(IEnumerable<CategoryIngredients>))]
        public IHttpActionResult Get()
        {
            IngridientsList list = new IngridientsList(_ingredientRepository);
            List<CategoryIngredients> result = new List<CategoryIngredients>();
            
            List<CategoryDto> categories = list.GetIngredientCategories();
            foreach(var category in categories)
            {
                CategoryIngredients categoryIngredients = new CategoryIngredients();
                categoryIngredients.Category = category;
                categoryIngredients.Ingredients = 
                    list.GetIngridientsByCategory(category.Name);
                result.Add(categoryIngredients);
            }

            return Ok(result);
        }
    }
}
