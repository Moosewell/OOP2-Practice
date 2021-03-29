using BankDomain.Customers.Interfaces;
using BankDTO.dto;
using System.Collections.Generic;


namespace BankDomain.Customers.CustomerService.Interfaces
{
    public interface ICustomerService
    {
        ICustomer RegisterCustomer(ICustomerRequest customerRequest);
        bool EnsureCustomerHasValidInformaiton(ICustomer customer, List<ICustomer> customerList);
    }
}
