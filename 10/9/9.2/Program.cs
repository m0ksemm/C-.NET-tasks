using System;
using System.Collections;
using System.Text;

class Person
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public int Phone { get; set; }
    public Person()
    {
        Name = "Maksym";
        Surname = "Cheban";
        Age = 19;
        Phone = 995260721;
    }
    public void Print()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Name:     |{0}", Name);
        Console.WriteLine("Surname:  |{0}", Surname);
        Console.WriteLine("Age:      |{0}", Age);
        Console.WriteLine("Phone:    |{0}", Phone);
    }
}

class Student : Person, IComparable
{
    public double Average { get; set; }
    public int Number_Of_Group { get; set; }
    public Student()
    {
        Average = 10.0;
        Number_Of_Group = 1;
    }
    public Student(string name, string surname, int age, int phone, double agerage, int group)
    {
        Name = name;
        Surname = surname;
        Age = age;
        Phone = phone;
        Average = agerage;
        Number_Of_Group = group;
    }
    new public void Print()
    {
        base.Print();
        Console.WriteLine("Average:  |{0}", Average);
        Console.WriteLine("Group:    |{0}", Number_Of_Group);
        Console.WriteLine("------------------------\n");
    }
    public int CompareTo(object obj)
    {
        if (obj is Student)
            return this.Name.CompareTo((obj as Student).Name);

        throw new NotImplementedException();
    }
    public class SortBySurname : IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            if (obj1 is Student && obj2 is Student)
                return (obj1 as Student).Surname.CompareTo((obj2 as Student).Surname);

            throw new NotImplementedException();
        }
    }
    public class SortByAge : IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            if (obj1 is Student && obj2 is Student)
                return (obj1 as Student).Age.CompareTo((obj2 as Student).Age);

            throw new NotImplementedException();
        }
    }
    public class SortByAverage : IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            if (obj1 is Student && obj2 is Student)
                return (obj1 as Student).Average.CompareTo((obj2 as Student).Average);

            throw new NotImplementedException();
        }
    }
    public class SortByGroup : IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            if (obj1 is Student && obj2 is Student)
                return (obj1 as Student).Number_Of_Group.CompareTo((obj2 as Student).Number_Of_Group);

            throw new NotImplementedException();
        }
    }
}

class Academy_Group : IEnumerable
{
    protected ArrayList group;
    private int curpos = -1;
    public Academy_Group()
    {
        group = new ArrayList();
    }
    public int GetQuantityOfStudents()
    {
        return group.Count;
    }
    public void Add()
    {
        Console.WriteLine("Enter new name: ");
        string nm = Console.ReadLine();
        Console.WriteLine("Enter new surname: ");
        string sn = Console.ReadLine();
        Console.WriteLine("Enter the age: ");
        int ag = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the phone: ");
        int ph = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the average: ");
        double av = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the group: ");
        int gr = Convert.ToInt32(Console.ReadLine());

        Student st = new Student(nm, sn, ag, ph, av, gr);
        group.Add(st);

        Console.WriteLine("New student is added! ");
        Console.ReadKey();
    }

