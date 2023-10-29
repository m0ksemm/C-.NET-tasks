// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

class Arrays
{
    static void ArrayOutput(int[] array) 
    {
        foreach (int n in array)
        {
            System.Console.Write("{0, 4}", n);
        }
    }

    static void _2DArrayOutput(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write("{0,4}", array[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Task1() 
    {
        Console.WriteLine("Task1: \n");

        int[] array = new int[10];

        Random r = new Random();
        Console.WriteLine("Array: ");
        for (int i = 0; i < array.Length; i++) 
        {
           array[i] = r.Next(0, 6);
            System.Console.Write("{0, 4}", array[i]);
        }
 
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == 0) 
            {
                for (int j = i; j < array.Length - 1; j++)
                {
                    array[j] = array[j+1];
                    array[j + 1] = -1;
                }
                i--;
            }
        }
        Console.WriteLine("\nArray2: ");

        ArrayOutput(array);

    }

    static void Task2() 
    {
        Console.WriteLine("\n\n\nTask2: ");

        Console.Write("\nEnter N(odd number):  ");
        int N;
        while (true)
        {
            N = Convert.ToInt32(Console.ReadLine());
            if (N % 2 == 0)
            {
                Console.Write("N is not an odd number. Enter N again:  ");
            }
            else break;
        }

        int[,] array = new int[N, N];

        int strp = 1;
        int n = 1;
        bool flag = true;

        int x = N / 2 ;
        int y = N / 2 ;

        for (int i = 0; i < N * 2 - 1 ; i++) 
        {
            int k = i % 4;
            switch (k) 
            {
                case 0:
                    for (int j = 0; j < strp; j++) 
                    {
                        
                        array[x, y] = n++;
                        y--;
                    }

                    if (flag == false) 
                    {
                        strp++;
                        flag = true;
                    }
                    else 
                        flag = false;
                    break;
                case 1:
                    for (int j = 0; j < strp; j++)
                    {
                        
                        array[x, y] = n++;
                        x++;
                    }

                    if (flag == false)
                    {
                        strp++;
                        flag = true;
                    }
                    else
                        flag = false;
                    break;
                case 2:
                    for (int j = 0; j < strp; j++)
                    {
                        
                        array[x, y] = n++;
                        y++;
                    }

                    if (flag == false)
                    {
                        strp++;
                        flag = true;
                    }
                    else
                        flag = false;
                    break;

                case 3:
                    for (int j = 0; j < strp; j++)
                    {
                        
                        array[x, y] = n++;
                        x--;
                    }

                    if (flag == false)
                    {
                        strp++;
                        flag = true;
                    }
                    else
                        flag = false;
                    break;


            }
        }

        Console.WriteLine("\nmatrix:");

        _2DArrayOutput(array);
    }

    static void Task3() 
    {
        Console.WriteLine("\n\n\nTask3: ");

        Console.Write("Enter N: ");
        int N = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter M: ");
        int M = Convert.ToInt32(Console.ReadLine());

        int[,] array = new int[N, M];

        Random r = new Random();

        for (int i = 0; i < array.GetLength(0); i++) 
        {
            for (int j = 0; j < array.GetLength(1); j++) 
            {
                array[i, j] = r.Next(0, 101);
            }
        }

        Console.WriteLine("\nmatrix:");

        _2DArrayOutput(array);


        Console.Write("\nEnter the number of shifts:");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nEnter L to make the shifts to the left;");
        Console.Write("Enter R to make the shifts to the right:   ");

        string str = Console.ReadLine();

        if (str == "L") 
        {

            Console.WriteLine("\nArray after {0} shifts to the left: ", n);

            for (int k = 0; k < n; k++) 
            {
                for (int i = 0; i < array.GetLength(0); i++) 
                {
                    for (int j = 0; j < array.GetLength(1) - 1; j++) 
                    {
                        int tmp = array[i, j];
                        array[i, j] = array[i, j + 1];
                        array[i, j + 1] = tmp;
                    }
                }
            }
            _2DArrayOutput(array);
        }
        else if (str == "R") 
        {
            Console.WriteLine("\nArray after {0} shifts to the right: ", n);

            for (int k = 0; k < n; k++)
            {
                for (int i = array.GetLength(0) - 1; i >= 0; i--)
                {
                    for (int j = array.GetLength(1) - 1; j > 0; j--) 
                    {
                        int tmp = array[i,j];
                        array[i, j] = array[i, j - 1];
                        array[i, j - 1] = tmp;
                    }
                }
            }
            _2DArrayOutput(array);
        }
        else Console.WriteLine("\nYou have choosen wrong direction. ");
    }

    static void Main()
    {
        try
        {
            Task1();
            Task2();
            Task3();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.Read();
    }
}