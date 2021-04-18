using MyrddinsOwl.Core;
using TMPro;
using UnityEngine;

namespace MyrddinsOwl.CardGame.Debug
{
    public sealed class DebugHudView : View<DebugHudModel>
    {
        [SerializeField] public TextMeshProUGUI _fps;
        [SerializeField] private TextMeshProUGUI _server;

        private void SetFpsText(string value)
        {
            _fps.text = value;
        }
        
        private void SetServerText(string value)
        {
            _server.text = value;
        }

        protected override void OnReady()
        {
            SubscribeEvents();
            base.OnReady();
        }

        private void SubscribeEvents()
        {
            Model.FpsChanged += SetFpsText;
            Model.ServerChanged += SetServerText;
        }
        
        private void UnsubscribeEvents()
        {
            Model.FpsChanged -= SetFpsText;
            Model.ServerChanged -= SetServerText;
        }

        #region Dispose
        // To detect redundant calls
        private bool _disposed;

        ~DebugHudView() => Dispose(false);

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