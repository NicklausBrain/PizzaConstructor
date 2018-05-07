using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaConstructor.Core.DTO;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Core.Tests.EntityToDto_Tests
{
    [TestClass]
    public class EntityBuilderOrderTests : DtoBuilderTestsBase
    {
        [TestMethod]
        public void ToEntityOrder_OrderIsCorrect_OrderDtoIsEqualToOrder()
        {
            OrderDto expectedOrder = new OrderDto(2000, DateTime.Now, new ContactDto(), new UserDto(),new List<PizzaItemDto>() );
            expectedOrder.OrderStatus = new OrderStatusDto("New");
            PizzaItemDto pizza1 = new PizzaItemDto(
                "Margarita",
                1200,
                "Margarita.png", 
                DateTime.Now, 
                new List<IngredientDto>());
            pizza1.Ingredients.Add(new IngredientDto(
               "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                new CategoryDto( Categories.Dough.ToString()),
                5));
            pizza1.Ingredients.Add(new IngredientDto(
                "Bacon",
                200,
                "Bacon.png",
                "BaconBase.png",
                new CategoryDto(Categories.Meat.ToString()),
                500));
            PizzaItemDto pizza2 = new PizzaItemDto(
            "Margarita",
                1200,
                "Margarita.png", 
                DateTime.Now, 
                new List<IngredientDto>());
            pizza2.Ingredients.Add(new IngredientDto(
               "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
               new CategoryDto(Categories.Dough.ToString()),
                5));
            pizza2.Ingredients.Add(new IngredientDto(
                "Cheese",
                150,
                "Cheese.png",
                "CheeseBase.png",
                new CategoryDto(Categories.Cheese.ToString()),
                10));

            Order actualOrder = EntityBuilder.ToEntity(expectedOrder);

            base.AssertOrdersEntitiesAreEqual(actualOrder, expectedOrder);
        }


       [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToEntityOrder_PizzasAreNull_NullReferenceException()
        {
            OrderDto expectedOrder = new OrderDto(2000, DateTime.Now, new ContactDto(), new UserDto(), new List<PizzaItemDto>());
            expectedOrder.Pizzas = null;

            Order actualOrder = EntityBuilder.ToEntity(expectedOrder);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToEntityOrder_OrderIsNull_NullReferenceException()
        {
            OrderDto expectedOrder = null;

            Order actualOrder = EntityBuilder.ToEntity(expectedOrder);
        }
    }
}
