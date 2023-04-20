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
        Console.WriteLine("Welcome to the bank. Please select an option: \n");

        for (int i = 0; i < item.Length; i++)
        {
            if (menuIndex == i)
            {
                Console.WriteLine($"[{item[i]}]");
            }
            else
            {
                Console.WriteLine($"{item[i]}");
            }
        }

        ConsoleKeyInfo ckey = Console.ReadKey(); //Looks for user key input

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

    public static void StartMenu() //This is the first menu that the user is shown and contains login and exit options
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
        accounts[1][2] = new AccountModel("Bob", "Savings #1", "234", 5000.25M);
        accounts[1][3] = new AccountModel("Bob", "Savings #2", "234", 5000.25M);

        accounts[2][0] = new AccountModel("David", "Checking", "345", 1000M);
        accounts[2][1] = new AccountModel("David", "Salary", "345", 1750M);
        accounts[2][2] = new AccountModel("David", "Savings #1", "345", 7500.75M);
        accounts[2][3] = new AccountModel("David", "Savings #2", "345", 7500.75M);
        accounts[2][4] = new AccountModel("David", "Savings #3", "345", 7500.75M);

        accounts[3][0] = new AccountModel("Erik", "Checking", "456", 1000M);
        accounts[3][1] = new AccountModel("Erik", "Salary", "456", 2000M);
        accounts[3][2] = new AccountModel("Erik", "Savings #1", "456", 10000.25M);
        accounts[3][3] = new AccountModel("Erik", "Savings #2", "456", 10000.25M);

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
                    Console.WriteLine("Shutting down application.");
                    Environment.Exit(0);
                    break;
            }
        }
    }

    public static void Login(AccountModel[][] accounts) //This is where the user will log in to the bank
    {
        string? input;
        int loginAttempts = 0; //The user starts out at zero login attempts
        //int loginAttemptsLeft = 2; //Amount of login attempts left starts at two and goes down to zero once three failed login attempts has been made

        while (loginAttempts < 3) //This keeps looping as long as the user hasn't failed at least three login attempts
        {
            Console.Clear();
            Console.WriteLine("Please enter the name of your account: ");
            input = Console.ReadLine();

            for (int i = 0; i < accounts.Length; i++)
            {
                if (input == accounts[i][0].AccountIdCheck())
                {
                    Console.WriteLine("\nPlease enter the password of your account: ");
                    input = Console.ReadLine();

                    if (input == accounts[i][0].PasswordCheck())
                    {
                        Console.WriteLine("\nLogin successful.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        BankMenu(accounts[i][0].AccountIdCheck(), accounts);
                        loginAttempts = 5;
                        break;
                    }
                }
            }
            Console.WriteLine("\nLogin attempt failed!");
            //Console.WriteLine($"You have failed {loginAttempts + 1} login attempt(s). \nYou have {loginAttemptsLeft} login attempt(s) left.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            loginAttempts++;
            //loginAttemptsLeft--;
        }
        if (loginAttempts == 3)
        {
            Console.WriteLine("You have used up all of your login attempts. Shutting down application.");
            Environment.Exit(0);
        }
    }

    public static void BankMenu(string id, AccountModel[][] accounts) //This is the bank menu that contains all of the bank options
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
                    Console.WriteLine("Accounts and balances\n");

                    for (int i = 0; i < accounts.Length; i++)
                    {
                        if (accounts[i][0].AccountIdCheck() == id)
                        {
                            currentUser = accounts[i];

                            for (int j = 0; j < currentUser.Length; j++)
                            {
                                Console.WriteLine($"{j + 1}: {currentUser[j].AccountNameCheck()} - {currentUser[j].BalanceCheck()}");
                            }
                        }
                    }
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadLine();
                    break;

                case 1:
                    Console.Clear();

                    for (int t = 0; t < accounts.Length; t++)
                    {
                        if (accounts[t][0].AccountIdCheck() == id)
                        {
                            TransferMenu(accounts[t]);
                        }
                    }
                    break;

                case 2:
                    Console.Clear();

                    for (int w = 0; w < accounts.Length; w++)
                    {
                        if (accounts[w][0].AccountIdCheck() == id)
                        {
                            WithdrawMenu(accounts[w]);
                        }
                    }
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("\nLogging out.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                    menuIndex = 0;
                    return;
            }
        }
    }

    public static void TransferMenu(AccountModel[] currentUser) //This is where the user can transfer money between several accounts
    {
        string? input;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Transfer\n");

            for (int i = 0; i < currentUser.Length; i++)
            {
                Console.WriteLine($"{i}: {currentUser[i].AccountNameCheck()} {currentUser[i].BalanceCheck()}");
            }

            Console.WriteLine("\nPlease enter the number of the account you wish to transfer from.\nType exit to return to the main menu.\n");
            input = Console.ReadLine();

            if (input.ToLower() == "exit") //If the user types in a capital E it will then be converted to a lowercase e
            {
                Console.WriteLine("\nExiting the transfer menu.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
                break;
            }
            else if (string.IsNullOrWhiteSpace(input)) //The user will be returned to the main menu if the input is empty or null
            {
                Console.WriteLine("No inputs detected.\nReturning to main menu.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
                break;
            }
            else if (int.TryParse(input, out int index))
            {
                Console.WriteLine($"\nPlease enter the amount you wish to transfer from {currentUser[index].AccountNameCheck()}:");
                if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    if (amount < 0)
                    {
                        Console.WriteLine("\nThis amount is negative. Please try again.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                    }
                    else if (currentUser[index].BalanceCheck() - amount < 0)
                    {
                        Console.WriteLine("\nThis amount is larger than the current balance of this account. Please try again.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("\nPlease enter the number of the account you wish to transfer to: ");
                        if (int.TryParse(Console.ReadLine(), out int account))
                        {
                            currentUser[index].Withdraw(amount);
                            currentUser[account].Transfer(amount);
                            Console.WriteLine($"\nSuccess! {amount} has been transferred from {currentUser[index].AccountNameCheck()} to {currentUser[account].AccountNameCheck()}.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nYou have entered an invalid account number. Please try again.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nYou have entered an invalid amount. Please try again.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("\nYou have entered an invalid account number. Please try again.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
        }
    }

    public static void WithdrawMenu(AccountModel[] currentUser) //This is where the user can withdraw money from an account
    {
        string? input;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Withdraw\n");

            for (int i = 0; i < currentUser.Length; i++)
            {
                Console.WriteLine($"{i}: {currentUser[i].AccountNameCheck()} {currentUser[i].BalanceCheck()}");
            }

            Console.WriteLine("\nPlease enter the number of the account you wish to withdraw from.\nType exit to return to the main menu.\n");
            input = Console.ReadLine();

            if (input.ToLower() == "exit") //If the user types in a capital E it will then be converted to a lowercase e
            {
                Console.WriteLine("\nExiting the withdraw menu.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
                break;
            }
            else if (string.IsNullOrWhiteSpace(input)) //The user will be returned to the main menu if the input is empty or null
            {
                Console.WriteLine("No inputs detected.\nReturning to main menu.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
                break;
            }
            else if (int.TryParse(input, out int accountNumber))
            {
                Console.WriteLine($"\nPlease enter the amount you wish to withdraw from {currentUser[accountNumber].AccountNameCheck()}:");
                if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    if (amount < 0)
                    {
                        Console.WriteLine("\nThis amount is negative. Please try again.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                    }
                    else if (currentUser[accountNumber].BalanceCheck() - amount < 0)
                    {
                        Console.WriteLine("\nThis amount is larger than the current balance of this account. Please try again.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                    }
                    else
                    {
                        currentUser[accountNumber].Withdraw(amount);
                        Console.WriteLine($"\nSuccess! {amount} has been withdrawn from {currentUser[accountNumber].AccountNameCheck()}.");
                        Console.WriteLine($"The updated balance of account {currentUser[accountNumber].AccountNameCheck()} is now {currentUser[accountNumber].BalanceCheck()}.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nYou have entered an invalid account number. Please try again.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
        }
    }
}