    public void Remove()
    {
        int n = 0, remove = 0;
        Console.WriteLine("Enter the surname of the student:");
        string s = Console.ReadLine();
        bool flag = false;
        foreach (Student obj in group)
        {
            if (obj.Surname == s)
            {
                remove = n;
                flag = true;
            }
            n++;
        }
        if (flag == false)
            Console.WriteLine("\nThere is no such a student in this group");
        else
        {
            group.Remove(group[remove]);
            Console.WriteLine("\nThe student is removed!");
        }
        Console.ReadKey();
    }
    public void Edit()
    {
        Console.WriteLine("Enter the surname of the student:");
        string s = Console.ReadLine();
        bool flag = false;
        foreach (Student obj in group)
        {
            if (obj.Surname == s)
            {
                flag = true;
                Console.WriteLine("New data: ");
                Console.Write("Name: ");
                obj.Name = Console.ReadLine();

                Console.Write("Surname: ");
                obj.Surname = Console.ReadLine();

                Console.Write("Age: ");
                obj.Age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Phone: ");
                obj.Phone = Convert.ToInt32(Console.ReadLine());

                Console.Write("Average: ");
                obj.Average = Convert.ToDouble(Console.ReadLine());

                Console.Write("Group: ");
                obj.Number_Of_Group = Convert.ToInt32(Console.ReadLine());
            }
        }

        if (flag == false)
            Console.WriteLine("\nThere is no such a student in this group");
        else Console.WriteLine("\nThe student's data is edited!");
        Console.ReadKey();
    }
    public void Search()
    {

        bool flag = false;
        Console.WriteLine("1 - name \n2 - surname \n3 - age \n4 - phone \n5 - average \n6 - group");
        ConsoleKeyInfo criteria = Console.ReadKey(true);
        if (criteria.Key == ConsoleKey.D1)
        {
            Console.Write("Enter the name:   ");
            string n = Console.ReadLine();
            foreach (Student obj in group)
            {
                if (obj.Name == n)
                {
                    obj.Print();
                    flag = true;
                }
            }
        }
        else if (criteria.Key == ConsoleKey.D2)
        {
            Console.Write("Enter the surname:   ");
            string s = Console.ReadLine();
            foreach (Student obj in group)
            {
                if (obj.Surname == s)
                {
                    obj.Print();
                    flag = true;
                }
            }
        }
        else if (criteria.Key == ConsoleKey.D3)
        {
            Console.Write("Enter the age:   ");
            int a = Convert.ToInt32(Console.ReadLine());
            foreach (Student obj in group)
            {
                if (obj.Age == a)
                {
                    obj.Print();
                    flag = true;
                }
            }
        }
        else if (criteria.Key == ConsoleKey.D4)
        {
            Console.Write("Enter the phone:   ");
            int p = Convert.ToInt32(Console.ReadLine());
            foreach (Student obj in group)
            {
                if (obj.Phone == p)
                {
                    obj.Print();
                    flag = true;
                }
            }
        }
        else if (criteria.Key == ConsoleKey.D5)
        {
            Console.Write("Enter the average:   ");
            double d = Convert.ToDouble(Console.ReadLine());
            foreach (Student obj in group)
            {
                if (obj.Average == d)
                {
                    obj.Print();
                    flag = true;
                }
            }
        }
        else if (criteria.Key == ConsoleKey.D6)
        {
            Console.Write("Enter the group:   ");
            int g = Convert.ToInt32(Console.ReadLine());
            foreach (Student obj in group)
            {
                if (obj.Number_Of_Group == g)
                {
                    obj.Print();
                    flag = true;
                }
            }
        }
        if (flag == false)
        {
            Console.WriteLine("There is no such a student in this group");
            Console.ReadKey();
        }
        else Console.ReadKey();
    }
    public void Print()
    {
        int i = 0;
        foreach (Student obj in group)
        {
            Console.WriteLine("Student № {0}:", ++i);
            obj.Print();
        }
        Console.ReadKey();
    }
    public void Save()
    {
        StreamWriter sw = new StreamWriter("Group.log", false, Encoding.Default);
        sw.WriteLine(Convert.ToString(group.Count));
        foreach (Student obj in group)
        {
            sw.WriteLine(obj.Name);
            sw.WriteLine(obj.Surname);
            string str = Convert.ToString(obj.Age);
            sw.WriteLine(str);
            str = Convert.ToString(obj.Phone);
            sw.WriteLine(str);
            str = Convert.ToString(obj.Average);
            sw.WriteLine(str);
            str = Convert.ToString(obj.Number_Of_Group);
            sw.WriteLine(str);
        }
        sw.Close();
    }
    public void Load()
    {
        StreamReader sr = new StreamReader("Group.log", Encoding.Default);
        int n = Convert.ToInt32(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Student obj = new Student();
            obj.Name = (sr.ReadLine());
            obj.Surname = (sr.ReadLine());
            obj.Age = Convert.ToInt32(sr.ReadLine());
            obj.Phone = Convert.ToInt32(sr.ReadLine());
            obj.Average = Convert.ToDouble(sr.ReadLine());
            obj.Number_Of_Group = Convert.ToInt32(sr.ReadLine());
            group.Add(obj);
        }
        sr.Close();
    }
    public IEnumerator GetEnumerator()
    {
        //Console.WriteLine("\nВыполняется метод GetEnumerator");
        // возвращается ссылка на объект класса, реализующего перечислитель
        Console.WriteLine("\nВыполняется метод GetEnumerator");
        for (int i = 0; i < group.Count; i++)
            yield return group[i];
    }

    // реализация перечислителя NO NEED
    
    public void Sort()
    {
        Student[] st = new Student[group.Count];
        int i = 0;
        foreach (Student obj in group)
        {
            st[i] = obj;
            i++;
        }
        Console.WriteLine("Choose the criteria of sorting: ");
        Console.WriteLine("1 - name");
        Console.WriteLine("2 - surname");
        Console.WriteLine("3 - age");
        Console.WriteLine("4 - average");
        Console.WriteLine("5 - group");

        ConsoleKeyInfo criteria = Console.ReadKey(true);

        if (criteria.Key == ConsoleKey.D1)
            Array.Sort(st);
        else if (criteria.Key == ConsoleKey.D2)
            Array.Sort(st, new Student.SortBySurname());
        else if (criteria.Key == ConsoleKey.D3)
            Array.Sort(st, new Student.SortByAge());
        else if (criteria.Key == ConsoleKey.D4)
            Array.Sort(st, new Student.SortByAverage());
        else if (criteria.Key == ConsoleKey.D5)
            Array.Sort(st, new Student.SortByGroup());

        group.Clear();

        for (i = 0; i < st.Length; i++)
        {
            group.Add(st[i]);
        }

        Console.WriteLine("Sorted!");
        Console.ReadKey();
    }
}

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
            "7 - sort students\n" +
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
                    int i = 0;
                    foreach (Student obj in group)/////// вывод будет происходить с использованием
                    {                                  // интерфейсa IEnumerable
                        Console.WriteLine("Student № {0}:", ++i);
                        obj.Print();
                    }
                    Console.ReadKey();

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
                    group.Add();
                }
                else if (criteria.Key == ConsoleKey.D4)
                {
                    Console.Clear();
                    group.Remove();
                }
                else if (criteria.Key == ConsoleKey.D5)
                {
                    Console.Clear();
                    group.Edit();
                }
                else if (criteria.Key == ConsoleKey.D6)
                {
                    Console.Clear();
                    group.Search();
                }
                else if (criteria.Key == ConsoleKey.D7)
                {
                    Console.Clear();
                    group.Sort();
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