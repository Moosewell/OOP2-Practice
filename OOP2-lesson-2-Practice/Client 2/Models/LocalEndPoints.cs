using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankClient.Models
{
    public class LocalEndPoints : IEndPoints
    {
        public string urlCreateBankAccount => "https://localhost:44316/api/BankAccountService/CreateBankAccount";
        public string urlGetBankAccountList => "https://localhost:44316/api/BankAccountService/GetBankAccountList";
        public string urlWithdraw => "https://localhost:44316/api/BankAccountService/Withdraw";
        public string urlDeposit => "https://localhost:44316/api/BankAccountService/Deposit";
        public string urlGetCustomerBankAccounts => "https://localhost:44316/api/BankAccountService/GetCustomerBankAccounts?customerId=";
        public string urlCreateCustomer => "https://localhost:44316/api/CustomerService/CreateCustomer";
        public string urlGetCustomerList => "https://localhost:44316/api/CustomerService/GetCustomerList";
    }
}