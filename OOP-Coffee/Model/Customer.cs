using OOP_Coffee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OOP_Coffee.Utils;

namespace OOP_CoffeeApp
{
    public class Customer : Person
    {
        private int customerID;

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

        static public bool checkLogin(string username, string password)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var user = db.CustomerDBs.FirstOrDefault(u => u.CustomerID.ToString() == username);

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
}