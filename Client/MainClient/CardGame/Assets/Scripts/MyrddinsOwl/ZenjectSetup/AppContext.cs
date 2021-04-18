using MyrddinsOwl.CardGame.Core;
using Zenject;

namespace MyrddinsOwl.ZenjectSetup
{
    public class AppContext : SceneContext
    {
        public void Init()
        {
            Container.Resolve<App>();
        }
    }
}