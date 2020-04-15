using System;
using System.Collections.Generic;
using System.Text;

namespace ATMConsoleApp
{
    public class CashDispenser
    {
        private const int INITIAL_COUNT = 500;
        private int billCount;

        public CashDispenser()
        {
            billCount = INITIAL_COUNT;
        }

        public void DispenseCash(decimal amount)
        {
            int billRequired = ((int)amount) / 20;
            billCount -= billRequired;
        }

        public bool InsufficientCashAvailable(decimal amount)
        {
            int billRequired = ((int)amount) / 20;
            return (billCount >= billRequired);
        }

    }
}
