using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Calculator model = new Calculator();
            CalculatorView view = new CalculatorView();
            Presenter presenter = new Presenter(view, model);
            Application.Run(view);
        }
    }
}
