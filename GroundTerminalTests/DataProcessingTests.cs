using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GroundTerminalSystem;
using GroundTerminalSystem.Data;

namespace GroundTerminalTests
{
    [TestClass]
    public class DataProcessingTests
    {
        [TestMethod]
        public void Test121()
        {
            Flight flight = new Flight();
            flight.AircraftTail = "C-FGAX";
            Director.DataManagerInstance.AddFlightData("C-FGAX;1;7_8_2018 19:34:3,-0.319754,-0.716176,1.797150,2154.670410,1643.844116,0.022278,0.033622;548");
            Assert.AreEqual(flight.AircraftTail, Director.DataManagerInstance.Flights[0].AircraftTail);
        }

        [TestMethod]
        public void Test122()
        {
            Director.DataManagerInstance.AddFlightData("C-FGAX;1;7_8_2018 19:34:3,-0.319754,-0.716176,1.797150,2154.670410,1643.844116,0.022278,0.033622;548");
            Director.DataManagerInstance.AddFlightData("C-FGAX;1;7_8_2018 19:34:3,-0.319754,-0.716176,1.797150,2154.670410,1643.844116,0.022278,0.033622;548");
            Assert.AreEqual(1643.844116f, Director.DataManagerInstance.Flights[0].AttitudeParams[1].Altitude);
        }
    }
}
