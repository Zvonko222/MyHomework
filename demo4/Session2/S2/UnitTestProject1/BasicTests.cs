using Microsoft.VisualStudio.TestTools.UnitTesting;
using S2.util;

namespace UnitTestProject1
{
    [TestClass]
    public class BasicTests
    {
        [TestInitialize]
        public void SetUp()
        {
            CurrentOfficer.JobNumber = "A001";
            CurrentOfficer.FirstName = "Tom";
            CurrentOfficer.LastName = "Lee";
            CurrentOfficer.RoleName = "Customs Officer";
        }



        [TestMethod]
        public void FullName_JoinsFirstAndLastName()
        {
            Assert.AreEqual("Tom Lee", CurrentOfficer.FullName);
        }

        [TestMethod]
        public void Title_ContainsPageName()
        {
            Assert.AreEqual(
                "SH Port Customs-Security Check(Tom Lee-Customs Officer)",
                CurrentOfficer.Title("Security Check"));
        }

        [TestMethod]
        public void PendingStatus_HasExpectedValue()
        {
            Assert.AreEqual("Pending", StatusUtils.Pending);
        }

        [TestMethod]
        public void ApprovedStatus_HasExpectedValue()
        {
            Assert.AreEqual("Approved", StatusUtils.Approved);
        }

        [TestMethod]
        public void RejectedStatus_HasExpectedValue()
        {
            Assert.AreEqual("Rejected", StatusUtils.Rejected);
        }

        [TestMethod]
        public void NotStartedStatus_HasExpectedValue()
        {
            Assert.AreEqual("Not Started", StatusUtils.NotStarted);
        }

        [TestMethod]
        public void InitialInspectionStatus_HasExpectedValue()
        {
            Assert.AreEqual("Initial Inspection", StatusUtils.InitialInspection);
        }

        [TestMethod]
        public void ExceptionStatus_HasExpectedValue()
        {
            Assert.AreEqual("Exception", StatusUtils.Exception);
        }

        [TestMethod]
        public void ReleasedStatus_HasExpectedValue()
        {
            Assert.AreEqual("Released", StatusUtils.Released);
        }

        [TestMethod]
        public void SeizedStatus_HasExpectedValue()
        {
            Assert.AreEqual("Seized", StatusUtils.Seized);
        }
    }
}
