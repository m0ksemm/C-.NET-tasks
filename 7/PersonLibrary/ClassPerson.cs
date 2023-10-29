namespace PersonLibrary
{
    public class Person
    {
        protected string name;
        protected string surname;
        protected int age;
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
                "Name:    {0} \nSurname: {1} \nAge:     " +
                "{2} \nPhone:   {3}", name, surname, age, phone);
        }
    }
}