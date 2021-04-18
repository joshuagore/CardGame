using System.Threading.Tasks;
using MyrddinsOwl.CardGame.Debug;
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
        private StartScreen _startScreen;

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
            var _debugHudView = _container.InstantiatePrefabForComponent<DebugHudView>(gameObject);
            _debugHudController = _mvcFactory.CreateController<DebugHudController, DebugHudView>(_debugHudView);
        }

        private async Task CreateStartScreen()
        {
            _logger.Info("CreatingStartScreen");
            var gameObject = await _assetLoader.Load<GameObject>("Prefabs/Entry");
            _startScreen = _container.InstantiatePrefabForComponent<StartScreen>(gameObject);
        }
    }
}


