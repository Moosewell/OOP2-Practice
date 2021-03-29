using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_lesson_2_Practice.Interfaces
{
    public interface IBookService
    {
        List<IBook> GetBookList();
        List<IBook> SearchForBooks(string searchtext);
        void AddBook(IBook book);
        void AddBooks(List<IBook> books);
        void RemoveBook(int id);
        void UpdateBook(int id, IBook book);
    }
}
