using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_CoffeeApp
{
    public abstract class Person
    {
        private string name;
        private string gender;
        private string phone;
        private string address;
        private System.DateTime birthDate;
    

        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Address { get => address; set => address = value; }
        public DateTime Birthdate { get => birthDate; set => birthDate = value; }

        public int Password
        {
            get => default;
            set
            {
            }
        }

        public Person()
        {
            Name = "not yet defined";
            Phone = "not yet defined";
            Gender = "not yet defined";
            Address = "not yet defined";
            Birthdate = new DateTime(1900, 1, 1);
        }

        protected Person(string name, string gender, string phone, string address, DateTime birthDate)
        {
            this.name = name;
            this.gender = gender;
            this.phone = phone;
            this.address = address;
            this.birthDate = birthDate;
        }

        public abstract void PrintDetails();
    }
}