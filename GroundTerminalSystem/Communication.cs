using System;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace GT_connection_example
{
    public class Communication
    {
        private TcpClient clientSocket;
        private String ATS_ID;


        public void StartCommunication(TcpClient inClientSocket, String ATS_ID)
        {
            // - Initial Settings
            this.clientSocket = inClientSocket;
            this.ATS_ID = ATS_ID;

            // - Start Threading to get packet
            Thread th = new Thread(GetPacket);
            th.Start();
        }

        private void GetPacket()
        {
            String dataFromClient = null;
            NetworkStream networkStream = clientSocket.GetStream();
            byte[] bytesFrom = new byte[clientSocket.ReceiveBufferSize];
            MemoryStream s = new MemoryStream(); // - you can use memory stream if you want

            // Step 1. Loop until the connection is lost
            bool bLoop = true;
            while (bLoop) // <= or simply you can ch do ~ while (s.Length < (int)clientSocket.ReceiveBufferSize);
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


    }
}
