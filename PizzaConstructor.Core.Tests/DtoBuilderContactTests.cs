using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaConstructor.Core.DTO;
using PizzaConstructor.Entities;
using System;

namespace PizzaConstructor.Core.Tests
{
    /// <summary>
    /// Class to test method DtoBuilder.ToDto with Contact param
    /// </summary>
    [TestClass]
    public class DtoBuilderContactTests : DtoBuilderTestsBase
    {
        [TestMethod]
        public void ToContactDto_ContactIsCorrect_ContactDtoIsEqualToContact()
        {            
            Contact contact = new Contact(
                Guid.NewGuid(),
                "Oleksandr Yatsenko",
                "05008838220",
                "Kharkiv");

            ContactDto result = DtoBuilder.ToDto(contact);

            base.AssertContactsAreEqual(contact, result);
        }

        [TestMethod]
        public void ToContactDto_ContactWithEmptyFields_ContactDtoIsEqualToContact()
        {
            Contact contact = new Contact();

            ContactDto result = DtoBuilder.ToDto(contact);

            base.AssertContactsAreEqual(contact, result);
        }

        [TestMethod]
        public void ToContactDto_ContactNameIsNull_ContactDtoIsEqualToContact()
        {
            Contact contact = new Contact(
                Guid.NewGuid(),
                null,
                "05008838220",
                "Kharkiv");

            ContactDto result = DtoBuilder.ToDto(contact);

            base.AssertContactsAreEqual(contact, result);
        }

        [TestMethod]
        public void ToContactDto_ContactPhoneIsNull_ContactDtoIsEqualToContact()
        {
            Contact contact = new Contact(
                Guid.NewGuid(),
                "Oleksandr Yatsenko",
                null,
                "Kharkiv");

            ContactDto result = DtoBuilder.ToDto(contact);

            base.AssertContactsAreEqual(contact, result);
        }

        [TestMethod]
        public void ToContactDto_ContactDeliveryAddressIsNull_ContactDtoIsEqualToContact()
        {
            Contact contact = new Contact(
                Guid.NewGuid(),
                "Oleksandr Yatsenko",
                "0508838220",
                null);

            ContactDto result = DtoBuilder.ToDto(contact);

            base.AssertContactsAreEqual(contact, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToContactDto_ContactIsNull_ContactDtoIsNull()
        {
            Contact contact = null;

            ContactDto result = DtoBuilder.ToDto(contact);
        }
    }
}
