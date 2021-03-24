using System.Threading.Tasks;
using MyrddinsOwl.CardGame.Server.Core;

namespace MyrddinsOwl.CardGame.Server
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var _installer = new ServerContext();
            _installer.InstallBindings();
            await _installer.Run();
        }
    }
}
