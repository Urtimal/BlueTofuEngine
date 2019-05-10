using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ErpoowEngine.Network
{
    public class EEClient
    {
        private TcpClient _client;

        private Task readingTask;

        public event Action<byte[]> DataReceived;
        public event Action Disconnected;

        public string RemoteEndPoint { get; set; }

        public EEClient(TcpClient client)
        {
            _client = client;
            RemoteEndPoint = client.Client.RemoteEndPoint.ToString();
            readingTask = Task.Run(async () => await readingData());
        }

        /// <summary>
        /// Close the client connection
        /// </summary>
        public void Close()
        {
            try
            {
                _client.Close();
            }
            catch { }
        }

        /// <summary>
        /// Send data to the client
        /// </summary>
        /// <param name="data"></param>
        public void Send(byte[] data)
        {
            if (data == null || data.Length < 1)
                return;

            try
            {
                _client.Client.Send(data);
                if (!_client.Client.Connected)
                    this.Close();
            }
            catch
            {
                this.Close();
            }
        }

        private async Task readingData()
        {
            try
            {
                while (true)
                {
                    if (_client == null || !_client.Connected)
                        break;
                    
                    var data = await read();
                    if (data.Length > 0)
                        DataReceived?.Invoke(data);
                    else
                        break;
                }
            }
            catch { }
            Disconnected?.Invoke();
        }

        private async Task<byte[]> read()
        {
            List<byte> data = new List<byte>();
            var buffer = new byte[1024];
            while (true)
            {
                int bytesRead = _client.GetStream().Read(buffer, 0, buffer.Length);
                //int bytesRead = await _client.Client.ReceiveAsync(buffer, SocketFlags.None);
                data.AddRange(buffer.Take(bytesRead));
                if (bytesRead < 1024)
                    return data.ToArray();
            }
        }
    }
}
