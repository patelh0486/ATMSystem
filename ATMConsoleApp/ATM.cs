using System;
using System.Collections.Generic;
using System.Text;

namespace ATMConsoleApp
{
    public class ATM
    {
        private bool userAuthenticate;
        private int currentAccountNmber;

        private Screen screen;
        private Keypad keypad;
        private CashDispenser cashDispenser;
        private DepositSlot depositSlot;
        private BankDatabase bankDataBase;

        private enum MenuOption
        {
            BALANCE_INQUIRY = 1,
            WITHDRAW = 2,
            DEPOSIT=3,
            EXIT_ATM = 4
        }

        public ATM()
        {
            userAuthenticate =  false;
            currentAccountNmber = 0;
            screen = new Screen();
            keypad = new Keypad();
            cashDispenser = new CashDispenser();
            depositSlot = new DepositSlot();
            bankDataBase = new BankDatabase();
        }

        public void Run()
        {
            while (true)
            {
                while (!userAuthenticate)
                {
                    screen.DisplayMessageLine("\n WELCOME");
                    AuthenticateUser();
                }
                PerformTransaction();
                userAuthenticate = false;
                currentAccountNmber = 0;
                screen.DisplayMessageLine("\nThank you! Good bye. ");

            }
        }

        private void AuthenticateUser()
        {
            screen.DisplayMessage("\n Please enter your account number: ");
           int accountNumber =  keypad.GetInput();
            screen.DisplayMessage("\nEenter PIN: ");
            int pin = keypad.GetInput();

            userAuthenticate = bankDataBase.AuthenticateUser(accountNumber, pin);
            if (userAuthenticate)
            {
                currentAccountNmber = accountNumber;
            }
            else
            {
                screen.DisplayMessageLine("\n invalid account number or pin. Please try again.");
            }
        }

        private void PerformTransaction()
        {
            Transaction currentTransaction;
            bool userExited = false;
            while (!userExited)
            {
                int mainMenuSelection = DisplayMainMenu();
                switch((MenuOption)mainMenuSelection)
               {
                    case MenuOption.BALANCE_INQUIRY:
                    case MenuOption.WITHDRAW:
                    case MenuOption.DEPOSIT:
                        currentTransaction = CreateTransaction(mainMenuSelection);
                        currentTransaction.Execute();
                        break;
                    case MenuOption.EXIT_ATM:
                        screen.DisplayMessageLine("\n You are exiting the system");
                        break;
                    default: screen.DisplayMessageLine("\n You did not select valid option. Try again ");
                        break;

                }
            }
        }

        public int DisplayMainMenu()
        {
            screen.DisplayMessageLine("\n Main menu ");
            screen.DisplayMessageLine("1- View my balance: ");
            screen.DisplayMessageLine("2- withdraw cash: ");
            screen.DisplayMessageLine("3- Deposit cash: ");
            screen.DisplayMessageLine("4- Exit: \n");
            screen.DisplayMessage("Enter a choice: ");
            return keypad.GetInput();
        }
        private Transaction CreateTransaction(int type)
        {
            Transaction temp = null;
            switch ((MenuOption)type)
            {
                case MenuOption.BALANCE_INQUIRY:
                    temp = new BalanceEnquiry(currentAccountNmber, screen, bankDataBase);
                    break;
                case MenuOption.WITHDRAW:
                    temp = new Withdrawal(currentAccountNmber, screen, bankDataBase, keypad, cashDispenser);
                    break;
                case MenuOption.DEPOSIT:
                    temp = new Deposit(currentAccountNmber, screen, bankDataBase, keypad, depositSlot);
                    break;
            }    
            return temp;
        }
            
    }
}
