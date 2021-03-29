using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDTO.dto
{
    public class TransactionRequest : ITransactionRequest
    {
        public int accountId { get; set; }
        public float amount { get; set; }
    }
}
