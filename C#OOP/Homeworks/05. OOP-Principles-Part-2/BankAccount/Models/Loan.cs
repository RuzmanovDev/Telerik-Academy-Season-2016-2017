namespace BankAccount.Models
{
    using System;

    using BankAccount.Contracts;

    public class Loan : Account, IDepositable
    {
        public Loan(Customer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
        {
        }

        public override decimal InerestForGivenPeriod(int numberOfMonths)
        {
            int numberOfMonthsSuspended = this.Customer.CustomerType == CustomerType.Companies ? -2 : -3;
            numberOfMonths += numberOfMonthsSuspended;

            if (numberOfMonths < 1)
            {
                throw new ArgumentException("The number of months is less than 1");
            }

            return base.InerestForGivenPeriod(numberOfMonths);
        }
    }
}
