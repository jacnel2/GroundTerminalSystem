using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundTerminalSystem.Data
{
    /// <summary>
    /// Models the G Force Parameter data for the flight.
    /// </summary>
    public class G_ForceParams
    {
        /// <summary>
        /// Models the G Force Parameter data for the flight.
        /// </summary>
        public G_ForceParams()
        {
            //nothing
        }

        /// <summary>
        /// Models the G Force Parameter data for the flight.
        /// </summary>
        /// <param name="timestamp">Time at which the data was collected.</param>
        /// <param name="accelX">Acceleration in the X direction.</param>
        /// <param name="accelY">Acceleration in the Y direction.</param>
        /// <param name="accelZ">Acceleration in the Z direction.</param>
        /// <param name="weight">Weight of the craft.</param>
        public G_ForceParams(DateTime timestamp, float accelX, float accelY, float accelZ, float weight)
        {
            Timestamp = timestamp;
            AccelX = accelX;
            AccelY = accelY;
            AccelZ = accelZ;
            Weight = weight;
        }

        /// <value>Indicates the time at which the reading was taken</value>
        public DateTime Timestamp { get; set; }

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
