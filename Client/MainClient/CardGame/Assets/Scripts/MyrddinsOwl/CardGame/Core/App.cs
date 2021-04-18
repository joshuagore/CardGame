using System.Threading.Tasks;
using MyrddinsOwl.CardGame.Debug;
using MyrddinsOwl.CardGame.StartScreen;
using MyrddinsOwl.Core;
using UnityEngine;
using ILogger = MyrddinsOwl.CardGame.Shared.ILogger;

namespace MyrddinsOwl.CardGame.Core
{
    public sealed class App
    {
        private readonly ILogger _logger;
        private readonly MvcFactory _mvcFactory;
        private readonly AssetLoader _assetLoader;
        private readonly IContainer _container;

        private DebugHudController _debugHudController;
        private StartScreenController _startScreenController;

        public App(IContainer container, ILogger logger, MvcFactory mvcFactory, AssetLoader assetLoader )
        {
            _container = container;
            _logger = logger;
            _mvcFactory = mvcFactory;
            _assetLoader = assetLoader;

            _logger.Info("Initialized App and starting game");
            StartGame();
        }

        private async void StartGame()
        {
            await Task.WhenAll(CreateDebugHud(), CreateStartScreen());
        }

        private async Task CreateDebugHud()
        {
            _logger.Info("Creating DebugHud");
            var gameObject = await _assetLoader.Load<GameObject>("Prefabs/Debug");
            var debugHudView = _container.InstantiatePrefabForComponent<DebugHudView>(gameObject);
            var debugHudModel = new DebugHudModel();
            _debugHudController = _mvcFactory.CreateController<DebugHudController, DebugHudView, DebugHudModel>(debugHudView, debugHudModel);
        }

        private async Task CreateStartScreen()
        {
            _logger.Info("CreatingStartScreen");
            var gameObject = await _assetLoader.Load<GameObject>("Prefabs/Entry");
            var startScreenView = _container.InstantiatePrefabForComponent<StartScreenView>(gameObject);
            var startScreenModel = new StartScreenModel();
            _startScreenController = _mvcFactory.CreateController<StartScreenController, StartScreenView, StartScreenModel>(startScreenView, startScreenModel);
        }
    }
}


