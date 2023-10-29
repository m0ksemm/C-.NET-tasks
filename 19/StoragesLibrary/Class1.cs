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

using LogLibrary;

namespace StoragesLibrary
{
    [Serializable]
    [KnownType(typeof(Flash))]
    [KnownType(typeof(DVD))]
    [KnownType(typeof(HDD))]
    [XmlInclude(typeof(Flash))]
    [XmlInclude(typeof(DVD))]
    [XmlInclude(typeof(HDD))]
    [DataContract]
    public class Storage
    {
        [DataMember]
        public string Manufacturer { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Capacity { get; set; }
        [DataMember]
        public int Count { get; set; }
        public virtual void Print(ILog log) { }
        public Storage()
        {
            Manufacturer = "manufacturer";
            Model = "model";
            Name = "name";
            Capacity = 0;
            Count = 0;
        }
        public Storage(string man, string mod, string nam, int cap, int cnt)
        {
            Manufacturer = man;
            Model = mod;
            Name = nam;
            Capacity = cnt;
            Count = cnt;
        }
    }

    [Serializable]
    [DataContract]
    public class Flash : Storage
    {
        [DataMember]
        public int SpeedUSB { get; set; }
        public Flash() : base()
        {
            SpeedUSB = 0;
        }
        public Flash(string man, string mod, string nam, int cap, int cnt, int spdusb)
            : base(man, mod, nam, cap, cnt)
        {
            SpeedUSB = spdusb;
        }
        public override void Print(ILog log)
        {
            string s = "Manuf.  |  " + Manufacturer + "\n" +
                       "Model   |  " + Model + "\n" +
                       "Name    |  " + Name + "\n" +
                       "Cap.    |  " + Capacity.ToString() + "\n" +
                       "Count   |  " + Count.ToString() + "\n" +
                       "SpeedUSB|  " + SpeedUSB.ToString() + "\n";

            log.Print(s);
        }
    }

    [Serializable]
    [DataContract]
    public class HDD : Storage
    {
        [DataMember]
        public int RotationalSpeed { get; set; }
        public HDD() : base()
        {
            RotationalSpeed = 0;
        }
        public HDD(string man, string mod, string nam, int cap, int cnt, int rtspd)
            : base(man, mod, nam, cap, cnt)
        {
            RotationalSpeed = rtspd;
        }
        public override void Print(ILog log)
        {
            string s = "Manuf.  |  " + Manufacturer + "\n" +
                       "Model   |  " + Model + "\n" +
                       "Name    |  " + Name + "\n" +
                       "Cap.    |  " + Capacity.ToString() + "\n" +
                       "Count   |  " + Count.ToString() + "\n" +
                       "Rt.Speed|  " + RotationalSpeed.ToString() + "\n";

            log.Print(s);
        }
    }

    [Serializable]
    [DataContract]
    public class DVD : Storage
    {
        [DataMember]
        public int WritingSpeed { get; set; }
        public DVD() : base()
        {
            WritingSpeed = 0;
        }
        public DVD(string man, string mod, string nam, int cap, int cnt, int wrtspd)
            : base(man, mod, nam, cap, cnt)
        {
            WritingSpeed = wrtspd;
        }
        public override void Print(ILog log)
        {
            string s = "Manuf.  |  " + Manufacturer + "\n" +
                       "Model   |  " + Model + "\n" +
                       "Name    |  " + Name + "\n" +
                       "Cap.    |  " + Capacity.ToString() + "\n" +
                       "Count   |  " + Count.ToString() + "\n" +
                       "Wr.Speed|  " + WritingSpeed.ToString() + "\n";
            log.Print(s);
        }
    }
}