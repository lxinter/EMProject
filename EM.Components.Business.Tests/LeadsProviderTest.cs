using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EM.Components.Business;
using EM.Components.Entities;

namespace EM.Components.Business.Tests
{
    [TestClass]
    public class LeadsProviderTest
    {
        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        [TestCategory("LeadsProviderTest")]
        public void AddTest()
        {
            LeadsProvider target = new LeadsProvider();
            EM_Leads entity = null;
            entity = new EM_Leads();
            entity.FirstName = "John";
            entity.LastName = "Smith";
            entity.EmailAddress = DateTime.Now.ToString().Replace(" ", "") +
            "John@test.com";
            entity.IsValid = null;
            entity.Unsubscribed = null;
            EM_Leads actual;
            actual = target.Add(entity);
            Assert.AreEqual(true, (actual != null && actual.LeadID > 0));
        }

        /// <summary>
        ///Exception test for Add
        ///</summary>
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        [TestCategory("LeadsProviderTest")]
        public void AddExceptionTest()
        {
            LeadsProvider target = new LeadsProvider();
            EM_Leads entity = null;
            entity = new EM_Leads();
            entity.FirstName = "John";
            entity.LastName = "Smith";
            entity.EmailAddress = DateTime.Now.ToString().Replace(" ", "") +
            "John@test.com";
            entity.IsValid = null;
            entity.Unsubscribed = null;
            EM_Leads actual;
            actual = target.Add(entity);
            actual = target.Add(entity);
        }
    }
}
