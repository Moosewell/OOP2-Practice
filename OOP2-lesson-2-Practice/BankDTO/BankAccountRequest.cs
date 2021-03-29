using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BankDTO.dto
{
    public class BankAccountRequest : IBankAccountRequest
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public string AccountName { get; set; }
        public float Balance { get; set; }

    }
}