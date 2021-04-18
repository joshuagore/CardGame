using System;
using MyrddinsOwl.CardGame.Shared;

namespace MyrddinsOwl.CardGame.Server.Logging
{
    public class ServerLogger : ILogger
    {
        private enum LogType
        {
            Info = 0,
            Warning = 1,
            Error = 2
        }
        
        public void Info(object obj)
        {
            Log(LogType.Info, obj);
        }

        public void Warning(object obj)
        {
            Log(LogType.Warning, obj);
        }

        public void Error(object obj)
        {
            Log(LogType.Error, obj.ToString());
        }

        private void Log(LogType type, object obj)
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
            
            Console.WriteLine($"{DateTime.UtcNow:o} | {prefix} | {obj}");
        }
    }
}