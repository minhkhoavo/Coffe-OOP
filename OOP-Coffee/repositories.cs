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
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var productName = db.ItemDBs
                .Where(item => item.ItemId == id)
                .Select(item => item.ItemName)
                .FirstOrDefault();
            return productName ?? "Unknown";
        }
    }
}
