using System;
using MyrddinsOwl.Mvc.Interfaces;

namespace MyrddinsOwl.CardGame.Debug
{
    public sealed class DebugHudModel : IModel
    {
        public Action<string> FpsChanged;
        private string _fps;
        public string Fps {
            set
            {
                _fps = value;
                FpsChanged?.Invoke(_fps);
            }
        }

        public Action<string> ServerChanged;
        private string _server;
        public string Server {
            set
            {
                _server = value;
                ServerChanged?.Invoke(_server);
            }
        }
    }
}