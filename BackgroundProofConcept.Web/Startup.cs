using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;

[assembly: OwinStartup(typeof(BackgroundProofConcept.Web.Startup))]

namespace BackgroundProofConcept.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("hangDb");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
            app.MapSignalR();            
        }
    }
}
