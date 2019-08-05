using Marketplace.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Hubs
{
    public class ChatHub : Hub
    {
        public asyncTask SendMessage(Message message) =>
            await Clients.All.SendAsync("recieveMessage", message);
    }
}
