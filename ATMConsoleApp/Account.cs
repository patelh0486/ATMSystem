using System;
using System.Collections.Generic;
using System.Text;

namespace ATMConsoleApp
{
    public class Account
    {
        private int accountNumber;
        private int pin;
        private decimal availableBalance;
        private decimal totalBalance;

        public Account(int TheaccountNumber, int Thepin, decimal TheavailableBalance, decimal ThetotalBalance)
        {
            accountNumber = TheaccountNumber;
            pin = Thepin;
            availableBalance = TheavailableBalance;
            totalBalance = ThetotalBalance;
        }

        public int AccountNumber
        {
            get { return accountNumber; }
        }
        public decimal AvailableBalance {
            get { return availableBalance; }
        }
        public decimal TotalBalance {
            get
            {
                return totalBalance;
            }
        }

        public bool ValidatePIN(int userPIN)
        {
            return (userPIN == pin);
        }

        public void Credit(decimal amount)
        {
            totalBalance += amount;
        }

        public void Debit(decimal amount)
        {
            availableBalance -= amount;
            totalBalance -= amount;
        }
    }
}
