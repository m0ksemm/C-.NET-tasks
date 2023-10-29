using System.Collections;

//Классы
//o House (Дом), Basement(Фундамент), Walls
//(Стены), Door(Дверь), Window(Окно), Roof
//(Крыша);
//o Team(Бригада строителей), Worker
//(Строитель), TeamLeader(Бригадир).

// Интерфейсы
//o IWorker, IPart.


interface IWorker                     // Интерфейс для всех членов команды, для всех работников 
{
    string Name { get; set; }         // Имя
    string Surname { get; set; }      // Фамилия
    int WorkExperience { get; set; }  // Опыт работы в годах. Чем выше опыт работы,  
                                      // тем быстрее строитель будет строить дом
    void Work(IPart part);            // Способность всех строителей работать - строить какую-то
                                      // определённую часть дома. Для лидера команды - способность
                                      // делать отчёт о проделанной работе
}
interface IPart                     // Интерфейс для каждой части дома. 
{
    int Built { get; set; }          // Состояние части дома. Сколько уже
                                     // построено. 0 - ничего. 50 - готово.  
    bool IfBuilt();                 // Проверка части дома на готовность. 
}

class Builder : IWorker               // Класс строителя 
{
    private string name;
    private string surname;
    private int work_experience;
    #region Properties1
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
    public int WorkExperience
    {
        get
        {
            return work_experience;
        }
        set
        {
            if (value >= 0)
                work_experience = value;
            else work_experience = 0;
        }
    }
    #endregion
    public Builder()
    {
        name = "Taras";
        surname = "Robotyaga";
        work_experience = 7;
    }
    public Builder(string nm, string snm, int wex)
    {
        name = nm;
        surname = snm;
        work_experience = wex;
    }
    public void Work(IPart part)            // Метод для выполнения работы    
    {
        int value;                          // В зависимости от опыта работы,
        if (work_experience < 5)            // к состоянию части дома прибавляется  
            value = 5;                      // значание, какую часть уже построил 
        else if (work_experience < 10)      // строитель. 
            value = 10;
        else value = 15;

        part.Built += value;

        if (part.Built > 50)                // Если состояние части дома превышает
            part.Built = 50;                // 50, то происходит регуляция значения,
                                            // т.к. 50 это максимум. 
    }
    public void PrintInfo()                 // Метод выводит в консоль всю информацию о строителе. 
    {
        Console.WriteLine("//////////Builder//////////////");
        Console.WriteLine(" _______________________________");
        Console.WriteLine("| Name       | {0} ", Name);
        Console.WriteLine("| Surname    | {0}", Surname);
        Console.WriteLine("| Experience | {0}", Surname);
    }
}
class TeamLeader : IWorker              // Класс лидера строителей             
{
    private string name;
    private string surname;
    private int work_experience;
    private int result = 0;     // Поле, которое содержит информацию о том, какая часть роботы
                                // выполненеа. Держит лидера в курсе о проделанной работе
    public TeamLeader()
    {
        name = "Vasyl";
        surname = "Bossenko";
        work_experience = 10;
    }
    public TeamLeader(string nm, string snm, int wex)
    {
        name = nm;
        surname = snm;
        work_experience = wex;
    }
    #region Properties2
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
    public int WorkExperience
    {
        get
        {
            return work_experience;
        }
        set
        {
            if (value >= 0)
                work_experience = value;
            else work_experience = 0;
        }
    }
    #endregion
    public void Work(IPart part)
    {
        Console.WriteLine("The house is built for {0}%! ", result += part.Built / 5 * 2);
    }
    public void PrintInfo()
    {
        Console.WriteLine("//////////TeamLeader////////////");
        Console.WriteLine(" _______________________________");
        Console.WriteLine("| Name       | {0} ", Name);
        Console.WriteLine("| Surname    | {0}", Surname);
        Console.WriteLine("| Experience | {0}", Surname);
    }
}
class Basement : IPart                  // Фундамент.
{
    int built;
    public Basement() { built = 0; }
    public int Built
    {
        get
        {
            return built;
        }
        set
        {
            built = value;
        }
    }
    public bool IfBuilt()               // Метод для проверки, готов ли фундамент.
    {
        if (built == 50)
            return true;
        else if (built > 50)
        {
            built = 50;
            return true;
        }
        else return false;
    }
}                                       // дальше по анологии
class Walls : IPart
{
    int built;
    public int Built
    {
        get
        {
            return built;
        }
        set
        {
            built = value;
        }
    }
    public Walls() { built = 0; }
    public bool IfBuilt()
    {
        if (built == 50)
            return true;
        else if (built > 50)
        {
            built = 50;
            return true;
        }
        else return false;
    }
}
class Door : IPart
{
    int built;
    public int Built
    {
        get
        {
            return built;
        }
        set
        {
            built = value;
        }
    }
    public Door() { built = 0; }
    public bool IfBuilt()
    {
        if (built == 50)
            return true;
        else if (built > 50)
        {
            built = 50;
            return true;
        }
        else return false;
    }
}
class Roof : IPart
{
    int built;
    public Roof() { built = 0; }
    public int Built
    {
        get
        {
            return built;
        }
        set
        {
            built = value;
        }
    }
    public bool IfBuilt()
    {
        if (built == 50)
            return true;
        else if (built > 50)
        {
            built = 50;
            return true;
        }
        else return false;
    }
}
class Windows : IPart
{
    int built;
    public Windows() { built = 0; }
    public int Built
    {
        get
        {
            return built;
        }
        set
        {
            built = value;
        }
    }
    public bool IfBuilt()
    {
        if (built == 50)
            return true;
        else if (built > 50)
        {
            built = 50;
            return true;
        }
        else return false;
    }
}
class House                                         // Класс дом. Содержит в себе объекты на 
{                                                   // части дома Basement(Фундамент), Walls (Стены),
    protected Basement basement = new Basement();   // Door(Дверь), Window(Окно), Roof(Крыша); (композиция)
    protected Walls walls = new Walls();            // Также работает с командой строителей (агрегация) 
    protected Door door = new Door();
    protected Windows windows = new Windows();
    protected Roof roof = new Roof();
    protected Team team;
    public House()                          // Конструктор по умолчанию. Конструирует  
    {                                       // бригаду строителей самостоятельно
        team = new Team();
    }
    public House(Team t)                    // Конструктор с 1 параметром - командой строителей
    {
        team = t;
    }
    public void BuildTheBasement()          // Метод постройки фундамента
    {
        // Для начала в консоль выводятся имена/фамилии строителей, которые конструируют часть дома.
        Console.WriteLine("__________________________________________________");
        Console.Write("Builders ");
        Console.Write(team.worker1.Name); 
        Console.Write(" ");
        Console.Write(team.worker1.Surname);
        Console.Write(" and ");
        Console.Write(team.worker2.Name);
        Console.Write(" ");
        Console.Write(team.worker2.Surname);
        Console.WriteLine(" \nstart to build the basement. ");
        while (true)                                        // Затем запускается цикл, в котором каждый 
        {                                                   // строитель по очереди выполняет свою работу.
            if (basement.IfBuilt() == true)
                break;
            int tmp = basement.Built;                       
            team.worker1.Work(basement);
            System.Threading.Thread.Sleep(300);
            Console.Beep();
            for (int i = 0; i < (basement.Built - tmp); i++)
            {
                Console.Write("█");
            }
            if (HowMuchBuilt() == 20)
                break;
            tmp = basement.Built;
            team.worker1.Work(basement);
            System.Threading.Thread.Sleep(300);
            Console.Beep();
            for (int i = 0; i < (basement.Built - tmp); i++) 
            {
                Console.Write("█");
            }
            if (HowMuchBuilt() == 20)
                break;
        }
        Console.WriteLine();                // По завершению постройки части дома лидер команды 
        Console.Write("Team leader ");      // строителей делает отчёт о проделанной работе и 
        Console.Write(team.leader.Name);    // докладывает про готовность дома в процентах   
        Console.Write(" ");
        Console.Write(team.leader.Surname);
        Console.Write(" reports: \n");
        team.leader.Work(basement);
        System.Threading.Thread.Sleep(600);

    }
    public void BuildTheWalls()             // Со всеми остальными частями дома по анологии. 
    {
        Console.WriteLine("__________________________________________________");
        Console.Write("Builders ");
        Console.Write(team.worker3.Name);
        Console.Write(" ");
        Console.Write(team.worker3.Surname);
        Console.Write(" and ");
        Console.Write(team.worker4.Name);
        Console.Write(" ");
        Console.Write(team.worker4.Surname);
        Console.WriteLine(" \nstart to build the walls. ");
        while (true)
        {
            if (walls.IfBuilt() == true)
                break;
            int tmp = walls.Built;
            team.worker3.Work(walls);
            System.Threading.Thread.Sleep(300);
            Console.Beep();
            for (int i = 0; i < (walls.Built - tmp); i++)
            {
                Console.Write("█");
            }
            if (HowMuchBuilt() == 40)
                break;
            tmp = walls.Built;
            team.worker4.Work(walls);
            System.Threading.Thread.Sleep(300);
            Console.Beep();
            for (int i = 0; i < (walls.Built - tmp); i++)
            {
                Console.Write("█");
            }
            if (HowMuchBuilt() == 40)
                break;
        }
        Console.WriteLine();
        Console.Write("Team leader ");
        Console.Write(team.leader.Name);
        Console.Write(" ");
        Console.Write(team.leader.Surname);
        Console.Write(" reports: \n");
        team.leader.Work(basement);
        System.Threading.Thread.Sleep(600);
    }
    public void BuildTheDoor()    
    {
        Console.WriteLine("__________________________________________________");
        Console.Write("Builders ");
        Console.Write(team.worker1.Name);
        Console.Write(" ");
        Console.Write(team.worker1.Surname);
        Console.Write(" and ");
        Console.Write(team.worker2.Name);
        Console.Write(" ");
        Console.Write(team.worker2.Surname);
        Console.WriteLine(" \nstart to build the door. ");
        while (true)
        {
            if (door.IfBuilt() == true)
                break;
            int tmp = door.Built;
            team.worker3.Work(door);
            System.Threading.Thread.Sleep(300);
            Console.Beep();
            for (int i = 0; i < (door.Built - tmp); i++)
            {
                Console.Write("█");
            }
            if (HowMuchBuilt() == 60)
                break;
            tmp = door.Built;
            team.worker4.Work(door);
            System.Threading.Thread.Sleep(300);
            Console.Beep();
            for (int i = 0; i < (door.Built - tmp); i++)
            {
                Console.Write("█");
            }
            if (HowMuchBuilt() == 60)
                break;
        }
        Console.WriteLine();
        Console.Write("Team leader ");
        Console.Write(team.leader.Name);
        Console.Write(" ");
        Console.Write(team.leader.Surname);
        Console.Write(" reports: \n");
        team.leader.Work(basement);
        System.Threading.Thread.Sleep(600);
    }
    public void BuildTheWindows()
    {
        Console.WriteLine("__________________________________________________");
        Console.Write("Builders ");
        Console.Write(team.worker3.Name);
        Console.Write(" ");
        Console.Write(team.worker3.Surname);
        Console.Write(" and ");
        Console.Write(team.worker4.Name);
        Console.Write(" ");
        Console.Write(team.worker4.Surname);
        Console.WriteLine(" \nstart to build the windows. ");
        while (true)
        {
            if (windows.IfBuilt() == true)
                break;
            int tmp = windows.Built;
            team.worker3.Work(windows);
            System.Threading.Thread.Sleep(300);
            Console.Beep();
            for (int i = 0; i < (windows.Built - tmp); i++)
            {
                Console.Write("█");
            }
            if (HowMuchBuilt() == 80)
                break;
            tmp = windows.Built;
            team.worker4.Work(windows);
            System.Threading.Thread.Sleep(300);
            Console.Beep();
            for (int i = 0; i < (windows.Built - tmp); i++)
            {
                Console.Write("█");
            }
            if (HowMuchBuilt() == 80)
                break;
        }
        Console.WriteLine();
        Console.Write("Team leader ");
        Console.Write(team.leader.Name);
        Console.Write(" ");
        Console.Write(team.leader.Surname);
        Console.Write(" reports: \n");
        team.leader.Work(basement);
        System.Threading.Thread.Sleep(600);
    }
    public void BuildTheRoof()
    {
        Console.WriteLine("__________________________________________________");
        Console.WriteLine("The whole team starts to build the roof. ");
        while (true)
        {
            if (roof.IfBuilt() == true)
                break;
            int tmp = roof.Built;
            team.worker1.Work(roof);
            System.Threading.Thread.Sleep(300);
            Console.Beep();
            for (int i = 0; i < (roof.Built - tmp); i++)
            {
                Console.Write("█");
            }
            if (HowMuchBuilt() == 100)
                break;
            tmp = roof.Built;
            team.worker2.Work(roof);
            System.Threading.Thread.Sleep(300);
            Console.Beep();
            for (int i = 0; i < (roof.Built - tmp); i++)
            {
                Console.Write("█");
            }
            if (HowMuchBuilt() == 100)
                break;
            tmp = roof.Built;
            team.worker3.Work(roof);
            System.Threading.Thread.Sleep(300);
            Console.Beep();
            for (int i = 0; i < (roof.Built - tmp); i++)
            {
                Console.Write("█");
            }
            if (HowMuchBuilt() == 100)
                break;
            tmp = roof.Built;
            team.worker4.Work(roof);
            System.Threading.Thread.Sleep(300);
            Console.Beep();
            for (int i = 0; i < (roof.Built - tmp); i++)
            {
                Console.Write("█");
            }
            if (HowMuchBuilt() == 100)
                break;

        }
        Console.WriteLine();
        Console.Write("Team leader ");
        Console.Write(team.leader.Name);
        Console.Write(" ");
        Console.Write(team.leader.Surname);
        Console.Write(" reports: \n");
        team.leader.Work(basement);
        System.Threading.Thread.Sleep(600);
    }
    private int HowMuchBuilt()          // Метод, который возвращает проценты готовности дома
    {
        return ((basement.Built + walls.Built + door.Built + windows.Built + roof.Built) / 5 * 2);
    }
    public void BuildingTheHouse()      // Вызываются все методы поочереди, дом строится   
    {
        BuildTheBasement();
        BuildTheWalls();
        BuildTheDoor();
        BuildTheWindows();
        BuildTheRoof();
        ShowResult();
    }
    public void ShowResult()           // Результат выводится в консоль. Показывается дом, а после    
    {                                  // выводится информация про команду строителей
        Console.WriteLine("__________________________________________________");
        Console.WriteLine("                   House:\n");
        Console.WriteLine("                    ███");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("                  ███████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("              ██████████████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("           ████████████████████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("        ██████████████████████████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("     ████████████████████████████████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("    ██████████████████████████████████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("     ████████████████████████████████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("     ████░░░░██░░░░██████████████████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("     ████░░░░██░░░░███▒▒▒▒▒▒▒▒███████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("     ████░░░░██░░░░███▒▒▒▒▒▒▒▒███████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("     █████████████████▒▒▒░░▒▒▒███████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("     ████░░░░██░░░░███▒▒▒▒▒▒▒▒███████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("     ████░░░░██░░░░███▒▒▒▒▒▒▒▒███████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("     ████░░░░██░░░░███▒▒▒▒▒▒▒▒███████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("     █████████████████▒▒▒▒▒▒▒▒███████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("     █████████████████▒▒▒▒▒▒▒▒███████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("     █████████████████▓▓▓▓▓▓▓▓███████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("    █████████████████▓▓▓▓▓▓▓▓▓▓███████");
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("    ████████████████▓▓▓▓▓▓▓▓▓▓▓▓██████");
        System.Threading.Thread.Sleep(100);

        Console.WriteLine("\nThe team that built this house: ");
        team.ShowTeam();

    }
}
class Team              // Класс команды строителей. Включает в себя 1 лидера и 4 строителей
{
    public TeamLeader leader;
    public Builder worker1;
    public Builder worker2;
    public Builder worker3;
    public Builder worker4;

    public Team(TeamLeader l, Builder b1, Builder b2, Builder b3, Builder b4) 
    {
        leader = l;
        worker1 = b1;
        worker2 = b2;
        worker3 = b3;
        worker4 = b4;
    }
    public Team()
    {
        leader = new TeamLeader("Serhiy", "Shevchenko", 14);
        worker1 = new Builder("Olexiy", "Nesteruk", 7);
        worker2 = new Builder("Mykola", "Pirohov", 11);
        worker3 = new Builder("Olexandr", "Gusak", 6);
        worker4 = new Builder("Oleg", "Maystrenko", 4);
    }
    public void setMembers(TeamLeader l, Builder b1, Builder b2, Builder b3, Builder b4)  
    {                                   // Метод позволяет полностью заменить членов команды
        leader = l;
        worker1 = b1;
        worker2 = b2;
        worker3 = b3;
        worker4 = b4;
    }
    public void ShowTeam()              // Метод выводит информацию о всей команде
    {
        leader.PrintInfo();
        Console.WriteLine("=================================\n");
        System.Threading.Thread.Sleep(100);
        worker1.PrintInfo();
        Console.WriteLine("=================================\n");
        System.Threading.Thread.Sleep(100);
        worker2.PrintInfo();
        Console.WriteLine("=================================\n");
        System.Threading.Thread.Sleep(100);
        worker3.PrintInfo();
        Console.WriteLine("=================================\n");
        System.Threading.Thread.Sleep(100);
        worker4.PrintInfo();
        Console.WriteLine("=================================\n");
        System.Threading.Thread.Sleep(100);
    }
}




class MainClass 
{
    public static void Main() 
    {
        while (true)                // Клиент может использовать уже готовую команду,
        {                           // но может создать и свою. 
            Console.Clear();
            Console.WriteLine("1 - choose the default team");    
            Console.WriteLine("2 - create your  own team");
            Console.WriteLine("                            ESC - exit");

            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Escape)
                break;
            else if (key.Key == ConsoleKey.D1) 
            {
                Console.Clear();
                Console.WriteLine("Start!");

                Team brigade = new Team();
                House house = new House(brigade);
                house.BuildingTheHouse();
                Console.WriteLine("\n\n\nPress any key to continue");
                Console.ReadKey();
            }
            else if (key.Key == ConsoleKey.D2)
            {
                Console.Clear();

                Console.WriteLine("Leader: ");
                Console.Write("Name:       ");
                string name = Console.ReadLine();
                Console.Write("Surname:    ");
                string surname = Console.ReadLine();
                Console.Write("Experience: ");
                int years = Convert.ToInt32(Console.ReadLine());
                TeamLeader l = new TeamLeader(name, surname, years);
                Console.WriteLine("_______________________________");

                Console.WriteLine("\nBuilder 1: ");
                Console.Write("Name:       ");
                name = Console.ReadLine();
                Console.Write("Surname:    ");
                surname = Console.ReadLine();
                Console.Write("Experience: ");
                years = Convert.ToInt32(Console.ReadLine());
                Builder b1 = new Builder(name, surname, years);
                Console.WriteLine("_______________________________");

                Console.WriteLine("\nBuilder 2: ");
                Console.Write("Name:       ");
                name = Console.ReadLine();
                Console.Write("Surname:    ");
                surname = Console.ReadLine();
                Console.Write("Experience: ");
                years = Convert.ToInt32(Console.ReadLine());
                Builder b2 = new Builder(name, surname, years);
                Console.WriteLine("_______________________________");

                Console.WriteLine("\nBuilder 3: ");
                Console.Write("Name:       ");
                name = Console.ReadLine();
                Console.Write("Surname:    ");
                surname = Console.ReadLine();
                Console.Write("Experience: ");
                years = Convert.ToInt32(Console.ReadLine());
                Builder b3 = new Builder(name, surname, years);
                Console.WriteLine("_______________________________");

                Console.WriteLine("\nBuilder 4: ");
                Console.Write("Name:       ");
                name = Console.ReadLine();
                Console.Write("Surname:    ");
                surname = Console.ReadLine();
                Console.Write("Experience: ");
                years = Convert.ToInt32(Console.ReadLine());
                Builder b4 = new Builder(name, surname, years);
                Team brigade = new Team(l, b1, b2, b3, b4);
                Console.WriteLine("_______________________________");

                Console.Clear();
                Console.WriteLine("Start!");
                House house = new House(brigade);
                house.BuildingTheHouse();
                Console.WriteLine("\n\n\nPress any key to continue");
                Console.ReadKey();
            }
        }  
    }
}

