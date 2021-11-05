using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundTerminalSystem.Data
{
    /// <summary>
    /// Models the attributes of a flight.
    /// </summary>
    class Flight
    {
        /// <value>Denotes the identifier for the aircraft, also know as its "tail".</value>
        public String AircraftTail
        {
            get
            {
                return AircraftTail;
            }
            set
            {
                AircraftTail = value;
            }
        }

        /// <value>Attitude values collected for this specific flight.</value>
        public List<AttitudeParams> AttitudeParams
        {
            get
            {
                return AttitudeParams;
            }
            set
            {
                AttitudeParams = value;
            }
        }

        /// <value>G-Force values collected for this specific flight.</value>
        public List<G_ForceParams> G_ForceParams
        {
            get
            {
                return G_ForceParams;
            }
            set
            {
                G_ForceParams = value;
            }
        }
    }
}
