using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Collections;
using System.Runtime.Serialization;
using System.Text;
using System.Reflection;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

using StoragesLibrary;

namespace SerializeLibrary
{
    public interface ISerialize
    {
        public void Save(List<Storage> L);
        public List<Storage> Load();
    }

    [Serializable]
    public class BinarySerialize : ISerialize
    {
        public void Save(List<Storage> L)
        {
            FileStream stream = new FileStream("PriceListBIN.txt", FileMode.Create); ;
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, L);
            stream.Close();
            Console.WriteLine("\n  Serialized TO PriceListBIN.log" +
                "\n  Press any key to continue");
            Console.ReadKey();
        }
        public List<Storage> Load()
        {
            List<Storage> L = new List<Storage>();
            FileStream stream = new FileStream("PriceListBIN.txt", FileMode.Open); ;
            BinaryFormatter formatter = new BinaryFormatter();
            L = (List<Storage>)formatter.Deserialize(stream);
            stream.Close();
            Console.WriteLine("\n  Serialized from PriceListBIN.log" +
                "\n  Press any key to continue");
            Console.ReadKey();
            return L;
        }
    }

    public class XMLSerialize : ISerialize
    {
        public void Save(List<Storage> L)
        {
            FileStream stream = new FileStream("PriceListXML.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Storage>));
            serializer.Serialize(stream, L);
            stream.Close();
            Console.WriteLine("\n  Serialized TO PriceListXML.xml" +
                "\n  Press any key to continue");
            Console.ReadKey();
        }
        public List<Storage> Load()
        {
            List<Storage> L = new List<Storage>();
            FileStream stream = new FileStream("PriceListXML.xml", FileMode.Open); ;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Storage>));
            L = (List<Storage>)serializer.Deserialize(stream);
            stream.Close();
            Console.WriteLine("\n  Deserialized FROM PriceListXML.xml." +
                "\n  Press any key to continue");
            Console.ReadKey();
            return L;
        }
    }

    public class JSONSerialize : ISerialize
    {
        public void Save(List<Storage> L)
        {
            FileStream stream = new FileStream("PriceListJSON.json", FileMode.Create);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Storage>));
            serializer.WriteObject(stream, L);
            stream.Close();
            Console.WriteLine("\n  Serialized TO PriceListJSON.json" +
                "\n  Press any key to continue");
            Console.ReadKey();
        }
        public List<Storage> Load()
        {
            List<Storage> L = new List<Storage>();
            FileStream stream = new FileStream("PriceListJSON.json", FileMode.Open);
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Storage>));
            L = (List<Storage>)jsonFormatter.ReadObject(stream);
            stream.Close();

            Console.WriteLine("\n  Deserialized FROM PriceListJSON.json" +
                "\n  Press any key to continue");
            Console.ReadKey();
            return L;
        }
    }
}