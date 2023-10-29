using System;
using System.Timers;

class Tamagotchi
{
    public int refusal = 0;
    public bool alive = true;
    public string CurrentFace;
    private int previous = 0;
    public string HappyFace =  "\t   ----          ---- \n" +
                               "\t  |    |        |    |\n" +
                               "\t  |    |        |    |\n" +
                               "\t  |    |        |    |\n" +
                               "\t  |    ----------    |\n" +
                               "\t  |                  |\n" +
                               "\t  |   --         --  |\n" +
                               "\t  |                  |\n" +
                               "\t  |                  |\n" +
                               "\t  |   \\_________/    |\n" +
                               "\t  |                  |\n" +
                               "\t   ------------------ \n";

    public string SadFace = "\t                      ---- \n" +
                            "\t   --------          |    |\n" +
                            "\t  |        |         |    |\n" +
                            "\t   ----    |         |    |\n" +
                            "\t       |    ----------    |\n" +
                            "\t       |                  |\n" +
                            "\t       |   O          O   |\n" +
                            "\t       |                  |\n" +
                            "\t       |                  |\n" +
                            "\t       |    __________    |\n" +
                            "\t       |   /          \\   |\n" +
                            "\t        ------------------ \n";

    public string DeadFace =  "\t   ---------          --------\n" +
                              "\t  |        |         |        |\n" +
                              "\t   ----    |         |    ----\n" +
                              "\t       |    ----------    |\n" +
                              "\t       |                  |\n" +
                              "\t       |   X          X   |\n" +
                              "\t       |                  |\n" +
                              "\t       |                  |\n" +
                              "\t       |    __________    |\n" +
                              "\t       |   /          \\   |\n" +
                              "\t        ------------------ \n";

    public Tamagotchi() 
    {
        CurrentFace = HappyFace;
    }

    public delegate void AccountStateHandler();
    public event AccountStateHandler Eat;      // 1
    public event AccountStateHandler Walk;     // 2
    public event AccountStateHandler Sleep;    // 3
    public event AccountStateHandler Feel_ill; // 4
    public event AccountStateHandler Play;     // 5

    public void Generate_event()
    {
        if (refusal == 3)
        {
            Console.WriteLine("Tamagotchi feels ill!                         !!!");
            Console.WriteLine("Press ENTER to cure your Tamagotchi           :)");
            Console.WriteLine("Press any other key to ignore this request   :(");
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
            {
                Feel_ill?.Invoke();
                CurrentFace = HappyFace;
            }
            else
            {
                Console.WriteLine("Tamagotchi is sad :(");
                alive = false;
                CurrentFace = DeadFace;
                Console.WriteLine("\n\nPress any key to continue");
                Console.ReadKey(false);
            }
        }
        else
        {
            Random rnd = new Random();
            int number;
            while (true)
            {
                number = rnd.Next(1, 6);
                if (number != previous)
                    break;
            }
            previous = number;

            if (number == 1)
            {
                Console.WriteLine("Tamagotchi is hungry!                       !!!");
                Console.WriteLine("Press ENTER to feed your Tamagotchi         :)");
                Console.WriteLine("Press any other key to ignore this request :(");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Eat?.Invoke();
                    CurrentFace = HappyFace;
                }
                else
                {
                    Console.WriteLine("Tamagotchi is sad :(");
                    refusal++;
                    CurrentFace = SadFace;
                    Console.WriteLine("\n\nPress any key to continue");
                    Console.ReadKey(false);
                }
            }
            else if (number == 2)
            {
                Console.WriteLine("Tamagotchi wants to go for a walk!                      !!!");
                Console.WriteLine("Press capital 'W' to go for a walk with your Tamagotchi :)");
                Console.WriteLine("Press any other key to ignore this request              :(");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.W)
                {
                    Walk?.Invoke();
                    CurrentFace = HappyFace;
                }
                else
                {
                    Console.WriteLine("Tamagotchi is sad :(");
                    refusal++;
                    CurrentFace = SadFace;
                    Console.WriteLine("\n\nPress any key to continue");
                    Console.ReadKey(false);
                }
            }
            else if (number == 3)
            {
                Console.WriteLine("Tamagotchi wants to sleep!                           !!!");
                Console.WriteLine("Press capital 'S' to put Tamagotchi to the bed       :)");
                Console.WriteLine("Press any other key to ignore this request           :(");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.S)
                {
                    Sleep?.Invoke();
                    CurrentFace = HappyFace;
                }
                else
                {
                    Console.WriteLine("Tamagotchi is sad :(");
                    refusal++;
                    CurrentFace = SadFace;
                    Console.WriteLine("\n\nPress any key to continue");
                    Console.ReadKey(false);
                }
            }
            else if (number == 4)
            {
                Console.WriteLine("Tamagotchi feels ill!                        !!!");
                Console.WriteLine("Press capital 'H' to heal your Tamagotchi    :)");
                Console.WriteLine("Press any other key to ignore this request   :(");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.H)
                {
                    Feel_ill?.Invoke();
                    CurrentFace = HappyFace;
                }
                else
                {
                    Console.WriteLine("Tamagotchi is sad :(");
                    alive = false;
                    CurrentFace = DeadFace;
                    Console.WriteLine("\n\nPress any key to continue");
                    Console.ReadKey(false);
                }
            }
            else if (number == 5)
            {
                Console.WriteLine("Tamagotchi wants to play!                      !!!");
                Console.WriteLine("Press capital 'P' to play with your Tamagotchi :)");
                Console.WriteLine("Press any other key to ignore this request     :(");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.P)
                {
                    Play?.Invoke();
                    CurrentFace = HappyFace;
                }
                else
                {
                    Console.WriteLine("Tamagotchi is sad :(");
                    refusal++;
                    CurrentFace = SadFace;
                    Console.WriteLine("\n\nPress any key to continue");
                    Console.ReadKey(false);
                }
            }
        }
    }


}

