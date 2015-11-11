using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Principal;
using EM.Components.Business;
using EM.Components.Entities;

namespace EM.Components.Business.Tests
{
    [TestClass]
    public class CampaginProviderTest
    {
        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        [TestCategory("CampaignProviderTest")]
        public void AddTest()
        {
            CampaignProvider target = new CampaignProvider();
            EM_Campaigns entity = null;
            EM_Campaigns actual;
            entity = Create();
            actual = target.Add(entity);
            Assert.AreEqual(true, actual.CampaignID > 0);
        }

        private EM_Campaigns Create()
        {
            var entity = new EM_Campaigns();
            entity.CampaignName = DateTime.Now.Ticks.ToString() + "Name";
            entity.CampaignDesc = "Description for " + entity.CampaignName;
            entity.StartDate = DateTime.Now;
            entity.EndDate = DateTime.Now.AddDays(10);
            entity.Owner = WindowsIdentity.GetCurrent().Name;
            entity.CreatedBy = entity.Owner;
            entity.CreatedDate = DateTime.Now;
            entity.Guid = Guid.NewGuid();
            return entity;
        }
        /// <summary>
        ///A test for Submit
        ///</summary>
        [TestMethod()]
        [TestCategory("CampaignProviderTest")]
        public void SubmitTest()
        {
            CampaignProvider target = new CampaignProvider();
            int entityId = 0;
            var entity = Create();
            entity = target.Add(entity);
            entityId = entity.CampaignID;
            target.Submit(entityId);
            entity = target.Get(entityId);
            Assert.AreEqual(true, entity.Submitted);
        }
    }
}
