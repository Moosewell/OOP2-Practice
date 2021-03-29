using BankDomain.BankAccounts.Interfaces;
using BankDomain.Customers.Interfaces;
using System.Collections.Generic;

namespace BankRepository.Interfaces
{
    public interface ICustomerRepository
    {
        void CreateCustomer(ICustomer bankaccount);
        List<ICustomer> GetAllCustomers();
        ICustomer GetCustomer(int bankAccountId);
        ICustomer UpdateCustomer(ICustomer account);
        void DeleteCustomer(int bankAccountId);
    }
}