class Nanny1 
{
    public void feed() 
    {
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(500);
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(500);
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(500);
        Console.WriteLine("Tamagotchi is fed!");
        Console.WriteLine("\n\nPress any key to continue");
        Console.ReadKey(false);
    }
    public void walk_out()
    {
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(700);
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(700);
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(700);
        Console.WriteLine("Tamagotchi went for a walk!");
        Console.WriteLine("\n\nPress any key to continue");
        Console.ReadKey(false);
    }
}

class Nanny2 
{
    public void put_to_sleep() 
    {
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(1500);
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(1500);
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(1500);
        Console.WriteLine("Tamagotchi has been put to sleep!");
        Console.WriteLine("\n\nPress any key to continue");
        Console.ReadKey(false);
    }
    public void cure()
    {
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(600);
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(600);
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(600);
        Console.WriteLine("Tamagotchi has been cured!");
        Console.WriteLine("\n\nPress any key to continue");
        Console.ReadKey(false);
    }
}

class Nanny3
{
    public void entertain_or_play()
    {
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(500);
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(500);
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(500);
        Console.WriteLine("Tamagotchi played!");
        Console.WriteLine("\n\nPress any key to continue");
        Console.ReadKey(false);
    }
}

class Test
{
    static void Main(string[] args)
    {
        Tamagotchi tmg = new Tamagotchi();
        Nanny1 n1 = new Nanny1();
        Nanny2 n2 = new Nanny2();
        Nanny3 n3 = new Nanny3();

        tmg.Eat += n1.feed;
        tmg.Walk += n1.walk_out;
        tmg.Sleep += n2.put_to_sleep;
        tmg.Feel_ill += n2.cure;
        tmg.Play += n3.entertain_or_play;


        System.Timers.Timer t = new System.Timers.Timer
        {
            Interval = 1000
        };
        // public event ElapsedEventHandler Elapsed - это событие происходит по истечении интервала времени
        

        Console.WriteLine("TTTTT     A     M   M     A     GGGGGG  OOOOO TTTTT CCCCC H   H  I \n" +
                          "  T      A A    MM MM    A A    G       O   O   T   C     H   H  I \n" +
                          "  T     A   A   M M M   A   A   G GGGG  O   O   T   C     HHHHH  I \n" +
                          "  T    AAAAAAA  M   M  AAAAAAA  G    G  O   O   T   C     H   H  I \n" +
                          "  T   A       A M   M A       A GGGGGG  OOOOO   T   CCCCC H   H  I \n");

        ConsoleKeyInfo key;
        while (true)
        {
            Console.WriteLine("\t\tPress ENTER to play the game");
            Console.WriteLine("\t\tPress ESCAPE to close the program");

            Console.WriteLine("\n  \t   The game lasts 1 minute 30 seconds maximum");

            key = Console.ReadKey(true);
            Console.Clear();
            if (key.Key == ConsoleKey.Enter)
            {
                t.Elapsed += new ElapsedEventHandler(OnTimer);
                t.Start(); // Начинает вызывать событие Elapsed
                do
                {
                    if (tmg.alive == false)
                    {
                        Console.Clear();
                        tmg.CurrentFace = tmg.DeadFace;
                        Console.WriteLine("Tamagotchi died ((((");
                        Console.WriteLine(tmg.CurrentFace);
                        break;
                    }

                    Console.WriteLine(tmg.CurrentFace);
                    tmg.Generate_event();
                    Console.Clear();

                } while (count < 90);
                if (count == 90) 
                {
                    Console.Clear();
                    Console.WriteLine("Game over! \n" +
                        "Tamagotchi left our world due to old age, being happy.");
                }
                break;
            }
            else if (key.Key == ConsoleKey.Escape)
                break;
        }
    }
    private static int count = 0;
    private static void OnTimer(object sender, ElapsedEventArgs arg /* Предоставляет данные для события Elapsed */)
    {

        System.Timers.Timer t = (System.Timers.Timer)sender;
        count++;
        if (count == 90)
            t.Stop();
        Console.Title = String.Format("{0}", arg.SignalTime);

    }
}

