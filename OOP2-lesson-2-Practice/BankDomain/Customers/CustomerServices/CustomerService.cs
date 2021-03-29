using BankDomain.Customers.CustomerService.Interfaces;
using BankDomain.Customers.Interfaces;
using BankDTO.dto;
using System.Collections.Generic;

namespace BankDomain.Customers.CustomerService
{
    public class CustomerService : ICustomerService
    {
        public ICustomer RegisterCustomer(ICustomerRequest customerRequest)
        {
           
            return new Customer(customerRequest);
        }

        public bool EnsureCustomerHasValidInformaiton(ICustomer newCustomer, List<ICustomer> CustomerList)
        {
            foreach(ICustomer customer in CustomerList)
            {
                if (customer.Username == newCustomer.Username)
                    return false;
            }
            return true;
        }
    }
}