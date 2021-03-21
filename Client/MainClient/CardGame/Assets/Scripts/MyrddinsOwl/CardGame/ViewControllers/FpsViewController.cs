using System;
using System.Threading.Tasks;
using MyrddinsOwl.Core;
using TMPro;
using UnityEngine;

namespace MyrddinsOwl.CardGame.ViewControllers
{
    public class FpsViewController : IDisposable
    {
        private TextMeshProUGUI _fps;
        private bool _updateLoopRunning;

        public FpsViewController(TextMeshProUGUI fps)
        {
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
                
                await Task.Delay(500);
            }
        }

        public void Dispose()
        {
            _fps = null;
            _updateLoopRunning = false;
        }
    }
}
