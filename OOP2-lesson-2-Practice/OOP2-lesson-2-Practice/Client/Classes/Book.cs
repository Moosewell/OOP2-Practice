using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Client.Interfaces;

namespace Client.Classes
{
    public class Book : IBook
    {
        private int id { get; set; }
        public int Id => id;
        private string isbnCode { get; set; }
        public string IsbnCode => isbnCode;
        private string title { get; set; }
        public string Title => title;
        private string author { get; set; }
        public string Author => author;
        private string description { get; set; }
        public string Description => description;

        public Book(int id, string isbnCode, string title, string author, string description)
        {
            this.id = id;
            this.isbnCode = isbnCode;
            this.title = title;
            this.author = author;
            this.description = description;
        }

        //public Book(BookRequest bookRequest)
        //{
        //    this.id = bookRequest.Id;
        //    this.isbnCode = bookRequest.IsbnCode;
        //    this.title = bookRequest.Title;
        //    this.author = bookRequest.Author;
        //    this.description = bookRequest.Description;
        //}
    }
}