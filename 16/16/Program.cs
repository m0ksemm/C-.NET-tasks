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
        
        List<Department> departments = new List<Department>()
        { 
            new Department(){ Id = 1, Country = "Ukraine", City = "Odesa"},
            new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
            new Department(){ Id = 3, Country = "France", City = "Paris" },
            new Department(){ Id = 4, Country = "Ukraine", City = "Lviv"}
        };
        List<Employee> employees = new List<Employee>()
        {
            new Employee() { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
            new Employee() { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
            new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
            new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
            new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
            new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
            new Employee() { Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4 }
        };

        try
        {
            var workers = from e in employees
                          from d in departments
                          where e.DepId == d.Id
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

            var workers1 = employees.Join(departments, e => e.DepId, d => d.Id, (e, d) => new
            {
                e.Id,
                e.FirstName,
                e.LastName,
                e.Age,
                d.Country,
                d.City
            }).ToList();
            foreach (var w in workers1)
                Console.WriteLine(" {0, 2} |   {1, 6} |" +
                    " {2, 8} | {3, 2} | {4, 7} |" +
                    " {5, 6}", w.Id, w.FirstName, w.LastName, w.Age, w.Country, w.City);

//////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\n--------------------------Task1--------------------------");

            Console.WriteLine("Ordered by name:");
            var workers3 = (from e in workers
                            where e.Country == "Ukraine"
                            orderby e.FirstName
                            select e).ToList();
            Console.WriteLine(" Id |First name|Last name |Age | Country | City");
            Console.WriteLine(" ------------------------------------------------");
            foreach (var w in workers3)
                Console.WriteLine(" {0, 2} |   {1, 6} |" +
                    " {2, 8} | {3, 2} | {4, 7} |" +
                    " {5, 6}", w.Id, w.FirstName, w.LastName, w.Age, w.Country, w.City);

            Console.WriteLine("\nOrdered by surname:");
            Console.WriteLine(" Id |First name|Last name |Age | Country | City");
            Console.WriteLine(" ------------------------------------------------");
            var workers4 = workers.Where(e => e.Country == "Ukraine")
                .OrderBy(e => e.LastName).ToList();
            foreach (var w in workers4)
                Console.WriteLine(" {0, 2} |   {1, 6} |" +
                    " {2, 8} | {3, 2} | {4, 7} |" +
                    " {5, 6}", w.Id, w.FirstName, w.LastName, w.Age, w.Country, w.City);

//////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\n--------------------------Task2--------------------------");

            var workers5 = (from w in workers
                            orderby w.Age descending
                            select new
                            {
                                w.Id,
                                w.FirstName,
                                w.LastName,
                                w.Age,
                            }).ToList();

            Console.WriteLine(" Id |First name|Last name |Age |");
            Console.WriteLine(" -------------------------------");
            foreach (var w in workers5)
                Console.WriteLine(" {0, 2} |   {1, 6} |" +
                    " {2, 8} | {3, 2} | ", w.Id, w.FirstName, w.LastName, w.Age);

            Console.WriteLine();

            var workers6 = workers.OrderByDescending(w => w.Age)
            .Select(e => new
            {
                e.Id,
                e.FirstName,
                e.LastName,
                e.Age,
            }).ToList();

            Console.WriteLine(" Id |First name|Last name |Age |");
            Console.WriteLine(" -------------------------------");
            foreach (var w in workers6)
                Console.WriteLine(" {0, 2} |   {1, 6} |" +
                    " {2, 8} | {3, 2} | ", w.Id, w.FirstName, w.LastName, w.Age);

//////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\n--------------------------Task3--------------------------");

            var workers7 = (from w in workers
                            group w by w.Age into g
                            select new
                            {
                                Age = g.Key,
                                Count = g.Count(),
                                Person = from p in g select new { p.Id, p.FirstName, p.LastName }
                            }).ToList();

            foreach (var w in workers7)
            {
                Console.WriteLine(" Age = {0} | Count = {1}", w.Age, w.Count);
                Console.WriteLine(" --------------------");
                Console.WriteLine(" Id |First name|Last name |");
                Console.WriteLine(" --------------------------");
                foreach (var g in w.Person)
                    Console.WriteLine(" {0, 2} |   {1, 6} |" +
                    " {2, 8} | ", g.Id, g.FirstName, g.LastName);
                Console.WriteLine("");
            }

            Console.WriteLine("--------------------------------------\n--------------------------------------");
            var workers8 = workers.GroupBy(w => w.Age)
                .Select(e => new
                {
                    Age = e.Key,
                    Count = e.Count(),
                    Person = e.Select(e => new { e.Id, e.FirstName, e.LastName })
                }).ToList();

            foreach (var w in workers8)
            {
                Console.WriteLine(" Age = {0} | Count = {1}", w.Age, w.Count);
                Console.WriteLine(" --------------------");
                Console.WriteLine(" Id |First name|Last name |");
                Console.WriteLine(" --------------------------");
                foreach (var g in w.Person)
                    Console.WriteLine(" {0, 2} |   {1, 6} |" +
                    " {2, 8} | ", g.Id, g.FirstName, g.LastName);
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        { 
            Console.WriteLine(ex.Message); 
        }
        Console.ReadLine();
    }
}