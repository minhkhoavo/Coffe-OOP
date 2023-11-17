using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace WinFormsApp1
{
    public class ProductClickedEventArgs : EventArgs
    {
        public int Id { get; }
        public string ProductName { get; }
        public double ProductPrice { get; }
        public Image ProductImage { get; }

        public ProductClickedEventArgs(int id, string name, double price, Image img)
        {
            Id = id;
            ProductName = name;
            ProductPrice = price;
            ProductImage = img;
        }
    }

    public class NumericChangeValue : EventArgs
    {
        public double Value { get; }

        public NumericChangeValue(double value)
        {
            Value = value;
        }
    }
}
