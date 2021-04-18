namespace MyrddinsOwl.CardGame.Shared
{
    public interface ILogger
    {
        void Info(object obj);
        void Warning(object obj);
        void Error(object obj);
    }
}