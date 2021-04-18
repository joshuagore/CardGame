using MyrddinsOwl.CardGame.Shared;

namespace MyrddinsOwl.CardGame.Server
{
    public class MessageProcessor
    {
        private readonly ILogger _logger;
        
        public MessageProcessor(ILogger logger)
        {
            _logger = logger;
        }

        public void DoTheThing()
        {
            _logger.Info("Some Info Message");
            _logger.Warning("Some Warning Message");
            _logger.Error("Some Error Message");
        }
    }
}