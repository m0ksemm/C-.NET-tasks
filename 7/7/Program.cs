using System;
using AcademyGroupLibrary;

class MainClass 
{
    static public void Menu()
    {
        Console.WriteLine("1 - print the group\n" +
            "2 - get the quantity of students\n" +
            "3 - add a new student\n" +
            "4 - remove a student\n" +
            "5 - edit a student's data\n" +
            "6 - find a student\n" +
            "\t\t\tPress escape to finish");
    }
    static void Main() 
    {
        try
        {
            ConsoleKeyInfo criteria;
            Academy_Group group = new Academy_Group();
            group.Load();
            while (true)
            {
                Console.Clear();
                Menu();
                criteria = Console.ReadKey(true);

                if (criteria.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    group.Print();
                }
                else if (criteria.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("There are {0} students in this group", group.GetQuantityOfStudents());
                    Console.ReadKey(true);
                }
                else if (criteria.Key == ConsoleKey.D3)
                {
                    Console.Clear();
                    group.AddStudent();
                }
                else if (criteria.Key == ConsoleKey.D4)
                {
                    Console.Clear();
                    group.RemoveStudent();
                }
                else if (criteria.Key == ConsoleKey.D5)
                {
                    Console.Clear();
                    group.EditStudent();
                }
                else if (criteria.Key == ConsoleKey.D6)
                {
                    Console.Clear();
                    group.SearchStudent();
                }
                else if (criteria.Key == ConsoleKey.Escape)
                {
                    group.Save();
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine("\n\nPress any key");
        Console.ReadKey();

    }
}