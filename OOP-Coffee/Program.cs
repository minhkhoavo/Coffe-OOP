
using OOP_Coffee;
using OOP_Coffee.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP_Coffee.Form.UserControlUI;

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


            //Application.Run(new AddItem());
            //Application.Run(new fAdmin());
            //Application.Run(new Form1(1));
            //Application.Run(new ThemItem());
            //Application.Run(new fRegister());

            //fLogin fLogin = new fLogin();
            Application.Run(new fLogin());

            /*if (fLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new ParistaFrm());
            }
            else
            {
                Application.Exit();
            }*/
        }
    }
}
