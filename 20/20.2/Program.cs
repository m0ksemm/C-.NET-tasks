using System.Text.RegularExpressions;

namespace Program
{
    class MyClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter your email :\n");
            string input = Console.ReadLine();
            string pattern = @"\w{3,16}@\w+((\.\w+)+)?\.\w{2,3}$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(input))
                Console.WriteLine("Email is correct");
            else Console.WriteLine("Email is INcorrect!");
        }
    }
}