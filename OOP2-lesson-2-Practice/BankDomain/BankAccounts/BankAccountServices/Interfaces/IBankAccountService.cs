
using BankDomain.BankAccounts.Interfaces;
using BankDTO.dto;
using System.Collections.Generic;

namespace BankDomain.BankAccounts.BankAccountServices.Interfaces
{
    public interface IBankAccountService
    {
        IBankAccount CreateBankAccount(IBankAccountRequest bankAccountRequest);
        void Withdraw(float amount, IBankAccount bankAccount);
        void Deposit(float amount, IBankAccount bankAccount);
    }
}
