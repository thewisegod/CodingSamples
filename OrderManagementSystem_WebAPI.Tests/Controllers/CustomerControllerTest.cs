using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManagementSystem_WebAPI;
using OrderManagementSystem_WebAPI.Controllers;
using OrderManagementSystem_WebAPI.Controllers.Api;

namespace OrderManagementSystem_WebAPI.Tests.Controllers
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            CustomerController controller = new CustomerController();

            // Act
            //ViewResult result = controller.Index() as ViewResult;

            // Assert
            //Assert.IsNotNull(result);
        }
    }
}
