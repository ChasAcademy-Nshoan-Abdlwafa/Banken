using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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

    class UserAccount //Class for the users' accounts
    {
        string username;
        string password;
        List<OpenedAccount> openedAccount = new List<OpenedAccount>();

        private UserAccount(string username, string password, List<OpenedAccount> moneyAccount)
        {
            this.username = username;
            this.password = password;
        }

        private string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string Password
        {
            get { return password; }
            set { password = value; }
        }

        private List<OpenedAccount> OpenedAccounts
        {
            get { return openedAccount; }
            set { openedAccount = value; }
        }
    }

    class OpenedAccount //Class for the users' opened bank accounts
    {
        private string accountName = "Bank account";
        private double balance = 0;

        private OpenedAccount(string accountname, double balance)
        {
            accountName = accountname;
            balance = balance;
        }

        private string AccountName
        {
            get { return accountName; }
            set { accountName = value; }
        }
        
        private double Balance
        {
            get { return balance; }
            set { balance = Math.Truncate(value * 100) / 100; }
        }
    }
}