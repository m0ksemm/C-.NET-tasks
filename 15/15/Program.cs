using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int DepId { get; set; }
}
class Department
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}

class Program
{
    static void Main()
    {
        try
        {
            List<Department> departments = new List<Department>()
        {
            new Department(){ Id = 1, Country = "Ukraine", City = "Lviv" },
            new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
            new Department(){ Id = 3, Country = "France", City = "Paris" },
            new Department(){ Id = 4, Country = "Ukraine", City = "Odesa" }
        };
            List<Employee> employees = new List<Employee>()
        {
            new Employee() { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
            new Employee() { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
            new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
            new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
            new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
            new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
            new Employee() { Id = 7, FirstName = "Nikita", LastName = "Krotov ", Age = 27, DepId = 4 }
        };
            ////////////////////////////////////////////////////////////////////////////////////////////////
            var workers = from e in employees
                          join d in departments on e.DepId equals d.Id
                          select new
                          {
                              e.Id,
                              e.FirstName,
                              e.LastName,
                              e.Age,
                              d.Country,
                              d.City
                          };

            Console.WriteLine(" Id |First name|Last name |Age | Country | City");
            Console.WriteLine(" ------------------------------------------------");
            foreach (var w in workers)
                Console.WriteLine(" {0, 2} |   {1, 6} |" +
                    " {2, 8} | {3, 2} | {4, 7} |" +
                    " {5, 6}", w.Id, w.FirstName, w.LastName, w.Age, w.Country, w.City);

            Console.WriteLine();

            var workers2 = employees.Join(departments, e => e.DepId, d => d.Id, (e, d) => new
            {
                e.Id,
                e.FirstName,
                e.LastName,
                e.Age,
                d.Country,
                d.City
            });
            Console.WriteLine(" Id |First name|Last name |Age | Country | City");
            Console.WriteLine(" ------------------------------------------------");
            foreach (var w in workers2)
                Console.WriteLine(" {0, 2} |   {1, 6} |" +
                    " {2, 8} | {3, 2} | {4, 7} |" +
                    " {5, 6}", w.Id, w.FirstName, w.LastName, w.Age, w.Country, w.City);

            //////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\n-------------------------Task1-------------------------\n");

            var workers3 = from w in workers
                           where w.Country == "Ukraine"
                           where w.City != "Odesa"
                           select new
                           {
                               w.FirstName,
                               w.LastName
                           };
            foreach (var w in workers3)
                Console.WriteLine(w.FirstName + " " + w.LastName);

            Console.WriteLine();
            var p = workers.Where(w => w.Country == "Ukraine" && w.City != "Odesa")
                .Select(g => new
                {
                    g.FirstName,
                    g.LastName
                });
            foreach (var w in p)
                Console.WriteLine(w.FirstName + " " + w.LastName);

            //////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\n-------------------------Task2-------------------------\n");

            var f = from co in workers
                    select co.Country;
            var f2 = f.Distinct();

            foreach (var co in f2)
                Console.WriteLine(co);

            Console.WriteLine();

            var f3 = workers.Select(w => w.Country).Distinct();
            foreach (var co in f3)
                Console.WriteLine(co);

            //////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\n-------------------------Task3-------------------------\n");
            int i = 0;
            var first3 = from e in workers
                         where e.Age > 25 && i++ < 3
                         select e;

            Console.WriteLine(" Id |First name|Last name |Age | Country | City");
            Console.WriteLine(" ------------------------------------------------");
            foreach (var w in first3)
                Console.WriteLine(" {0, 2} |   {1, 6} |" +
                    " {2, 8} | {3, 2} | {4, 7} |" +
                    " {5, 6}", w.Id, w.FirstName, w.LastName, w.Age, w.Country, w.City);

            Console.WriteLine();
            i = 0;
            var first3_2 = workers.Where(w => w.Age > 25 && i++ < 3).Select(g => g);
            Console.WriteLine(" Id |First name|Last name |Age | Country | City");
            Console.WriteLine(" ------------------------------------------------");
            foreach (var w in first3_2)
                Console.WriteLine(" {0, 2} |   {1, 6} |" +
                    " {2, 8} | {3, 2} | {4, 7} |" +
                    " {5, 6}", w.Id, w.FirstName, w.LastName, w.Age, w.Country, w.City);

            //////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\n-------------------------Task4-------------------------\n");

            var v = from e in workers
                    where e.Age > 23 && e.City == "Kyiv"
                    select new
                    {
                        e.FirstName,
                        e.LastName,
                        e.Age
                    };
            if (v.Count() == 0)
                Console.WriteLine("There are no such workers!");
            else foreach (var w in v)
                    Console.WriteLine(w.FirstName + w.LastName + w.Age);

            Console.WriteLine();

            var q = workers.Where(w => w.Age > 23 && w.City == "Kyiv")
                .Select(g => new
                {
                    g.FirstName,
                    g.LastName,
                    g.Age
                });
            if (v.Count() == 0)
                Console.WriteLine("There are no such workers!");
            else foreach (var w in v)
                    Console.WriteLine(w.FirstName + w.LastName + w.Age);
        }
        catch (Exception ex)    
        {
            Console.WriteLine(ex.Message); 
        }
        Console.ReadLine();
    }
}

