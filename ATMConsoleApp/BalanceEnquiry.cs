using System;
using System.Collections.Generic;
using System.Text;

namespace ATMConsoleApp
{
    public class BalanceEnquiry: Transaction
    {
        public BalanceEnquiry(int userAccountNumber, Screen atmScreen, BankDatabase atmBankDatabse) :
            base(userAccountNumber, atmScreen, atmBankDatabse){ }

        public override void Execute()
        {
            decimal availableBalance = Database.GetAvailableBalance(AccountNumber);
            decimal totalBalance = Database.GetTotalBalance(AccountNumber);

            UserScreen.DisplayMessageLine("\n Your Balance information: ");
            UserScreen.DisplayMessage("-Available balance: ");
            UserScreen.DisplayDollarAmount(availableBalance);
            UserScreen.DisplayMessage("\n -Total balance: ");
            UserScreen.DisplayDollarAmount(totalBalance);
            UserScreen.DisplayMessageLine("");

        }
    }
}
