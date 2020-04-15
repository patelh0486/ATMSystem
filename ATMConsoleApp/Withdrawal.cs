using System;
using System.Collections.Generic;
using System.Text;

namespace ATMConsoleApp
{
   public class Withdrawal: Transaction
    {
       
        private decimal amount;
        private Keypad keypad;
        private CashDispenser cashDispenser;
       

        private const int CANCELED = 6;
        public Withdrawal(int UseraccountNumber, Screen Atmscreen, BankDatabase AtmbankDataBase, Keypad Atmkeypad, CashDispenser AtmcashDispenser) :
            base(UseraccountNumber, Atmscreen, AtmbankDataBase)
        {
            keypad = Atmkeypad;
            cashDispenser = AtmcashDispenser;

        }

        public override void Execute()
        {
            bool cashDispensed = false;
            bool transactionCanceled = false;

            do
            {
                int selection = DisplayMenuOfAmounts();

                if (selection != CANCELED)
                {
                    amount = selection;
                    decimal availableBalance = Database.GetAvailableBalance(AccountNumber);
                    if (amount <= availableBalance)
                    {
                        if (cashDispenser.InsufficientCashAvailable(amount))
                        {
                            Database.Debit(AccountNumber, amount);
                            cashDispenser.DispenseCash(amount);
                            cashDispensed = true;
                            UserScreen.DisplayMessageLine("\n Please take your cash from the cashdispenser");
                        }
                        else
                        {
                            UserScreen.DisplayMessageLine("\nInsufficient cash available in ATM" +
                                "\n\n Please choose a smaller amount");
                        }
                    }
                    else
                    {
                        UserScreen.DisplayMessageLine("\nInsufficient cash available in your account"
                            + "\n\nPlease choose smaller amount");
                    }
                }
                else
                {
                    UserScreen.DisplayMessageLine("\nCancelling transaction");
                    transactionCanceled = true;
                }
            } while ((!cashDispensed) && (!transactionCanceled));
        }

        private int DisplayMenuOfAmounts()
        {
            int userChoice = 0;
            int[] amounts = {0,20,40,60,100, 120 };

            while(userChoice == 0)
            {
                UserScreen.DisplayMessageLine("\n Withdrawal Options :");
                UserScreen.DisplayMessageLine("1 - $20");
                UserScreen.DisplayMessageLine("2 - $40");
                UserScreen.DisplayMessageLine("3 - $60");
                UserScreen.DisplayMessageLine("4 - $100");
                UserScreen.DisplayMessageLine("5 - $120");
                UserScreen.DisplayMessageLine("6 - Cancel Transaction");
                UserScreen.DisplayMessageLine("\n choose a withdrawal option (1-6)");

                int input = keypad.GetInput();

                switch (input)
                {
                    case 1: case 2: case 3: case 4: case 5:
                        userChoice = amounts[input];
                        break;
                    case CANCELED:
                        userChoice = CANCELED;
                        break;
                    default:
                        UserScreen.DisplayMessageLine("\n Invalid selection, please try again!");
                        break;
                            
                }
            }
            return userChoice;
        }

                    
                      
                    }
                }
