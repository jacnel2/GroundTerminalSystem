using GroundTerminalSystem.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
        
        /// <summary>
        /// Takes a string of Flight data and stores it in memory.
        /// </summary>
        /// <param name="flightData">String of data to store.</param>
        public static void SendFlightDataToMemory(String flightData)
        {
            Commons.WriteDataControl.WaitOne();
            DataManagerInstance.AddFlightData(flightData);
            Commons.WriteDataControl.ReleaseMutex();
        }

        /// <summary>
        /// Returns all Flight data in memory as a FlightDisplay object.
        /// </summary>
        /// <returns>Returns all Flight data in memory as a FlightDisplay object.</returns>
        public static ObservableCollection<FlightDisplay> DisplayFlightDataInMemory()
        {
            return DataManagerInstance.FlightsForDisplay;
        }

        /// <summary>
        /// Gathers all GForce data stored in database.
        /// </summary>
        /// <returns>All GForce data stored in database.</returns>
        public static DataTable GetGForceGrid()
        {
            return DatabaseManager.retrieveData("gForceParameters");
        }

        /// <summary>
        /// Gathers all Attitude data stored in the database.
        /// </summary>
        /// <returns>All Attitude data stored in the database.</returns>
        public static DataTable GetAttitudeGrid()
        {
            return DatabaseManager.retrieveData("attitudeParameters");
        }

        /// <summary>
        /// Clears the GForce database.
        /// </summary>
        /// <returns>The result of the clear.</returns>
        public static DataTable ClearGForceGrid()
        {
            return DatabaseManager.deleteData("gForceParameters");
        }

        /// <summary>
        /// Clears the Attitude database.
        /// </summary>
        /// <returns>The result of the clear.</returns>
        public static DataTable ClearAttitudeGrid()
        {
            return DatabaseManager.deleteData("attitudeParameters");
        }

        /// <summary>
        /// Searches for data within the given range for the given table.
        /// </summary>
        /// <param name="dbTable">Table to search.</param>
        /// <param name="startDate">Starting date for search range.</param>
        /// <param name="endDate">End date for search range.</param>
        /// <returns>The result of the search.</returns>
        public static DataTable SearchData(string dbTable, string startDate, string endDate)
        {
            return DatabaseManager.searchDataBetweenDates(dbTable, startDate, endDate);
        }
    }
}
