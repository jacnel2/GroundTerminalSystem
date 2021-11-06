using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundTerminalSystem.Data
{
    /// <summary>
    /// Compares two Flights to see if they're equal.
    /// </summary>
    class FlightComparer : EqualityComparer<Flight>
    {
        /// <summary>
        /// Compares two Flights to see if they're equal.
        /// </summary>
        /// <param name="x">First Flight.</param>
        /// <param name="y">Second Flight.</param>
        /// <returns>True if they are equal, False if otherwise.</returns>
        public override bool Equals(Flight x, Flight y)
        {
            if (x.AircraftTail == y.AircraftTail)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Calculates Flight object's hash code.
        /// </summary>
        /// <param name="obj">Flight object to calculate.</param>
        /// <returns>The Flight object's hash code.</returns>
        public override int GetHashCode(Flight obj)
        {
            return obj.GetHashCode();
        }
    }
}
