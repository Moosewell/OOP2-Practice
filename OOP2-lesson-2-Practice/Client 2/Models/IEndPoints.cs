using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankClient.Models
{
    public interface IEndPoints 
    {
         string urlCreateBankAccount { get; }
        string urlGetBankAccountList { get; }
        string urlWithdraw { get; }
        string urlDeposit { get; }
        string urlGetCustomerBankAccounts { get; }
        string urlCreateCustomer { get; }
         string urlGetCustomerList { get; }
    }
}