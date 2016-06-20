namespace BankAccount.Models
{
    using System;

    using Contracts;

    public abstract class Account : IDepositable
    {
        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Ballance = balance;
            this.InterestRate = interestRate;
        }

        public Account(Customer customer, decimal balance)
        {
            this.Customer = customer;
            this.Ballance = balance;
        }

        public Customer Customer { get; set; }

        public virtual decimal Ballance { get; set; }

        public virtual decimal InterestRate { get; set; }

        public virtual decimal InerestForGivenPeriod(int numberOfMonths)
        {
            return this.InterestRate * numberOfMonths;
        }

        public virtual void DepositSum(decimal ammmount)
        {
            if (ammmount < 0)
            {
                throw new ArgumentException("Can not deposit negative sum");
            }

            this.Ballance += ammmount;
        }
    }
}
