using MyrddinsOwl.CardGame.Core;
using Zenject;

namespace MyrddinsOwl.ZenjectSetup
{
    public class AppContext : SceneContext
    {
        private void Awake()
        {
            PostResolve += Init;
            base.Awake();
        }
        
        private void Init()
        {
            Container.Resolve<App>();
        }
    }
}