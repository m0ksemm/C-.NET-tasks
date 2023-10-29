using System;
using System.Collections.Generic;
using System.Linq;
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

class LazyLoad14 
{
    public static void Main() 
    {
        try
        {
            List<Person> person = new List<Person>()
        {
            new Person(){ Name = "Andrey", Age = 24, City = "Kyiv"},
            new Person(){ Name = "Liza", Age = 18, City = "Odesa" },
            new Person(){ Name = "Oleg", Age = 15, City = "London" },
            new Person(){ Name = "Sergey", Age = 55, City = "Kyiv" },
            new Person(){ Name = "Sergey", Age = 32, City = "Lviv" }
        };
            ////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("---------------Task1----------------");
            var p1 = from p in person
                     where p.Age > 25
                     select new
                     {
                         Name = p.Name,
                         Age = p.Age,
                         City = p.City
                     };
            foreach (var p in p1)
                Console.WriteLine(p.Name + ", " + p.Age + " y.o., from " + p.City);

            Console.WriteLine();
            var p2 = person.Where(p => p.Age > 25)
                .Select(g => new { Name = g.Name, Age = g.Age, City = g.City });

            foreach (var p in p2)
                Console.WriteLine(p.Name + ", " + p.Age + " y.o., from " + p.City);

            ////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("---------------Task2----------------");
            p1 = from p in person
                 where p.City != "London"
                 select new
                 {
                     Name = p.Name,
                     Age = p.Age,
                     City = p.City
                 };
            foreach (var p in p1)
                Console.WriteLine(p.Name + ", " + p.Age + " y.o., from " + p.City);

            Console.WriteLine();
            p2 = person.Where(p => p.City != "London")
                .Select(g => new { Name = g.Name, Age = g.Age, City = g.City });
            foreach (var p in p2)
                Console.WriteLine(p.Name + ", " + p.Age + " y.o., from " + p.City);

            ////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("---------------Task3----------------");
            var p3 = from p in person
                     where p.City == "Kyiv"
                     select p.Name;

            foreach (var p in p3)
                Console.WriteLine(p);

            Console.WriteLine();
            p3 = person.Where(p => p.City == "Kyiv").Select(g => g.Name);
            foreach (var p in p3)
                Console.WriteLine(p);

            ////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("---------------Task4----------------");
            p1 = from p in person
                 where p.Age > 35 && p.Name == "Sergey"
                 select new
                 {
                     Name = p.Name,
                     Age = p.Age,
                     City = p.City
                 };
            foreach (var p in p1)
                Console.WriteLine(p.Name + ", " + p.Age + " y.o., from " + p.City);

            Console.WriteLine();
            p2 = person.Where(person => person.Age > 35 && person.Name == "Sergey")
                .Select(g => new { Name = g.Name, Age = g.Age, City = g.City });
            foreach (var p in p2)
                Console.WriteLine(p.Name + ", " + p.Age + " y.o., from " + p.City);

            ////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("---------------Task5----------------");
            p1 = from p in person
                 where p.City == "Odesa"
                 select new
                 {
                     Name = p.Name,
                     Age = p.Age,
                     City = p.City
                 };
            foreach (var p in p1)
                Console.WriteLine(p.Name + ", " + p.Age + " y.o., from " + p.City);

            Console.WriteLine();

            p2 = person.Where(p => p.City == "Odesa")
                .Select(g => new { Name = g.Name, Age = g.Age, City = g.City });
            foreach (var p in p2)
                Console.WriteLine(p.Name + ", " + p.Age + " y.o., from " + p.City);
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadLine();
    }
}
