using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaConstructor.Entities;
using PizzaConstructor.Core.DTO;

namespace PizzaConstructor.Core.Tests
{
    /// <summary>
    /// Class to test method DtoBuilder.ToDto with PizzaItem param
    /// </summary>
    [TestClass]
    public class DtoBuilderPizzaItemTests : DtoBuilderTestsBase
    {  
        [TestMethod]
        public void ToPizzaItemDto_PizzaItemIsCorrect_PizzaItemDtoIsEqualToPizzaItem()
        {
            PizzaItem expected = new PizzaItem(
                Guid.NewGuid(),
                "Margarita",
                1200,
                "Margarita.png");

            expected.Order = new Order(Guid.NewGuid(), 1200, new Contact());

            expected.AddIngredient(new Ingredient(
                Guid.NewGuid(),
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                Categories.Dough,
                5));
            expected.AddIngredient(new Ingredient(
                Guid.NewGuid(),
                "Bacon",
                200,
                "Bacon.png",
                "BaconBase.png",
                Categories.Meat,
                500));


            PizzaItemDto actual = DtoBuilder.ToDto(expected);


            base.AssertPizzaItemsAreEqual(expected, actual);
        }

        [TestMethod]
        public void ToPizzaItemDto_OrderIsEmpty_PizzaItemDtoIsEqualToPizzaItem()
        {
            PizzaItem expected = new PizzaItem(
                Guid.NewGuid(),
                "Margarita",
                200,
                "Margarita.png");
            expected.Order = new Order();
            expected.AddIngredient(new Ingredient(
                Guid.NewGuid(),
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                Categories.Dough,
                5));

            PizzaItemDto actual = DtoBuilder.ToDto(expected);

            base.AssertPizzaItemsAreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToPizzaItemDto_OrderIsNull_NullReferenceException()
        {
            PizzaItem expected = new PizzaItem(
                Guid.NewGuid(),
                "Margarita",
                200,
                "Margarita.png");
            expected.Order = null;
            expected.AddIngredient(new Ingredient(
                Guid.NewGuid(),
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                Categories.Dough,
                5));

            PizzaItemDto actual = DtoBuilder.ToDto(expected);
        }

        [TestMethod]
        public void ToPizzaItemDto_PizzaItemIsEmpty_PizzaItemDtoIsEqualToPizzaItem()
        {
            PizzaItem expected = new PizzaItem();
            expected.Order = new Order();

            PizzaItemDto actual = DtoBuilder.ToDto(expected);

            base.AssertPizzaItemsAreEqual(expected, actual);
        }

        [TestMethod]
        public void ToPizzaItemDto_IngredientsAreEmpty_PizzaItemDtoIsEqualToPizzaItem()
        {
            PizzaItem expected = new PizzaItem(
                Guid.NewGuid(),
                "Margarita",
                200,
                "Margarita.png");
            expected.Order = new Order();

            expected.Ingredients = new List<Ingredient>();

            PizzaItemDto actual = DtoBuilder.ToDto(expected);

            base.AssertPizzaItemsAreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToPizzaItemDto_IngredientsAreNull_NullReferenceException()
        {
            PizzaItem expected = new PizzaItem(
                Guid.NewGuid(),
                "Margarita",
                200,
                "Margarita.png");
            expected.Order = new Order();

            expected.Ingredients = null;

            PizzaItemDto actual = DtoBuilder.ToDto(expected);
        }

        [TestMethod]
        public void ToPizzaItemDto_NameIsNull_PizzaItemDtoIsEqualToPizzaItem()
        {
            PizzaItem expected = new PizzaItem(
                Guid.NewGuid(),
                null,
                200,
                "Margarita.png");
            expected.Order = new Order();
            expected.AddIngredient(new Ingredient(
                Guid.NewGuid(),
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                Categories.Dough,
                5));

            PizzaItemDto actual = DtoBuilder.ToDto(expected);

            base.AssertPizzaItemsAreEqual(expected, actual);
        }
    }
}
