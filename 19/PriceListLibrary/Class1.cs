using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Reflection;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

using StoragesLibrary;
using LogLibrary;
using SerializeLibrary;

namespace PriceListLibrary
{
    [Serializable]
    [DataContract]
    public class PriceList
    {
        [DataMember]
        public List<Storage> list = new List<Storage>();
        public void Add()
        {
            ConsoleKeyInfo type;
            Console.WriteLine("What type of storage do you want to add?");
            Console.WriteLine("  1. Flash");
            Console.WriteLine("  2. HDD");
            Console.WriteLine("  3. DVD");
            Console.WriteLine("  0. Return ");

            while (true)
            {
                type = Console.ReadKey(true);
                if (type.Key == ConsoleKey.D1 || type.Key == ConsoleKey.D2
                        || type.Key == ConsoleKey.D3 || type.Key == ConsoleKey.D0)
                    break;
                else continue;
            }
            string man, mod, nam;
            int cp, cnt, spd;
            Storage st;

            switch (type.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("Input the data about new Flash drive storage:");
                    Console.Write("Manufacturer: | ");
                    man = Console.ReadLine();
                    Console.Write("Model:        | ");
                    mod = Console.ReadLine();
                    Console.Write("Name:         | ");
                    nam = Console.ReadLine();
                    Console.Write("Capacity:     | ");
                    cp = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Count:        | ");
                    cnt = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Speed USB:    | ");
                    spd = Convert.ToInt32(Console.ReadLine());

                    st = new Flash(man, mod, nam, cp, cnt, spd);
                    list.Add(st);
                    Console.WriteLine("  New Flash drive was added.\n" +
                                      "  Press any key to continue");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Input the data about new HDD drive storage:");
                    Console.Write("Manufacturer: | ");
                    man = Console.ReadLine();
                    Console.Write("Model:        | ");
                    mod = Console.ReadLine();
                    Console.Write("Name:         | ");
                    nam = Console.ReadLine();
                    Console.Write("Capacity:     | ");
                    cp = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Count:        | ");
                    cnt = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Rot. speed:   | ");
                    spd = Convert.ToInt32(Console.ReadLine());

                    st = new Flash(man, mod, nam, cp, cnt, spd);
                    list.Add(st);
                    Console.WriteLine("  New HDD drive was added.\n" +
                                      "  Press any key to continue");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("Input the data about new DVD drive storage:");
                    Console.Write("Manufacturer: | ");
                    man = Console.ReadLine();
                    Console.Write("Model:        | ");
                    mod = Console.ReadLine();
                    Console.Write("Name:         | ");
                    nam = Console.ReadLine();
                    Console.Write("Capacity:     | ");
                    cp = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Count:        | ");
                    cnt = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Writing speed:| ");
                    spd = Convert.ToInt32(Console.ReadLine());

                    st = new Flash(man, mod, nam, cp, cnt, spd);
                    list.Add(st);
                    Console.WriteLine("  New DVD drive was added.\n" +
                                      "  Press any key to continue");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D0:
                    break;
            }

        }
        public void Print(ILog log)
        {
            Console.Clear();
            if (log is FileLog)
            {
                StreamWriter sw = new StreamWriter("PriceList.log", false, Encoding.Default);
                sw.Close();
                Console.WriteLine("\n    Printed into the file PriceList.log.\n");
            }
            else if (log is ConsoleLog)
                Console.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                log.Print((i + 1).ToString());
                list[i].Print(log);
            }

