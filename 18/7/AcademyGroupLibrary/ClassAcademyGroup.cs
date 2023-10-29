using System.Collections;
using StudentLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using PersonLibrary;

namespace AcademyGroupLibrary
{
    [Serializable]
    [DataContract]
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
        public void ClearGroup() 
        {
            Console.WriteLine("  Are you sure that you want to clear the group? ");
            Console.WriteLine("  1. - Yes \n  2. - No");
            ConsoleKeyInfo yesno;
            while (true)
            {
                yesno = Console.ReadKey(true);
                if (yesno.Key == ConsoleKey.D1 || yesno.Key == ConsoleKey.D2)
                    break;
                else continue;
            }
            if (yesno.Key == ConsoleKey.D1)
            {
                group.Clear();
                Console.WriteLine("   Academy group was cleared. \n   Press any key to continue");
                Console.ReadKey();
            }
        }
        public void Save() // Метод для сериализации/сорхранения данных
        {
            if (group.Count == 0) 
            {
                Console.WriteLine("  Group is empty! Are you sure\n" +
                                  "  that you want to save it?   \n" +
                                  "   1. Yes\n" +
                                  "   2. No \n");
                ConsoleKeyInfo sv;
                while (true)
                {
                    sv = Console.ReadKey(true);
                    if (sv.Key == ConsoleKey.D1 || sv.Key == ConsoleKey.D2)
                        break;
                    else continue;
                }
                if (sv.Key == ConsoleKey.D2)
                    return;
            }

            Console.WriteLine("  Choose the format to save: ");
            Console.WriteLine("  1. txt ");
            Console.WriteLine("  2. Binary ");
            Console.WriteLine("  3. SOAP ");
            Console.WriteLine("  4. XML ");
            Console.WriteLine("  5. JSON ");

            ConsoleKeyInfo frmt;
            while (true) 
            {
                frmt = Console.ReadKey(true);
                if (frmt.Key == ConsoleKey.D1 || frmt.Key == ConsoleKey.D2 
                    || frmt.Key == ConsoleKey.D3 || frmt.Key == ConsoleKey.D4 
                    || frmt.Key == ConsoleKey.D5)
                    break;
                else continue;
            }

            if (frmt.Key == ConsoleKey.D1) // Текстовый файл
            {
                StreamWriter sw = new StreamWriter("GroupTXT.log", false, Encoding.Default);
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
                Console.WriteLine("\n  Serialized TO GroupTXT.log." +
                    "\n  Press any key to continue");
                Console.ReadKey();
            }
            if (frmt.Key == ConsoleKey.D2) // Бинарный файн 
            {
                FileStream stream = new FileStream("GroupBIN.txt", FileMode.Create); ;
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, group);
                stream.Close();
                Console.WriteLine("\n  Serialized TO GroupBIN.log." +
                    "\n  Press any key to continue");
                Console.ReadKey();
            }
            if (frmt.Key == ConsoleKey.D3) // SOAP файл 
            {
                FileStream stream = new FileStream("GroupSOAP.xml", FileMode.Create); ;
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(stream, group);
                stream.Close();
                Console.WriteLine("\n  Serialized TO GroupSOAP.xml." +
                    "\n  Press any key to continue");
                Console.ReadKey();
            }
            if (frmt.Key == ConsoleKey.D4) // XML файл 
            {
                List<Student> L = new List<Student>();
                foreach (Student s in group) 
                    L.Add(s);

                FileStream stream = new FileStream("GroupXML.xml", FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
                serializer.Serialize(stream, L);
                stream.Close();
                Console.WriteLine("\n  Serialized TO GroupXML.xml" +
                    "\n  Press any key to continue");
                Console.ReadKey();
            }
            if (frmt.Key == ConsoleKey.D5) // JSON файл
            {
                List<Student> L = new List<Student>();
                foreach (Student s in group) 
                    L.Add(s);

                FileStream stream = new FileStream("GroupJSON.json", FileMode.Create);
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Student>));
                jsonFormatter.WriteObject(stream, L);
                stream.Close();
                Console.WriteLine("\n  Serialized TO GroupJSON.json" +
                    "\n  Press any key to continue");
                Console.ReadKey();
            }
        }
        public void Load()
        {
            group.Clear();
            Console.WriteLine("  Choose the format to download from: ");
            Console.WriteLine("  1. txt ");
            Console.WriteLine("  2. Binary ");
            Console.WriteLine("  3. SOAP ");
            Console.WriteLine("  4. XML ");
            Console.WriteLine("  5. JSON ");

            ConsoleKeyInfo frmt;
            while (true)
            {
                frmt = Console.ReadKey(true);
                if (frmt.Key == ConsoleKey.D1 || frmt.Key == ConsoleKey.D2
                    || frmt.Key == ConsoleKey.D3 || frmt.Key == ConsoleKey.D4 
                    || frmt.Key == ConsoleKey.D5)
                    break;
                else continue;
            }

            if (frmt.Key == ConsoleKey.D1) // Текстовый файл
            {
                group.Clear();
                StreamReader sr = new StreamReader("GroupTXT.log", Encoding.Default);
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
                Console.WriteLine("\n  Deserialized FROM GroupTXT.log." +
                    "\n  Press any key to continue");
                Console.ReadKey();
            }
            else if (frmt.Key == ConsoleKey.D2) // Бинарный файн 
            {
                group.Clear();
                FileStream stream = new FileStream("GroupBIN.txt", FileMode.Open); ;
                BinaryFormatter formatter = new BinaryFormatter();
                group = (ArrayList)formatter.Deserialize(stream);
                stream.Close();
                Console.WriteLine("\n  Serialized from GroupBIN.log." +
                    "\n  Press any key to continue");
                Console.ReadKey();
            }
            else if (frmt.Key == ConsoleKey.D3) // SOAP файл 
            {
                group.Clear();
                FileStream stream = new FileStream("GroupSOAP.xml", FileMode.Open); 
                SoapFormatter formatter = new SoapFormatter();
                group = (ArrayList)formatter.Deserialize(stream);
                stream.Close();
                Console.WriteLine("\n  Serialized FROM GroupSOAP.xml" +
                    "\n  Press any key to continue");
                Console.ReadKey();
            }
            else if (frmt.Key == ConsoleKey.D4) // XML файл 
            {
                group.Clear();
                List<Student> L = new List<Student>();
                FileStream stream = new FileStream("GroupXML.xml", FileMode.Open); ;
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
                L = (List<Student>)serializer.Deserialize(stream);
                stream.Close(); 
                
                foreach (Student s in L)
                    group.Add(s);
                Console.WriteLine("\n  Deserialized FROM GroupXML.xml." +
                    "\n  Press any key to continue");
                Console.ReadKey();
            }
            else if (frmt.Key == ConsoleKey.D5) // JSON файл
            {
                group.Clear();
                List<Student> L = new List<Student>();

                FileStream stream = new FileStream("GroupJSON.json", FileMode.Open);
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Student>));
                L = (List<Student>)jsonFormatter.ReadObject(stream);
                stream.Close();

                foreach (Student s in L)
                    group.Add(s);

                Console.WriteLine("\n  Deserialized FROM GroupJSON.json" +
                    "\n  Press any key to continue");
                Console.ReadKey();
            }
        }
    }
}