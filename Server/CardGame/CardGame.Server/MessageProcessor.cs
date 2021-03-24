using MyrddinsOwl.CardGame.Shared;

namespace MyrddinsOwl.CardGame.Server
{
    public class MessageProcessor
    {
        private readonly ILogService _logService;
        
        public MessageProcessor(ILogService logService)
        {
            _logService = logService;
        }

        public void DoTheThing()
        {
            _logService.Info("Some Info Message");
            _logService.Warning("Some Warning Message");
            _logService.Error("Some Error Message");
        }
    }
}