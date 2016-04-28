using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class DigitPressedEventArgs : EventArgs
    {
        public char Digit { get; private set; }

        public DigitPressedEventArgs(char digit)
        {
            Digit = digit;
        }
    }

    public enum Command { Add = 1, Sub, Mul, Div, Clr, ClrAll, Bsp, Neg, Dot, Eq }

    public class CommandPressedEventArgs : EventArgs
    {
        public Command Command { get; private set; }

        public CommandPressedEventArgs(Command command)
        {
            Command = command;
        }
    }

    interface ICalculatorView
    {
        event EventHandler<DigitPressedEventArgs> DigitPressed;
        event EventHandler<CommandPressedEventArgs> CommandPressed;

        string Output { set; }
        string Error { set; }
    }
}
