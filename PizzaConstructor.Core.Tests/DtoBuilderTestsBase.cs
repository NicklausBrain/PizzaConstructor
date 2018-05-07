using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaConstructor.Core.DTO;
using PizzaConstructor.Entities;
using System.Linq;

namespace PizzaConstructor.Core.Tests
{
    /// <summary>
    /// Base class for test classes. Contains methods of comparing entities with dtos
    /// </summary>
    public abstract class DtoBuilderTestsBase
    {
        // ----- METHODS TO CHECK EQUALITY OF DTO TO ENTITY -----
        
        protected void AssertIngredientsAreEqual(Ingredient ingredient, IngredientDto ingredientDto)
        {
            Assert.AreEqual(ingredient.Category.ToString(), ingredientDto.Category.Name);
            Assert.AreEqual(ingredient.ImageUrl, ingredientDto.ImageUrl);
            Assert.AreEqual(ingredient.ImageUrlMain, ingredientDto.ImageUrlMain);
            Assert.AreEqual(ingredient.Index, ingredientDto.Index);
            Assert.AreEqual(ingredient.Name, ingredientDto.Name);
            Assert.AreEqual(ingredient.Price, ingredientDto.Price);
        }

        protected void AssertContactsAreEqual(Contact contact, ContactDto contactDto)
        {
            Assert.AreEqual(contact.Name, contactDto.Name);
            Assert.AreEqual(contact.Phone, contactDto.Phone);
            Assert.AreEqual(contact.DeliveryAddress, contactDto.DeliveryAddress);
        }

        protected void AssertPizzaItemsAreEqual(PizzaItem pizzaItem, PizzaItemDto pizzaItemDto)
        {
            Assert.AreEqual(pizzaItem.Order.Date, pizzaItemDto.Date);
            Assert.AreEqual(pizzaItem.Name, pizzaItemDto.Name);
            Assert.AreEqual(pizzaItem.TotalCost, pizzaItemDto.TotalCost);

            Assert.AreEqual(pizzaItem.Ingredients.Count, pizzaItemDto.Ingredients.Count);
            for(int i = 0; i < pizzaItem.Ingredients.Count; i++)
            {
                Ingredient expectedIngredient = pizzaItem.Ingredients.ElementAt(i);
                IngredientDto actualIngredientDto = pizzaItemDto.Ingredients.ElementAt(i);

                this.AssertIngredientsAreEqual(expectedIngredient, actualIngredientDto);
            }
        }
        protected void AssertPizzaItemsAreEqualEntities(PizzaItem pizzaItem, PizzaItemDto pizzaItemDto)
        {
            Assert.AreEqual(pizzaItem.Name, pizzaItemDto.Name);
            Assert.AreEqual(pizzaItem.TotalCost, pizzaItemDto.TotalCost);

            Assert.AreEqual(pizzaItem.Ingredients.Count, pizzaItemDto.Ingredients.Count);
            for (int i = 0; i < pizzaItem.Ingredients.Count; i++)
            {
                Ingredient expectedIngredient = pizzaItem.Ingredients.ElementAt(i);
                IngredientDto actualIngredientDto = pizzaItemDto.Ingredients.ElementAt(i);

                this.AssertIngredientsAreEqual(expectedIngredient, actualIngredientDto);
            }
        }

        protected void AssertPizzaTemplatesAreEqual(PizzaTemplate pizzaTemplate, TemplateDto templateDto)
        {
            Assert.AreEqual(pizzaTemplate.Name, templateDto.Name);
            Assert.AreEqual(pizzaTemplate.TotalCost, templateDto.TotalCost);

            Assert.AreEqual(pizzaTemplate.Ingredients.Count, templateDto.Ingredients.Count);
            for(int i = 0; i < pizzaTemplate.Ingredients.Count; i++)
            {
                Ingredient expectedIngredient = pizzaTemplate.Ingredients.ElementAt(i);
                IngredientDto actualIngredientDto = templateDto.Ingredients.ElementAt(i);

                this.AssertIngredientsAreEqual(expectedIngredient, actualIngredientDto);
            }
        }

        protected void AssertOrdersAreEqual(Order order, OrderDto orderDto)
        {
            Assert.AreEqual(order.Date, orderDto.Date);
            Assert.AreEqual(order.OrderStatus.ToString(), orderDto.OrderStatus.Status);
            Assert.AreEqual(order.TotalPrice, orderDto.TotalPrice);
            Assert.AreEqual(order.Id, orderDto.Id);

            this.AssertContactsAreEqual(order.Contact, orderDto.Contact);

            Assert.AreEqual(order.Pizzas.Count, orderDto.Pizzas.Count);
            for(int i = 0; i < order.Pizzas.Count; i++)
            {
                this.AssertPizzaItemsAreEqual(order.Pizzas.ElementAt(i), orderDto.Pizzas.ElementAt(i));
            }
        }
        protected void AssertOrdersEntitiesAreEqual(Order order, OrderDto orderDto)
        {
            Assert.AreEqual(order.OrderStatus.ToString(), orderDto.OrderStatus.Status);
            Assert.AreEqual(order.TotalPrice, orderDto.TotalPrice);
            
            this.AssertContactsAreEqual(order.Contact, orderDto.Contact);

            Assert.AreEqual(order.Pizzas.Count, orderDto.Pizzas.Count);
            for (int i = 0; i < order.Pizzas.Count; i++)
            {
                this.AssertPizzaItemsAreEqual(order.Pizzas.ElementAt(i), orderDto.Pizzas.ElementAt(i));
            }
        }
        protected void AssertUsersAreEqual(User user, UserDto userDto)
        {
            Assert.AreEqual(user.Email, userDto.Email);
            Assert.AreEqual(user.Name, userDto.Name);

            Assert.AreEqual(user.Orders.Count, userDto.Orders.Count);
            for(int i = 0; i < user.Orders.Count; i++)
            {
                this.AssertOrdersAreEqual(user.Orders.ElementAt(i), userDto.Orders.ElementAt(i));
            }
        }
        protected void AssertUsersAreEqualEntity(User user, UserDto userDto)
        {
            Assert.AreEqual(user.Email, userDto.Email);
            Assert.AreEqual(user.Name, userDto.Name);

            Assert.AreEqual(user.Orders.Count, userDto.Orders.Count);
            for (int i = 0; i < user.Orders.Count; i++)
            {
                this.AssertOrdersEntitiesAreEqual(user.Orders.ElementAt(i), userDto.Orders.ElementAt(i));
            }
        }
    }
}
