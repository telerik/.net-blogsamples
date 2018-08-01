using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRHub
{
    public class SampleHub : Hub
    {
        private static Dictionary<string, string> userNames = new Dictionary<string, string>();

        public void Send(string name, string message)
        {
            Clients.AllExcept(userNames[name]).broadcastMessage(name, message);
        }

        public void Register(string userName)
        {
            if (!userNames.ContainsKey(userName))
            {
                userNames.Add(userName, Context.ConnectionId);

            }
            else
            {
                userNames[userName] = Context.ConnectionId;
            }

            Clients.All.usersLoggedIn(userName);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var userName = string.Empty;

            foreach (var key in userNames.Keys)
            {
                if (userNames[key] == Context.ConnectionId)
                {
                    userName = key;
                }
            }

            userNames.Remove(userName);
            Clients.All.usersLoggedOut(userName);

            return base.OnDisconnected(stopCalled);
        }
    }
}