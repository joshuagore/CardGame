using System.Threading.Tasks;
using MyrddinsOwl.CardGame.Server.Logging;
using MyrddinsOwl.CardGame.Shared;
using Zenject;

namespace MyrddinsOwl.CardGame.Server.Core
{
    public class ServerContext
    {
        private readonly DiContainer _diContainer;
        public DiContainer Container => _diContainer;

        public ServerContext()
        {
            _diContainer = new DiContainer();
        }

        public void InstallBindings()
        {
            Container.Bind<ILogService>().To<ServerLogService>().AsSingle();

            Container.Bind<MessageProcessor>().AsTransient();
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