using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDTO.dto
{
    public interface ICustomerRequest
    {
        string Username { get; set; }
        string Password { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string SocialSequrityNumber { get; set; }
    }
}
