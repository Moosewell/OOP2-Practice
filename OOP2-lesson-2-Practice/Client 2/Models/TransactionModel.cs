using BankClient.Models.Interfaces;
using BankDTO.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankClient.Models
{
    public class TransactionModel : ITransaction
    {
        public int AccountId { get; set; }
        public float Amount { get; set; }

        public TransactionRequest GetDTO()
        {
            TransactionRequest request = new TransactionRequest();
            request.accountId = this.AccountId;
            request.amount = this.Amount;
            return request;
        }
    }
}