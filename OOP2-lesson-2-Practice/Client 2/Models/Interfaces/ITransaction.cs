using BankDTO.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient.Models.Interfaces
{
    public interface ITransaction
    {
        int AccountId { get; set; }
        float Amount { get; set; }
        TransactionRequest GetDTO();
    }
}
