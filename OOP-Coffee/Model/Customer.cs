using OOP_Coffee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OOP_Coffee.Utils;
using System.Windows.Forms;
using System.Net;
using System.Xml.Linq;
using OOP_Coffee.Form.UserControlUI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Sprache;

namespace OOP_CoffeeApp
{
    public class Customer : Person
    {
        private int customerID;

        public int CustomerID { get => customerID; set => customerID = value; }

        public Customer(int customerID, string name, string gender, string phone, string address, DateTime birthDate)
        : base(name, gender, phone, address, birthDate)
        {
            this.CustomerID = customerID;
        }

        public int Orders()
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();   
            OrderDB newOrder = new OrderDB
            {
                CustomerID = this.CustomerID,
                OrderDate = DateTime.Now,
                RatingStar = null,
                Comment = null
            };
            db.OrderDBs.InsertOnSubmit(newOrder);
            db.SubmitChanges();
            return newOrder.OrderID;
        }

        public void Pays(string method)
        {
            MessageBox.Show("Phương thức thanh toán bạn đã chọn là " + method);
        }

        public void Feedback(int orderID, int rating, string comment)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            OrderDB orderToUpdate = db.OrderDBs.FirstOrDefault(order => order.OrderID == orderID);

            if (orderToUpdate != null)
            {
                if (rating != -1)
                {
                    orderToUpdate.RatingStar = rating;
                }
                if (!string.IsNullOrEmpty(comment))
                {
                    orderToUpdate.Comment = comment;
                }
            }
            db.SubmitChanges();
        }
        public static Customer FindCustomerByUsername(int username)
        {
           CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var query = from customer in db.CustomerDBs
                        where customer.CustomerID == username
                        select customer;
            var foundCustomer = query.FirstOrDefault();
            if(foundCustomer != null)
            {
                DateTime? birthdate = foundCustomer.Birthdate;
                DateTime birthdateValue = birthdate ?? DateTime.MinValue;

                return new Customer(username, foundCustomer.Name, foundCustomer.Gender, foundCustomer.Phone, foundCustomer.Address, birthdateValue);
            }
            return null;
        }
        static public bool checkLogin(string username, string password)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var user = db.CustomerDBs.FirstOrDefault(u => u.CustomerID.ToString() == username);

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
            string kq = ($" Customer\nName: {Name},\n Phone: {Phone},\n" +
                $" Gender: {Gender},\n Address: {Address},\n" +
                $"\n BirthDate: {day}");
            MessageBox.Show(kq, "Thong bao");
        }
    }
}