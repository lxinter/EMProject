using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EM.Components.Entities;

namespace EM.Components.DataAccess.Tests
{
    [TestClass]
    public class EmailDataAccessTest
    {
        [TestMethod()]
        [TestCategory("EmailDataAccessTest")]
        public void AddTest()
        {
            EmailDataAccess target = new EmailDataAccess();
            EM_EmailInstances entity = null;
            EM_EmailInstances expected = null;

            EM_EmailInstances actual;
            entity = new EM_EmailInstances();
            entity.CampaignID = 1;
            entity.CreatedBy =
            System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            entity.SubjectLine = "Email Subject";
            entity.EmailBody = "Test email body";
            entity.CreatedDate = DateTime.Now;
            actual = target.Add(entity);
            Assert.AreEqual(true, actual.EmailInstanceID > 0);
        }
    }
}
