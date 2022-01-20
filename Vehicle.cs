using System;
using System.Collections.Generic;
using System.Text;

namespace WestminsterRentals
{
    abstract class Vehicle
    {
        //declare attributes of the vehicle class
        private string registrationNumber;
        private string make;
        private string model;
        private int passengerCapacity;
        private static int numberOfVehicles = 0;

        //constructor with parameters registration number, make, model and passenger capacity
        public Vehicle(string registerNum, string manufacturer, string modelName,int capacity)
        {
            registrationNumber = registerNum;
            make = manufacturer;
            model = modelName;
            passengerCapacity = capacity;
            numberOfVehicles++;
        }
        //initialize an abstract method to printInfo
        public abstract void printInfo();


        //getter method to get registration number
        public string getRegistrationNumber()
        {
            return registrationNumber;
        }

        //getter method to get make
        public string getMake()
        {
            return make;
        }

        //getter method to get model
        public string getModel()
        {
            return model;
        }

        //set method to set the make
        public void setMake(string manufacturer)
        {
            make = manufacturer;
        }

        //set method to set the model
        public void setModel(string modelName)
        {
            model = modelName;
        }
        

    }
}
