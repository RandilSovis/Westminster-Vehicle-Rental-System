using System;
using System.Collections.Generic;
using System.Text;

namespace WestminsterRentals
{
    class Customer : User
    {
        //declare attributes of the customer class
        private string address;
        private string licenseNo;
        private int telephone;
        //constructor with different parameters of class Customer
        public Customer(string uID, string uName, string addre, string license, int contact):base(uID, uName)
        {
            address = addre;
            licenseNo = license;
            telephone = contact;
        }

        //getter method to get address
        public string getAddress()
        {
            return address;
        }
        //getter method to get license No
        public string getLicenseNo()
        {
            return licenseNo;
        }
        //getter method to get telephone
        public int getTelephone()
        {
            return telephone;
        }
        //setter method to set address
        public void setAddress(string newAddress)
        {
            address = newAddress;
        }
        //setter method to set telephone
        public void setTelephone(int newTelephone)
        {
            telephone = newTelephone;
        }
    }
}
