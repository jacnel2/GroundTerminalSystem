using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundTerminalSystem.Data
{
    /// <summary>
    /// Used to display Flight information by the UI
    /// </summary>
    public class FlightDisplay
    {
        /// <summary>
        /// Used to display Flight information by the UI
        /// </summary>
        /// <param name="aircraftTail">Denotes the identifier for the aircraft, also know as its "tail".</param>
        /// <param name="timestamp">Time at which the measurement was taken.</param>
        /// <param name="altitude">The altitude of the craft.</param>
        /// <param name="pitch">The pitch of the craft.</param>
        /// <param name="bank">The bank of the craft.</param>
        /// <param name="accelX">Acceleration in the X direction.</param>
        /// <param name="accelY">Acceleration in the Y direction.</param>
        /// <param name="accelZ">Acceleration in the Z direction.</param>
        /// <param name="weight">Weight of the craft.</param>
        public FlightDisplay(string aircraftTail, DateTime timestamp, float altitude, float pitch, float bank, float accelX, float accelY, float accelZ, float weight)
        {
            AircraftTail = aircraftTail;
            Timestamp = timestamp;
            Altitude = altitude;
            Pitch = pitch;
            Bank = bank;
            AccelX = accelX;
            AccelY = accelY;
            AccelZ = accelZ;
            Weight = weight;
        }

        /// <value>Denotes the identifier for the aircraft, also know as its "tail".</value>
        public String AircraftTail { get; set; }


        //***ATTITUDE***

        /// <value>Indicates the time at which the reading was taken</value>
        public DateTime Timestamp { get; set; }

        /// <value>Indicates the Altitude reading for the flight</value>
        public float Altitude { get; set; }

        /// <value>Indicates the Pitch reading for the flight</value>
        public float Pitch { get; set; }

        /// <value>Indicates the Bank reading for the flight</value>
        public float Bank { get; set; }


        //***GFORCE***

        /// <value>Acceleration in the X direction at time of measurement.</value>
        public float AccelX { get; set; }

        /// <value>Acceleration in the Y direction at time of measurement.</value>
        public float AccelY { get; set; }

        /// <value>Acceleration in the Z direction at time of measurement.</value>
        public float AccelZ { get; set; }

        /// <value>Weight of craft in lbs at time of measurement.</value>
        public float Weight { get; set; }
    }
}
