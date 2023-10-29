// See https://aka.ms/new-console-template for more information

class Date 
{
    int day;
    int month;
    int year;

    public Date() 
    {
        day = 1;
        month = 1;  
        year = 1;   
    }
    public Date(int d, int m, int y)
    {
        day = d;
        month = m;
        year = y;
    }

    public int Day
    {
        get
        {
            return day;
        }
        set
        {
            if (value > 0 && value < 31)
                day = value;
        }
    }
    public int Month
    {
        get
        {
            return month;
        }
        set
        {
            if (value > 0 && value <13)
                month = value;
        }
    }
    public int Year
    {
        get
        {
            return year;
        }
        set
        {
            if (value > 0)
                year = value;
        }
    }
    public int Day_Of_Week() 
    {
        if (month == 1 || month == 2)
        {
            month += 12;
            year--;
        }
        int iWeek = (day + 2 * month + 3 * (month + 1) / 5 + year + year / 4 - year / 100 + year / 400) % 7;  
        switch (iWeek)
        {
            case 0:
                Console.WriteLine("Monday");
                break;
            case 1:
                Console.WriteLine("Tuesday");
                break;
            case 2:
                Console.WriteLine("Wednesday");
                break;
            case 3:
                Console.WriteLine("Thursday");
                break;
            case 4:
                Console.WriteLine("Friday");
                break;
            case 5:
                Console.WriteLine("Saturday");
                break;
            case 6:
                Console.WriteLine("Sunday");
                break;
        }
        return iWeek;
    }
    public int NumberOfDays(Date dt)
    {
        int x = 0, y = 0;
        int a = day;
        int b = month;
        int c = year;
        int d = dt.day;
        int e = dt.month;
        int f = dt.year;

        int leap = c;
        int k = 0;
        while (leap <= f)
        {

            if (leap % 4 == 0 && leap % 100 != 0 || leap % 400 == 0)
            {
                k = k + 1;
            }
            leap++;
        }
        int m1 = 31, m2 = 28, m3 = 31, m4 = 30, m5 = 31, m6 = 30, m7 = 31, m8 = 31, m9 = 30, m10 = 31, m11 = 30, m12 = 31;

        if (b == 1) { x = a; }
        else if (b == 2) { x = m1 + a; }
        else if (b == 3) { x = m1 + m2 + a; }
        else if (b == 4) { x = m1 + m2 + m3 + a; }
        else if (b == 5) { x = m1 + m2 + m3 + m4 + a; }
        else if (b == 6) { x = m1 + m2 + m3 + m4 + m5 + a; }
        else if (b == 7) { x = m1 + m2 + m3 + m4 + m5 + m6 + a; }
        else if (b == 8) { x = m1 + m2 + m3 + m4 + m5 + m6 + m7 + a; }
        else if (b == 9) { x = m1 + m2 + m3 + m4 + m5 + m6 + m7 + m8 + a; }
        else if (b == 10) { x = m1 + m2 + m3 + m4 + m5 + m6 + m7 + m8 + m9 + a; }
        else if (b == 11) { x = m1 + m2 + m3 + m4 + m5 + m6 + m7 + m8 + m9 + m10 + a; }
        else if (b == 12) { x = m1 + m2 + m3 + m4 + m5 + m6 + m7 + m8 + m9 + m10 + m11 + a; }

        if (e == 1) { y = d; }
        else if (e == 2) { y = m1 + d; }
        else if (e == 3) { y = m1 + m2 + d; }
        else if (e == 4) { y = m1 + m2 + m3 + d; }
        else if (e == 5) { y = m1 + m2 + m3 + m4 + d; }
        else if (e == 6) { y = m1 + m2 + m3 + m4 + m5 + d; }
        else if (e == 7) { y = m1 + m2 + m3 + m4 + m5 + m6 + d; }
        else if (e == 8) { y = m1 + m2 + m3 + m4 + m5 + m6 + m7 + d; }
        else if (e == 9) { y = m1 + m2 + m3 + m4 + m5 + m6 + m7 + m8 + d; }
        else if (e == 10) { y = m1 + m2 + m3 + m4 + m5 + m6 + m7 + m8 + m9 + d; }
        else if (e == 11) { y = m1 + m2 + m3 + m4 + m5 + m6 + m7 + m8 + m9 + m10 + d; }
        else if (e == 12) { y = m1 + m2 + m3 + m4 + m5 + m6 + m7 + m8 + m9 + m10 + m11 + d; }

        if ((c % 4 == 0 && leap % 100 != 0 || leap % 400 == 0) && b > 2) { k = k - 1; } 
        if ((f % 4 == 0 && leap % 100 != 0 || leap % 400 == 0) && d <= 29 && e < 3) { k = k - 1; } 

        if (c == f)
        {
            return( (y - x) + k );
        }
        else
            return( (f - c) * 365 + ((y - x) + k) );
    }
    public void ChangeDate(int n) 
    {
        if (n > 0)
        {
            for (int i = 0; i < n; i++)
            {
                if (month == 12 && day == 30)
                {
                    day = 1;
                    month = 1;
                    year++;
                }
                else if (day == 30)
                {
                    day = 1;
                    month++;
                }
                else day++;

            }
        }
        else  if (n < 0)
        {
            for (int i = 0; i < -n; i++)
            {
                if (month == 1 && day == 1)
                {
                    day = 30;
                    month = 12;
                    year--;
                }
                else if (day == 1)
                {
                    day = 30;
                    month--;
                }
                else day--;

            }
        }
    }

    public void Print() 
    {
        Console.WriteLine($"{day}\t{month}\t{year}");
    }

    static void Main() 
    {
        try 
        {
            //constructors:
            Date d1 = new Date();
            d1.Print();//print of date
            Date d2 = new Date(22, 11, 2003);
            d2.Print();
            Console.WriteLine();

            //properties
            d2.Day = 12;
            d2.Month = 3;
            d2.Year = 1988;
            d2.Print();
            Console.WriteLine($"{d2.Day}\t{d2.Month}\t{d2.Year}");
            int dow = d2.Day_Of_Week();
            Console.WriteLine();

            //number of days
            Date d3 = new Date(22, 11, 1990);
            int n = d2.NumberOfDays(d3);
            Console.WriteLine(n);
            Console.WriteLine();

            //changing date
            d3.ChangeDate(12);
            d3.Print();
            d3.ChangeDate(-40);
            d3.Print();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.Read();

    }
}