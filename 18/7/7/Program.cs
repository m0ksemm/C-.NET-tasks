using System;
using AcademyGroupLibrary;

class MainClass 
{
    static public void Menu()
    {
        Console.WriteLine("1 - print the group\n" +
            "2 - GET the QUANTITY of students\n" +
            "3 - ADD a new student\n" +
            "4 - REMOVE a student\n" +
            "5 - EDIT a student's data\n" +
            "6 - FIND a student\n" +
            "7 - SAVE data of the group\n" +
            "8 - LOAD data of the group\n" +
            "9 - CLEAR the group\n" +
            "\t\t\t\t\tPress Escape to finish");
    }
    static void Main() 
    {
        try
        {
            ConsoleKeyInfo criteria;
            Academy_Group group = new Academy_Group();
            //group.Load();
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
                else if (criteria.Key == ConsoleKey.D7) 
                {
                    group.Save();
                }
                else if (criteria.Key == ConsoleKey.D8) 
                {
                    group.Load();
                }
                else if (criteria.Key == ConsoleKey.D9)
                {
                    group.ClearGroup();
                }
                else if (criteria.Key == ConsoleKey.Escape)
                {
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