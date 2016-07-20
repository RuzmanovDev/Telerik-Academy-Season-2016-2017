namespace BankAccount.Models
{
    using BankAccount.Contracts;

    public class Customer : ICustomer
    {
        public Customer(string name, CustomerType customerType)
        {
            this.Name = name;
            this.CustomerType = customerType;
        }

        public CustomerType CustomerType { get; protected set; }

        public string Name { get; protected set; }
    }
}
