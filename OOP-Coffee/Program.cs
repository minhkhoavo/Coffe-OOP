
using OOP_Coffee;
using OOP_Coffee.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CoffeeApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Iventory());
            //Application.Run(new fAdmin());
            //Application.Run(new Form1(1));
            //Application.Run(new fFeedback());
            //Application.Run(new fLogin());
            fLogin fLogin = new fLogin();

            if (fLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new fAdmin());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
