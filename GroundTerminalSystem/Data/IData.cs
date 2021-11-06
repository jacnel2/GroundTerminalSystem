using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundTerminalSystem.Data
{
    public interface IData
    {
        List<Flight> Flights { get; set; }
    }
}
