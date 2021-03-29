using System.Web.Http;
using BankDomain.Customers.CustomerService.Interfaces;
using BankDTO.dto;
using BankRepository.Interfaces;

namespace BankAPI.Controllers
{
    public class CustomerServiceController : ApiController
    {
        private readonly ICustomerService customerService;
        private readonly ICustomerRepository bankRepository;

        public CustomerServiceController(ICustomerService customerService, ICustomerRepository bankRepository)
        {
            this.customerService = customerService;
            this.bankRepository = bankRepository;
        }

        [HttpPost]
        [Route("api/CustomerService/CreateCustomer")]
        public IHttpActionResult CreateCustomer(CustomerRequest customerRequest)
        {
            var customer = customerService.RegisterCustomer(customerRequest);
            customerService.EnsureCustomerHasValidInformaiton(customer, bankRepository.GetAllCustomers());

            bankRepository.CreateCustomer(customer);

            return Ok();
        }

        [HttpGet]
        [Route("api/CustomerService/GetCustomerList")]
        public IHttpActionResult GetCustomerList()
        {
            return Ok(bankRepository.GetAllCustomers());
        }

    }
}
