namespace BankAccount.Models
{
    using BankAccount.Contracts;

    public class Mortgage : Account, IDepositable
    {
        public Mortgage(Customer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
        {
        }

        public override decimal InerestForGivenPeriod(int numberOfMonths)
        {
            decimal result = 0;

            if (this.Customer.CustomerType == CustomerType.Companies)
            {
                decimal interestForFIrst12 = this.InterestRate / 2;
                result += interestForFIrst12 * 12;

                if (numberOfMonths > 12)
                {
                    int residualMonth = numberOfMonths - 12;
                    result += residualMonth * this.InterestRate;
                }
            }
            else
            {
                if (numberOfMonths > 6)
                {
                    int resMonth = numberOfMonths - 6;
                    result += resMonth * this.InterestRate;
                }
            }

            return result;
        }
    }
}
