using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ATMConsoleApp
{
    public class Keypad
    {
        public int GetInput()
        {
            return int.Parse(ReadLine());
        }
    }
}
