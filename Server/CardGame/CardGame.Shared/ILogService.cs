namespace MyrddinsOwl.CardGame.Shared
{
    public interface ILogService
    {
        void Info(string logMessage);
        void Warning(string logMessage);
        void Error(string logMessage);
    }
}