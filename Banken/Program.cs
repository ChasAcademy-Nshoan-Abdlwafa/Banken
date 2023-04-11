using System.Security.Principal;

namespace Banken;

public class Program
{
    public static int menuIndex = 0;

    public static void Main(string[] args)
    {
        Console.CursorVisible = false;
        StartMenu();
    }

    public static int DrawMenu(string[] item)
    {
        Console.Clear();
        Console.WriteLine("\n Welcome to the bank. Please select an option: ");

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

        ConsoleKeyInfo ckey = Console.ReadKey(); //Checks user key input

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

    public static void StartMenu()
    {
        AccountModel[][] accounts = new AccountModel[5][]; //Declarations of the users' accounts
        accounts[0] = new AccountModel[3];
        accounts[1] = new AccountModel[4];
        accounts[2] = new AccountModel[5];
        accounts[3] = new AccountModel[6];
        accounts[4] = new AccountModel[7];

        accounts[0][0] = new AccountModel("Andreas", "Checking", "123", 1000M);
        accounts[0][1] = new AccountModel("Andreas", "Salary", "123", 1250M);
        accounts[0][2] = new AccountModel("Andreas", "Savings", "123", 2500.50M);

        accounts[1][0] = new AccountModel("Bob", "Checking", "234", 1000M);
        accounts[1][1] = new AccountModel("Bob", "Salary", "234", 1500M);
        accounts[1][2] = new AccountModel("Bob", "Savings", "234", 5000.25M);

        accounts[2][0] = new AccountModel("David", "Checking", "345", 1000M);
        accounts[2][1] = new AccountModel("David", "Salary", "345", 1750M);
        accounts[2][2] = new AccountModel("David", "Savings", "345", 7500.75M);

        accounts[3][0] = new AccountModel("Erik", "Checking", "456", 1000M);
        accounts[3][1] = new AccountModel("Erik", "Salary", "456", 2000M);
        accounts[3][2] = new AccountModel("Erik", "Savings", "456", 10000.25M);

        accounts[4][0] = new AccountModel("Gustav", "Checking", "567", 1000M);
        accounts[4][1] = new AccountModel("Gustav", "Salary", "567", 2250M);
        accounts[4][2] = new AccountModel("Gustav", "Savings", "567", 12500.50M);

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
                    Console.WriteLine("\n Shutting down application.");
                    Environment.Exit(0);
                    break;
            }
        }
    }

    public static void Login(AccountModel[][] accounts)
    {
        string? input;
        int loginAttempts = 0; //The user starts out at zero login attempts
        int loginAttemptsUsed = 1;
        int loginAttemptsLeft = 2;

        while (loginAttempts < 3) //This keeps looping as long as the user hasn't failed at least three login attempts
        {
            Console.Clear();
            Console.WriteLine("\n Please enter the name of your account: ");
            input = Console.ReadLine();

            for (int i = 0; i < accounts.Length; i++)
            {
                if (input == accounts[i][0].GetAccountId())
                {
                    Console.WriteLine("\n Please enter the password of your account: ");
                    input = Console.ReadLine();

                    if (input == accounts[i][0].GetPassword())
                    {
                        BankMenu(accounts[i][0].GetAccountId(), accounts);
                        loginAttempts = 4;
                    }
                }
            }
            Console.WriteLine("\n Login attempt failed. Please try again.");
            Console.WriteLine($"\n You have used up {loginAttemptsUsed} login attempt(s). \n You have {loginAttemptsLeft} login attempt(s) left.");
            Console.WriteLine("\n Press any key to continue.");
            Console.ReadLine();
            loginAttempts++;
            loginAttemptsUsed++;
            loginAttemptsLeft--;
        }
        if (loginAttempts == 3)
        {
            Console.WriteLine(" You have used up all of your login attempts. Shutting down application.");
            Environment.Exit(0);
        }
    }

    public static void BankMenu(string id, AccountModel[][] accounts)
    {
        AccountModel[] currentUser;

        string[] BankMenu = new string[] //Array containing the bankmenu options
        {
            "Accounts and balances",
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
                    Console.WriteLine("Accounts and balances");

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

                case 1:
                    //Console.Clear();
                    Console.WriteLine("\n Transfer");

                    for (int h = 0; h < accounts.Length; h++)
                    {
                        if (accounts[h][0].GetAccountId() == id)
                        {
                            TransferMenu(accounts[h]);
                        }
                    }
                    break;

                //case 2: Withdraw will go here

                case 3:
                    Console.Clear();
                    Console.WriteLine("\n You will now be logged out.");
                    Console.WriteLine("\n Press any key to continue.");
                    Console.ReadLine();
                    menuIndex = 0;
                    return;


            }
        }
    }

    public static void TransferMenu(AccountModel[] currentUser)
    {
        string? input;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Transfer");

            for (int i = 0; i <  currentUser.Length; i++)
            {
                Console.WriteLine($"{i}: {currentUser[i].GetAccountName()} {currentUser[i].BalanceCheck()}");
            }

            Console.WriteLine("\n Please enter the number of the account that you wish to transfer from.\n You can also exit the transfer menu by typing in e/E.");
            input = Console.ReadLine();

            if (input.ToLower() == "e") //If the user types in a capital E it will then be converted to a lowercase e
            {
                Console.WriteLine(" Exiting the transfer menu.");
                Console.WriteLine(" Press any key to continue.");
                Console.ReadLine();
                break;
            }
            else if (input == null)
            {
                break;
            }
            else if (int.TryParse(input, out int index))
            {
                Console.WriteLine($"\n Please enter the amount you wish to transfer from {currentUser[index].GetAccountName()}");
                if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    if (amount < 0)
                    {
                        Console.WriteLine(" This amount is negative. Please try again.");
                        Console.WriteLine(" Press any key to continue.");
                        Console.ReadLine();
                    }
                    else if (currentUser[index].BalanceCheck() - amount < 0)
                    {
                        Console.WriteLine(" This amount is larger than the current balance of this account. Please try again.");
                        Console.WriteLine(" Press any key to continue.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("\n Please enter the number of the account you wish to transfer to: ");
                        if (int.TryParse(Console.ReadLine(), out int account))
                        {
                            currentUser[index].Withdraw(amount);
                            currentUser[account].Transfer(amount);
                            Console.WriteLine($" Success! {amount} has been transferred from {currentUser[index].GetAccountName()} to {currentUser[account].GetAccountName()}");
                            Console.WriteLine(" Press any key to continue.");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n You have entered an invalid account number. Please try again.");
                            Console.WriteLine(" Press any key to continue.");
                            Console.ReadLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n You have entered an invalid amount. Please try again.");
                    Console.WriteLine(" Press any key to continue.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("\n You have entered an invalid account number. Please try again.");
                Console.WriteLine(" Press any key to continue.");
                Console.ReadLine();
            }
        }
    }
}