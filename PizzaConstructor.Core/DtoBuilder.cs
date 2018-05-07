using System.Collections.Generic;
using PizzaConstructor.Core.DTO;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Core
{
    public class DtoBuilder
    {
        public static CategoryDto ToDto(Categories category)
        {
            return new CategoryDto(category.ToString()); 
        }

        public static OrderStatusDto ToDto(OrderStatus orderStatus)
        {
            return new OrderStatusDto(orderStatus.ToString());
        }

        public static ContactDto ToDto(Contact contact)
        {
            return new ContactDto(contact.Name, contact.Phone, contact.DeliveryAddress);
        }

        public static IngredientDto ToDto(Ingredient ingredient)
        {
            return new IngredientDto(ingredient.Name, ingredient.Price, ingredient.ImageUrl, ingredient.ImageUrlMain, ToDto(ingredient.Category), ingredient.Index);
        }

        public static OrderDto ToDto(Order order)
        {
            OrderDto orderDto = new OrderDto
            {
                Id = order.Id,
                Date = order.Date,
                TotalPrice = order.TotalPrice,
                User = new UserDto(),
                //User = ToDto(order.User),
                Contact = ToDto(order.Contact),
                OrderStatus = ToDto(order.OrderStatus)
            };
            foreach (var pizzaItem in order.Pizzas)
            {
                orderDto.Pizzas.Add(ToDto(pizzaItem));
            }
            return orderDto;
        }

        public static PizzaItemDto ToDto(PizzaItem pizzaItem)
        {
            PizzaItemDto pizzaItemDto = new PizzaItemDto(
                pizzaItem.Name,
                pizzaItem.TotalCost,
                pizzaItem.ImageUrl,
                pizzaItem.Order.Date, 
                new List<IngredientDto>());
            foreach (var ingredient in pizzaItem.Ingredients)
            {
                pizzaItemDto.Ingredients.Add(ToDto(ingredient));
            }
            return pizzaItemDto;
        }

        public static TemplateDto ToDto(PizzaTemplate pizzaTemplate)
        {
            TemplateDto templateDto = new TemplateDto(pizzaTemplate.Name, pizzaTemplate.TotalCost, pizzaTemplate.ImageUrl, new List<IngredientDto>());
            foreach (var ingredient in pizzaTemplate.Ingredients)
            {
                templateDto.Ingredients.Add(ToDto(ingredient));
            }
            return templateDto;
        }

        public static UserDto ToDto(User user)
        {
            var userDto = new UserDto
            {
                Name = user.Name,
                Email = user.Email,
            };
            foreach (var order in user.Orders)
            {
                userDto.Orders.Add(ToDto(order));
            }
            return userDto;
        }
    }
}
