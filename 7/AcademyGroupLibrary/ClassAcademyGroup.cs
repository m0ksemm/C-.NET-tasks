using System.Collections;
using StudentLibrary;
using System.IO;
using System.Text;
using System.Threading;

namespace AcademyGroupLibrary
{
    public class Academy_Group
    {
        protected ArrayList group;
       
        public Academy_Group() 
        {
            group = new ArrayList();
        }
        public int GetQuantityOfStudents() 
        {
            return group.Count;
        }
        public void AddStudent()
        {
            Console.WriteLine("New student: ");
            Console.Write("Name:    ");
            string n = Console.ReadLine();

            Console.Write("Surname: ");
            string s = Console.ReadLine();

            Console.Write("Age:     ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Phone:   ");
            int p = Convert.ToInt32(Console.ReadLine());

            Console.Write("Double:  ");
            double d = Convert.ToDouble(Console.ReadLine());

            Console.Write("Group:   ");
            int g = Convert.ToInt32(Console.ReadLine());

            Student st = new Student(n, s, a, p, d, g);
            group.Add(st);

            Console.WriteLine("New student is added! ");
            Console.ReadKey();
        }
        public void RemoveStudent() 
        {
            int n = 0, remove = 0; //
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
        public void EditStudent()
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
                    obj.Number_of_group = Convert.ToInt32(Console.ReadLine());
                }
            }

            if (flag == false)
                Console.WriteLine("\nThere is no such a student in this group");
            else Console.WriteLine("\nThe student's data is edited!");
            Console.ReadKey();
        }
        public void SearchStudent()
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
                    if (obj.Number_of_group == g)
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
                str = Convert.ToString(obj.Number_of_group);
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
                obj.Number_of_group = Convert.ToInt32(sr.ReadLine());
                group.Add(obj);
            }
            sr.Close();
        }


    }
}