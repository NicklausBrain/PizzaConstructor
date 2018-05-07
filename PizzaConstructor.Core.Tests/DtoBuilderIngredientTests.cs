using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaConstructor.Entities;
using PizzaConstructor.Core.DTO;

namespace PizzaConstructor.Core.Tests
{
    /// <summary>
    /// Class to test method DtoBuilder.ToDto with Ingredient param
    /// </summary>
    [TestClass]
    public class DtoBuilderIngredientTests : DtoBuilderTestsBase
    {
        [TestMethod]
        public void ToIngredientDto_IngredientIsCorrect_IngredientDtoIsEqualToIngredient()
        {
            Ingredient ingredient = new Ingredient(
                Guid.NewGuid(), 
                "Tomato", 
                (decimal)10.0, 
                "ImageUrl.png", 
                "ImageMainUrl.png", 
                Categories.Vegetables, 
                10);

            IngredientDto result = DtoBuilder.ToDto(ingredient);

            base.AssertIngredientsAreEqual(ingredient, result);
        }

        [TestMethod]
        public void ToIngredientDto_IngredientWithEmptyFields_IngredientDtoIsEqualToIngredient()
        {
            Ingredient ingredient = new Ingredient();

            IngredientDto result = DtoBuilder.ToDto(ingredient);

            base.AssertIngredientsAreEqual(ingredient, result);
        }

        [TestMethod]
        public void ToIngredientDto_IngredientNameIsNull_IngredientDtoIsEqualToIngredient()
        {
            Ingredient ingredient = new Ingredient(
                Guid.NewGuid(),
                null,
                (decimal)100.0,
                "ImageUrl.png",
                "ImageMainUrl.png",
                Categories.Vegetables,
                200);

            IngredientDto result = DtoBuilder.ToDto(ingredient);

            base.AssertIngredientsAreEqual(ingredient, result);
        }

        [TestMethod]
        public void ToIngredientDto_IngredientImageUrlIsNull_IngredientDtoIsEqualToIngredient()
        {
            Ingredient ingredient = new Ingredient(
                Guid.NewGuid(),
                "Tomato",
                (decimal)-200.0,
                null,
                "ImageMainUrl.png",
                Categories.Vegetables,
                10);

            IngredientDto result = DtoBuilder.ToDto(ingredient);

            base.AssertIngredientsAreEqual(ingredient, result);
        }

        [TestMethod]
        public void ToIngredientDto_IngredientImageMainUrlIsNull_IngredientDtoIsEqualToIngredient()
        {
            Ingredient ingredient = new Ingredient(
                Guid.NewGuid(),
                "Tomato",
                (decimal)10.0,
                "ImageUrl.png",
                null,
                Categories.Vegetables,
                -200);

            IngredientDto result = DtoBuilder.ToDto(ingredient);

            base.AssertIngredientsAreEqual(ingredient, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToIngredientDto_IngredientIsNull_IngredientDtoIsNull()
        {
            Ingredient ingredient = null;

            IngredientDto result = DtoBuilder.ToDto(ingredient);
        }
    }
}
