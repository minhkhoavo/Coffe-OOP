using OOP_Coffee.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace OOP_Coffee.Model
{
    internal class Dashboard
    {
        static public List<ChartData> getSuccessOrderByDay(DateTime startDate, DateTime endDate)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var successfulOrders = db.OrderItemDBs
                .Join(db.OrderDBs, oi => oi.OrderID, o => o.OrderID, (oi, o) => new { oi, o })
                .Where(x => x.oi.Status == "Completed" && x.o.OrderDate.Date >= startDate && x.o.OrderDate.Date <= endDate)
                .GroupBy(x => x.o.OrderDate.Date)
                .Select(g => new ChartData { OrderDate = g.Key, OrdersCount = g.Count() })
                .OrderBy(x => x.OrderDate)
                .ToList();
            return successfulOrders;
        }
        static public List<ChartData> getRejectedOrderByDay(DateTime startDate, DateTime endDate)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var rejectedOrders = db.OrderItemDBs
                .Join(db.OrderDBs, oi => oi.OrderID, o => o.OrderID, (oi, o) => new { oi, o })
                .Where(x => x.oi.Status == "Rejected")
                .GroupBy(x => x.o.OrderDate.Date) // Instead of EntityFunctions.TruncateTime()
                .Select(g => new ChartData { OrderDate = g.Key, OrdersCount = g.Count() })
                .OrderBy(x => x.OrderDate)
                .ToList();
            return rejectedOrders;
        }
        static public List<ChartData> getAverageRatingByDay(DateTime startDate, DateTime endDate)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var ratings = db.OrderDBs
                .Where(order => order.RatingStar != null && order.OrderDate.Date >= startDate && order.OrderDate.Date <= endDate)
                .GroupBy(order => order.OrderDate)
                .Select(group => new ChartData
                {
                    OrderDate = group.Key,
                    OrdersCount = group.Average(order => (decimal)order.RatingStar)
                })
                .OrderBy(result => result.OrderDate)
                .ToList();
            return ratings;
        }
        static public decimal GetAverageRating(DateTime startDate, DateTime endDate)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();

            var averageRating = db.OrderDBs
                .Where(order => order.RatingStar != null && order.OrderDate.Date >= startDate && order.OrderDate.Date <= endDate)
                .Average(order => (decimal)order.RatingStar);

            return Math.Round(averageRating, 1);  // Làm tròn về một chữ số sau dấu phẩy
        }
        static public int GetCompletedOrderCount(DateTime startDate, DateTime endDate)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            return db.OrderDBs
            .Where(order => order.OrderDate.Date >= startDate && order.OrderDate.Date <= endDate)
            .Join(db.OrderItemDBs,
                order => order.OrderID,
                orderItem => orderItem.OrderID,
                (order, orderItem) => new { order, orderItem })
            .Count(joinResult => joinResult.orderItem.Status == "Completed");
        }
        static public int GetRejectedOrderCount(DateTime startDate, DateTime endDate)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            return db.OrderDBs
            .Where(order => order.OrderDate.Date >= startDate && order.OrderDate.Date <= endDate)
            .Join(db.OrderItemDBs,
                order => order.OrderID,
                orderItem => orderItem.OrderID,
                (order, orderItem) => new { order, orderItem })
            .Count(joinResult => joinResult.orderItem.Status == "Rejected");
        }
    }
    public class ChartData
    {
        public DateTime OrderDate { get; set; }
        public decimal OrdersCount { get; set; }
    }
}
