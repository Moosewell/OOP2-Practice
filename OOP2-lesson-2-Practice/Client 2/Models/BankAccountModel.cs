using BankClient.Models.Interfaces;
using BankDTO.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient.Models
{
    public class BankAccountModel : IBankAccount
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public string AccountName { get; set; }
        public float Balance { get; set; }

        public BankAccountRequest GetDTO()
        {
            BankAccountRequest request = new BankAccountRequest();
            request.CustomerId = CustomerId;
            request.AccountName = AccountName;
            return request;
        }
    }
}
