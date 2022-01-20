using System;
using System.Collections.Generic;
using System.Text;

namespace WestminsterRentals
{
    interface IRentalVehicleCustomer
    {
        //declare interface methods
        //Method to list a specific type of available vehicles in a given scheduled 
        public void listAvailableVehicles(Schedule wantedSchedule, VehicleType type);
        //method to rent a vehicle when the registration number and the schedule was mentioned
        public bool rentVehicle(string RegistrationNumber, Schedule wantedSchedule);
    }
}