            Console.WriteLine("\n    Press any key to continue");
            Console.ReadKey();
        }
        public void Remove()
        {
            Console.WriteLine("  Enter the number of the item that you want to remove:");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number - 1 >= 0 && number - 1 < list.Count)
            {
                list.RemoveAt(number - 1);
                Console.WriteLine("\n    Item was removed." +
                "\n    Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n    Wrong number!" +
                "\n    Press any key to continue");
                Console.ReadKey();
            }
        }
        public void Save(ISerialize ser)
        {
            ser.Save(list);
        }
        public void Load(ISerialize ser)
        {
            list.Clear();
            list = ser.Load();
        }
        public void Edit()
        {
            Console.WriteLine("  Enter the number of the item that you want to edit:");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number - 1 >= 0 && number - 1 < list.Count)
            {
                string man, mod, nam;
                int cp, cnt, spd;
                if (list[number - 1] is Flash)
                {
                    Console.WriteLine("Input the data about new Flash drive storage:");
                    Console.Write("Manufacturer: | ");
                    man = Console.ReadLine();
                    Console.Write("Model:        | ");
                    mod = Console.ReadLine();
                    Console.Write("Name:         | ");
                    nam = Console.ReadLine();
                    Console.Write("Capacity:     | ");
                    cp = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Count:        | ");
                    cnt = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Speed USB:    | ");
                    spd = Convert.ToInt32(Console.ReadLine());

                    list[number - 1] = new Flash(man, mod, nam, cp, cnt, spd);
                }
                if (list[number - 1] is HDD)
                {
                    Console.WriteLine("Input the data about new HDD drive storage:");
                    Console.Write("Manufacturer: | ");
                    man = Console.ReadLine();
                    Console.Write("Model:        | ");
                    mod = Console.ReadLine();
                    Console.Write("Name:         | ");
                    nam = Console.ReadLine();
                    Console.Write("Capacity:     | ");
                    cp = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Count:        | ");
                    cnt = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Rot.Speed:    | ");
                    spd = Convert.ToInt32(Console.ReadLine());

                    list[number - 1] = new HDD(man, mod, nam, cp, cnt, spd);
                }
                if (list[number - 1] is DVD)
                {
                    Console.WriteLine("Input the data about new DVD drive storage:");
                    Console.Write("Manufacturer: | ");
                    man = Console.ReadLine();
                    Console.Write("Model:        | ");
                    mod = Console.ReadLine();
                    Console.Write("Name:         | ");
                    nam = Console.ReadLine();
                    Console.Write("Capacity:     | ");
                    cp = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Count:        | ");
                    cnt = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Wrt.Speed:    | ");
                    spd = Convert.ToInt32(Console.ReadLine());

                    list[number - 1] = new DVD(man, mod, nam, cp, cnt, spd);
                }
                Console.WriteLine("  Data was edited.\n" +
                                  "  Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n    Wrong nunber!" +
                "\n    Press any key to continue");
                Console.ReadKey();
            }
        }
        public void Find(ILog log)
        {
            Console.WriteLine("Choose the key of the search: ");
            Console.WriteLine("  1. Manufacturer");
            Console.WriteLine("  2. Model");
            Console.WriteLine("  3. Name");
            Console.WriteLine("  4. Capacity");
            Console.WriteLine("  5. Count");
            Console.WriteLine("  6. Speed USB");
            Console.WriteLine("  7. Rotation speed");
            Console.WriteLine("  8. Writing speed");
            ConsoleKeyInfo key;

            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.D2 ||
                    key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.D4 ||
                    key.Key == ConsoleKey.D5 || key.Key == ConsoleKey.D6 ||
                    key.Key == ConsoleKey.D7 || key.Key == ConsoleKey.D8)
                    break;
                else continue;
            }

            string s;
            int n;

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("Enter the key (Manufacturer):");
                    s = Console.ReadLine();
                    var str1 = from st in list
                               where (st.Manufacturer.Contains(s))
                               select st;
                    foreach (var st in str1)
                    {
                        log.Print((list.IndexOf(st) + 1).ToString());
                        st.Print(log);
                    }
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Enter the key (Model):");
                    s = Console.ReadLine();
                    var str2 = from st in list
                               where (st.Model.Contains(s))
                               select st;
                    foreach (var st in str2)
                    {
                        log.Print((list.IndexOf(st) + 1).ToString());
                        st.Print(log);
                    }
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("Enter the key (Name):");
                    s = Console.ReadLine();
                    var str3 = from st in list
                               where (st.Name.Contains(s))
                               select st;
                    foreach (var st in str3)
                    {
                        log.Print((list.IndexOf(st) + 1).ToString());
                        st.Print(log);
                    }
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("Enter the key (Capacity):");
                    n = Convert.ToInt32(Console.ReadLine());
                    var str4 = from st in list
                               where (st.Capacity == n)
                               select st;
                    foreach (var st in str4)
                    {
                        log.Print((list.IndexOf(st) + 1).ToString());
                        st.Print(log);
                    }
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine("Enter the key (Count):");
                    n = Convert.ToInt32(Console.ReadLine());
                    var str5 = from st in list
                               where (st.Count == n)
                               select st;
                    foreach (var st in str5)
                    {
                        log.Print((list.IndexOf(st) + 1).ToString());
                        st.Print(log);
                    }
                    break;
                case ConsoleKey.D6:
                    Console.WriteLine("Enter the key (Speed USB):");
                    n = Convert.ToInt32(Console.ReadLine());
                    foreach (Flash flsh in list)
                    {
                        if (flsh.SpeedUSB == n)
                        {
                            log.Print((list.IndexOf(flsh) + 1).ToString());
                            flsh.Print(log);
                        }
                    }
                    break;
                case ConsoleKey.D7:
                    Console.WriteLine("Enter the key (Rotation speed):");
                    n = Convert.ToInt32(Console.ReadLine());
                    foreach (HDD hdd in list)
                    {
                        if (hdd.RotationalSpeed == n)
                        {
                            log.Print((list.IndexOf(hdd) + 1).ToString());
                            hdd.Print(log);
                        }
                    }
                    break;
                case ConsoleKey.D8:
                    Console.WriteLine("Enter the key (Writing speed):");
                    n = Convert.ToInt32(Console.ReadLine());
                    foreach (DVD dvd in list)
                    {
                        if (dvd.WritingSpeed == n)
                        {
                            log.Print((list.IndexOf(dvd) + 1).ToString());
                            dvd.Print(log);
                        }
                    }
                    break;
            }
            Console.WriteLine("  Press any key to continue");
            Console.ReadKey();
        }
    }
}