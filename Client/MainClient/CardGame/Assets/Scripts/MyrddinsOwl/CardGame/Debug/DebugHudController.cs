using MyrddinsOwl.Core;

namespace MyrddinsOwl.CardGame.Debug
{
    public sealed class DebugHudController : Controller<DebugHudView, DebugHudModel>
    {
        private readonly FpsService _fpsService;

        public DebugHudController(FpsService fpsService)
        {
            _fpsService = fpsService;
        }

        protected override void OnReady()
        {
            RunController();
            base.OnReady();
        }

        private void RunController()
        {
            SubscribeEvents();
            SetServer("SomeServer");
        }

        private void SetFps(string value)
        {
            Model.Fps = value;
        }

        private void SetServer(string value)
        {
            Model.Server = value;
        }

        private void SubscribeEvents()
        {
            _fpsService.FpsUpdated += SetFps;
        }

        private void UnsubscribeEvents()
        {
            _fpsService.FpsUpdated -= SetFps;
        }

        private void DisposeManaged()
        {
            UnsubscribeEvents();
            _fpsService.Dispose();
        }

        #region Dispose
        // To detect redundant calls
        private bool _disposed;

        ~DebugHudController() => Dispose(false);

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