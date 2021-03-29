using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OOP2_lesson_2_Practice.Interfaces;

namespace OOP2_lesson_2_Practice.Classes
{
    public class BookRequest : IBookRequest
    {
        public int Id { get; set; }

        public string IsbnCode { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }


    }
}