using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaConstructor.WebApi.Controllers;

namespace PizzaConstructor.WebApi.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_NotNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index(null, null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }

        [TestMethod]
        public void Index_ErrorStatusMessage()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index(ManageMessageId.LoginError, null) as ViewResult;

            // Assert
            Assert.AreEqual("You don`t have permission to attend this page!", result.ViewBag.StatusMessage);
        }

        [TestMethod]
        public void Index_SuccessStatusMessage()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index(ManageMessageId.OrderSuccess, null) as ViewResult;

            // Assert
            Assert.AreEqual("Your order was added!", result.ViewBag.StatusMessage);
        }

        [TestMethod]
        public void Index_SuccessStatus()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index(null, false) as ViewResult;

            // Assert
            Assert.AreEqual("success", result.ViewBag.Status);
        }

        [TestMethod]
        public void Index_DangerStatus()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index(null, true) as ViewResult;

            // Assert
            Assert.AreEqual("danger", result.ViewBag.Status);
        }

        [TestMethod]
        public void Templates_NotNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Templates() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PizzaConstructor_NotNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.PizzaConstructor() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void OrdersHistory_NotNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.OrdersHistory() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
