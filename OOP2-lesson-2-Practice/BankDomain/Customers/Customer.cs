using System.Collections.Generic;
using BankDomain.Customers.Interfaces;
using BankDTO.dto;

namespace BankDomain.Customers
{
    public class Customer : ICustomer
    {
        public Customer(string firstName, string lastName, string socialSecurityNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.socialSecurityNumber = socialSecurityNumber;
        }
        public Customer(string username, string password, string firstName, string lastName, string socialSecurityNumber)
        {
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.socialSecurityNumber = socialSecurityNumber;
        }
        public Customer(ICustomerRequest customerRequest)
        {
            this.username = customerRequest.Username;
            this.password = customerRequest.Password;
            this.firstName = customerRequest.FirstName;
            this.lastName = customerRequest.LastName;
            this.socialSecurityNumber = customerRequest.SocialSequrityNumber;
        }

        private int id { get; set; }
        public int Id => id;

        private string username { get; set; }
        public string Username => username;

        private string password { get; set; }
        public string Password => password;

        private string firstName { get; set; }
        public string FirstName => firstName;

        private string lastName { get; set; }
        public string LastName => lastName;

        private string socialSecurityNumber { get; set; }
        public string SocialSecurityNumber => socialSecurityNumber;

    }
}