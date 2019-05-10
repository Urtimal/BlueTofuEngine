using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ErpoowEngine.Network
{
    public class EEServer
    {
        private TcpListener _listener;
        private volatile bool isWorking;
        private Task listeningTask;
        
        public event Action ServerListening;
        public event Action<Exception> ServerListeningFailed;
        public event Action<EEClient> ClientAccepted;

        public EEServer(string ip, int port)
        {
            if (ip.Equals("localhost", StringComparison.OrdinalIgnoreCase))
                ip = "127.0.0.1";
            _listener = new TcpListener(IPAddress.Parse(ip), port);
        }

        /// <summary>
        /// Start the listening server
        /// </summary>
        public void Start()
        {
            try
            {
                _listener.Start();
                isWorking = true;
                listeningTask = Task.Run(async () => await waitingForClients());
                ServerListening?.Invoke();
            }
            catch (Exception e)
            {
                ServerListeningFailed.Invoke(e);
            }
        }

        /// <summary>
        /// Stop the listening server
        /// </summary>
        public void Stop()
        {
            isWorking = false;
            _listener.Stop();
            Task.WaitAll(listeningTask);
        }

        /// <summary>
        /// Loop to accept and register clients
        /// </summary>
        /// <returns></returns>
        private async Task waitingForClients()
        {
            while (isWorking)
            {
                var socket = await _listener.AcceptTcpClientAsync();
                if (socket != null && socket.Connected)
                {
                    var client = new EEClient(socket);
                    ClientAccepted?.Invoke(client);
                }       
            }
        }
    }
}
