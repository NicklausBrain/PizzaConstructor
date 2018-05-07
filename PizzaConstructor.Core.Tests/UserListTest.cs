using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PizzaConstructor.Data.Interfaces;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Core.Tests
{
    [TestClass]
    public class UserListTest
    {
        [TestMethod, TestCategory("UserList")]
        public void GetUserList_NoParams_ReturnsListOfUsers()
        {
            var mock = new Mock<IUserRepository>();
            List<User> users = new List<User>()
            {
                new User("john1", "smith@exmp1.com"),
                new User("john2", "smith@exmp2.com"),
                new User("john3", "smith@exmp3.com"),
                new User("john4", "smith@exmp4.com"),
                new User("john5", "smith@exmp5.com")
            };
            mock.Setup(moq => moq.GetList(null)).Returns(users);
            UserList orderList = new UserList(mock.Object);
            int expected = users.Count;

            int actual = orderList.GetUserList().Count;

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("UserList")]
        public void GetUserList_ExistingUserEmail_ReturnsListOfUsers()
        {
            var mock = new Mock<IUserRepository>();
            string email = "smith@exmp1.com";

            List<User> users = new List<User>()
            {
                new User("john1", "smith@exmp1.com"),
                new User("john2", "smith@exmp2.com"),
                new User("john3", "smith@exmp3.com"),
                new User("john4", "smith@exmp4.com"),
                new User("john5", "smith@exmp5.com")
            };

            mock.Setup(moq => moq.GetById(email)).Returns(users.FirstOrDefault(u => u.Email == email));
            UserList orderList = new UserList(mock.Object);
            User expected = users.FirstOrDefault(u => u.Email == email);

            User actual = orderList.GetUserByEmail(email);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("UserList")]
        public void GetUserList_NotExistingUserEmail_ReturnsListOfUsers()
        {
            var mock = new Mock<IUserRepository>();
            string email = "smith@exmp8.com";

            List<User> users = new List<User>()
            {
                new User("john1", "smith@exmp1.com"),
                new User("john2", "smith@exmp2.com"),
                new User("john3", "smith@exmp3.com"),
                new User("john4", "smith@exmp4.com"),
                new User("john5", "smith@exmp5.com")
            };

            mock.Setup(moq => moq.GetById(email)).Returns(users.FirstOrDefault(u => u.Email == email));
            UserList orderList = new UserList(mock.Object);

            User actual = orderList.GetUserByEmail(email);

            Assert.IsNull(actual);
        }
    }
}
