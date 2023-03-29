namespace Banken;

class Program
{
    public static int menuIndex = 0;

    static void Main(string[] args)
    {
        //StartMenu;
    }

    static void StartMenu()
    {
        Console.CursorVisible = false;
    }

    private static int DrawMenu(List<string> menuItem, string menuMessage)
    {
        Console.Clear();
        Console.WriteLine(string.Empty);

        Console.WriteLine(menuMessage);
        Console.WriteLine(string.Empty);

        for (int i = 0; i < menuItem.Count; i++)
        {
            if (menuIndex == i)
            {
                Console.WriteLine($"[{menuItem[i]}]");
            }
            else
            {
                Console.WriteLine($" {menuItem[i]} ");
            }
        }

        ConsoleKeyInfo ckey = Console.ReadKey(); //Checks key input

        if (ckey.Key == ConsoleKey.DownArrow)
        {
            if (menuIndex == menuItem.Count - 1) { }
            else { menuIndex++; }
        }
        else if (ckey.Key == ConsoleKey.UpArrow)
        {
            if (menuIndex <= 0) { }
            else { menuIndex--; }
        }
        else if (ckey.Key == ConsoleKey.Enter)
        {
            return menuIndex;
        }
        else
        {
            return 100;
        }

        return 100;
    }

    static void Login()
    {
        string? name, password;

        int loginAttempts = 3; //The number of attempts that the user starts out with

        for (int i = 0; i < loginAttempts; i--) //The user has three attempts; using up all attempts will close the application
        {
            Console.WriteLine("\n Please enter your details");
            Console.Write($"\n First name: ");
            name = Console.ReadLine();

            Console.Write($" PIN code: ");
            password = Console.ReadLine();
        }
    }
}