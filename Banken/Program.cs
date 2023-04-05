using System.Security.Principal;

namespace Banken;

class Program
{
    public static int menuIndex = 0;

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        //StartMenu;
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
        accounts[0] = new AccountModel[0];
        accounts[1] = new AccountModel[1];
        accounts[2] = new AccountModel[2];
        accounts[3] = new AccountModel[3];
        accounts[4] = new AccountModel[4];

        accounts[0][0] = new AccountModel("Andreas", "Checking", "123", 1000);
        accounts[0][1] = new AccountModel("Andreas", "Salary", "123", 1000);
        accounts[0][2] = new AccountModel("Andreas", "Savings", "123", 1000,50);

        accounts[1][0] = new AccountModel("Bob", "Checking", "234", 1000);
        accounts[1][1] = new AccountModel("Bob", "Salary", "234", 1000);
        accounts[1][2] = new AccountModel("Bob", "Savings", "234", 1000,25);

        accounts[2][0] = new AccountModel("David", "Checking", "345", 1000);
        accounts[2][1] = new AccountModel("David", "Salary", "345", 1000);
        accounts[2][2] = new AccountModel("David", "Savings", "345", 1000,75);

        accounts[3][0] = new AccountModel("Erik", "Checking", "456", 1000);
        accounts[3][1] = new AccountModel("Erik", "Salary", "456", 1000);
        accounts[3][2] = new AccountModel("Erik", "Savings", "456", 1000,25);

        accounts[4][0] = new AccountModel("Gustav", "Checking", "567", 1000);
        accounts[4][1] = new AccountModel("Gustav", "Salary", "567", 1000);
        accounts[4][2] = new AccountModel("Gustav", "Savings", "567", 1000,50);

        string[] startMenu = new string[] //Array containing the startmenu options
        {
            "Log in",
            "Exit"
        };

        while (true)
        {
            int selectedMenuItem = DrawMenu(startMenu);

            switch (selectedMenuItem)
            {
                case 0:
                    Login(accounts);
                    break;

                case 1:
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
            "Accounts",
            "Transfer",
            "Withdraw",
            "Log out"
        };

        while (true)
        {
            int selectedMenuItem = DrawMenu(BankMenu);

            switch (selectedMenuItem)
            {
                case 0:
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

    static void TransferMenu(AccountModel[] currentUser)
    {
        string? input;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n Transfer options");

            for (int i = 0; i < currentUser.Length; i++)
            {
                Console.WriteLine($"{i}: {currentUser[i].GetAccountName()} {currentUser[i].BalanceCheck()}");
                input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out int index))
                {
                    Console.WriteLine($" Please enter the amount that you wish to transfer from {currentUser[index].GetAccountName()} ");

                    if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                    {
                        if (amount < 0)
                        {
                            Console.WriteLine("This amount is invalid. Please enter a valid number.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadLine();
                        }
                        else if (currentUser[index].BalanceCheck() - amount < 0)
                        {
                            Console.WriteLine("This amount is larger than your current account balance. Please try again.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Please enter the account number of the account that you would like to transfer to: ");

                            if (int.TryParse(Console.ReadLine(), out int account))
                            {
                                currentUser[index].Withdraw(amount);
                                currentUser[account].Transfer(amount);

                                Console.WriteLine($"{amount} has been successfully transferred from {currentUser[index].GetAccountName()} to {currentUser[account].GetAccountName()}");
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadLine();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You have entered an invalid account. Please try again.");
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadLine();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have entered an invalid amount. Please try again.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    //Console.WriteLine("You have entered an invalid account number. Please try again.");
                    //Console.WriteLine("Press any key to continue.");
                    //Console.ReadLine();
                }
            }
        }
    }
}