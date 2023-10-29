using System.Runtime.Serialization;

namespace PersonLibrary
{
    [Serializable]
    [DataContract]
    public class Person
    {
        [DataMember]
        protected string name;
        [DataMember]
        protected string surname;
        [DataMember]
        protected int age;
        [DataMember]
        protected int phone;
        public Person()
        {
            name = "New";
            surname = "Student";
            age = 17;
            phone = 1111111111;
        }
        public Person(string n, string s, int a, int p)
        {
            name = n;
            surname = s;
            age = a;
            phone = p;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public int Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }
        public void Print()
        {
            Console.WriteLine("______________________________\n" +
                "Name    | {0,10} \nSurname | {1,10} \nAge     | " +
                "{2,10} \nPhone   | {3,10}", name, surname, age, phone);
        }
    }
}