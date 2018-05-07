using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using PizzaConstructor.Core;
using PizzaConstructor.Core.DTO;
using PizzaConstructor.Data.Interfaces;

namespace PizzaConstructor.WebApi.Controllers
{
    using System;

    [System.Web.Http.Authorize]
    public class OrdersHistoryController : ApiController
    {
        private IPizzaRepository _repository;

        public OrdersHistoryController()
        {
            this._repository = DependencyResolver.Current.GetService<IPizzaRepository>();
        }

        [ResponseType(typeof(IEnumerable<PizzaItemDto>))]
        public IHttpActionResult Get()
        {
            var pizzas = new PizzaList(this._repository);
            IEnumerable<PizzaItemDto> pizzasList;
            string userName = User.Identity.Name;
            pizzasList = pizzas.GetPizzasListByUserFullName(userName); 

            return Ok<IEnumerable<PizzaItemDto>>(pizzasList);
        }

        protected override void Dispose(bool disposing)
        {
            this._repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
