using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EM.Components.DataAccess;
using EM.Components.Entities;
using System.Collections.Generic;

namespace EM.Components.DataAccess.Tests
{
    [TestClass]
    
    public class LeadsDataAccessTest
    {
        //A method for test
        [TestMethod]
        [TestCategory("LeadsDataAccessTest")]
        public void AddTest()
        {
            LeadsDataAccess target = new LeadsDataAccess();
            EM_Leads entity = null;
            entity = new EM_Leads();
            entity.FirstName = "John";
            entity.LastName = "Smith";
            entity.EmailAddress = DateTime.Now.ToString().Replace(" ", "") +
            "John@test.com";
            entity.IsValid = null;
            entity.Unsubscribed = null;
            EM_Leads expected = null;
            EM_Leads actual;
            actual = target.Add(entity);
            Assert.AreEqual(true, (actual != null && actual.LeadID > 0));
        }

        /// <summary>
        ///A test for GetAll
        ///</summary>
        [TestMethod()]
        [TestCategory("LeadsDataAccessTest")]
        public void GetAllTest()
        {
            LeadsDataAccess target = new LeadsDataAccess();
            List<EM_Leads> actual;
            actual = target.GetAll();
            Assert.AreEqual(true, actual.Count > 0);
        }

        /// <summary>
        ///A test for Get
        ///</summary>
        [TestMethod()]
        [TestCategory("LeadsDataAccessTest")]
        public void GetTest()
        {
            LeadsDataAccess target = new LeadsDataAccess();
            int entityId = 1;
            EM_Leads expected = null;
            EM_Leads actual;
            actual = target.Get(entityId);
            Assert.AreEqual(true, actual.EmailAddress.Length > 1);
        }
        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        [TestCategory("LeadsDataAccessTest")]
        public void UpdateTest()
        {
            LeadsDataAccess target = new LeadsDataAccess();
            EM_Leads entity = new EM_Leads();
            entity.LeadID = 1;
            entity.FirstName = "John1";
            entity.LastName = "Smith";
            entity.EmailAddress = DateTime.Now.Ticks.ToString() + "John@test.com";
            entity.IsValid = null;
            entity.Unsubscribed = null;
            EM_Leads expected = null;
            EM_Leads actual;
            actual = target.Update(entity);
            Assert.AreEqual(true, actual.FirstName == entity.FirstName);
        }
    }
}
