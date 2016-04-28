using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    class Presenter
    {
        private ICalculatorView view;
        private Calculator model;

        private string operand = "";
        private string error = "";

        private IDictionary<Command, Action> commandHandlers = new Dictionary<Command, Action>();

        public Presenter(ICalculatorView view, Calculator model)
        {
            this.view = view;
            this.model = model;
            view.CommandPressed += View_CommandPressed;
            view.DigitPressed += View_DigitPressed;

            InitializeHandlers();
        }

        private void View_DigitPressed(object sender, DigitPressedEventArgs e)
        {
            operand += e.Digit;
            double number;
            if (double.TryParse(operand, out number))
            {
                model.Operand = number;
            }
            else
            {
                error = "Invalid digit";
            }
            RefreshView();
        }

        private void InitializeHandlers()
        {
            commandHandlers.Add(Command.Add, HandleAdd);
            commandHandlers.Add(Command.Eq, HandleEq);
            commandHandlers.Add(Command.Dot, HandleDot);
        }

        private void HandleDot()
        {
            if (string.IsNullOrEmpty(operand))
            {
                operand += "0.";
            }
            else if (!operand.Contains("."))
            {
                operand += ".";
            }
        }

        private void HandleAdd()
        {
            model.SetAdd();
            operand = "";
        }

        private void HandleEq()
        {
            model.Execute();
            operand = model.Result.ToString();
        }

        private void View_CommandPressed(object sender, CommandPressedEventArgs e)
        {
            commandHandlers[e.Command]?.Invoke();
            /*
            var hanlder = commandHandlers[e.Command];
            if (handler != null)
            {
                handler();
            }*/
            RefreshView();
        }

        private void RefreshView()
        {
            view.Output = operand;
            view.Error = error;
        }
    }
}
