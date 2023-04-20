namespace Banken
{
    public class AccountModel
    {
        readonly string? accountId;
        readonly string? accountName;
        readonly string? password;
        decimal balance = 0M;

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

        public string AccountIdCheck()
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

        public string AccountNameCheck()
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

        public string PasswordCheck()
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

        public decimal BalanceCheck()
        {
            return balance;
        }

        public void Transfer(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("This amount is negative. Please try again.");
            }
            else
            {
                balance += amount;
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("This amount is negative. Please try again.");
            }
            else if (amount > balance)
            {
                Console.WriteLine("This amount is larger than your current balance. Please try again.");
            }
            else
            {
                balance -= amount;
            }
        }
    }
}