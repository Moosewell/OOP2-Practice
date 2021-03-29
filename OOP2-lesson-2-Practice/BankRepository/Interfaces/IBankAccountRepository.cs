using BankDomain.BankAccounts.Interfaces;
using System.Collections.Generic;

namespace BankRepository.Interfaces
{
    public interface IBankAccountRepository
    {
        void CreateBankAccount(IBankAccount bankaccount);
        List<IBankAccount> GetAllBankAccounts();
        IBankAccount GetBankAccount(int bankAccountId);
        void UpdateBankAccount(IBankAccount account);
        void DeleteBankAccount(int bankAccountId);
    }
}
