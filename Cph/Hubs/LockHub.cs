using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Cph.Hubs
{
    public class LockHub : Hub
    {
        private static readonly Dictionary<string, string> _locks = new Dictionary<string, string>();
        private static readonly HashSet<string> _clients = new HashSet<string>();

        public bool Lock(string entityId)
        {
            lock (_locks)
            {
                if (_locks.ContainsKey(entityId))
                {
                    return false;
                }

                _locks.Add(entityId, Context.ConnectionId);
                Clients.Others.@lock(entityId);
                return true;
            }
        }

        public void Unlock(string entityId)
        {
            lock (_locks)
            lock (_clients)
            {
                _locks.Remove(entityId);

                var others = _clients.Except(new[] {Context.ConnectionId}).ToList();
                if (others.Any())
                {
                    var next = others.First();
                    _locks.Add(entityId, next);
                    Clients.Client(next).unlock(entityId);
                }
            }
        }

        public override Task OnConnected()
        {
            lock (_clients)
            {
                _clients.Add(Context.ConnectionId);
            }

            return base.OnConnected();
        }

        public override Task OnDisconnected()
        {
            lock (_clients)
            {
                _clients.Remove(Context.ConnectionId);
            }

            lock (_locks)
            {
                if (_locks.ContainsValue(Context.ConnectionId))
                {
                    var entityId = _locks.First(l => l.Value == Context.ConnectionId).Key;
                    Unlock(entityId);
                }
            }

            return base.OnDisconnected();
        }
    }
}