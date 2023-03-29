using System.Security.Principal;

namespace Banken;

class Program
{
    private static int menuIndex = 0;

    private static void Main(string[] args)
    {
        StartMenu();
    }

    private static void StartMenu()
    {
        Console.CursorVisible = false;

        string menuMessage = " Hello and welcome to the bank. \n Please select an option: ";

        List<string> menuItems = new()
            {
                "Log in",
                "Exit"
            };

        while (true)
        {
            int selectedMenuItem = DrawMenu(menuItems, menuMessage);
            switch (selectedMenuItem)
            {
                case 0:
                    Console.Clear();
                    Login();
                    break;

                case 1:
                    Console.Clear();
                    Exit();
                    break;
            }
        }
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

    private static void Login()
    {

    }

    private static void Exit()
    {
        Console.Clear();
        Console.WriteLine("\n Exiting application.");
        Environment.Exit(0);
    }
}