using System.Security.Principal;

namespace Banken;

class Program
{
    public static int menuIndex = 0;

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        StartMenu;
    }

    public static int DrawMenu(string[] item)
    {
        Console.Clear();
        Console.WriteLine("\n Hello! Welcome to the bank. Please select an option: ");

        for (int i = 0; i < item.Length; i++)
        {
            if (menuIndex == i)
            {
                Console.WriteLine($"[{item[i]}]");
            }
            else
            {
                Console.WriteLine($" {item[i]} ");
            }
        }

        ConsoleKeyInfo ckey = Console.ReadKey(); //Checks key input

        if (ckey.Key == ConsoleKey.DownArrow)
        {
            if (menuIndex == item.Length - 1) { }
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

    static void StartMenu()
    {
        AccountModel[][] accounts = new AccountModel[5][]; //Declarations of the users' accounts
        accounts[0] = new AccountModel[1];
        accounts[1] = new AccountModel[2];
        accounts[2] = new AccountModel[3];
        accounts[3] = new AccountModel[4];
        accounts[4] = new AccountModel[5];

        accounts[0][0] = new AccountModel("Andreas", "Checking", "123", 1000);
        accounts[0][1] = new AccountModel("Andreas", "Salary", "123", 1000);
        accounts[0][2] = new AccountModel("Andreas", "Savings", "123", 1000.50);

        accounts[1][0] = new AccountModel("Bob", "Checking", "234", 1000);
        accounts[1][1] = new AccountModel("Bob", "Salary", "234", 1000);
        accounts[1][2] = new AccountModel("Bob", "Savings", "234", 1000.25);

        accounts[2][0] = new AccountModel("David", "Checking", "345", 1000);
        accounts[2][1] = new AccountModel("David", "Salary", "345", 1000);
        accounts[2][2] = new AccountModel("David", "Savings", "345", 1000.75);

        accounts[3][0] = new AccountModel("Erik", "Checking", "456", 1000);
        accounts[3][1] = new AccountModel("Erik", "Salary", "456", 1000);
        accounts[3][2] = new AccountModel("Erik", "Savings", "456", 1000.25);

        accounts[4][0] = new AccountModel("Gustav", "Checking", "567", 1000);
        accounts[4][1] = new AccountModel("Gustav", "Salary", "567", 1000);
        accounts[4][2] = new AccountModel("Gustav", "Savings", "567", 1000.50);

        string[] startMenu = new string[] //Array containing the startmenu options
        {
            "Log in", "Exit"
        };

        while (true)
        {
            string selectedMenuItem = DrawMenu(startMenu);

            switch (selectedMenuItem)
            {
                case "Log in":
                    Login(accounts);
                    break;

                case "Exit":
                    Console.Clear();
                    Console.WriteLine("Exiting application.");
                    Environment.Exit(0);
                    break;
            }
        }
    }

    static void BankMenu(string id, AccountModel[][] accounts)
    {
        AccountModel[] currentUser;

        string[] BankMenu = new string[] //Array containing the bankmenu options
        {
            "Accounts", "Transfer", "Withdraw", "Log out"
        };

        while (true)
        {
            string selectedMenuItem = DrawMenu(BankMenu);

            switch (selectedMenuItem)
            {
                case "Accounts":
                    Console.Clear();
                    Console.WriteLine("\n Accounts");

                    for (int i = 0; i < accounts.Length; i++)
                    {
                        if (accounts[i][0].GetAccountId() == id)
                        {
                            currentUser = accounts[i];

                            for (int j = 0; j < currentUser.Length; j++)
                            {
                                Console.WriteLine($"{j + 1}: {currentUser[j].GetAccountName()} - {currentUser[j].BalanceCheck()}");
                            }
                        }
                    }

                    Console.WriteLine("\n Press any key to continue.");
                    Console.ReadLine();
                    break;


            }
        }
    }
}