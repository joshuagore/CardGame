using MyrddinsOwl.CardGame.Shared;
using Zenject;

namespace MyrddinsOwl.Core
{
    public class SystemInstaller : Installer<SystemInstaller>
    {
        public override void InstallBindings()
        {
                Container.Bind<IContainer>().To<Container>().FromInstance(new Container(Container)).AsSingle();
                Container.Bind<ILogger>().To<Logger>().AsSingle();
                Container.Bind<AssetLoader>().AsSingle();
                Container.Bind<MvcFactory>().AsSingle();
        }
    }
}