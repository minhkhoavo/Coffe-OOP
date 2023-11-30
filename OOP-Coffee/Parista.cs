using OOP_Coffee;
using Sprache;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace OOP_CoffeeApp
{
    public class Barista : Person
    {
        public void PreparesCoffee()
        {
            throw new System.NotImplementedException();
        }

        public void ServesCoffe()
        {
            throw new System.NotImplementedException();
        }

        static public bool checkLogin(string username, string password)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var user = db.BaristaDBs.FirstOrDefault(u => u.BaristaID.ToString() == username);

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
}