using System.ServiceProcess;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin;


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
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
    }
}
