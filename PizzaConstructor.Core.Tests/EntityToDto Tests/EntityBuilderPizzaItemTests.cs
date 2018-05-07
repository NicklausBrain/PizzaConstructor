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
    public class EntityBuilderPizzaItemTests : DtoBuilderTestsBase
    {
        [TestMethod]
        public void ToPizzaItemEntity_PizzaItemIsCorrect_PizzaItemDtoIsEqualToPizzaItem()
        {
            PizzaItemDto pizzaItemDto = new PizzaItemDto(
               "Margarita",
                1200,
                "Margarita.png", 
                DateTime.Now, 
                new List<IngredientDto>());
            pizzaItemDto.Ingredients.Add(new IngredientDto(
               "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                new CategoryDto(Categories.Dough.ToString()), 
                5));
            pizzaItemDto.Ingredients.Add(new IngredientDto(
                "Bacon",
                200,
                "Bacon.png",
                "BaconBase.png",
                new CategoryDto(Categories.Meat.ToString()),
                500));
            

            PizzaItem actual = EntityBuilder.ToEntity(pizzaItemDto);


            base.AssertPizzaItemsAreEqualEntities(actual, pizzaItemDto);
        }

        [TestMethod]
        public void ToPizzaItemEntity_OrderIsEmpty_PizzaItemDtoIsEqualToPizzaItem()
        {
            PizzaItemDto expected = new PizzaItemDto(
                "Margarita",
                200,
                "Margarita.png", 
                DateTime.Now, 
                new List<IngredientDto>());

            expected.Ingredients.Add(new IngredientDto(
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                new CategoryDto(Categories.Dough.ToString()),
                5));

            PizzaItem actual = EntityBuilder.ToEntity(expected);

            base.AssertPizzaItemsAreEqualEntities(actual, expected);
        }

        [TestMethod]
        public void ToPizzaItemEntity_PizzaItemIsEmpty_PizzaItemDtoIsEqualToPizzaItem()
        {
            PizzaItemDto expected = new PizzaItemDto();

            PizzaItem actual = EntityBuilder.ToEntity(expected);

            base.AssertPizzaItemsAreEqualEntities(actual, expected);
        }

        [TestMethod]
        public void ToPizzaItemEntity_IngredientsAreEmpty_PizzaItemDtoIsEqualToPizzaItem()
        {
            PizzaItemDto expected = new PizzaItemDto(
                "Margarita",
                200,
                "Margarita.png",
                DateTime.Now,
                new List<IngredientDto>());

            expected.Ingredients = new List<IngredientDto>();

            PizzaItem actual = EntityBuilder.ToEntity(expected);

            base.AssertPizzaItemsAreEqualEntities(actual, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToPizzaItemEntity_IngredientsAreNull_NullReferenceException()
        {
            PizzaItemDto expected = new PizzaItemDto(
                "Margarita",
                200,
                "Margarita.png",
                DateTime.Now,
                new List<IngredientDto>());

            expected.Ingredients = null;

            PizzaItem actual = EntityBuilder.ToEntity(expected);
            
        }

        [TestMethod]
        public void ToPizzaItemEntity_NameIsNull_PizzaItemDtoIsEqualToPizzaItem()
        {
            PizzaItemDto expected = new PizzaItemDto(
                "Margarita",
                200,
                "Margarita.png",
                DateTime.Now,
                new List<IngredientDto>());
            expected.Ingredients.Add(new IngredientDto(
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                new CategoryDto(Categories.Dough.ToString()),
                5));

            PizzaItem actual = EntityBuilder.ToEntity(expected);

            base.AssertPizzaItemsAreEqualEntities(actual, expected);
        }
    }
}
