using System;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace GroundTerminalSystem
{
    /// <summary>
    /// Handles receving packets from the ATS and processing the data within.
    /// </summary>
    public class Communication
    {
        /// <value>Socket for the client (ATS).</value>
        private TcpClient clientSocket;
        /// <value>ATS instance identifier.</value>
        private String ATS_ID;
        /// <value>Thread which receives the comms.</value>
        private Thread th;
        /// <value>Controls the comms loop which in turn controls comms in general.</value>
        bool bLoop = true;

        /// <summary>
        /// Handles receving packets from the ATS and processing the data within.
        /// </summary>
        /// <param name="inClientSocket"></param>
        /// <param name="ATS_ID"></param>
        public Communication(TcpClient inClientSocket, String ATS_ID)
        {
            // - Initial Settings
            this.clientSocket = inClientSocket;
            this.ATS_ID = ATS_ID;
        }

        /// <summary>
        /// Starts the process of receiving packets.
        /// </summary>
        public void StartCommunication()
        {
            bLoop = true;
            // - Start Threading to get packet
            th = new Thread(GetPacket);
            th.Start();
        }

        /// <summary>
        /// Receives packets from the ATS.
        /// </summary>
        private void GetPacket()
        {
            String dataFromClient;
            NetworkStream networkStream = clientSocket.GetStream();
            byte[] bytesFrom = new byte[clientSocket.ReceiveBufferSize];
            
            while (bLoop)
            {
                try
                {
                    if (networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize) == 0)
                    {
                        break;
                    }


                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! -- there is meesage
                    if (dataFromClient.StartsWith("TEST"))
                    {
                        Console.WriteLine("ATS [" + ATS_ID + "] : This is for Connection test from ATS!!!!!!!!!!!!!!!");
                    }
                    else
                    {
                        Console.WriteLine("ATS [" + ATS_ID + "] : " + dataFromClient);
                    }
                }
                // - when the connection is lost
                catch (Exception ex)
                {
                    Console.WriteLine("ATS [" + ATS_ID + "] : " + "Error : " + ex.Message);
                    bLoop = false;
                }
            }

           Console.WriteLine("ATS [" + ATS_ID + "] : " + "Disconnected.");
           clientSocket.Close();
           networkStream.Close();
        }

        /// <summary>
        /// Stops the communication loop in GetPacket, joins the thread.
        /// </summary>
        public void StopCommunication()
        {
            bLoop = false;
            th.Join(Commons.THREAD_JOIN_WAIT);
        }
    }
}
