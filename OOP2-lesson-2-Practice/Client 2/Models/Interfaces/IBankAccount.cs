using BankDTO.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient.Models.Interfaces
{
    public interface IBankAccount
    {
        int AccountId { get; set; }
        int CustomerId { get; set; }
        string AccountName { get; set; }
        float Balance { get; set; }
        BankAccountRequest GetDTO();

    }
}
