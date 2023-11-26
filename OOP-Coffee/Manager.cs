using OOP_Coffee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeShop
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
    }
    public class SalesResult
    {
        public int ProductID { get; set; }
        public int TotalQuantity { get; set; }
    
    }
}