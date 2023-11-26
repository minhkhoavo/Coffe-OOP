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
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }

        public Person()
        {
            Name = "not yet defined";
            Phone = "not yet defined";
            Gender = "not yet defined";
            Address = "not yet defined";
            BirthDate = new DateTime(1900, 1, 1);
        }
        public Person(string name):this()
        {
            Name = name;
        }
        public Person(string name, string phoneNumber) : this(name)
        {
            Phone = phoneNumber;
        }
        public Person(string name, string phoneNumber, string gender) : this(name, phoneNumber)
        {
            Gender = gender;
        }
        public Person(string name, string phone, string gender,string address): this(name, phone, gender)
        {
            Address = address;
        }
        public Person(string name, string gender, string phone, string address, string email, DateTime birthDate):this(name, gender, phone, address)
        {
            BirthDate = birthDate;
        }

        public void PrintDetails()
        {
            string day = string.Format("{0:dd/MM/yyyy}", BirthDate);
            string kq = ($" Name: {Name},\n Phone: {Phone},\n" +
                $" Gender: {Gender},\n Address: {Address},\n" +
                $"\n BirthDate: {day}");
            MessageBox.Show(kq , "Thong bao");
        }
    }
}