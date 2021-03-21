using System;
using MyrddinsOwl.CardGame.ViewControllers;
using MyrddinsOwl.Core;
using TMPro;
using UnityEngine;

namespace MyrddinsOwl.CardGame.Core
{
    public class DebugHud : CheckingBehavior
    {
        [SerializeField] private TextMeshProUGUI _fps;
        [SerializeField] private TextMeshProUGUI _server;

        private FpsViewController _fpsViewController;
        
        protected override void Awake()
        {             
            base.Awake();
        }

        public void Init()
        {
            _fpsViewController = new FpsViewController(_fps);
        }

        protected override void ValidateFields()
        {
            LogIfMissing(_fps, nameof(_fps));
            LogIfMissing(_server, nameof(_server));
        }

        private void OnDestroy()
        {
            _fpsViewController.Dispose();
        }
    }
}