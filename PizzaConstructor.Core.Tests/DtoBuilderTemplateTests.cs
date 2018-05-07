using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaConstructor.Entities;
using PizzaConstructor.Core.DTO;
using System.Collections.Generic;

namespace PizzaConstructor.Core.Tests
{
    [TestClass]
    public class DtoBuilderTemplateTests : DtoBuilderTestsBase
    {
        [TestMethod]
        public void ToPizzaTemplateDto_PizzaTemplateIsCorrect_PizzaTemplateDtoIsEqualToPizzaTemplate()
        {
            PizzaTemplate expected = new PizzaTemplate(
                Guid.NewGuid(),
                "Template",
                "ImageUrl.png",
                700);
            expected.Ingredients.Add(new Ingredient(
                Guid.NewGuid(),
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                Categories.Dough,
                5));
            expected.Ingredients.Add(new Ingredient(
                Guid.NewGuid(),
                "Bacon",
                200,
                "Bacon.png",
                "BaconBase.png",
                Categories.Meat,
                50));

            TemplateDto actual = DtoBuilder.ToDto(expected);

            base.AssertPizzaTemplatesAreEqual(expected, actual);
        }

        [TestMethod]
        public void ToPizzaTemplateDto_PizzaTemplateIsEmpty_PizzaTemplateDtoIsEqualToPizzaTemplate()
        {
            PizzaTemplate expected = new PizzaTemplate();            

            TemplateDto actual = DtoBuilder.ToDto(expected);

            base.AssertPizzaTemplatesAreEqual(expected, actual);
        }

        [TestMethod]
        public void ToPizzaTemplateDto_IngredientsAreEmpty_PizzaTemplateDtoIsEqualToPizzaTemplate()
        {
            PizzaTemplate expected = new PizzaTemplate(
                Guid.NewGuid(),
                "Template",
                "ImageUrl.png",
                700);
            expected.Ingredients = new List<Ingredient>();

            TemplateDto actual = DtoBuilder.ToDto(expected);

            base.AssertPizzaTemplatesAreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToPizzaTemplateDto_IngredientsAreNull_NullReferenceException()
        {
            PizzaTemplate expected = new PizzaTemplate(
                Guid.NewGuid(),
                "Template",
                "ImageUrl.png",
                700);
            expected.Ingredients = null;

            TemplateDto actual = DtoBuilder.ToDto(expected);
        }

        [TestMethod]
        public void ToPizzaTemplateDto_NameIsNull_PizzaTemplateDtoIsEqualToPizzaTemplate()
        {
            PizzaTemplate expected = new PizzaTemplate(
                Guid.NewGuid(),
                null,
                "ImageUrl.png",
                700);
            expected.Ingredients.Add(new Ingredient(
                Guid.NewGuid(),
                "Dough",
                200,
                "Dough.png",
                "DoughBase.png",
                Categories.Dough,
                5));
            expected.Ingredients.Add(new Ingredient(
                Guid.NewGuid(),
                "Bacon",
                200,
                "Bacon.png",
                "BaconBase.png",
                Categories.Meat,
                50));

            TemplateDto actual = DtoBuilder.ToDto(expected);

            base.AssertPizzaTemplatesAreEqual(expected, actual);
        }
    }
}
