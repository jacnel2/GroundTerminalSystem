using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GroundTerminalSystem
{
    /// <summary>
    /// Handles receving communcations from the ATS.
    /// </summary>
    public class Server
    {
        //****PUBLIC****
        /// <value>The IP address for this server.</value>
        public String SIPaddress { get; private set; }
        /// <value>The port for this server.</value>
        public String SPort { get; private set; }

        //****PRIVATE****
        /// <value>Socket for the server used for the TCP comms.</value>
        private TcpListener Socket_Server;
        /// <value>>Socket for the client (ATS) instance used for the TCP comms.</value>
        private TcpClient Socket_Client;
        /// <value>Stores reference to the thread which runs the server.</value>
        private Thread ServerThread;
        /// <value>Stores all the ATS communication instances found by listening over TCP port.</value>
        private List<Communication> ATSInstances = new List<Communication>();
        /// <value>Denotes if the server loop should continue running.</value>
        private bool RunServer = true;

        /// <summary>
        /// Handles receving communcations from the ATS.
        /// </summary>
        /// <param name="sPort">Port for server comms.</param>
        public Server(string sPort)
        {
            this.SPort = sPort;
            this.SIPaddress = GetLocalIPAddress();

            // Show the condition
            Console.WriteLine("\n2) Current Setting : \n\n"
                                + "  IP Address : " + SIPaddress + "\n"
                                + "  Port       : " + sPort);
        }

        /// <summary>
        /// Gets the Local IP for the machine running this program.
        /// </summary>
        /// <returns>The local IP as a String.</returns>
        private String GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return null;
        }

        /// <summary>
        /// To be run in a separate thread, recevies comms from the client (ATS).
        /// </summary>
        private void BeAServer()
        {
            Console.WriteLine("THREAD: " + Thread.CurrentThread.ManagedThreadId);
            while (RunServer)
            {
                Console.WriteLine("Server running - Poll for connection.");
                if (!Socket_Server.Pending())
                {
                    Thread.Sleep(Commons.THREAD_WAIT);
                    continue;
                }
                Commons.ServerMutex.WaitOne();

                Socket_Client = Socket_Server.AcceptTcpClient();

                ATSInstances.Add(new Communication(Socket_Client, ATSInstances.Count.ToString()));
                ATSInstances[ATSInstances.Count - 1].StartCommunication();

                Console.WriteLine("ATS - " + Convert.ToString(ATSInstances.Count - 1) + " connected!");

                Commons.ServerMutex.ReleaseMutex();
            }
            Console.WriteLine("Server stopped - Exit server loop.");
        }

        /// <summary>
        /// Opens the server, starts the listening thread (method: BeAServer).
        /// </summary>
        public void StartBeingAServer()
        {
            RunServer = true;
            Socket_Server = new TcpListener(IPAddress.Parse(SIPaddress), Int32.Parse(SPort));
            Socket_Server.Start();
            ServerThread = new Thread(BeAServer);
            ServerThread.Start();
        }

        /// <summary>
        /// Kills the server thread safely, let's us stop being a server.
        /// </summary>
        public void StopBeingAServer()
        {
            RunServer = false;
            ServerThread.Join(Commons.THREAD_JOIN_WAIT);
            if (ATSInstances != null)
            {
                foreach (Communication client in ATSInstances)
                {
                    client.StopCommunication();
                }
            }
            ATSInstances.Clear();
            ATSInstances.TrimExcess();
            Socket_Server.Stop();
        }
    }
}
