using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OOP2_lesson_2_Practice.Classes;
using OOP2_lesson_2_Practice.Interfaces;

namespace OOP2_lesson_2_Practice.Controllers
{
    public class BookController : Controller
    {
        public readonly IBookService bookService;

        [HttpGet]
        public ActionResult GetBooks()
        {
            return new JsonResult { Data = bookService.GetBookList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public ActionResult SearchForBooks(string searchtext)
        {
            return new JsonResult { Data = bookService.SearchForBooks(searchtext), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult AddBook(BookRequest bookRequest)
        {
            Book book = new Book(bookRequest);
            bookService.AddBook(book);
            return new HttpStatusCodeResult(200);
        }

        [HttpPost]
        public ActionResult AddBooks(List<Book> books)
        {



            //bookService.AddBooks(books);
            return new JsonResult { Data = bookService.GetBookList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return new HttpStatusCodeResult(200);
        }
        [HttpGet]
        public ActionResult RemoveBook()
        {

            return null;
        }
        [HttpGet]
        public ActionResult UpdateBook()
        {

            return null;
        }

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

    }

}