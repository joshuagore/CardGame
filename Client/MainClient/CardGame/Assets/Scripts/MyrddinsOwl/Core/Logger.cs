using UnityEngine;
using ILogger = MyrddinsOwl.CardGame.Shared.ILogger;

namespace MyrddinsOwl.Core
{
    public class Logger : ILogger
    {
        public Logger ()
        {
            _instance ??= this;
        }

        private static Logger _instance;
        public static Logger Instance => _instance ??= new Logger();

        private enum LogLevel
        {
            Info,
            Warning,
            Error
        }
        
        public void Info(object obj)
        {
            Log(LogLevel.Info, obj);
        }

        public void Warning(object obj)
        {
            Log(LogLevel.Warning, obj);
        }
        
        public void Error(object obj)
        {
            Log(LogLevel.Error, obj);
        }

        private void Log(LogLevel logLevel, object obj)
        {
            switch (logLevel)
            {
                case LogLevel.Info:
                    UnityEngine.Debug.Log(obj);
                    break;
                case LogLevel.Warning:
                    UnityEngine.Debug.LogWarning(obj);
                    break;
                case LogLevel.Error:
                    UnityEngine.Debug.LogError(obj);
                    break;
            }
        }
        
    }
}