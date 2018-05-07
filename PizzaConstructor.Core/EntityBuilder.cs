using System;
using PizzaConstructor.Core.DTO;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Core
{
    public class EntityBuilder
    {
        //public static Categories ToEntity(CategoryDto categoryDto)
        //{
        //    return new Categories(); // TODO
        //}
        public static Categories ToEntity(CategoryDto categoryDto)
        {
            if (categoryDto.Name == Categories.Vegetables.ToString())
            {
                return Categories.Vegetables;
            }
            if (categoryDto.Name == Categories.Meat.ToString())
            {
                return Categories.Meat;
            }
            if (categoryDto.Name == Categories.Cheese.ToString())
            {
                return Categories.Cheese;
            }
            if (categoryDto.Name == Categories.Dough.ToString())
            {
                return Categories.Dough;
            }
            if (categoryDto.Name == Categories.SeaFood.ToString())
            {
                return Categories.SeaFood;
            }
            if (categoryDto.Name == Categories.Souses.ToString())
            {
                return Categories.Souses;
            }
            else
            {
                return new Categories();
            }
        }
        public static Contact ToEntity(ContactDto contactDto)
        {
            return new Contact(Guid.NewGuid(), contactDto.Name, contactDto.Phone, contactDto.DeliveryAddress);
        }

        public static Ingredient ToEntity(IngredientDto ingredientDto)
        {
            return new Ingredient(Guid.NewGuid(),
                    ingredientDto.Name,
                    ingredientDto.Price,
                    ingredientDto.ImageUrl,
                    ingredientDto.ImageUrlMain,
                    ToEntity(ingredientDto.Category),
                    ingredientDto.Index);
        }

        public static Order ToEntity(OrderDto orderDto)
        {
            var order = new Order(
                Guid.NewGuid(),
                orderDto.TotalPrice,
                ToEntity(orderDto.Contact));
            foreach (var pizzaItemDto in orderDto.Pizzas)
            {
                order.Pizzas.Add(ToEntity(pizzaItemDto));
            }
            ;
            return order;
        }

        public static PizzaItem ToEntity(PizzaItemDto pizzaItemDto)
        {
            var pizzaItem = new PizzaItem(Guid.NewGuid(),
                                        pizzaItemDto.Name,
                                        pizzaItemDto.TotalCost,
                                        pizzaItemDto.ImageUrl);

            foreach (var ingredientDto in pizzaItemDto.Ingredients)
            {
                pizzaItem.Ingredients.Add(ToEntity(ingredientDto));
            }
            return pizzaItem;
        }

        public static PizzaTemplate ToEntity(TemplateDto templateDto)
        {
            var pizzaTemplate = new PizzaTemplate(Guid.NewGuid(),
                                                templateDto.Name,
                                                templateDto.ImageUrl,
                                                templateDto.TotalCost);
            foreach (var ingredientDto in templateDto.Ingredients)
            {
                pizzaTemplate.Ingredients.Add(ToEntity(ingredientDto));
            }
            return pizzaTemplate;
        }

        public static User ToEntity(UserDto userDto)
        {
            var user = new User(userDto.Name, userDto.Email);
            foreach (var orderDto in userDto.Orders)
            {
                user.Orders.Add(ToEntity(orderDto));
            }
            return user;
        }
    }
}
