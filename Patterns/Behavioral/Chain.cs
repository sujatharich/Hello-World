// -----------------------------------------------------------------------
//  <copyright file="Chain.cs" company="Microsoft Corporation">
//      Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Patterns.Behavioral
{
    using System;

    public class Loan
    {
        public double Amount;
    }

    public class LoanEventArgs : EventArgs
    {
        public Loan Loan { get; set; }
    }

    public abstract class Approver
    {
        public EventHandler<LoanEventArgs> LoanEventHandler;

        public Approver()
        {
            this.LoanEventHandler += this.LoanHandler;
        }

        public string Status { get; set; }
        public Approver Successor { get; set; }

        public abstract void LoanHandler(object sender, LoanEventArgs e);

        public void ProcessRequest(Loan l)
        {
            this.OnLoan(new LoanEventArgs { Loan = l });
        }

        public virtual void OnLoan(LoanEventArgs e)
        {
            if (this.LoanEventHandler != null)
            {
                this.LoanEventHandler(this, e);
            }
        }
    }

    public class Clerk : Approver
    {
        public override void LoanHandler(object sender, LoanEventArgs e)
        {
            if (e.Loan.Amount <= 10)
            {
                this.Status = "ClerkApproved:" + e.Loan.Amount;
            }
            else
            {
                this.Successor.LoanEventHandler(this, e);
            }
        }
    }

    public class AsstMgr : Approver
    {
        public override void LoanHandler(object sender, LoanEventArgs e)
        {
            if (e.Loan.Amount <= 100)
            {
                this.Status = "AsstMgrApproved:" + e.Loan.Amount;
            }
            else
            {
                this.Successor.LoanEventHandler(this, e);
            }
        }
    }

    public class Manager : Approver
    {
        public override void LoanHandler(object sender, LoanEventArgs e)
        {
            if (e.Loan.Amount <= 1000)
            {
                this.Status = "ManagerApproved:" + e.Loan.Amount;
            }
            else
            {
                this.Status = "NotApproved:" + e.Loan.Amount;
            }
        }
    }
}
