using System;
using System.Text.RegularExpressions;

namespace Program 
{
    class MyClass 
    {
        public static void Main(string[] args) 
        {
            Console.WriteLine("Enter your surname and initials (Eng/rus language):\n");
                string input = Console.ReadLine();
            string pattern = @"[A-Z][a-z]+\s[A-Z]\.?[A-Z]\.?|[А-Я][а-я]+\s[А-Я]\.?[А-Я]\.?";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(input))
                Console.WriteLine("Data is correct");
            else Console.WriteLine("Data is INcorrect!");
        }
    }
}