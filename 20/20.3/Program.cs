using System.Text.RegularExpressions;

namespace Program
{
    class MyClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the date:\n");
            string input = Console.ReadLine();
            string pattern = @"^((0[1-9]|[12][0-9])|(3[01])|[1-9])(:|\.)([1][012]|[0][1-9]|[0-9])((:|\.)\d{1,})?$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(input))
                Console.WriteLine("Email is correct");
            else Console.WriteLine("Email is INcorrect!");
        }
    }
}