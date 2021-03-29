using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDTO.dto
{
    public interface IBankAccountRequest
    {
        int AccountId { get; set; }
        int CustomerId { get; set; }
        string AccountName { get; set; }
        float Balance { get; set; }
    }
}
