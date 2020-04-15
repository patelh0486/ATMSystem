using System;
using System.Collections.Generic;
using System.Text;

namespace ATMConsoleApp
{
    class Deposit: Transaction
    {
        
        private decimal amount;
        private Keypad keypad;
        private DepositSlot depositSlot;
      

        private const int CANCELED = 0;
        public Deposit(int UseraccountNumber, Screen Atmscreen, BankDatabase AtmbankDataBase, Keypad Atmkeypad, DepositSlot AtmdepositSlot) :
            base(UseraccountNumber, Atmscreen, AtmbankDataBase)
        {
            keypad = Atmkeypad;
            depositSlot = AtmdepositSlot;

        }

        public override void Execute()
        {
            amount = PromptForDepositAmount();

            if (amount != CANCELED)
            {
                UserScreen.DisplayMessage("\n Please insert a deposit envelope containing ");
                UserScreen.DisplayDollarAmount(amount);
                UserScreen.DisplayMessageLine(" in deposit slot. ");

                bool envelopeReceived = depositSlot.IsDepositEnvelopeReceived();

                if (envelopeReceived)
                {
                    UserScreen.DisplayMessageLine("\n Your envelope has been received. \n" +
                        " The money just deposited will not be available until we verify it. ");
                    Database.Credit(AccountNumber, amount);
                }
                else
                {
                    UserScreen.DisplayMessageLine("\nYou did not inserted envelope in ATM, " +
                        "\n So ATM has canceled ypur transaction. ");
                }
            }         
                
                else
                {
                    UserScreen.DisplayMessageLine("\nCancelling transaction......");
                    
                }
            
        }

        private decimal PromptForDepositAmount()
        {
           
            
                UserScreen.DisplayMessageLine("\n Please input deposit amount in cents or (0 to cancel). ");

            int input = keypad.GetInput();

            if (input == 0)
                return CANCELED;
            else
                return input / 100.00m;

        }



    }
}

