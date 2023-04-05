﻿namespace Banken
{
    public class AccountModel
    {
        string? accountId;
        string? accountName;
        string? password;
        double balance = 0;

        public AccountModel(string? accountId, string? accountName, string? password, double balance)
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

        public string GetAccountId()
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

        public string GetAccountName()
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

        public string GetPassword()
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

        public double BalanceCheck()
        {
            return balance;
        }

        public void Transfer(double amount)
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

        public void Withdraw(double amount)
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