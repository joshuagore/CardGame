using MyrddinsOwl.CardGame.Shared;
using MyrddinsOwl.Core;

namespace MyrddinsOwl.CardGame.StartScreen
{
    public class StartScreenController : Controller<StartScreenView, StartScreenModel>
    {
        private readonly ILogger _logger;

        public StartScreenController(ILogger logger)
        {
            _logger = logger;
        }

        protected override void OnReady()
        {
            SubscribeEvents();
            base.OnReady();
        }
        
        private void OnPlayClicked()
        {
            UnsubscribeEvents();
            _logger.Info("Play Now!");
        }

        private void SubscribeEvents()
        {
            View.PlayClicked += OnPlayClicked;
        }

        private void UnsubscribeEvents()
        {
            View.PlayClicked -= OnPlayClicked;
        }
        private void DisposeManaged()
        {
            UnsubscribeEvents();
        }

        #region Dispose
        // To detect redundant calls
        private bool _disposed;

        ~StartScreenController() => Dispose(false);

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
                DisposeManaged();
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