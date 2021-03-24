using System;
using MyrddinsOwl.CardGame.Shared;

namespace MyrddinsOwl.CardGame.Server.Logging
{
    public class ServerLogService : ILogService
    {
        private enum LogType
        {
            Info = 0,
            Warning = 1,
            Error = 2
        }
        
        public void Info(string logMessage)
        {
            Log(LogType.Info, logMessage);
        }

        public void Warning(string logMessage)
        {
            Log(LogType.Warning, logMessage);
        }

        public void Error(string logMessage)
        {
            Log(LogType.Error, logMessage);
        }

        private void Log(LogType type, string logMessage)
        {
            var prefix = "";
            switch (type)
            {
                case LogType.Info:
                    prefix = "INFO";
                    break;
                case LogType.Warning:                   
                    prefix = "WARN";
                    break;
                case LogType.Error:                    
                    prefix = "ERRO";
                    break;
            }
            
            Console.WriteLine($"{DateTime.UtcNow:o} | {prefix} | {logMessage}");
        }
    }
}