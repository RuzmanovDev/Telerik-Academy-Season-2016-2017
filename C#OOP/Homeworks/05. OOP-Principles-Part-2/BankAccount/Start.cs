namespace BankAccount
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;
 
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var firm = new Customer("Telerik", CustomerType.Companies);
            var pesho = new Customer("Petar Tudjarov", CustomerType.Individuals);

            var peshoLoan = new Loan(pesho, 2000, 1.2M);
            var peshoDeposit = new Deposit(pesho, 15000, 2.1M);
            var peshoMortgade = new Mortgage(pesho, 15000000, 5.2M);

            var telerikLoan = new Loan(firm, 2000, 1.2M);
            var telerikDeposit = new Deposit(firm, 15000, 2.1M);
            var telerikMortgage = new Mortgage(firm, 15000000, 5.2M);

            var listOfAcc = new List<Account>()
            {
                peshoDeposit, peshoLoan, peshoMortgade,
                telerikDeposit, telerikLoan, telerikMortgage
            };

            var list = listOfAcc
                .Select(l => new
                {
                    Name = l.GetType().Name,
                    Type = l.Customer.CustomerType,
                    Interest = l.InerestForGivenPeriod(48)
                });

            foreach (var item in list)
            {
                Console.WriteLine(item.Name + " " + item.Type + " " + item.Interest);
            }
        }
    }
}
