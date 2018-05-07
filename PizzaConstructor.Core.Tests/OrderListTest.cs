using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaConstructor.Data.Interfaces;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Core.Tests
{
    [TestClass]
    public class OrderListTest
    {
        [TestMethod, TestCategory("OrderList")]
        public void GetOrdersList_IndexAndNumIsNotZeroAndAreInRange_ReturnsNumOrdersBeginsFromIndex()
        {
            var mock = new Mock<IOrderRepository>();
            int index = 1, num = 4;
            mock.Setup(moq => moq.GetList(null)).Returns(new List<Order>()
            {
                new Order(new Guid(),1,new Contact(),new User("john","smith@exmp.com") ),
                new Order(new Guid(),2,new Contact(),new User("john","smith@exmp.com") ),
                new Order(new Guid(),3,new Contact(),new User("john","smith@exmp.com") ),
                new Order(new Guid(),4,new Contact(),new User("john","smith@exmp.com") ),
                new Order(new Guid(),5,new Contact(),new User("john","smith@exmp.com") )
            });
            OrderList orderList = new OrderList(mock.Object);
            int expected = num;

            int actual = orderList.GetOrdersList(index, num).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("OrderList")]
        public void GetOrdersList_IndexAndNumIsZero_ReturnsNumOrdersBeginsFromIndex()
        {
            var mock = new Mock<IOrderRepository>();
            int index = 0, num = 0;
            mock.Setup(moq => moq.GetList(null)).Returns(new List<Order>());
            OrderList orderList = new OrderList(mock.Object);
            int expected = num;

            int actual = orderList.GetOrdersList(index, num).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("OrderList")]
        public void GetOrdersList_IndexMoreThanRangeNumIsNotZero_ReturnsZeroOrders()
        {
            var mock = new Mock<IOrderRepository>();
            int index = 4, num = 5;
            mock.Setup(moq => moq.GetList(null)).Returns(new List<Order>());
            OrderList orderList = new OrderList(mock.Object);
            int expected = 0;

            int actual = orderList.GetOrdersList(index, num).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("OrderList")]
        public void GetOrdersList_IndexNotZeroInRangeNumNotZeroMoreThanRange_ReturnsMoreThanZeroAndLessThanNumOrders()
        {
            var mock = new Mock<IOrderRepository>();
            int index = 4, num = 5;
            mock.Setup(moq => moq.GetList(null)).Returns(new List<Order>()
            {
                new Order(new Guid(),1,new Contact(),new User("john","smith@exmp.com") ),
                new Order(new Guid(),2,new Contact(),new User("john","smith@exmp.com") ),
                new Order(new Guid(),3,new Contact(),new User("john","smith@exmp.com") ),
                new Order(new Guid(),4,new Contact(),new User("john","smith@exmp.com") ),
                new Order(new Guid(),5,new Contact(),new User("john","smith@exmp.com") )
            });
            OrderList orderList = new OrderList(mock.Object);
            int expected = num;

            int actual = orderList.GetOrdersList(index, num).Count;

            Assert .IsTrue(actual<expected);
        }
    }
}
