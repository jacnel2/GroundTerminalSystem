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
    }
}
