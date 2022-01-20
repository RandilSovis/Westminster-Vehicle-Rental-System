using System;
using System.Collections.Generic;
using System.Text;

namespace WestminsterRentals
{
    class MotorBikes : Vehicle
    {
        //declare attributes of the MotorBikes class
        private bool helmet;

        //constructor with different parameters
        public MotorBikes(string registerNum, string manufacturer, string modelName, int capacity, bool helmt) : base(registerNum, manufacturer, modelName, capacity)
        {
            helmet = helmt;
        }
        //method to print the details of the vehicle
        public override void printInfo()
        {
            Console.Write(getMake() + " \t" + getRegistrationNumber() + "\t\t\t" + getModel() + " \t" + "\tMotorBike\t");
            if (helmet) { Console.Write("Helmet : Yes\t"); } else { Console.Write("Helmet : No\t"); }
        }
        //getter method to get availability of helmet
        public bool getAvailabilityOfHelmet()
        {
            return helmet;
        }
        //setter method to set the helmet availability
        public void setAvailabilityOfHelmet(bool helmt)
        {
            helmet = helmt;
        }
    }
}
