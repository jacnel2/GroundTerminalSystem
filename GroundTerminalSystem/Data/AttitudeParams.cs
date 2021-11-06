using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundTerminalSystem
{
    /// <summary>
    /// Models the attitude parameters at the time of measurement.
    /// </summary>
    public class AttitudeParams
    {
        /// <summary>
        /// Models the attitude parameters at the time of measurement.
        /// </summary>
        public AttitudeParams()
        {
            //nothing
        }

        /// <summary>
        /// Models the attitude parameters at the time of measurement.
        /// </summary>
        /// <param name="timestamp">Time at which the measurement was taken.</param>
        /// <param name="altitude">The altitude of the craft.</param>
        /// <param name="pitch">The pitch of the craft.</param>
        /// <param name="bank">The bank of the craft.</param>
        public AttitudeParams(DateTime timestamp, float altitude, float pitch, float bank)
        {
            Timestamp = timestamp;
            Altitude = altitude;
            Pitch = pitch;
            Bank = bank;
        }

        /// <value>Indicates the time at which the reading was taken</value>
        public DateTime Timestamp { get; set; }

        /// <value>Indicates the Altitude reading for the flight</value>
        public float Altitude { get; set; }

        /// <value>Indicates the Pitch reading for the flight</value>
        public float Pitch { get; set; }

        /// <value>Indicates the Bank reading for the flight</value>
        public float Bank { get; set; }
    }
}
