using GroundTerminalSystem.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundTerminalSystem
{
    /// <summary>
    /// Connects the Server/Communication classes with the UI, Model, and Database. 
    /// </summary>
    /// <remarks>
    /// This static class is basically the glue that holds the application together.
    /// It is directly responsible for making sure that data collected from the ATS clients are displayed by the UI and stored in the database.
    /// Of course, the actual process of storing and displaying data isn't carried out by this class. Instead this class passes data objects between
    /// each of the helper classes which do the actual work. 
    /// </remarks>
    public static class Director
    {
        /// <value>Instance of the Server, which is used to receive Communication from the ATS</value>
        public static Server ServerInstance = new Server("50001");

        /// <value>Used to manage and store data in memory.</value>
        public static DataManager DataManagerInstance = new DataManager();

        /// <summary>
        /// Starts the server.
        /// </summary>
        public static void StartServer()
        {
            ServerInstance.StartBeingAServer();
        }

        /// <summary>
        /// Stops the server.
        /// </summary>
        public static void StopServer()
        {
            ServerInstance.StopBeingAServer();
        }

        public static void SendFlightDataToMemory(String flightData)
        {
            Commons.WriteDataControl.WaitOne();
            DataManagerInstance.AddFlightData(flightData);
            Commons.WriteDataControl.ReleaseMutex();
        }

        public static ObservableCollection<FlightDisplay> DisplayFlightDataInMemory()
        {
            return DataManagerInstance.FlightsForDisplay;
        }
    }
}
