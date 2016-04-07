﻿using System.ServiceProcess;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;


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
        private static readonly ConcurrentDictionary<string, User> Users
         = new ConcurrentDictionary<string, User>();
        public MyHub()
        {
           
        }
        
        public override System.Threading.Tasks.Task OnConnected()
        {
            string connectionId = Context.ConnectionId;
            
            return base.OnConnected();
        }
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;
            return base.OnDisconnected(stopCalled);
        }
        public override System.Threading.Tasks.Task OnReconnected()
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;
            return base.OnReconnected();
        }
        
        public void Send(Message message)
        {
            Clients.All.addMessage(message);
        }
    }
}
