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
        public decimal ProductPrice { get; }
        public Image ProductImage { get; }

        public ProductClickedEventArgs(int id, string name, decimal price, Image img)
        {
            Id = id;
            ProductName = name;
            ProductPrice = price;
            ProductImage = img;
        }
    }

    public class NumericChangeValue : EventArgs
    {
        public decimal Value { get; }

        public NumericChangeValue(decimal value)
        {
            Value = value;
        }
    }
}
