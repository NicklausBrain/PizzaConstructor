using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaConstructor.Entities;
using PizzaConstructor.Core.DTO;

namespace PizzaConstructor.Core.Tests
{
    [TestClass]
    public class DtoBuilderUserTests : DtoBuilderTestsBase
    {
        [TestMethod]
        public void ToUserDto_UserIsCorrect_UserDtoIsEqualToUser()
        {
            User user = new User("Name", "Email");
            Order order = new Order(Guid.NewGuid(), 2000, new Contact());
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
            pizza1.Order = order;
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
            pizza2.Order = order;
            user.Orders.Add(order);

            UserDto userDto = DtoBuilder.ToDto(user);

            base.AssertUsersAreEqual(user, userDto);
        }

        [TestMethod]
        public void ToUserDto_NameIsNull_UserDtoIsEqualToUser()
        {
            User user = new User(null, "Email");
            Order order = new Order(Guid.NewGuid(), 2000, new Contact());
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
            pizza1.Order = order;
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
            pizza2.Order = order;
            user.Orders.Add(order);

            UserDto userDto = DtoBuilder.ToDto(user);

            base.AssertUsersAreEqual(user, userDto);
        }

        [TestMethod]
        public void ToUserDto_OrdersAreEmpty_UserDtoIsEqualToUser()
        {
            User user = new User("Name", "Email");

            UserDto userDto = DtoBuilder.ToDto(user);

            base.AssertUsersAreEqual(user, userDto);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToUserDto_UserIsNull_NullReferenceException()
        {
            User user = null;

            UserDto userDto = DtoBuilder.ToDto(user);
        }
    }
}
