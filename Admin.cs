using System;
using System.Collections.Generic;
using System.Text;


namespace WestminsterRentals
{
    class Admin : User
    {
        //declare attributes of the admin class
        private string role;
        private DateTime joinedDate;

        //constructor with different parameters of class admin
        public Admin(string uID, string uName,string position, DateTime join):base(uID, uName)
        {
            role = position;
            joinedDate = join;
        }
        //getter method to get role
        public string getRole()
        {
            return role;
        }
        //getter method to get joinedDate
        public DateTime getJoinedDate()
        {
            return joinedDate;
        }
        //setter method to set role
        public void setRole(string newRole)
        {
            role = newRole;
        }
        

    }
}
