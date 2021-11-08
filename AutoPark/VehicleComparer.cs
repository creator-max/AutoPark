using System;
using System.Collections.Generic;

namespace AutoPark
{
    public class VehicleComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle first, Vehicle second)
        {
            if(first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            return first.Model.CompareTo(second.Model);
        }
    }
}
