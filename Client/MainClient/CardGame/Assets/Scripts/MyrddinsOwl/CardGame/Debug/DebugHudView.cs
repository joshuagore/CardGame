using MyrddinsOwl.Core;
using TMPro;
using UnityEngine;

namespace MyrddinsOwl.CardGame.Debug
{
    public class DebugHudView : View
    {
        [SerializeField] public TextMeshProUGUI _fps;
        [SerializeField] private TextMeshProUGUI _server;

        public void SetFpsText(string value)
        {
            _fps.text = value;
        }
        
        public void SetServerText(string value)
        {
            _server.text = value;
        }
    }
}