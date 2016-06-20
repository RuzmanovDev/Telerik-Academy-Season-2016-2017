namespace BankAccount.Models
{
    using System;

    using Contracts;

    public class Deposit : Account, IDepositable, IWithdrawable
    {
        private decimal interestRate;

        public Deposit(Customer customer, decimal balance, decimal interestRate) : base(customer, balance)
        {
            this.InterestRate = interestRate;
        }

        public override decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }

            set
            {
                if (this.Ballance < 1000)
                {
                    this.interestRate = 0;
                }
                else
                {
                    this.interestRate = value;
                }
            }
        }

        public void Withdraw(decimal ammount)
        {
            if (ammount > this.Ballance)
            {
                throw new ArgumentException("There is not enogh money!");
            }

            this.Ballance -= ammount;
        }
    }
}
