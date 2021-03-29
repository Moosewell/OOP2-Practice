using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_lesson_2_Practice.Interfaces
{
    public interface IBookRequest
    {
        int Id { get; set; }
        string IsbnCode { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        string Description { get; set; }
    }
}
