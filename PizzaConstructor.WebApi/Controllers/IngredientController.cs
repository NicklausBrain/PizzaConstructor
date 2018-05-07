using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PizzaConstructor.Core.DTO;
using PizzaConstructor.Data.Interfaces;
using System.Web.Mvc;
using PizzaConstructor.Core;
using PizzaConstructor.Entities;

namespace PizzaConstructor.WebApi.Controllers
{
    public class IngredientController : ApiController
    {
        private IIngredientRepository _ingredientRepository;

        public IngredientController()
        {
            _ingredientRepository = DependencyResolver.Current.GetService<IIngredientRepository>();
        }

        [ResponseType(typeof(IngredientDto))]
        public IHttpActionResult Get(string ingredientName)
        {
            IHttpActionResult result;
            
            Ingredient ingredient = this._ingredientRepository.GetList(i => i.Name == ingredientName).FirstOrDefault();
            if (ingredient != null)
            {
                var ingredientDto = DtoBuilder.ToDto(ingredient);
                result = Ok(ingredientDto);
            }
            else
            {
                result = NotFound();
            }
            
            return result;
        }

        [ResponseType(typeof(IEnumerable<IngredientDto>))]
        public IHttpActionResult Get()
        {
            IngridientsList ingredientList = new IngridientsList(this._ingredientRepository);
            List<IngredientDto> result = ingredientList.GetIngridientsList();

            return Ok(result);
        }
    }
}
