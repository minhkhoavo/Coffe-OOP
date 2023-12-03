using OOP_Coffee;
using OOP_Coffee.Utils;
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

        static public List<DashboardDB> getSalesData(DateTime startDate, DateTime endDate)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var query = from data in db.DashboardDBs
                        where data.OrderDate >= startDate && data.OrderDate <= endDate
                        select data;
            List<DashboardDB> result = query.ToList();
            return result;
        }

        static public List<SalesResult> getSalesByProduct(DateTime startDate, DateTime endDate)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var result = db.SalesSummaryDBs
                .Where(s => s.date >= startDate && s.date <= endDate)
                .GroupBy(s => s.ItemID)
                .Select(g => new SalesResult
                {
                    ProductID = g.Key ,
                    TotalQuantity = g.Sum(s => s.quantity)
                })
                .ToList();
            return result;
        }

        static public bool checkLogin(string username, string password)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var user = db.ManagerDBs.FirstOrDefault(u => u.ManagerID.ToString() == username);

            if (user != null)
            {
                if (user.Password == password || Password.VerifyPassword(password, user.Password))
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