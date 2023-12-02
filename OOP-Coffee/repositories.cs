using OOP_Coffee;
using OOP_Coffee.Form.UserControlUI;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
        static decimal GetProductPrice(int itemId)
        {
            decimal price = 0;
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var item = db.ItemDBs.FirstOrDefault(i => i.ItemId == itemId);
            if (item != null)
            {
                price = item.Price;
            }

            return price;
        }
        static decimal GetProductCost(int itemId)
        {
            decimal cost = 0;
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var item = db.ItemDBs.FirstOrDefault(i => i.ItemId == itemId);
            if (item != null)
            {
                cost = item.Cost;
            }

            return cost;
        }
        static public void updateSaleSummaryDB(int orderID)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var order = db.OrderDBs.FirstOrDefault(o => o.OrderID == orderID);
            var query = from item in db.OrderItemDBs
                        where item.OrderID == orderID && item.Status == "Completed"
                        select new
                        {
                            item.ItemId,
                            item.Quantity
                        };

            foreach (var product in query)
            {
                var existingEntry = db.SalesSummaryDBs
                    .Where(s => s.date == DateTime.Today && s.ItemID == product.ItemId)
                    .FirstOrDefault();

                if (existingEntry != null)
                {
                    existingEntry.quantity += product.Quantity;
                }
                else
                {
                    db.SalesSummaryDBs.InsertOnSubmit(new SalesSummaryDB
                    {
                        date = order.OrderDate,
                        ItemID = product.ItemId,
                        quantity = product.Quantity,
                    });
                }
            }

            db.SubmitChanges();
        }

        static public void updateRevenueAndProfit(int orderID)
        {
            decimal totalRevenue = 0;
            decimal totalProfit = 0;

            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var order = db.OrderDBs.FirstOrDefault(o => o.OrderID == orderID);
            var orderItems = db.OrderItemDBs
                .Where(item => item.OrderID == orderID && item.Status == "Completed")
                .ToList();

            foreach (var item in orderItems)
            {
                decimal price = GetProductPrice(item.ItemId);
                decimal cost = GetProductCost(item.ItemId);

                totalRevenue += item.Quantity * price;
                totalProfit += (item.Quantity * price) - (item.Quantity * cost);
            }

            db.DashboardDBs.InsertOnSubmit(new DashboardDB
            {
                OrderID = orderID,
                OrderDate = order.OrderDate,
                totalRevenue = totalRevenue,
                totalProfit = totalProfit
            });

            db.SubmitChanges();
        }
    }
}
