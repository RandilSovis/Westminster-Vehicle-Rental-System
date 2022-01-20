using System;
using System.Collections.Generic;
using System.Text;

namespace WestminsterRentals
{
    class Van : ACVehicels
    {
        private bool miniFridge;
        //constructor with different parameters
        public Van(string registerNum, string manufacturer, string modelName, int capacity, bool ac,bool fridge) : base(registerNum,manufacturer,modelName,capacity,ac)
        {
            miniFridge = fridge;
        }
        //method to print the details of the vehicle
        public override void printInfo()
        {
            Console.Write(getMake() + "\t" + getRegistrationNumber() + "\t\t\t" + getModel() + "\t" + "\tVan\t\t");
            if (getAirConditioned()) { Console.Write("AC : Yes\t"); } else { Console.Write("AC : No\t"); }
            if (miniFridge) { Console.WriteLine("Fridge : Yes\t"); } else { Console.WriteLine("Fridge : No\t"); }
        }

        //getter method to get the availability of minifridge
        public bool getFridge()
        {
            return miniFridge;
        }
        //setter method to set the availability of mini fridge
        public void setFridge(bool fridge)
        {
            miniFridge = fridge;
        }
       
    }
}
