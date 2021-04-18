using MyrddinsOwl.Core;
using Zenject;

namespace MyrddinsOwl.CardGame.Debug
{
    public class DebugHudInstaller : Installer<DebugHudInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<FpsService>().AsTransient();
            Container.Bind<DebugHudController>().AsSingle();
        }
    }
}