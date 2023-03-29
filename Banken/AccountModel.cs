namespace Banken
{
    public class AccountModel
    {
        string? accountId;
        string? accountName;
        string? password;
        decimal balance = 0;

        public AccountModel(string? accountId, string? accountName, string? password, decimal balance)
        {
            this.accountId = accountId;
            this.accountName = accountName;
            this.password = password;
            this.balance = balance;
        }

        public void AccountInfo()
        {
            Console.WriteLine("accountId: {0}", accountId);
            Console.WriteLine("accountName {0}", accountName);
            Console.WriteLine("balance {0}", balance);
        }

        string GetAccountId()
        {
            if (accountId == null)
            {
                return "";
            }
            else
            {
                return accountId;
            }
        }

        string GetAccountName()
        {
            if (accountName == null)
            {
                return "";
            }
            else
            {
                return accountName;
            }
        }

        string GetPassword()
        {
            if (password == null)
            {
                return "";
            }
            else
            {
                return password;
            }
        }

        decimal BalanceCheck()
        {
            return balance;
        }

        void Transfer(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("This amount is negative.");
            }
            else
            {
                balance += amount;
            }
        }

        void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("This amount is negative.");
            }
            else if (amount >= balance)
            {
                    Console.WriteLine("This amount is larger than your current balance.");
            }
            else
            {
                balance -= amount;
            }
        }
    }
}