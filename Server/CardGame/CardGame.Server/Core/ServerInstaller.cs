
using System.Threading.Tasks;
using MyrddinsOwl.CardGame.Server.Logging;
using MyrddinsOwl.CardGame.Shared;
using Zenject;

namespace MyrddinsOwl.CardGame.Server.Core
{
    public class ServerInstaller : Installer<ServerInstaller>
    {
        public override void InstallBindings()
        {
            
            Container.Bind<ILogService>().To<ServerLogService>().AsSingle();

            Container.Bind<MessageProcessor>();
        }

        public async Task Run()
        {
            var messageProcessor = Container.Resolve<MessageProcessor>();
            
            var counter = 0;
            var max = -1;
            while (max == -1)
            {
                messageProcessor.DoTheThing();
                await Task.Delay(1000);
            }
        }
    }
}