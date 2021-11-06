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
    public class Flight : IDataFlight
    {
        /// <summary>
        /// Models the attributes of a flight.
        /// </summary>
        public Flight()
        {
            AttitudeParams = new List<AttitudeParams>();
            G_ForceParams = new List<G_ForceParams>();
        }

        /// <summary>
        /// Models the attributes of a flight.
        /// </summary>
        /// <param name="aircraftTail">Denotes the identifier for the aircraft, also know as its "tail".</param>
        /// <param name="attitudeParams">Attitude values collected for this specific flight.</param>
        /// <param name="g_ForceParams">G-Force values collected for this specific flight.</param>
        public Flight(string aircraftTail, List<AttitudeParams> attitudeParams, List<G_ForceParams> g_ForceParams)
        {
            AircraftTail = aircraftTail;
            AttitudeParams = attitudeParams;
            G_ForceParams = g_ForceParams;
        }

        /// <value>Denotes the identifier for the aircraft, also know as its "tail".</value>
        public String AircraftTail { get; set; }

        /// <value>Attitude values collected for this specific flight.</value>
        public List<AttitudeParams> AttitudeParams { get; set; }

        /// <value>G-Force values collected for this specific flight.</value>
        public List<G_ForceParams> G_ForceParams { get; set; }
    }
}
