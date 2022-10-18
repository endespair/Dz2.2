public abstract class Worker
{
    public string name;

    public string position;

    public int workDay;

    public Worker(string Name)
    {
        name = Name;
    }

    public void Call()
    {
    }

    public void WriteCode()
    {
    }

    public void Relax()
    {
    }

    public abstract void FillWorkDay();
}

public class Developer : Worker
{
    public Developer(string Name) : base(Name)
    {
        position = "Developer";
    }

    public override void FillWorkDay()
    {
        WriteCode();
        Call();
        Relax();
        WriteCode();
    }
}

public class Manager : Worker
{
    private Random random;
    public Manager(string Name) : base(Name)
    {
        position = "Manager";
    }


    public override void FillWorkDay()
    {
        random = new Random();
        for (int i = 0; i < random.Next(1, 10); i++)
        {
            Call();
        }
        Relax();
        for (int i = 0; i < random.Next(1, 5); i++)
        {
            Call();
        }
    }
}

public class Team
{
    private string Name;
    private List<Worker> workers = new List<Worker>();
    public Team(string Name)
    {
        this.Name = Name;
    }


    public void AddEmployee(Worker worker)
    {
        workers.Add(worker);
    }


    public void ShortInfo()
    {
        Console.WriteLine($"Team name: {Name}");
        foreach (var people in workers)
        {
            Console.WriteLine(people.name);
        }
    }

    public void LongInfo()
    {
        Console.WriteLine($"Team name: {Name}");
        foreach (var people in workers)
        {
            Console.WriteLine($"Name:{people.name} - Position:{people.position} - WorkDay:{people.workDay}");
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        string choice, name, position, tName;
        Console.Write("Enter team name: ");
        tName = Console.ReadLine();

        Team team = new Team(tName);

        do
        {
            Console.Write("Enter position: ");
            position = Console.ReadLine();

            if (position == "Developer")
            {
                Console.Write("Enter name: ");
                name = Console.ReadLine();
                var dev = new Developer(name);
                Console.Write("Enter WorkDay: ");
                dev.workDay = Convert.ToInt32(Console.ReadLine());
                team.AddEmployee(dev);
            }
            else
            {
                Console.Write("Enter name: ");
                name = Console.ReadLine();
                var manager = new Manager(name);
                Console.Write("Enter WorkDay: ");
                manager.workDay = Convert.ToInt32(Console.ReadLine());
                team.AddEmployee(manager);
            }
            Console.Write("Add a new member?(yes/no): ");
            choice = Console.ReadLine();
        } while (choice != "no");

        Console.Write("Show detailed information?(yes/no): ");
        choice = Console.ReadLine();
        if (choice == "yes")
        {
            team.LongInfo();
        }
        else
        {
            team.ShortInfo();
        }
    }
}