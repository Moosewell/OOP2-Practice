using System.Collections.Generic;
using BankDomain.BankAccounts.Interfaces;
using BankDTO.dto;

namespace BankDomain.BankAccounts
{
    public class BankAccount : IBankAccount
    {
        public BankAccount(int customerId, string accountName)
        {
            this.customerId = customerId;
            this.accountName = accountName;
            this.balance = 0;
        }
        public BankAccount(IBankAccountRequest bankAccountRequest)
        {
            this.customerId = bankAccountRequest.CustomerId;
            this.accountName = bankAccountRequest.AccountName;
            this.balance = 0;
        }
        public BankAccount(int id, int customerId, string accountName, float balance)
        {
            this.accountId = id;
            this.customerId = customerId;
            this.accountName = accountName;
            this.balance = balance;
        }

        private int accountId { get; set; }
        public int AccountId => accountId;

        private int customerId { get; set; }
        public int CustomerId => customerId;

        private string accountName { get; set; }
        public string AccountName => accountName;

        private float balance { get; set; }
        public float Balance => balance;

        public void Withdraw(float amount)
        {
            if (BalanceToLowForWithdrawl(amount))
                return;

            balance -= amount;
        }
        public void Deposit(float amount)
        {
            balance += amount;
        }
        public bool BalanceToLowForWithdrawl(float amount)
        {
            return this.balance - amount < 0;
        }

    }
}