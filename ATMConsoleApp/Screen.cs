using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace ATMConsoleApp
{
   public class Screen
    {
        public void DisplayMessage(string message)
        {
            WriteLine(message);
        }

        public void DisplayMessageLine(string message)
        {
            WriteLine(message);
        }

        public void DisplayDollarAmount(decimal amount)
        {
            Write("{0:C}" + amount);
        }
    }
}
