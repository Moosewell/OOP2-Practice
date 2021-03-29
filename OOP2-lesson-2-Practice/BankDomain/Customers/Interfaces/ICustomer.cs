

namespace BankDomain.Customers.Interfaces
{
    public interface ICustomer
    {
        int Id { get; }
        string Username { get; }
        string Password { get; }
        string FirstName { get; }
        string LastName { get; }
        string SocialSecurityNumber { get; }
    }
}
