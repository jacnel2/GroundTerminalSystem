using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundTerminalSystem.Data
{
    interface IDataFlight
    {
        /// <value>Attitude values collected for this specific flight.</value>
        List<AttitudeParams> AttitudeParams { get; set; }

        /// <value>G-Force values collected for this specific flight.</value>
        List<G_ForceParams> G_ForceParams { get; set; }
    }
}
