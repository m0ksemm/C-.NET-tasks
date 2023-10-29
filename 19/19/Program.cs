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

using PriceListLibrary;
using LogLibrary;
using SerializeLibrary;
using StoragesLibrary;

public class Program
{
    public static void Menu()
    {
        Console.WriteLine("       Storage Price-List");
        Console.WriteLine("1 - Print");
        Console.WriteLine("2 - Add");
        Console.WriteLine("3 - Remove");
        Console.WriteLine("4 - Find");
        Console.WriteLine("5 - Edit");
        Console.WriteLine("6 - Save");
        Console.WriteLine("7 - Load");
        Console.WriteLine("Exit - close the program");
    }
    public static void Main()
    {
        try
        {
            PriceList price_list = new PriceList();
            ConsoleKeyInfo key;
            while (true)
            {
                Console.Clear();
                Menu();
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    Console.WriteLine("  Choose the type of print");
                    Console.WriteLine("  1. Console");
                    Console.WriteLine("  2. File");
                    ConsoleKeyInfo keyLog;
                    while (true)
                    {
                        keyLog = Console.ReadKey(true);
                        if (keyLog.Key == ConsoleKey.D1 || keyLog.Key == ConsoleKey.D2)
                            break;
                        else continue;
                    }
                    ILog log;

                    if (keyLog.Key == ConsoleKey.D1)
                        log = new ConsoleLog();
                    else log = new FileLog();
                    price_list.Print(log);
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    price_list.Add();
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    price_list.Remove();
                }
                else if (key.Key == ConsoleKey.D4)
                {
                    Console.WriteLine("  Choose the type of print");
                    Console.WriteLine("  1. Console");
                    Console.WriteLine("  2. File");
                    ConsoleKeyInfo keyLog;
                    while (true)
                    {
                        keyLog = Console.ReadKey(true);
                        if (keyLog.Key == ConsoleKey.D1 || keyLog.Key == ConsoleKey.D2)
                            break;
                        else continue;
                    }
                    ILog log;

                    if (keyLog.Key == ConsoleKey.D1)
                        log = new ConsoleLog();
                    else
                    {
                        StreamWriter sw = new StreamWriter("PriceList.log", false, Encoding.Default);
                        sw.Close();
                        log = new FileLog();
                    }

                    price_list.Find(log);
                }
                else if (key.Key == ConsoleKey.D5)
                {
                    price_list.Edit();
                }
                else if (key.Key == ConsoleKey.D6)
                {
                    Console.WriteLine("  Choose the type of saving");
                    Console.WriteLine("  1. Binary");
                    Console.WriteLine("  2. XML");
                    Console.WriteLine("  3. JSON");
                    ConsoleKeyInfo keySer;
                    while (true)
                    {
                        keySer = Console.ReadKey(true);
                        if (keySer.Key == ConsoleKey.D1
                            || keySer.Key == ConsoleKey.D2
                            || keySer.Key == ConsoleKey.D3)
                            break;
                        else continue;
                    }
                    ISerialize ser;

                    if (keySer.Key == ConsoleKey.D1)
                        ser = new BinarySerialize();
                    else if (keySer.Key == ConsoleKey.D2)
                        ser = new XMLSerialize();
                    else ser = new JSONSerialize();

                    price_list.Save(ser);
                }
                else if (key.Key == ConsoleKey.D7)
                {
                    Console.WriteLine("  Choose the type of loading");
                    Console.WriteLine("  1. Binary");
                    Console.WriteLine("  2. XML");
                    Console.WriteLine("  3. JSON");
                    ConsoleKeyInfo keySer;
                    while (true)
                    {
                        keySer = Console.ReadKey(true);
                        if (keySer.Key == ConsoleKey.D1
                            || keySer.Key == ConsoleKey.D2
                            || keySer.Key == ConsoleKey.D3)
                            break;
                        else continue;
                    }
                    ISerialize ser;

                    if (keySer.Key == ConsoleKey.D1)
                        ser = new BinarySerialize();
                    else if (keySer.Key == ConsoleKey.D2)
                        ser = new XMLSerialize();
                    else ser = new JSONSerialize();

                    price_list.Load(ser);
                }
                else if (key.Key == ConsoleKey.Escape)
                    break;

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}