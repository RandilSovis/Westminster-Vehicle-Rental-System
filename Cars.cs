using System;
using System.Collections.Generic;
using System.Text;

namespace WestminsterRentals
{
    class Cars : ACVehicels
    {
        //specific attributes for the car is not defined.
        //constructor with different parameters
        public Cars(string registerNum, string manufacturer, string modelName, int capacity, bool ac) : base(registerNum, manufacturer, modelName, capacity, ac) { }

        //method to print the details of the vehicle
        public override void printInfo()
        {
            Console.Write(getMake()+"\t"+getRegistrationNumber() + "\t\t\t" + getModel()+"\t" + "\tCar\t\t" );
            if (getAirConditioned()) { Console.WriteLine("AC : Yes\t"); } else { Console.WriteLine("AC : No\t"); }
        }

    }
}
