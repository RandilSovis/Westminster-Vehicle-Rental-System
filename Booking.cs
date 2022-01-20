using System;
using System.Collections.Generic;
using System.Text;

namespace WestminsterRentals
{
    class Booking : IComparable<Booking>
    {
        //declare attributes of the Booking class
        private int bookingId;
        private Schedule schedule;
        private Vehicle vehicle;
        private Customer customer;
        private static int numberOfBookings = 0;

        //constructor with different parameters of class Booking
        public Booking(Schedule shed, Vehicle V, Customer cus)
        {
            bookingId = numberOfBookings;
            schedule = shed;
            vehicle = V;
            customer = cus;
        }
        //Setter method to set the shedules
        public void setShedule(Schedule newShedule)
        {
            schedule= newShedule;
        }
        //setter methods to set the Vehicle
        public void setVehicle(Vehicle newVehicle)
        {
            vehicle = newVehicle;
        }
        //setter method to set the customer
        public void setCustomer(Customer newCustomer)
        {
            customer = newCustomer;
        }
        //getter method to get customer
        public Customer getCustomer()
        {
            return customer;
        }
        //getter method to get nooking ID
        public int getBookingID()
        {
            return bookingId;
        }
        //getter method to get schedule
        public Schedule getSchedule()
        {
            return schedule;
        }
        //getter method  to get vehicle details
        public Vehicle getVehicle()
        {
            return vehicle;
        }
        //Comparable method to sort the details according to the make of the vehicle
        public int CompareTo(Booking V)
        {
            return vehicle.getMake().CompareTo(V.getVehicle().getMake()); 
        }


}
}
