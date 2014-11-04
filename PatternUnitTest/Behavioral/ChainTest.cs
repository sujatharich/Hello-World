// -----------------------------------------------------------------------
//  <copyright file="ChainTest.cs" company="Microsoft Corporation">
//      Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace PatternUnitTest.Behavioral
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Patterns.Behavioral;

    [TestClass]
    public class ChainTest
    {
        private readonly AsstMgr asstMgr;
        private readonly Clerk clerk;
        private readonly Manager manager;

        public ChainTest()
        {
            this.clerk = new Clerk();
            this.asstMgr = new AsstMgr();
            this.manager = new Manager();
            this.clerk.Successor = this.asstMgr;
            this.asstMgr.Successor = this.manager;
        }

        [TestMethod]
        public void ClerkTest()
        {
            var loan = new Loan { Amount = 10 };
            this.clerk.ProcessRequest(loan);
            Assert.IsTrue(this.clerk.Status == "ClerkApproved:" + loan.Amount);
        }

        [TestMethod]
        public void AsstMgrTest()
        {
            var loan = new Loan { Amount = 100 };
            this.clerk.ProcessRequest(loan);
            Assert.IsTrue(this.asstMgr.Status == "AsstMgrApproved:" + loan.Amount);
        }

        [TestMethod]
        public void Managerest()
        {
            var loan = new Loan { Amount = 1000 };
            this.clerk.ProcessRequest(loan);
            Assert.IsTrue(this.manager.Status == "ManagerApproved:" + loan.Amount);
        }

        [TestMethod]
        public void NoApprovalTest()
        {
            var loan = new Loan { Amount = 1001 };
            this.clerk.ProcessRequest(loan);
            Assert.IsTrue(this.manager.Status == "NotApproved:" + loan.Amount);
        }
    }
}
