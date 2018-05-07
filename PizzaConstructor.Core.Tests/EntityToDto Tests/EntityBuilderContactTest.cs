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
    public class EntityBuilderContactTest : DtoBuilderTestsBase
    {
        [TestMethod]
        public void ToEntityContact_ContactIsCorrect_ContactDtoIsEqualToContact()
        {
            ContactDto contact = new ContactDto(
                "Oleksandr Yatsenko",
                "05008838220",
                "Kharkiv");


            Contact contactDto = EntityBuilder.ToEntity(contact);

            this.AssertContactsAreEqual(contactDto, contact);
        }

        [TestMethod]
        public void ToEntityContact_ContactWithEmptyFields_ContactDtoIsEqualToContact()
        {
            ContactDto contact = new ContactDto();


            Contact contactDto = EntityBuilder.ToEntity(contact);

            this.AssertContactsAreEqual(contactDto, contact);
        }

        [TestMethod]
        public void ToEntityContact_ContactNameIsNull_ContactDtoIsEqualToContact()
        {
            ContactDto contact = new ContactDto(null,
                "05008838220",
                "Kharkiv");

            Contact contactDto = EntityBuilder.ToEntity(contact);

            this.AssertContactsAreEqual(contactDto, contact);

        }

        [TestMethod]
        public void ToEntityContact_ContactPhoneIsNull_ContactDtoIsEqualToContact()
        {
            ContactDto contact = new ContactDto(
              "Oleksandr Yatsenko",
                null,
                "Kharkiv");

            Contact contactDto = EntityBuilder.ToEntity(contact);

            this.AssertContactsAreEqual(contactDto, contact);
        }

        [TestMethod]
        public void ToEntityContact_ContactDeliveryAddressIsNull_ContactDtoIsEqualToContact()
        {
            ContactDto contact = new ContactDto(
               "Oleksandr Yatsenko",
                "0508838220",
                null);

            Contact contactDto = EntityBuilder.ToEntity(contact);

            this.AssertContactsAreEqual(contactDto, contact);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToEntityContact_ContactIsNull_ContactDtoIsNull()
        {
            Contact contact = null;

            ContactDto result = DtoBuilder.ToDto(contact);
        }
    }
}
