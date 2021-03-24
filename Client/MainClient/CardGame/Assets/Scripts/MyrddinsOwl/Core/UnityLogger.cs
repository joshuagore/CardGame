using MyrddinsOwl.CardGame.Shared;
using UnityEngine;

namespace MyrddinsOwl.Core
{
    public class UnityLogger : ILogService
    {
        private enum LogLevel
        {
            Info,
            Warning,
            Error
        }
        
        public void Info(string logMessage)
        {
            Log(LogLevel.Info, logMessage);
        }

        public void Warning(string logMessage)
        {
            Log(LogLevel.Warning, logMessage);
        }

        public void Error(string logMessage)
        {
            Log(LogLevel.Error, logMessage);
        }

        private void Log(LogLevel logLevel, string logMessage)
        {
            switch (logLevel)
            {
                case LogLevel.Info:
                    Debug.Log(logMessage);
                    break;
                case LogLevel.Warning:
                    Debug.LogWarning(logMessage);
                    break;
                case LogLevel.Error:
                    Debug.LogError(logMessage);
                    break;
            }
        }
        
    }
}