using System;
using System.Collections.Generic;
using System.Text;

namespace WestminsterRentals
{
    class Schedule : IOverlappable
    {
        //declare attributes of the Schedule Class
        private DateTime pickUpDate;
        private DateTime dropOffDate;
        //constructor with different parameters
        public Schedule(DateTime pick, DateTime drop)
        {
            pickUpDate = pick;
            dropOffDate = drop;
        }
        //method to check whether two shedules overlaps
        public bool Overlaps(Schedule other)
        {
            //returns true if two shedules overlaps, otherwise return false
            return ((pickUpDate.CompareTo(other.getDropOff())<=0) && (other.getPickUp().CompareTo(dropOffDate) <=0));
        }
        //getter method to get pickup time
        public DateTime getPickUp()
        {
            return pickUpDate;
        }
        //getter method to get dropoff time
        public DateTime getDropOff()
        {
            return dropOffDate;
        }

    }
}
