using BankDTO.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient.Models.Interfaces
{
    public interface ICustomer
    {
        string Username { get; }
        string Password { get; }
        string FirstName { get; }
        string LastName { get; }
        string SocialSecurityNumber { get; }
        CustomerRequest GetDTO();
    }
}
