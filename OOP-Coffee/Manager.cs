using OOP_Coffee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_CoffeeApp
{
    public class Manager : Person
    {
        public void StaffManagement()
        {
            throw new System.NotImplementedException();
        }

        public void InventoryManagement()
        {
            throw new System.NotImplementedException();
        }

        static public List<Dashboard> getSalesData(DateTime startDate, DateTime endDate)
        {
            LinQDBDataContext db = new LinQDBDataContext();
            var query = from data in db.Dashboards
                        where data.order_date >= startDate && data.order_date <= endDate
                        select data;
            List<Dashboard> result = query.ToList();
            return result;
        }

        static public List<SalesResult> getSalesByProduct(DateTime startDate, DateTime endDate)
        {
            LinQDBDataContext db = new LinQDBDataContext();
            var result = db.salesSummaries
                .Where(s => s.date >= startDate && s.date <= endDate)
                .GroupBy(s => s.productID)
                .Select(g => new SalesResult
                {
                    ProductID = g.Key ?? 0,
                    TotalQuantity = g.Sum(s => s.quantity) ?? 0
                })
                .ToList();
            return result;
        }

        static public bool checkLogin(string username, string password)
        {
            LinQDBDataContext db = new LinQDBDataContext();
            var user = db.Managers.FirstOrDefault(u => u.ManagerID.ToString() == username);

            if (user != null)
            {
                if (user.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
    public class SalesResult
    {
        public int ProductID { get; set; }
        public int TotalQuantity { get; set; }
    
    }
}