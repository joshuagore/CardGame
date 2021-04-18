using MyrddinsOwl.Core;
using Zenject;

namespace MyrddinsOwl.CardGame.Debug
{
    public class DebugInstaller : Installer<DebugInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<FpsService>().AsSingle();
            Container.Bind<DebugHudController>().AsSingle();
        }
    }
}