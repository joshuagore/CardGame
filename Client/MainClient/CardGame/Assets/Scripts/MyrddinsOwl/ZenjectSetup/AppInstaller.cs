using MyrddinsOwl.CardGame.Core;
using MyrddinsOwl.CardGame.Debug;
using MyrddinsOwl.Core;
using Zenject;

namespace MyrddinsOwl.ZenjectSetup
{
    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SystemInstaller.Install(Container);
            Container.Bind<App>().AsSingle();
            DebugInstaller.Install(Container);
        }
    }
}
