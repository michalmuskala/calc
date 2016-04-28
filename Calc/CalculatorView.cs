using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class CalculatorView : Form, ICalculatorView
    {
        public CalculatorView()
        {
            InitializeComponent();
        }

        public string Error
        {
            set { error.SetError(output, value); }
        }

        public string Output
        {
            set { output.Text = value; }
        }

        public event EventHandler<CommandPressedEventArgs> CommandPressed;
        public event EventHandler<DigitPressedEventArgs> DigitPressed;

        private void Digit_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var args = new DigitPressedEventArgs(button.Text[0]);
                DigitPressed?.Invoke(this, args);
                /* var handler = DigitPressed;
                if (handler != null)
                {
                    handler(this, args);
                } */
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PressCommand(Command.Add);
        }

        private void PressCommand(Command command)
        {
            var args = new CommandPressedEventArgs(command);
            CommandPressed?.Invoke(this, args);
        }

        private void btnEq_Click(object sender, EventArgs e)
        {
            PressCommand(Command.Eq);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            PressCommand(Command.Dot);
        }
    }
}
