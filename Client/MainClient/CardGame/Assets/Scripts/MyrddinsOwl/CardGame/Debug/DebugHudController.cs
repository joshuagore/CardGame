using System;
using MyrddinsOwl.Core;

namespace MyrddinsOwl.CardGame.Debug
{
    public sealed class DebugHudController : Controller<DebugHudView>, IDisposable
    {
        private readonly FpsService _fpsService;

        public DebugHudController(FpsService fpsService)
        {
            _fpsService = fpsService;
        }

        protected override void OnViewReady()
        {
            _fpsService.FpsUpdated += SetFps;
        }

        protected override void OnViewDestroyed()
        {
            Dispose();
        }

        private void SetFps(string value) => View.SetFpsText(value);

        public override void Dispose()
        {
            _fpsService.Dispose();
        }
    }
}