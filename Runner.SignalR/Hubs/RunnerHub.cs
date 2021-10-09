using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Runner.SignalR.Hubs
{
    public class RunnerHub : Hub
    {
        public async Task SendTauntMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveTauntMessage", message);
        }

    }
}
