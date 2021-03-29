using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankClient.Models
{
    public class AzureEndPoints : IEndPoints
    {
        public string urlCreateBankAccount => "https://maxnewtonbankapi.azurewebsites.net/api/BankAccountService/CreateBankAccount";
        public string urlGetBankAccountList => "https://maxnewtonbankapi.azurewebsites.net/api/BankAccountService/GetBankAccountList";
        public string urlWithdraw => "https://maxnewtonbankapi.azurewebsites.net/api/BankAccountService/Withdraw";
        public string urlDeposit => "https://maxnewtonbankapi.azurewebsites.net/api/BankAccountService/Deposit";
        public string urlGetCustomerBankAccounts => "https://maxnewtonbankapi.azurewebsites.net/api/BankAccountService/GetCustomerBankAccounts?customerId=";
        public string urlCreateCustomer => "https://maxnewtonbankapi.azurewebsites.net/api/CustomerService/CreateCustomer";
        public string urlGetCustomerList => "https://maxnewtonbankapi.azurewebsites.net/api/CustomerService/GetCustomerList";
    }
}