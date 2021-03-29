using BankDomain.BankAccounts.Interfaces;
using BankDomain.BankAccounts;
using BankDomain.Customers.Interfaces;
using BankRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankRepository.Classes
{
    public class LocalRepository : IBankAccountRepository, ICustomerRepository
    {
        private readonly BankDataContextDataContext dataContext;

        public LocalRepository()
        {
            dataContext = new BankDataContextDataContext();
        }

        public void CreateBankAccount(IBankAccount bankaccount)
        {
            var newBankAccount = new BankAccount
            {
                Name = bankaccount.AccountName
            };

            dataContext.BankAccounts.InsertOnSubmit(newBankAccount);
            dataContext.SubmitChanges();

            var newCustomerBankAccount = new CustomerBankAccount
            {
                BankAccountId = newBankAccount.Id,
                CustomerId = bankaccount.CustomerId
            };

            dataContext.CustomerBankAccounts.InsertOnSubmit(newCustomerBankAccount);
            dataContext.SubmitChanges();
        }

        public void CreateCustomer(ICustomer customer)
        {
            var newCustomer = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                SocialSequrityNumber = customer.SocialSecurityNumber
            };

            dataContext.Customers.InsertOnSubmit(newCustomer);
            dataContext.SubmitChanges();
        }

        public void DeleteBankAccount(int bankAccountId)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int bankAccountId)
        {
            throw new NotImplementedException();
        }

        public List<IBankAccount> GetAllBankAccounts()
        {
            var BankAccounts = new List<IBankAccount>();
            foreach(var bankAccountEntity in dataContext.BankAccounts)
            {
                var CustomerBankAccount = dataContext.CustomerBankAccounts.Where(
                    o => o.BankAccountId == bankAccountEntity.Id).FirstOrDefault();
                IBankAccount bankAccount = new BankDomain.BankAccounts.BankAccount(bankAccountEntity.Id,
                                                                                   CustomerBankAccount.CustomerId,
                                                                                   bankAccountEntity.Name,     
                                                                                   (float)bankAccountEntity.Balance);
                BankAccounts.Add(bankAccount);
            }
            return BankAccounts;
        }

        public List<ICustomer> GetAllCustomers()
        {
            var customers = new List<ICustomer>();
            foreach (var customerEntity in dataContext.Customers)
            {
                ICustomer customer = new BankDomain.Customers.Customer(customerEntity.FirstName, 
                                                                       customerEntity.LastName, 
                                                                       customerEntity.SocialSequrityNumber);
                customers.Add(customer);
            }
            return customers;
        }

        public IBankAccount GetBankAccount(int bankAccountId)
        {
            var bankAccount = dataContext.BankAccounts.Where(o => o.Id == bankAccountId).FirstOrDefault();
            var CustomerBankAccount = dataContext.CustomerBankAccounts.Where(
                   o => o.BankAccountId == bankAccount.Id).FirstOrDefault();
            IBankAccount newBankAccount = new BankDomain.BankAccounts.BankAccount(bankAccount.Id,
                                                                                  CustomerBankAccount.CustomerId,
                                                                                  bankAccount.Name,
                                                                                  (float)bankAccount.Balance);
            return newBankAccount;
        }

        public ICustomer GetCustomer(int bankAccountId)
        {
            throw new NotImplementedException();
        }

        public void UpdateBankAccount(IBankAccount bankAccount)
        {
            using (dataContext)
            {
                var oldBankAccount = dataContext.BankAccounts.Single(o => o.Id == bankAccount.AccountId);
                oldBankAccount.Id = bankAccount.AccountId;
                oldBankAccount.Name = bankAccount.AccountName;
                oldBankAccount.Balance = bankAccount.Balance;
                dataContext.SubmitChanges();
            }
            
        }

        public ICustomer UpdateCustomer(ICustomer bankAccount)
        {
            throw new NotImplementedException();
        }
    }
}
