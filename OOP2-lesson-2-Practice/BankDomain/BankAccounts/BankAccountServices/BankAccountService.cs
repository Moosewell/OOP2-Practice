
using BankDomain.BankAccounts.BankAccountServices.Interfaces;
using BankDomain.BankAccounts.Interfaces;
using BankDTO.dto;
using System.Collections.Generic;
using System.Linq;

namespace BankDomain.BankAccounts.BankAccountServices
{
    public class BankAccountService : IBankAccountService
    {

        public IBankAccount CreateBankAccount(IBankAccountRequest bankAccountRequest)
        {
            return new BankAccount(bankAccountRequest);
        }

        public void Withdraw(float amount, IBankAccount bankAccount)
        {
            bankAccount.Withdraw(amount);
        }

        public void Deposit(float amount, IBankAccount bankAccount)
        {
            bankAccount.Deposit(amount);
        }

    }
}