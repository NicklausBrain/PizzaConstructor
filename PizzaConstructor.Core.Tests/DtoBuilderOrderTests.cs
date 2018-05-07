using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaConstructor.Core.DTO;
using PizzaConstructor.Entities;
using System;

namespace PizzaConstructor.Core.Tests
{
    [TestClass]
    public class DtoBuilderOrderTests : DtoBuilderTestsBase
    {
        [TestMethod]
        public void ToOrderDto_OrderIsCorrect_OrderDtoIsEqualToOrder()
        {
            Order expectedOrder = new Order(Guid.NewGuid(), 2000, new Contact());
            PizzaItem pizza1 = new PizzaItem(
                Guid.NewGuid(),
                "Margarita",
                1200,
                "Margarita.png");
            pizza1.AddIngredient(new Ingredient(
                Guid.NewGuid(),
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                Categories.Dough,
                5));
            pizza1.AddIngredient(new Ingredient(
                Guid.NewGuid(),
                "Bacon",
                200,
                "Bacon.png",
                "BaconBase.png",
                Categories.Meat,
                500));
            pizza1.Order = expectedOrder;
            PizzaItem pizza2 = new PizzaItem(
                Guid.NewGuid(),
                "Margarita",
                1200,
                "Margarita.png");
            pizza2.AddIngredient(new Ingredient(
                Guid.NewGuid(),
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                Categories.Dough,
                5));
            pizza2.AddIngredient(new Ingredient(
                Guid.NewGuid(),
                "Cheese",
                150,
                "Cheese.png",
                "CheeseBase.png",
                Categories.Cheese,
                10));
            pizza2.Order = expectedOrder;

            OrderDto actualOrder = DtoBuilder.ToDto(expectedOrder);

            base.AssertOrdersAreEqual(expectedOrder, actualOrder);
        }
        

        [TestMethod]
        public void ToOrderDto_PizzasAreEmpty_OrderDtoIsEqualToOrder()
        {
            Order expectedOrder = new Order(Guid.NewGuid(), 2000, new Contact());

            OrderDto actualOrder = DtoBuilder.ToDto(expectedOrder);

            base.AssertOrdersAreEqual(expectedOrder, actualOrder);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToOrderDto_PizzasAreNull_NullReferenceException()
        {
            Order expectedOrder = new Order(Guid.NewGuid(), 2000, new Contact());
            expectedOrder.Pizzas = null;

            OrderDto actualOrder = DtoBuilder.ToDto(expectedOrder);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToOrderDto_OrderIsNull_NullReferenceException()
        {
            Order expectedOrder = null;

            OrderDto actualOrder = DtoBuilder.ToDto(expectedOrder);
        }
    }
}
