namespace BankAccount.Contracts
{
    using BankAccount.Models;

    public interface ICustomer : ICustomerType
    {
        string Name { get; }
    }
}
