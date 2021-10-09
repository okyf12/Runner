using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner2.Services
{
    public class SignalRService
    {
        private readonly HubConnection _connection;

        public event Action<string> TauntMessageReceived;

        public SignalRService(HubConnection connection)
        {
            _connection = connection;

            _connection.On<string>("ReceiveTauntMessage", (message) => TauntMessageReceived?.Invoke(message));
        }

        public async Task Connect()
        {
            await _connection.StartAsync();
        }

        public async Task SendTauntMessage(string message)
        {
            await _connection.SendAsync("SendTauntMessage", message);
        }
    }
}
