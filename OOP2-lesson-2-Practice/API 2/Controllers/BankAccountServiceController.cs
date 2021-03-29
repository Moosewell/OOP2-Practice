using System.Web.Http;
using BankDomain.BankAccounts.BankAccountServices.Interfaces;
using BankDomain.BankAccounts.Interfaces;
using BankDTO.dto;
using BankRepository.Interfaces;

namespace BankAPI.Controllers
{
    public class BankAccountServiceController : ApiController
    {
        private readonly IBankAccountService bankAccountService;
        private readonly IBankAccountRepository bankRepository;

        public BankAccountServiceController(IBankAccountService bankAccountService, IBankAccountRepository bankRepository)
        {
            this.bankAccountService = bankAccountService;
            this.bankRepository = bankRepository;
        }

        [HttpPost]
        [Route("api/BankAccountService/CreateBankAccount")]
        public IHttpActionResult CreateBankAccount(BankAccountRequest bankAccountRequest)
        {
            IBankAccount bankAccount = bankAccountService.CreateBankAccount(bankAccountRequest);
            bankRepository.CreateBankAccount(bankAccount);
            return Ok();
        }

        [HttpGet]
        [Route("api/BankAccountService/GetBankAccountList")]
        public IHttpActionResult GetBankAccountList()
        {
            return Ok(bankRepository.GetAllBankAccounts());
        }

        [HttpPost]
        [Route("api/BankAccountService/Withdraw")]
        public IHttpActionResult Withdraw(TransactionRequest transactionRequest)
        {
            IBankAccount bankAccount = bankRepository.GetBankAccount(transactionRequest.accountId);
            bankAccountService.Withdraw(transactionRequest.amount, bankAccount);
            bankRepository.UpdateBankAccount(bankAccount);
            return Ok();
        }

        [HttpPost]
        [Route("api/BankAccountService/Deposit")]
        public IHttpActionResult Deposit(TransactionRequest transactionRequest)
        {
            IBankAccount bankAccount = bankRepository.GetBankAccount(transactionRequest.accountId);
            bankAccountService.Deposit(transactionRequest.amount, bankAccount);
            bankRepository.UpdateBankAccount(bankAccount);
            return Ok();
        }

        [HttpGet]
        [Route("api/BankAccountService/GetCustomerBankAccounts")]
        public IHttpActionResult GetCustomerBankAccounts(int customerId)
        {
            return Ok();//return customerbankaccounts)
        }

    }
}
