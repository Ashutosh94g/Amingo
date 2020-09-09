using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Datingapp.App_Start.OwinChatStartup))]

namespace Datingapp.App_Start
{
    public class OwinChatStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
