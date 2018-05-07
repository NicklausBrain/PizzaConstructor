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
    public class EntityBuilderIngredientTests : DtoBuilderTestsBase
    {
        [TestMethod]
        public void ToEntityIngredient_IngredientIsCorrect_IngredientDtoIsEqualToIngredient()
        {
            IngredientDto ingredient = new IngredientDto(
              "Tomato",
                (decimal)10.0,
                "ImageUrl.png",
                "ImageMainUrl.png",
                new CategoryDto( Categories.Vegetables.ToString()),
                10);

            Ingredient result = EntityBuilder.ToEntity(ingredient);

            base.AssertIngredientsAreEqual(result, ingredient);
        }

      

        [TestMethod]
        public void ToEntityIngredient_IngredientNameIsNull_IngredientDtoIsEqualToIngredient()
        {
            IngredientDto ingredient = new IngredientDto(
                null,
                (decimal)100.0,
                "ImageUrl.png",
                "ImageMainUrl.png",
                new CategoryDto(Categories.Vegetables.ToString()),
                200);
            Ingredient result = EntityBuilder.ToEntity(ingredient);

            base.AssertIngredientsAreEqual(result, ingredient);
        }

        [TestMethod]
        public void ToEntityIngredient_IngredientImageUrlIsNull_IngredientDtoIsEqualToIngredient()
        {
            IngredientDto ingredient = new IngredientDto(
                "Tomato",
                (decimal)-200.0,
                null,
                "ImageMainUrl.png",
                new CategoryDto(Categories.Vegetables.ToString()),
                10);
            Ingredient result = EntityBuilder.ToEntity(ingredient);

            base.AssertIngredientsAreEqual(result, ingredient);
        }

        [TestMethod]
        public void ToEntityIngredient_IngredientImageMainUrlIsNull_IngredientDtoIsEqualToIngredient()
        {
            IngredientDto ingredient = new IngredientDto(
                "Tomato",
                (decimal)10.0,
                "ImageUrl.png",
                null,
                new CategoryDto(Categories.Vegetables.ToString()),
                -200);
            Ingredient result = EntityBuilder.ToEntity(ingredient);

            base.AssertIngredientsAreEqual(result, ingredient);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToEntityIngredient_IngredientIsNull_IngredientDtoIsNull()
        {
            IngredientDto ingredient = null;

            Ingredient result = EntityBuilder.ToEntity(ingredient);
            
        }
    }
}
