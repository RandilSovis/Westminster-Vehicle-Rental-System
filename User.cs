using System;
using System.Collections.Generic;
using System.Text;

namespace WestminsterRentals
{
    class User
    {
        //declare attributes of user class
        private string userId;
        private string userName;

        //constructor with input parameters userId and User name
        public User(string uID, string uName)
        {
            userId = uID;
            userName = uName;
        }
        //Constructor with userId
        public User(string uID)
        {
            userId = uID;
        }

        //getter method to get user ID
        public string getUserId()
        {
            return userId;
        }
        //getter method to get username
        public string getUserName()
        {
            return userName;
        }
        //setter method to set user ID
        public void setUserId(string uID)
        {
            userId = uID;
        }
        //setter method to set username
        public void setUserName(string uName)
        {
            userName = uName;
        }
    }
}
