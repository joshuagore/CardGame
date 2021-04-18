using System.Threading.Tasks;
using MyrddinsOwl.CardGame.Server.Core;
using Unity;

namespace MyrddinsOwl.CardGame.Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var context = new Context();
            context.ConfigureContainer();
            context.RegisterTypes();

            var server = context.Container.Resolve<Core.Server>();
            server.BindMore();
            server.ResolveExtraThing();
            
            await server.Run();
        }
    }
}
