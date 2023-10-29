using System.Text;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Reflection;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace LogLibrary
{
    public interface ILog
    {
        public void Print(string s);
    }

    public class ConsoleLog : ILog
    {
        public void Print(string s)
        {
            Console.WriteLine(s);
            Console.WriteLine("-----------------------");
        }
    }
    public class FileLog : ILog
    {
        public void Print(string s)
        {
            StreamWriter sw = new StreamWriter("PriceList.log", true, Encoding.Default);
            sw.WriteLine(Convert.ToString(s));
            sw.Close();
        }
    }

}