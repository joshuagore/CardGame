using System;
using System.Threading.Tasks;
using MyrddinsOwl.CardGame.Shared;
using Unity;

namespace MyrddinsOwl.CardGame.Server.Core
{
    public class Server : IDisposable
    {
        private readonly ILogger _logger;
        private readonly MessageProcessor _messageProcessor;
        private readonly IUnityContainer _serverContainer;

        public Server(ILogger logger, MessageProcessor messageProcessor, IUnityContainer unityContainer)
        {
            _logger = logger;
            _messageProcessor = messageProcessor;
            _serverContainer = unityContainer.CreateChildContainer();
        }

        public void BindMore()
        {
            _serverContainer.RegisterType<IThing, Thing>();
        }

        public void ResolveExtraThing()
        {
            var thing = _serverContainer.Resolve<IThing>();
            thing.text = "text";
        }

        public async Task Run()
        {
            var counter = 0;
            var max = -1;
            while (max == -1)
            {
                _messageProcessor.DoTheThing();
                await Task.Delay(1000);
            }
        }

        public void Dispose()
        {
            _serverContainer?.Dispose();
        }
    }
}