using System.ServiceProcess;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using CaHm.Server.Helpers;
using CaHm.Server.Model;


namespace CaHm.Server
{
    public partial class CaHmService : ServiceBase
    {
        public CaHmService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            if (!System.Diagnostics.EventLog.SourceExists("CaHmService"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "CaHmService", "Application");
            }
            eventLog1.Source = "CaHmService";
            eventLog1.Log = "Application";

            eventLog1.WriteEntry("In OnStart");
            string url = "http://localhost:8080";
            WebApp.Start(url);

        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In OnStop");
        }
    }
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
    
    public class MyHub : Hub
    {
        private static readonly ConcurrentDictionary<string, List<string>> GroupWithConnections
         = new ConcurrentDictionary<string, List<string>>();
        public MyHub()
        {
           
        }
        public override System.Threading.Tasks.Task OnConnected()
        {
            
                   
            
           
            
            return base.OnConnected();
        }
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            string connectionId = Context.ConnectionId;
            return base.OnDisconnected(stopCalled);
        }
        public override System.Threading.Tasks.Task OnReconnected()
        {
            string connectionId = Context.ConnectionId;
            return base.OnReconnected();
        }
        
        public void Send(Message message)
        {
            Clients.All.addMessage(message);
            
        }
        public async Task CreateGame()
        {
            var connectionId = Context.ConnectionId;
            var groupId = GetNewGroupId();
            await Groups.Add(Context.ConnectionId, groupId.ToString());
            Clients.Client(connectionId).addMessage(groupId);

        }
        public async Task JoinGame(User user)
        {
            await Groups.Add(Context.ConnectionId, user.GroupId);
            AddPlayerToGroup(user.GroupId);
            Clients.Group(user.GroupId).addMessage(user);
        }

        public void StartGame(string cardPack, string groupId)
        {
            DealCards(cardPack, groupId);
        }
        private void DealCards(string cardPack, string groupId)
        {
            List<string> connections;
            GroupWithConnections.TryGetValue(groupId, out connections);
            if(connections!=null){
                var cardParser = new CardParser();
                Random rnd = new Random();
            
                List<WhiteCard> whiteCards = cardParser.GetWhiteCards();
                foreach(var id in connections){
                    var cardsForPlayer = new List<WhiteCard>();
                    for (int i = 0; i < 7; i++)
                    {
                        cardsForPlayer.Add(whiteCards[rnd.Next(0, 1047)]);
                    }
                    Clients.Client(id).addMessage(cardsForPlayer);
                }
            }
        }
        private int GetNewGroupId()
        {
            Random rnd = new Random();
            int groupId = rnd.Next(0, 100000);
            return groupId;
        }
        private void AddPlayerToGroup(string groupId)
        {
            string connectionId = Context.ConnectionId;
            var connectionIds = new List<string> { connectionId };

            GroupWithConnections.AddOrUpdate(groupId, connectionIds, (key, existingVal) =>
            {
                if(existingVal == null){
                    existingVal = new List<string> { connectionIds[0] };
                }
                else
                {
                    existingVal.Add(connectionIds[0]);
                }
                return existingVal;
            });
        }
    }
}
