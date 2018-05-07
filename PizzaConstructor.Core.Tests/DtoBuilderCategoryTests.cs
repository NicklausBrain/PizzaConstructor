using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaConstructor.Entities;
using PizzaConstructor.Core.DTO;

namespace PizzaConstructor.Core.Tests
{
    /// <summary>
    /// Class to test method DtoBuilder.ToDto with Categories param
    /// </summary>
    [TestClass]
    public class DtoBuilderCategoryTests : DtoBuilderTestsBase
    {
        #region Test correct categories

        [TestMethod]
        public void ToCategoryDto_CategoryIsVegetables_NameIsEqualToVegetableCategoryName()
        {
            Categories vegetablesCategory = Categories.Vegetables;

            CategoryDto result = DtoBuilder.ToDto(vegetablesCategory);

            Assert.AreEqual(vegetablesCategory.ToString(), result.Name);
        }

        [TestMethod]
        public void ToCategory_CategoryIsMeat_NameIsEqualToMeatCategoryName()
        {
            Categories meatCategory = Categories.Meat;

            CategoryDto result = DtoBuilder.ToDto(meatCategory);

            Assert.AreEqual(meatCategory.ToString(), result.Name);
        }

        [TestMethod]
        public void ToCategory_CategoryIsSeaFood_NameIsEqualToSeaFoodCategoryName()
        {
            Categories seaFoodCategory = Categories.SeaFood;

            CategoryDto result = DtoBuilder.ToDto(seaFoodCategory);

            Assert.AreEqual(seaFoodCategory.ToString(), result.Name);
        }

        [TestMethod]
        public void ToCategory_CategoryIsSouces_NameIsEqualToSoucesCategoryName()
        {
            Categories soucesCategory = Categories.Souses;

            CategoryDto result = DtoBuilder.ToDto(soucesCategory);

            Assert.AreEqual(soucesCategory.ToString(), result.Name);
        }

        [TestMethod]
        public void ToCategoryDto_CategoryIsCheese_NameIsEqualToCheeseCategoryName()
        {
            Categories cheeseCategory = Categories.Cheese;

            CategoryDto result = DtoBuilder.ToDto(cheeseCategory);

            Assert.AreEqual(cheeseCategory.ToString(), result.Name);
        }

        [TestMethod]
        public void ToCategoryDto_CategoryIsDough_NameIsEqualToDoughCategoryName()
        {
            Categories doughCategory = Categories.Dough;

            CategoryDto result = DtoBuilder.ToDto(doughCategory);

            Assert.AreEqual(doughCategory.ToString(), result.Name);
        }
        #endregion

        #region Test Incorrect categories

        //[TestMethod]
        //public void ToCategory_CategoryIsLessThanMinimumValue_CategoryDtoIsNull()
        //{
        //    Categories lessThanMinimum = (Categories)(-1);

        //    CategoryDto result = DtoBuilder.ToDto(lessThanMinimum);

        //    Assert.AreEqual(result, null);
        //}

        //[TestMethod]
        //public void ToCategory_CategoryIsGreaterThanMaximumValue_CategoryDtoIsNull()
        //{
        //    Categories greaterThanMaximum = (Categories)(6);

        //    CategoryDto result = DtoBuilder.ToDto(greaterThanMaximum);

        //    Assert.AreEqual(result, null);
        //}
        #endregion
    }
}
