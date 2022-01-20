using System;
using System.Collections.Generic;
using System.Text;

namespace WestminsterRentals
{
     class ACVehicels : Vehicle
    {
        //declare attributes of the van class
        private bool airconditioned;

        //constructor with different parameters of class ACVehicels
        public ACVehicels(string registerNum, string manufacturer, string modelName, int capacity, bool ac) : base(registerNum, manufacturer, modelName, capacity)
        {
            airconditioned = ac;
        }
        //method to print the details of the vehicle
        public override void printInfo()
        {
            Console.WriteLine(getRegistrationNumber());
        }
        //setter method to set status of ac
        public void setAirConditioned(bool modifyAC)
        {
            airconditioned = modifyAC;
        }
        //getter method to get status of ac
        public bool getAirConditioned()
        {
            return airconditioned;
        }
    }
}
