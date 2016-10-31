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
    
    public class NavbarControllerTest
    {
        private NavbarController controller;
        private UserPrincipal User ;
        private GenericIdentity fakeIdentity;
        private GenericPrincipal principal;
        public NavbarControllerTest()
        {
        fakeIdentity = new GenericIdentity("MSoria");
       

        principal = new GenericPrincipal(fakeIdentity, null);
            
        }

        public void Setup()
        {
        //    //controller = new NavbarController { ControllerContext = MockWebContext.BasicContext()}
        //fakeIdentity = new GenericIdentity("fkim");
       

        //principal = new GenericPrincipal(fakeIdentity, null);
            
        }
        
        [TestMethod]
        public void Accouting_User_Not_Access_Amin_Menu()
        {
            // Assign
            controller = new NavbarController(principal);
            // Act
            PartialViewResult result = controller.Index() as PartialViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}



