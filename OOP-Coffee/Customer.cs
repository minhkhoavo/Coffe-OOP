using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeShop
{
    public class Customer : Person
    {
        public Customer(string name, string phone):base(name,phone)
        {
        }
        public Customer(string name, string phone, string gender) : base(name, phone, gender)
        {
        }
        public Customer(string name, string phone, string gender, string address) : base(name, phone, gender, address)
        {

        }

        public void Orders()
        {
            throw new System.NotImplementedException();
        }

        public void Pays()
        {
            throw new System.NotImplementedException();
        }

        public void Feedback()
        {
            throw new System.NotImplementedException();
        }
    }
}