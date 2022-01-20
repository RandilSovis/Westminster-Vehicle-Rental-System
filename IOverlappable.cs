using System;
using System.Collections.Generic;
using System.Text;

namespace WestminsterRentals
{
    interface IOverlappable
    {
        //declare interface methods
        //method to check whether two shedules overlaps
        public bool Overlaps(Schedule other);
    }
}
