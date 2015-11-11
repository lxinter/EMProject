using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EM.Web;
using System.Web;
using EM.Web.Controllers;
using System.Web.Mvc;
using EM.Components.Entities;
using System.Collections.Generic;

namespace EM.Web.Tests
{
    [TestClass]
    public class LeadsControllerTest
    {
        /// <summary> 
        /// Test View 
        /// </summary> 
        [TestCategory("LeadsControllerTest")]
        [TestMethod]
        public void Index()
        {
            LeadsController lc = new LeadsController();
            ViewResult result = (ViewResult)lc.Index();
            var model = (List<EM_Leads>)result.Model;
            // Assert 
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(model);
        }
        [TestCategory("LeadsControllerTest")]
        [TestMethod]
        public void EditPost()
        {
            LeadsController lc = new LeadsController();
            // setup testing data 
            EM_Leads entity = new EM_Leads();
            entity.LeadID = 1;
            entity.FirstName = "John1";
            entity.LastName = "Smith";
            entity.EmailAddress = "john1.smith@test0303.com";
            entity.IsValid = true;
            RedirectToRouteResult result = (RedirectToRouteResult)lc.Edit(entity);
            result.RouteValues.ContainsValue("Index");
            // assert 
            Assert.IsTrue(result.RouteValues.ContainsValue("Index"));
        }
    }
}
