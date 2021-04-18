using Zenject;

namespace MyrddinsOwl.CardGame.StartScreen
{
    public class StartScreenInstaller : Installer<StartScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<StartScreenController>().AsSingle();
        }
    }
}