using PersonLibrary;

namespace StudentLibrary
{
    public class Student : Person
    {
        protected double average;
        protected int number_of_group;
        public double Average
        {
            get
            {
                return average;
            }
            set
            {
                average = value;
            }
        }
        public int Number_of_group
        {
            get
            {
                return number_of_group;
            }
            set
            {
                number_of_group = value;
            }
        }
        public Student() : base()
        {
            average = 0;
            number_of_group = 0;
        }

        public Student(Student st) : base(st.Name, st.Surname, st.Age, st.Phone)
        {
            average = 0;
            number_of_group = 0;
        }

        public Student(string n, string s, int a, int p, double d, int g) : base(n, s, a, p)
        {
            average = d;
            number_of_group = g;
        }
        new public void Print()
        {
            base.Print();
            Console.WriteLine("Average: {0} \nGroup number: {1}", average, number_of_group);
            Console.WriteLine("______________________________\n");
        }
    }
}