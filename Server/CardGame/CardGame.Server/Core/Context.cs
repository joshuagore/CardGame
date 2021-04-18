using MyrddinsOwl.CardGame.Server.Logging;
using MyrddinsOwl.CardGame.Shared;
using Unity;

namespace MyrddinsOwl.CardGame.Server.Core
{
    public class Context
    {
        private IUnityContainer _container;
        public IUnityContainer Container => _container;

        public void ConfigureContainer()
        {
            _container = new UnityContainer();
        }

        public void RegisterTypes()
        {
            Container.RegisterSingleton<ILogger, ServerLogger>();
        }
    }
}