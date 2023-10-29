// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


class HomeWork
{
    static private string str;
    static void Task1()
    {
        System.Console.WriteLine("Task1\nEnter the number:");
        str = Console.ReadLine();
        int number = int.Parse(str);
        int number1 = number, count = 1, dec = 1;
        
        while (number1 / 10 != 0) 
        {
            count++;
            number1 /= 10;
            dec *= 10;
        }

        number1 = number;

        bool flag = true;
        for (int i = 0; i < count / 2; i++)
        {
            if (number % 10 != number / dec) 
            {
                flag = false;

                break;
            }
            number = number % dec;
            number /= 10;
            dec /= 100;
        }
        if (flag)
            System.Console.WriteLine("{0} is a Palindrome \n\n", number1);
        else
            System.Console.WriteLine("{0} is Not a Palindrome \n\n", number1);

    }
    static void Task2()
    {
        System.Console.WriteLine("Task2\nEnter the number:");
        str = Console.ReadLine();
        int number = int.Parse(str);
        System.Console.WriteLine("Enter the number of shifts:");
        str = Console.ReadLine();
        int count = int.Parse(str);
        System.Console.WriteLine("Enter the direction: (<- of ->)");
        str = Console.ReadLine();


        int number1 = number, dec = 1;

        while (number1 / 10 != 0)
        {
            number1 /= 10;
            dec *= 10;
        }

        number1 = number;

        int tmp;
        switch (str) 
        {
            case "<-":
                for (int i = 0; i < count; i++)
                {
                    tmp = number / dec;
                    number = (number % dec) * 10 + tmp;
                }
                System.Console.WriteLine("{0} after {1} shifts to the {2} =  {3}\n\n", number1, count, str, number);
                break;
            case "->":
                for (int i = 0; i < count; i++)
                {
                    tmp = number % 10;
                    number = tmp * dec + (number / 10) ;
                }
                System.Console.WriteLine("{0} after {1} shifts to the {2} =  {3}\n\n", number1, count, str, number);
                break;
            default:
                System.Console.WriteLine("You entered the wrong direction.\n\n");
                break;
        }

    }

    static void Task3()
    {
        int number, prev_number, count = 1,  longestcount = 0, longestindex = 0;

        System.Console.WriteLine("Task3\nEnter 15 numbers: ");

        str = Console.ReadLine();
        prev_number = int.Parse(str);
        

        for (int i = 1; i < 15; i++)
        {
            str = Console.ReadLine();
            number = int.Parse(str);
            
            if (number >= prev_number) 
            {
                count++;
            }
            else
            {
                if (longestcount < count)
                {
                    longestcount = count;
                    longestindex = i - count;
                }

                count = 1;
            }
            if (i == 14)
            {
                if (longestcount < count)
                {
                    longestcount = count;
                    longestindex = i - count + 1;
                }
            }

            prev_number = number;
        }

        if (count == 15)
            System.Console.WriteLine("The whole range of numbers is non-decreasing");
        else 
        System.Console.WriteLine($"longest non-decreasing range of numbers" +
                                 "\nconsists of {0} numbers and starts from {1} " +
                                 "\nindex.\n\n", longestcount, longestindex);

    }

    static void Main()
    {
        Task1();
        Task2();
        Task3();
    }
}


