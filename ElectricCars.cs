using System;
using System.Collections.Generic;
using System.Text;

namespace WestminsterRentals
{
    class ElectricCars : ACVehicels
    {
        //declare attributes of the ElectricCars class
        private int rangeKM;
        //constructor with different parameters of Class Electric cars
        public ElectricCars(string registerNum, string manufacturer, string modelName, int capacity, bool ac,int range) : base(registerNum, manufacturer, modelName, capacity, ac)
        {
            rangeKM = range;
        }
        //method to print the details of the vehicle
        public override void printInfo()
        {
            Console.Write(getMake() + "\t" + getRegistrationNumber() + "\t\t\t" + getModel() + " \t" + "\tElectricCars\t");
            if (getAirConditioned()) { Console.Write("AC : Yes\t"); } else { Console.Write("AC : No\t"); }
            Console.Write("Range : " + rangeKM);
        }
        //setter method to set new range
        public void setRange(int newRange)
        {
            rangeKM = newRange;
        }
        //getter method to get the range
        public int getRange()
        {
            return rangeKM;
        }
    }
}
