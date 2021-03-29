using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_lesson_2_Practice.Interfaces
{
    public interface IBook
    {
        int Id { get; }
        string IsbnCode { get; }
        string Title { get; }
        string Author { get;}
        string Description { get;}
    }
}
