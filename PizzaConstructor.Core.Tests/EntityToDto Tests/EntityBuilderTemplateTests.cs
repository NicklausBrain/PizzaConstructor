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
    public class EntityBuilderTemplateTests : DtoBuilderTestsBase
    {
        [TestMethod]
        public void ToEntityPizzaTemplate_PizzaTemplateIsCorrect_PizzaTemplateDtoIsEqualToPizzaTemplate()
        {
            TemplateDto expected = new TemplateDto(
                "Template",
                700,
                "ImageUrl.png",
                new List<IngredientDto>());
            expected.Ingredients.Add(new IngredientDto(
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                new CategoryDto(Categories.Dough.ToString()),
                5));
            expected.Ingredients.Add(new IngredientDto(
                "Bacon",
                200,
                "Bacon.png",
                "BaconBase.png",
                new CategoryDto(Categories.Meat.ToString()),
                50));
            PizzaTemplate actual = EntityBuilder.ToEntity(expected);

            base.AssertPizzaTemplatesAreEqual(actual, expected);
        }

        [TestMethod]
        public void ToEntityPizzaTemplate_PizzaTemplateIsEmpty_PizzaTemplateDtoIsEqualToPizzaTemplate()
        {
            TemplateDto expected = new TemplateDto();
            PizzaTemplate actual = EntityBuilder.ToEntity(expected);

            base.AssertPizzaTemplatesAreEqual(actual, expected);
        }

        [TestMethod]
        public void ToEntityPizzaTemplate_IngredientsAreEmpty_PizzaTemplateDtoIsEqualToPizzaTemplate()
        {
            TemplateDto expected = new TemplateDto(
                "Template",
                700,
                "ImageUrl.png",
                new List<IngredientDto>());
            expected.Ingredients = new List<IngredientDto>();

            PizzaTemplate actual = EntityBuilder.ToEntity(expected);

            base.AssertPizzaTemplatesAreEqual(actual, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToEntityPizzaTemplate_IngredientsAreNull_NullReferenceException()
        {
            TemplateDto expected = new TemplateDto(
                "Template",
                700,
                "ImageUrl.png",
                new List<IngredientDto>());
            expected.Ingredients = null;

            PizzaTemplate actual = EntityBuilder.ToEntity(expected);
        }

        [TestMethod]
        public void ToEntityPizzaTemplate_NameIsNull_PizzaTemplateDtoIsEqualToPizzaTemplate()
        {
            TemplateDto expected = new TemplateDto(
                "Template",
                700,
                "ImageUrl.png",
                new List<IngredientDto>());
            expected.Ingredients.Add(new IngredientDto(
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                new CategoryDto(Categories.Dough.ToString()),
                5));
            expected.Ingredients.Add(new IngredientDto(
                "Bacon",
                200,
                "Bacon.png",
                "BaconBase.png",
                new CategoryDto(Categories.Meat.ToString()),
                50));

            PizzaTemplate actual = EntityBuilder.ToEntity(expected);

            base.AssertPizzaTemplatesAreEqual(actual, expected);
        }
    }
}
