using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GroundTerminalSystem.Data
{
    /// <summary>
    /// Manages data objects held in memory. 
    /// Stores Flight data objects in memory and provides the ability to write to them.
    /// </summary>
    public class DataManager : IData
    {
        /// <value>All flights stored in memory.</value>
        public List<Flight> Flights { get; set; }
        /// <value>All flights stored in memory formatted for apropriate display.</value>
        public ObservableCollection<FlightDisplay> FlightsForDisplay { get; set; }

        /// <summary>
        /// Manages data objects held in memory. 
        /// Stores Flight data objects in memory and provides the ability to write to them.
        /// </summary>
        public DataManager()
        {
            Flights = new List<Flight>();
            FlightsForDisplay = new ObservableCollection<FlightDisplay>();
            BindingOperations.EnableCollectionSynchronization(FlightsForDisplay, Commons._lock);
        }

        /// <summary>
        /// Stores the data collected by the Communication class from ATS.
        /// </summary>
        /// <param name="flightData">A line of data from ATS.</param>
        public void AddFlightData(String flightData)
        {
            Console.WriteLine("FROM DATA MANAGER: " + flightData);
            String[] contentDivided = flightData.Split(';');
            String[] messageContents = contentDivided[2].Split(',');
            String[] timeDivided = messageContents[0].Split(Commons.DATE_DELIM);
            DateTime newTimestamp = new DateTime(int.Parse(timeDivided[2]), int.Parse(timeDivided[0]), int.Parse(timeDivided[1]), int.Parse(timeDivided[3]), int.Parse(timeDivided[4]), int.Parse(timeDivided[5]));

            AttitudeParams newAlt = new AttitudeParams(newTimestamp, float.Parse(messageContents[5]), float.Parse(messageContents[6]), float.Parse(messageContents[7]));
            G_ForceParams newGForce = new G_ForceParams(newTimestamp, float.Parse(messageContents[1]), float.Parse(messageContents[2]), float.Parse(messageContents[3]), float.Parse(messageContents[4]));
            String flightDataTail = contentDivided[0];

            if (Flights.Count == 0)
            {
                Flight newFlight = new Flight();
                newFlight.AircraftTail = flightDataTail;
                newFlight.AttitudeParams.Add(newAlt);
                newFlight.G_ForceParams.Add(newGForce);
                Flights.Add(newFlight);
            }

            for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].AircraftTail == flightDataTail)
                {
                    Flights[i].AttitudeParams.Add(newAlt);
                    Flights[i].G_ForceParams.Add(newGForce);
                    break;
                }
                else if (i == Flights.Count - 1)
                {
                    Flight newFlight = new Flight();
                    newFlight.AircraftTail = flightDataTail;
                    newFlight.AttitudeParams.Add(newAlt);
                    newFlight.G_ForceParams.Add(newGForce);
                    Flights.Add(newFlight);
                }
            }

            lock (Commons._lock)
            {
                FlightsForDisplay.Add(new FlightDisplay(flightDataTail, newTimestamp, newAlt.Altitude, newAlt.Pitch, newAlt.Bank, newGForce.AccelX, newGForce.AccelY, newGForce.AccelZ, newGForce.Weight));
            }
        }
    }
}
