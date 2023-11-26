using OOP_Coffee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CoffeeApp
{
    internal class Repositories
    {
        static public string getProductNameById(int id)
        {
            LinQDBDataContext db = new LinQDBDataContext();
            var productName = db.Items
                .Where(item => item.ItemID == id)
                .Select(item => item.Name)
                .FirstOrDefault();
            return productName ?? "Unknown";
        }
    }
}
