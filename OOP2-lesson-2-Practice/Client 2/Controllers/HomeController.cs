using BankClient.Models;
using BankDTO.dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Client_2.Controllers
{
    public class HomeController : Controller
    {
        IEndPoints EndPoints = new AzureEndPoints();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }


        public ActionResult CreateBankAccount(BankAccountModel bankAccountModel)
        {
            using (HttpClient client = new HttpClient())
            {
                BankAccountRequest bankAccountRequest = bankAccountModel.GetDTO();
                var jsonBankAccountRequestString = JsonConvert.SerializeObject(bankAccountRequest);
                var stringContent = new StringContent(jsonBankAccountRequestString, UnicodeEncoding.UTF8, "application/json");
                var response = client.PostAsync(EndPoints.urlCreateBankAccount, stringContent).Result;

            }
            ViewBag.Message = "Your bank account has been made";
            return View("Results");
        }

        public ActionResult GetBankAccountList()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(EndPoints.urlGetBankAccountList).Result;
                if (response != null)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var bankAccounts = JsonConvert.DeserializeObject<List<BankAccountModel>>(jsonString);
                    ViewBag.Message = "List of customers recieved \n";
                    string listAsText = "";
                    foreach (BankAccountModel account in bankAccounts)
                    {
                        string accountAsText = JsonConvert.SerializeObject(account, Formatting.Indented);
                        listAsText += accountAsText + "\n";
                    }
                    ViewBag.Content = listAsText;
                }
            }
            return View("Results");
        }

        [HttpPost]
        public ActionResult Withdraw(TransactionModel requestModel)
        {
            using (HttpClient client = new HttpClient())
            {
                TransactionRequest transactionRequest = requestModel.GetDTO();
                var jsonTransactionRequestString = JsonConvert.SerializeObject(transactionRequest);
                var stringContent = new StringContent(jsonTransactionRequestString, UnicodeEncoding.UTF8, "application/json");
                var response = client.PostAsync(EndPoints.urlWithdraw, stringContent).Result;

            }
            ViewBag.Message = "Withdrawl has been made";
            return View("Results");
        }

        [HttpPost]
        public ActionResult Deposit(TransactionModel requestModel)
        {
            using (HttpClient client = new HttpClient())
            {
                TransactionRequest transactionRequest = requestModel.GetDTO();
                var jsonTransactionRequestString = JsonConvert.SerializeObject(transactionRequest);
                var stringContent = new StringContent(jsonTransactionRequestString, UnicodeEncoding.UTF8, "application/json");
                var response = client.PostAsync(EndPoints.urlDeposit, stringContent).Result;
                
            }
            ViewBag.Message = "Deposit has been made";
            return View("Results");
        }
        public ActionResult CreateCustomer(CustomerModel customerModel)
        {
            using (HttpClient client = new HttpClient())
            {
                
                CustomerRequest customerRequest = customerModel.GetDTO();
                var jsonCustomerRequestString = JsonConvert.SerializeObject(customerRequest);
                var stringContent = new StringContent(jsonCustomerRequestString, UnicodeEncoding.UTF8, "application/json");
                var response = client.PostAsync(EndPoints.urlCreateCustomer, stringContent).Result;

            }
            ViewBag.Message = "You have been registered as a customer";
            return View("Results");
        }
        public ActionResult GetCustomerList()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(EndPoints.urlGetCustomerList).Result;
                if (response != null)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var customers = JsonConvert.DeserializeObject<List<CustomerModel>>(jsonString);
                    ViewBag.Message = "List of customers recieved \n";
                    string listAsText = "";
                    foreach (CustomerModel customer in customers)
                    {
                        string customerAsText = JsonConvert.SerializeObject(customer, Formatting.Indented);
                        listAsText += customerAsText + "\n";
                    }
                    ViewBag.Content = listAsText;
                }
            }
            return View("Results");
        }
        public ActionResult GetCustomerBankAccounts(int customerId)
        {
            using (HttpClient client = new HttpClient())
            {
                string urlFullGetCustomerBankAccounts = EndPoints.urlGetCustomerBankAccounts + customerId.ToString();
                var response = client.GetAsync(urlFullGetCustomerBankAccounts).Result;
                if (response != null)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var bankAccounts = JsonConvert.DeserializeObject<List<BankAccountModel>>(jsonString);
                    ViewBag.Message = "Customers Bank Account recieved \n";
                    string listAsText = "";
                    foreach (BankAccountModel account in bankAccounts)
                    {
                        string accountAsText = JsonConvert.SerializeObject(account, Formatting.Indented);
                        listAsText += accountAsText + "\n";
                    }
                    ViewBag.Content = listAsText;
                }
            }
            return View("Results");
        }
    }
}