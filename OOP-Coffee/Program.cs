using CoffeeShop;
using OOP_Coffee;
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
<<<<<<< HEAD
            Application.Run(new Iventory());
=======
            //Application.Run(new fAdmin());
            Application.Run(new Form1());
>>>>>>> 9940db46e7269c4fe6be5b1477aa2cf43660c77a
        }
    }
}
