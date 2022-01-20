using System;
using System.Collections.Generic;
using System.Text;

namespace WestminsterRentals
{
    interface IRentalVehicleManager
    {
        //declare interface methods
        //method to add a vehicle to a the vehicle repository if that vehicle doesn't exist in the repository
        public bool addVehicle(Vehicle V);
        //Method to delete the vehicle when vehical registration number is provided
        public bool deleteVehicle(string RegistrationNumber);
        //Print the list of vehicles in the vehicle repository with there booking shedules
        public void listVehicles();
        //list the vehicles ordered and sort alphabatically according to the make
        public void listVehiclesOrdered();
        //save all the details of the vehicles in the vehicle repository in a text file
        public void generateReport(string filename);
      
        

    }
}
