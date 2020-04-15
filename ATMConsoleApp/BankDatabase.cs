using System;
using System.Collections.Generic;
using System.Text;

namespace ATMConsoleApp
{
   public class BankDatabase
    {
        private Account[] accounts;
        public BankDatabase()
        {
            accounts = new Account[2];
            accounts[0] = new Account (12345, 54321,  1000.00M, 1200.00M );
            accounts[0] = new Account(98765, 56789, 200.00M, 200.00M);
        }

        private static  List<Account> _database = new List<Account>()
        {
            new Account(12345, 5432, 2000.00m, 3200.00m),
            new Account(98765, 5678, 1000.00m, 1000.00m),
        };
        private Account GetAccount(int accountNumber)
        {
            foreach( Account currentAccount in _database)
            {
                if(currentAccount.AccountNumber == accountNumber)
                {
                    return currentAccount;
                }
            }
           return null;
        }
        
        public bool AuthenticateUser(int userAccountNumber, int userPin)
        {
            Account userAccount = GetAccount(userAccountNumber);
            if (userAccount != null)
            {
                return userAccount.ValidatePIN(userPin);
            }
            else
                return false;
        }

        public decimal GetAvailableBalance(int userAccountNumber)
        {
            Account userAccount = GetAccount(userAccountNumber);           
                return userAccount.AvailableBalance;            
        }

        public decimal GetTotalBalance(int userAccountNumber)
        {
            Account userAccount = GetAccount(userAccountNumber);
            return userAccount.TotalBalance;
        }

        public void Credit(int userAccountNumber, decimal amount)
        {
            Account userAccount = GetAccount(userAccountNumber);
            userAccount.Credit(amount);
        }

        public void Debit(int userAccountNumber, decimal amount)
        {
            Account userAccount = GetAccount(userAccountNumber);
            userAccount.Debit(amount);
        }
    }
}
