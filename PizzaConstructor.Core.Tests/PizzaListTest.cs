using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PizzaConstructor.Data.Interfaces;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Core.Tests
{
    [TestClass]
    public class PizzaListTest
    {
        [TestMethod, TestCategory("PizzaList")]
        public void GetPizzaList_NoParams_ReturnsListOfPizzas()
        {
            var mock = new Mock<IPizzaRepository>();
            List<PizzaItem> pizzaItems = new List<PizzaItem>()
            {
                new PizzaItem(){Order = new Order(new Guid(), 0,new Contact())},
                new PizzaItem(){Order = new Order(new Guid(), 0,new Contact())},
                new PizzaItem(){Order = new Order(new Guid(), 0,new Contact())},
                new PizzaItem(){Order = new Order(new Guid(), 0,new Contact())},
                new PizzaItem(){Order = new Order(new Guid(), 0,new Contact())}
            };
            mock.Setup(moq => moq.GetList(null)).Returns(pizzaItems);
            PizzaList pizzaList = new PizzaList(mock.Object);
            int expected = pizzaItems.Count;

            int actual = pizzaList.GetPizzasList().Count;

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("PizzaList")]
        public void GetPizzasListByUserFullName_ExistingUserName_ReturnsListOfPizzas()
        {
            var mock = new Mock<IPizzaRepository>();
            string name = "John";
            List<PizzaItem> pizzaItems = new List<PizzaItem>()
            {
                new PizzaItem(){ Order = new Order(new Guid(), 1, new Contact(), new User("John" ,"John`s email")) },
                new PizzaItem(){ Order = new Order(new Guid(), 2, new Contact(), new User("John" ,"John`s email")) },
                new PizzaItem(){ Order = new Order(new Guid(), 3, new Contact(), new User("John" ,"John`s email")) },
                new PizzaItem(){ Order = new Order(new Guid(), 4, new Contact(), new User("Sam" ,"John`s email")) },
                new PizzaItem(){ Order = new Order(new Guid(), 5, new Contact(), new User("Sam" ,"John`s email")) },
                new PizzaItem(){ Order = new Order(new Guid(), 6, new Contact(), new User("Sam" ,"John`s email")) },
                new PizzaItem(){ Order = new Order(new Guid(), 7, new Contact(), new User("John" ,"John`s email")) }
            };

            mock.Setup(moq => moq.GetList(It.IsAny<Expression<Func<PizzaItem, bool>>>())).Returns(pizzaItems.Where(p => p.Order.User.Name == name));

            PizzaList pizzaList = new PizzaList(mock.Object);
            int expected = 4;

            int actual = pizzaList.GetPizzasListByUserFullName(name).Count;

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }
    }
}
