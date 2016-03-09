using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Collections.Concurrent;
using Hangfire;
using System.Threading;
using BackgroundProofConcept.Web.Models;

namespace BackgroundProofConcept.Web.Hubs
{
    public class OrdenesHub : Hub
    {
        private static ConcurrentDictionary<string, Guid> _subscriptions = new ConcurrentDictionary<string, Guid>();
        public void SendOrder(Order order)
        {            
            BackgroundJob.Enqueue(() => RegisterOrder(order.Id,Context.ConnectionId));
        }

        /// <summary>
        /// Aqui se deberia usar un servicio para guardar la orden
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection"></param>
        public void RegisterOrder(Guid id,string connection)
        {
            Thread.Sleep(5000);
            var context = GlobalHost.ConnectionManager.GetHubContext<OrdenesHub>();
            context.Clients.Client(connection).DoneOrder(id);
        }
    }
}