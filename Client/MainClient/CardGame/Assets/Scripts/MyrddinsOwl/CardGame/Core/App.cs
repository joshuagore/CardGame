using MyrddinsOwl.CardGame.ViewControllers;
using MyrddinsOwl.Core;
using UnityEngine;

namespace MyrddinsOwl.CardGame.Core
{
    public class App : CheckingBehavior
    {
        [SerializeField] private DebugHud _debugHud;
        [SerializeField] private StartHud _startHud;

        protected override void Awake()
        {             
            base.Awake();
            
            //Add App Initialization Code here
            StartDebugHud();
        }
        
        protected override void ValidateFields()
        {
            LogIfMissing(_debugHud, nameof(_debugHud));
            LogIfMissing(_startHud, nameof(_startHud));
        }

        private void StartDebugHud()
        {
            _debugHud.Init();
        }
    }
}


