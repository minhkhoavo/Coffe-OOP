
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

            Application.Run(new AddItem());
            //Application.Run(new fAdmin());
            //Application.Run(new Form1());
            //Application.Run(new fFeedback());
            //Application.Run(new fLogin());
            //fLogin fLogin = new fLogin();
            //fLogin fLogin2 = new fLogin();
            //fLogin fLogin3 = new fLogin();
            //fLogin2.Show();
            //fLogin3.Show();
            //if (fLogin.ShowDialog() == DialogResult.OK)
            //{
            //    Application.Run(new Form1());
            //}
            //else
            //{
            //    Application.Exit();
            //}
        }
    }
}
