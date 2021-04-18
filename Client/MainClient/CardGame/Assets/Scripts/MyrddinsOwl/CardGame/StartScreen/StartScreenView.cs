using System;
using MyrddinsOwl.Core;
using UnityEngine;
using UnityEngine.UI;

namespace MyrddinsOwl.CardGame.StartScreen
{
    public class StartScreenView : View<StartScreenModel>
    {
        [SerializeField] private Button _play;

        public event Action PlayClicked;

        protected override void OnReady()
        {
            SubscribeListeners();
            base.OnReady();
        }
        
        private void OnPlayClicked()
        {
            PlayClicked?.Invoke();
        }
        
        private void SubscribeListeners()
        {
            _play.onClick.AddListener(OnPlayClicked);
        }
        
        private void UnsubscribeEvents()
        {
            _play.onClick.RemoveListener(OnPlayClicked);
        }

        #region Dispose
        // To detect redundant calls
        private bool _disposed;

        ~StartScreenView() => Dispose(false);

        // Protected implementation of Dispose pattern.
        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // dispose managed state (managed objects).
                UnsubscribeEvents();
            }

            // free unmanaged resources (unmanaged objects) and override a finalizer below.
            // set large fields to null.
            _disposed = true;

            // Call the base class implementation.
            base.Dispose(disposing);
        }
        #endregion
    }
}
