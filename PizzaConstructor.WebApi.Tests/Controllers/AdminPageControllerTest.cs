using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaConstructor.WebApi.Controllers;

namespace PizzaConstructor.WebApi.Tests.Controllers
{
    [TestClass]
    public class AdminPageControllerTest
    {
        [TestMethod]
        public void AdminPage_NotNull()
        {
            // Arrange
            AdminPageController controller = new AdminPageController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
