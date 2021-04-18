using System;
using System.Threading.Tasks;
using UnityEngine;

namespace MyrddinsOwl.Core
{
    public sealed class FpsService : IDisposable
    {
        private bool _isCancelled;
        public event Action<string> FpsUpdated;

        public FpsService()
        {
            Run();
        }

        private async void Run()
        {
            await UpdateLoop();
        }

        private async Task UpdateLoop()
        {
            while (!_isCancelled)
            {
                UpdateFps();
                await Task.Delay(500);
            }
        }

        private void UpdateFps()
        {
            var ms = Time.deltaTime * 1000;
            FpsUpdated?.Invoke((1000 / ms).ToString("N0"));
        }

        public void Dispose()
        {
            _isCancelled = true;
        }
    }
}
