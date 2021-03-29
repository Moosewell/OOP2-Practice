using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOP2_lesson_2_Practice.Functions
{
    public static class Function
    {
        public static bool IsNumeric(string input)
        {
            try
            {
                int.Parse(input);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}