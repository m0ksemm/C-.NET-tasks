// See https://aka.ms/new-console-template for more information

class Strings 
{
    static void Task1() 
    {
        Console.WriteLine("Task1\n");
        Console.WriteLine("Enter the expression: (example: 123+20-43)");
        double num1, result = 0;
        string math = Console.ReadLine();

        math += "=";
        char c = ' ';

        for (int i = 0; i < math.Length ; i++) 
        {
            int j = i;
            string s = "";
            while (math[j] != '+' && math[j] != '-' && math[j] != '=') 
            {
                s += math[j];
                j++;
            }

            i = j;
            num1 = Convert.ToInt32(s);

            if (c == '+' || c == ' ')
                result += num1;
            if (c == '-')
                result -= num1;

            if (math[j] == '+')
                c = '+';

            else if (math[j] == '-')
                c = '-';
            else c = '=';
        }
        Console.Write("={0}", result);

    }

    static void Task2()
    {
        Console.WriteLine("\n\n\nTask2\n");
        Console.WriteLine("Enter the text: ");
 
        string str = Console.ReadLine();
        bool flag = false;

        for (int i = 0; i < str.Length; i++) 
        {
            if (str[i] == '.' || str[i] == '!' || str[i] == '?') flag = false;
            if (flag == false && str[i] != ' ') 
            {
                char[] tmpstr = new char[str.Length];
                for (int j = 0; j < str.Length; j++)
                {
                    tmpstr[j] = str[j];
                }
                
                if (tmpstr[i] >= 97 && tmpstr[i] <= 122)
                {
                    tmpstr[i] = char.ToUpper(tmpstr[i]);
                    flag = true;
                }

                if (tmpstr[i] >= 65 && tmpstr[i] <= 90)
                {
                    flag = true;
                }
                    string s = new string(tmpstr);
                str = s;
            }
        }
        Console.WriteLine(str);

    }

    static void Main() 
    {
        try
        {
            Task1();
            Task2();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.Read();
    } 
}

