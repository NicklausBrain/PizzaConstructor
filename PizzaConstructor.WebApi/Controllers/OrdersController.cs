
using System.Linq;
using System.Web.Http.Description;
using System.Web.Mvc;
using PizzaConstructor.Data.Interfaces;

namespace PizzaConstructor.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using PizzaConstructor.Core;
    using PizzaConstructor.Core.DTO;
    using PizzaConstructor.Entities;
    using PizzaConstructor.WebApi.Models;

    public class OrdersController : ApiController
    {
        private IUserRepository userRepository;
        private IOrderRepository orderRepository;
        private IIngredientRepository ingredientRepository;
       
        public OrdersController()
        {
            this.ingredientRepository = DependencyResolver.Current.GetService<IIngredientRepository>();
            this.userRepository = DependencyResolver.Current.GetService<IUserRepository>();
            this.orderRepository = DependencyResolver.Current.GetService<IOrderRepository>();
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] OrderPostModel order)
        {

            if (!ModelState.IsValid)
            {
                return this.Conflict();
            }

            string userId = this.User.Identity.GetUserId();

            User user = this.userRepository.GetById(userId);

            PizzaItem newPizzaItem = new PizzaItem(Guid.NewGuid(), order.Pizza.Name, order.Pizza.TotalCost, order.Pizza.ImageUrl);

            foreach (var ingred in order.Pizza.Ingredients)
            {
                newPizzaItem.Ingredients.Add(this.ingredientRepository.GetList(ing => ing.Name == ingred.Name).FirstOrDefault());
            }

            Order orderEntity = new Order(
                Guid.NewGuid(), 
                order.Pizza.TotalCost,
                EntityBuilder.ToEntity(order.Contact));

            orderEntity.User = user;
            orderEntity.Pizzas = new List<PizzaItem>(){newPizzaItem};

            this.orderRepository.Add(orderEntity);
            this.orderRepository.SaveChanges();

            return this.Ok();
        }

        [AdminAuthorize]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<OrderDto>))]
        public IHttpActionResult Get(int index, int num)
        {
            var orders = new OrderList(this.orderRepository);
            List<OrderDto> orderList = orders.GetOrdersList(index, num);

            return Ok<IEnumerable<OrderDto>>(orderList);
        }

        [AdminAuthorize]
        [HttpPut]
        public IHttpActionResult EditOrder([FromBody] OrderDto order)
        {
            Order lastOrder = this.orderRepository.GetById(order.Id);
            lastOrder.ChangeStatus((OrderStatus)Enum.Parse(typeof(OrderStatus), order.OrderStatus.Status));             
            this.orderRepository.Update(lastOrder);
            return this.Ok();
        }


    }
}