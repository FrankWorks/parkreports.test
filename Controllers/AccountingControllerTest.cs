using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DashBoard.Web;
using DashBoard.Web.Controllers;
using Moq;
//using Telerik.JustMock;
using System.Web;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;


namespace DashBoard.Web.Test.Controllers
{
    [TestClass]
    
    public class AccountingControllerTest
    {
        private AccountController controller;
        [TestInitialize]
        public void Setup()
        {
            controller = new AccountController { ControllerContext = MockWebContext.BasicContext() };
        }
        [TestMethod]
        public void JSON_Returns_Value()
        {
            //controller.ControllerContext = MockWebContext.AuthenticatedContext("Parks\fkim", new[] { "Domain Users" }, true);
            //var result = controller.GetGroupsJsonClass();
            //Assert.IsNotNull(result);
            //Assert.IsInstanceOfType(result, typeof (ViewResult));
        }

        [TestMethod]
        public void GetGroupsJsonUsingModelTest()
        {
            
            // Arrange
        var fakeHttpContext = new Mock<HttpContextBase>();
        var fakeIdentity = new GenericIdentity("fkim");
       

        var principal = new GenericPrincipal(fakeIdentity, null);

            
            

        fakeHttpContext.Setup(t => t.User).Returns(principal);
        var controllerContext = new Mock<ControllerContext>();
        controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);  
            
            AccountController controller = new AccountController();
            controller.ControllerContext = controllerContext.Object;
            var ctx = new PrincipalContext(ContextType.Domain);
            //controller.GetGroupJsonUsingModel(principal, ctx);
            

            
            //var contextMock = new Mock<ControllerContext>();
            //var HttpContextMock = new Mock<HttpContextBase>();
            //var IWindowsIdentity = new WindowsIdentity("Administrator");
            //HttpContextMock.Setup(x => x.User).Returns(new WindowsPrincipal(IWindowsIdentity));
            //contextMock.Setup(ctx => ctx.HttpContext).Returns(HttpContextMock.Object);
            //controller.ControllerContext = contextMock.Object;




            // Act
            JsonResult result = controller.GetGroupJsonUsingModel(principal, ctx) as JsonResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
