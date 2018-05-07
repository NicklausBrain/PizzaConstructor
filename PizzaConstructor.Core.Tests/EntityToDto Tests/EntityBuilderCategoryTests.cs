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
    public class EntityBuilderCategoryTests: DtoBuilderTestsBase
    {
        #region Test correct categories

        [TestMethod]
        public void ToCategoryEntity_CategoryIsVegetables_NameIsEqualToVegetableCategoryName()
        {
            CategoryDto vegetDto = new CategoryDto("Vegetables");

            Categories result = EntityBuilder.ToEntity(vegetDto);
         
            Assert.AreEqual(vegetDto.Name, result.ToString());
        }

        [TestMethod]
        public void ToCategoryEntity_CategoryIsMeat_NameIsEqualToMeatCategoryName()
        {
            CategoryDto meatDto = new CategoryDto("Meat");

            Categories result1 = EntityBuilder.ToEntity(meatDto);

            Assert.AreEqual(meatDto.Name, result1.ToString());
        }
        [TestMethod]
        public void ToCategoryEntity_CategoryIsSeaFood_NameIsEqualToSeaFoodCategoryName()
        {
            CategoryDto seeDto = new CategoryDto("SeaFood");

            Categories result1 = EntityBuilder.ToEntity(seeDto);

            Assert.AreEqual(seeDto.Name, result1.ToString());
        }

        [TestMethod]
        public void ToCategoryEntity_CategoryIsSouces_NameIsEqualToSoucesCategoryName()
        {
            CategoryDto sousesDto = new CategoryDto("Souses");

            Categories result7 = EntityBuilder.ToEntity(sousesDto);

            Assert.AreEqual(sousesDto.Name, result7.ToString());
        }

        [TestMethod]
        public void ToCategoryEntity_CategoryIsCheese_NameIsEqualToCheeseCategoryName()
        {
            CategoryDto cheeseDto = new CategoryDto("Cheese");

            Categories result7 = EntityBuilder.ToEntity(cheeseDto);

            Assert.AreEqual(cheeseDto.Name, result7.ToString());
        }

        [TestMethod]
        public void ToCategoryEntity_CategoryIsDough_NameIsEqualToDoughCategoryName()
        {
            CategoryDto doughDto = new CategoryDto("Dough");

            Categories result7 = EntityBuilder.ToEntity(doughDto);

            Assert.AreEqual(doughDto.Name, result7.ToString());
        }
        #endregion

    }
}
