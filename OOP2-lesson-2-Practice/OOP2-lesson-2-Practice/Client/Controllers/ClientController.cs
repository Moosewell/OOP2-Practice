using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Client.Classes;

namespace Client.Controllers
{
    public class ClientController : Controller
    {

        private readonly string urlGetBooks = "https://localhost:44315/book/GetBooks";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetBooks()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(urlGetBooks).Result;
                if(response != null)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var books = JsonConvert.DeserializeObject<List<Book>>(jsonString);
                    ViewBag.Message = "Lista av böcker hämtad \n";
                    string listAsText = "";
                    foreach(Book book in books)
                    {
                        string bookAsText = JsonConvert.SerializeObject(book, Formatting.Indented);
                        listAsText += bookAsText + "\n";
                    }
                    ViewBag.Content = listAsText;
                }
            }
            return View("About");
        }
    }
}