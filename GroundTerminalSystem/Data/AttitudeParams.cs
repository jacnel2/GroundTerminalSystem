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
    class AttitudeParams
    {
        /// <summary>
        /// Models the attitude parameters at the time of measurement.
        /// </summary>
        /// <param name="time">Time at which the measurement was taken.</param>
        /// <param name="altitude">The altitude of the craft.</param>
        /// <param name="pitch">The pitch of the craft.</param>
        /// <param name="bank">The bank of the craft.</param>
        public AttitudeParams(DateTime time, float altitude, float pitch, float bank)
        {
            Time = time;
            Altitude = altitude;
            Pitch = pitch;
            Bank = bank;
        }

        /// <value>Indicates the time at which the reading was taken</value>
        public DateTime Time 
        {
            get
            {
                return Time;
            }
            protected set
            {
                Time = value;
            }
        }

        /// <value>Indicates the Altitude reading for the flight</value>
        public float Altitude
        {
            get
            {
                return Altitude;
            }
            protected set
            {
                Altitude = value;
            }
        }

        /// <value>Indicates the Pitch reading for the flight</value>
        public float Pitch
        {
            get
            {
                return Pitch;
            }
            protected set
            {
                Pitch = value;
            }
        }

        /// <value>Indicates the Bank reading for the flight</value>
        public float Bank
        {
            get
            {
                return Bank;
            }
            protected set
            {
                Bank = value;
            }
        }
    }
}
