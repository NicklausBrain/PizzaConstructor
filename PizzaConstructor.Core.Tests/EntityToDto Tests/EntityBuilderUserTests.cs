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
    public class EntityBuilderUserTests : DtoBuilderTestsBase
    {
        [TestMethod]
        public void ToEntityUser_UserIsCorrect_UserDtoIsEqualToUser()
        {
            OrderDto orderDto = new OrderDto();
            orderDto.TotalPrice = 2000;
            orderDto.Contact = new ContactDto();
            orderDto.OrderStatus = new OrderStatusDto("New");
            UserDto userDto = new UserDto("Name", "Email", new List<OrderDto>());

            PizzaItemDto pizza1 = new PizzaItemDto(
               "Margarita",
                1200,
                "Margarita.png", new DateTime(), new List<IngredientDto>());
            pizza1.Ingredients.Add(new IngredientDto(
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                new CategoryDto( Categories.Dough.ToString()),
                5));

            pizza1.Ingredients.Add(new IngredientDto(
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                new CategoryDto(Categories.Dough.ToString()),
                5));
            pizza1.Ingredients.Add(new IngredientDto(
                "Bacon",
                200,
                "Bacon.png",
                "BaconBase.png",
                new CategoryDto(Categories.Meat.ToString()),
                500));
            pizza1.Ingredients.Add(new IngredientDto(
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                new CategoryDto(Categories.Dough.ToString()),
                5));
            pizza1.Ingredients.Add(new IngredientDto(
               "Cheese",
                150,
                "Cheese.png",
                "CheeseBase.png",
               new CategoryDto(Categories.Cheese.ToString()),
                10));
           userDto.Orders.Add(orderDto);

            User user = EntityBuilder.ToEntity(userDto);
           
            base.AssertUsersAreEqualEntity(user, userDto);
        }

        [TestMethod]
        public void ToEntityUser_NameIsNull_UserDtoIsEqualToUser()
        {
            OrderDto orderDto = new OrderDto();
            orderDto.TotalPrice = 2000;
            orderDto.Contact = new ContactDto();
            orderDto.OrderStatus = new OrderStatusDto("New");
            UserDto userDto = new UserDto(null, "Email", new List<OrderDto>());

            PizzaItemDto pizza1 = new PizzaItemDto(
                "Margarita",
                1200,
                "Margarita.png", new DateTime(), new List<IngredientDto>());
            pizza1.Ingredients.Add(new IngredientDto(
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                new CategoryDto(Categories.Dough.ToString()),
                5));

            pizza1.Ingredients.Add(new IngredientDto(
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                new CategoryDto(Categories.Dough.ToString()),
                5));
            pizza1.Ingredients.Add(new IngredientDto(
                "Bacon",
                200,
                "Bacon.png",
                "BaconBase.png",
                new CategoryDto(Categories.Meat.ToString()),
                500));
            pizza1.Ingredients.Add(new IngredientDto(
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                new CategoryDto(Categories.Dough.ToString()),
                5));
            pizza1.Ingredients.Add(new IngredientDto(
                "Cheese",
                150,
                "Cheese.png",
                "CheeseBase.png",
                new CategoryDto(Categories.Cheese.ToString()),
                10));
            userDto.Orders.Add(orderDto);

            User user = EntityBuilder.ToEntity(userDto);

            base.AssertUsersAreEqualEntity(user, userDto);
        }

        [TestMethod]
        public void ToEntityUser_OrdersAreEmpty_UserDtoIsEqualToUser()
        {
         UserDto userDto = new UserDto("Name", "Email", new List<OrderDto>());
            User user = EntityBuilder.ToEntity(userDto);
            base.AssertUsersAreEqual(user, userDto);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToEntityUser_UserIsNull_NullReferenceException()
        {
           UserDto userDto = null;
            User user = EntityBuilder.ToEntity(userDto);
        }
    }
}
