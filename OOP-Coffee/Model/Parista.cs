using OOP_Coffee;
using OOP_Coffee.Utils;
using Sprache;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OOP_CoffeeApp
{
    public class Barista : Person
    {
        private int baristaID;
        private int managerID;

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
                if (user.Password == password || PasswordHash.VerifyPassword(password, user.Password))
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
        public override void PrintDetails()
        {
            string day = string.Format("{0:dd/MM/yyyy}", Birthdate);
            string kq = ($" Barista\nName: {Name},\n Phone: {Phone},\n" +
                $" Gender: {Gender},\n Address: {Address},\n" +
                $"\n BirthDate: {day}");
            MessageBox.Show(kq, "Thong bao");
        }
    }
}