using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDomain.BankAccounts.Interfaces
{
    public interface IBankAccount
    {
        int AccountId { get; }
        int CustomerId { get; }
        string AccountName { get; }
        float Balance { get; }
        void Withdraw(float amount);
        void Deposit(float amount);
        bool BalanceToLowForWithdrawl(float amount);
    }
}
