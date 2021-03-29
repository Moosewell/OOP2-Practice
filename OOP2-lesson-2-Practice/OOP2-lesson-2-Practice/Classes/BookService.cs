using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OOP2_lesson_2_Practice.Interfaces;
using OOP2_lesson_2_Practice.Functions;
using System.Text.RegularExpressions;

namespace OOP2_lesson_2_Practice.Classes
{
    public class BookService : IBookService
    {
        public List<IBook> GetBookList()
        {
            return bookDatabase;
        }

        public List<IBook> SearchForBooks(string searchtext)
        {
            if (searchtext == null)
                return bookDatabase;

            List<IBook> searchList = new List<IBook>();

            if (Function.IsNumeric(searchtext))
            {
                var booksById = bookDatabase.Where(o => o.Id == int.Parse(searchtext)).ToList();
                searchList = searchList.Concat(booksById).ToList();
            }

            List<List<IBook>> Lists = new List<List<IBook>>()
            {
                new List<IBook>(),
                new List<IBook>(),
                new List<IBook>(),
                new List<IBook>(),
            };
            //Lists[0] = bookDatabase.Where(o => o.IsbnCode.Contains(searchtext)).ToList();
            //Lists[1] = bookDatabase.Where(o => o.Title.Contains(searchtext)).ToList();
            //Lists[2] = bookDatabase.Where(o => o.Author.Contains(searchtext)).ToList();
            //Lists[3] = bookDatabase.Where(o => o.Description.Contains(searchtext)).ToList();
            Lists[0] = bookDatabase.Where(o => Regex.IsMatch(o.IsbnCode, searchtext, RegexOptions.IgnoreCase)).ToList();
            Lists[1] = bookDatabase.Where(o => Regex.IsMatch(o.Title, searchtext, RegexOptions.IgnoreCase)).ToList();
            Lists[2] = bookDatabase.Where(o => Regex.IsMatch(o.Author, searchtext, RegexOptions.IgnoreCase)).ToList();
            Lists[3] = bookDatabase.Where(o => Regex.IsMatch(o.Description, searchtext, RegexOptions.IgnoreCase)).ToList();

            List<IBook> books2remove = new List<IBook>();

            foreach (var list in Lists)
            {
                foreach(var book in list)
                {
                    bool exists = false;
                    foreach(var searchBook in searchList)
                    {
                        if (searchBook.Id == book.Id)
                            exists = true;
                    }
                    if (exists)
                        books2remove.Add(book);
                }
                foreach(var book in books2remove)
                {
                    list.Remove(book);
                }
                searchList = searchList.Concat(list).ToList();
            }

            return searchList; 
        }
        public void AddBook(IBook book)
        {
            bookDatabase.Add(book);
        }

        public void AddBooks(List<IBook> books)
        {
            bookDatabase.Concat(books);
        }

        public void RemoveBook(int id)
        {
            bookDatabase = bookDatabase.Where(o => o.Id != id).ToList();
        }

        public void UpdateBook(int id, IBook book)
        {
            bookDatabase = bookDatabase.Where(o => o.Id != id).ToList();
            bookDatabase.Add(book);
        }

        List<IBook> bookDatabase = new List<IBook>() {
            new Book(7, "0-2823-3915-9", "Faceless Grace", "Ashlyn Flaviana", "The unexciting life of a girl is going in a different direction as a childhood friend enters her life."),
            new Book(1, "0-3525-8457-2", "The Summer Beast", "Paul Heraclio", "The relaxed life of a young girl changes for better or worse as a strange boy enters her life."),
            new Book(4, "0-3986-0258-1", "Nebula Weeping", "Krsto Roshni", "The smooth life of a elderly man will be permanently altered as a friendly acquaintance enters his life."),
            new Book(3, "0-9747-6167-2", "Iris Beauty", "Rufina Anastasia", "The calm life of a teenage boy will be permanently altered as a friendly acquaintance enters his life."),
            new Book(8, "0-1185-3528-5", "Inferno Hearts", "Hallþóra Padrig", "The laid-back life of a elderly woman might turn out differently as a strange girl enters her life."),
            new Book(2, "0-7510-7398-9", "Attack of Arcadia", "Bohdana Ioana", "The nonchalant life of a man will be permanently altered as a neighbor enters his life."),
            new Book(6, "0-2994-8535-8", "Built for Sin", "Cenric Jonathan", "The fast-paced life of a elderly woman changes for better or worse as a strange woman enters her life."),
            new Book(5, "0-9971-2675-2", "The Dancing Guitar", "Antonin Preeti", "The quiet life of a boy will be permanently altered as a strange man enters his life.")
            };
    }
}