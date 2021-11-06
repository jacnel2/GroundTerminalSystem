using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GroundTerminalSystem
{
    /// <summary>
    /// Defines common values between each of the classes.
    /// </summary>
    public static class Commons
    {
        /// <value>Thread join time-out.</value>
        public static readonly int THREAD_JOIN_WAIT = 1000;

        /// <value>Thread sleep wait time.</value>
        public static readonly int THREAD_WAIT = 500;

        /// <value>To control thread access of Server data members.</value>
        public static Mutex ServerMutex = new Mutex();

        /// <value>To control thread calls to the DataManager class to write data to memory.</value>
        public static Mutex WriteDataControl = new Mutex();

        /// <value>Separators for converting a date string to a DateTime object.</value>
        public static Char[] DATE_DELIM = { '_', ' ', ':' };

        /// <summary>
        /// Used to call Director functions asynchronously.
        /// </summary>
        /// <param name="data">Data to be passed with call.</param>
        public delegate void AsyncMethodCaller(String data);

        /// <value>Denotes how long to wait before updating the RealTimeFlightScreen.</value>
        public static readonly int THREAD_SCREEN_UPDATE_WAIT = 500;

        /// <value>Used to lock access to Lists when they are being accessed from multiple threads.</value>
        public static object _lock = new object();
    }
}
