using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankClient.Models.Interfaces;
using BankDTO.dto;

namespace BankClient.Models
{
    public class CustomerModel : ICustomer
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }

        public CustomerRequest GetDTO()
        {
            CustomerRequest request = new CustomerRequest();
            request.Username = Username;
            var passwordByte = Encoding.UTF8.GetBytes(Password);
            request.Password = Convert.ToBase64String(passwordByte);
            request.FirstName = FirstName;
            request.LastName = LastName;
            request.SocialSequrityNumber = SocialSecurityNumber;
            return request;
        }
    }
}
