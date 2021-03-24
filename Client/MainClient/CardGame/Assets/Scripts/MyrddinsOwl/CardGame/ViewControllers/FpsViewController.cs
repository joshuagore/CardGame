using System;
using System.Threading.Tasks;
using MyrddinsOwl.CardGame.Shared;
using MyrddinsOwl.Core;
using TMPro;
using UnityEngine;

namespace MyrddinsOwl.CardGame.ViewControllers
{
    public class FpsViewController : IDisposable
    {
        private TextMeshProUGUI _fps;
        private bool _updateLoopRunning;
        private readonly ILogService _logService;

        public FpsViewController(TextMeshProUGUI fps)
        {
            _logService = new UnityLogger();
            
            _fps = fps;
            
            Init();
        }

        private void Init()
        {
            TaskUtility.AsyncTask(UpdateFps());
        }

        private async Task UpdateFps()
        {
            _updateLoopRunning = true;
            while (_updateLoopRunning)
            {
                var ms = Time.deltaTime * 1000;

                _fps.text = (1000 / ms).ToString("N0");
                _logService.Info("Start of wait");
                await Task.Delay(500);
                _logService.Info("End of wait");
            }
        }

        public void Dispose()
        {
            _fps = null;
            _updateLoopRunning = false;
        }
    }
}
