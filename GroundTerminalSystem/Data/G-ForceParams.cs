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
    class G_ForceParams
    {
        /// <summary>
        /// Models the G Force Parameter data for the flight.
        /// </summary>
        /// <param name="time">Time at which the data was collected.</param>
        /// <param name="accelX">Acceleration in the X direction.</param>
        /// <param name="accelY">Acceleration in the Y direction.</param>
        /// <param name="accelZ">Acceleration in the Z direction.</param>
        /// <param name="weight">Weight of the craft.</param>
        public G_ForceParams(DateTime time, float accelX, float accelY, float accelZ, float weight)
        {
            Time = time;
            AccelX = accelX;
            AccelY = accelY;
            AccelZ = accelZ;
            Weight = weight;
        }

        /// <value>Indicates the time at which the reading was taken</value>
        public DateTime Time
        {
            get
            {
                return Time;
            }
            set
            {
                Time = value;
            }
        }

        /// <value>Acceleration in the X direction at time of measurement.</value>
        public float AccelX
        {
            get
            {
                return AccelX;
            }
            set
            {
                AccelX = value;
            }
        }

        /// <value>Acceleration in the Y direction at time of measurement.</value>
        public float AccelY
        {
            get
            {
                return AccelY;
            }
            set
            {
                AccelY = value;
            }
        }

        /// <value>Acceleration in the Z direction at time of measurement.</value>
        public float AccelZ
        {
            get
            {
                return AccelZ;
            }
            set
            {
                AccelZ = value;
            }
        }

        /// <value>Weight of craft in lbs at time of measurement.</value>
        public float Weight
        {
            get
            {
                return Weight;
            }
            set
            {
                AccelZ = value;
            }
        }
    }
}
