using UnityEngine;
using Assets.Scripts.UI.Common;
using Assets.Scripts.UI.UIFactory;
using Assets.Scripts.Infrastructure.Services.SceneLoaderFolder;
using Assets.Scripts.Infrastructure.Services.Factory.PlayerFactory;
using Assets.Scripts.Infrastructure.Services.StaticDataServiceFolder;
using Assets.Scripts.Infrastructure.StaticData.GameStaticDataFolder;

namespace Assets.Scripts.Infrastructure.StateMachine.States
{
    public class LoadPlaySceneState : IPayloadState<string>
    {
        private readonly ServiceLocator _serviceLocator;
        private readonly LoadingCurtains _loadingCurtain;
        private readonly IGameStateMachine _gameStateMachine;

        private IUIFactory _uiFactory;
        private ISceneLoader _sceneLoader;
        private IPlayerFactory _playerFactory;
        private IStaticDataService _staticData;

        public LoadPlaySceneState(IGameStateMachine gameStateMachine, ServiceLocator serviceLocator, GameObject loadingCurtain) 
        {
            _serviceLocator = serviceLocator;
            _gameStateMachine = gameStateMachine;
            _loadingCurtain = loadingCurtain.GetComponent<LoadingCurtains>();
        }

        public void Enter(string sceneName)
        {
            //Debug.Log($"Entered {this.GetType().Name}");
            _loadingCurtain.Show();
            GetServices();
            LoadScene(sceneName);
        }

        public void Exit() => _loadingCurtain.Hide();

        private void GetServices()
        {
            _uiFactory = _serviceLocator.GetService<IUIFactory>();
            _sceneLoader = _serviceLocator.GetService<ISceneLoader>();
            _playerFactory = _serviceLocator.GetService<IPlayerFactory>();
            _staticData = _serviceLocator.GetService<IStaticDataService>();
        }

        private void LoadScene(string sceneName) => _sceneLoader.Load(sceneName, OnLoaded);

        private void OnLoaded()
        {
            ConstructPlayScene();
            _gameStateMachine.EnterToState<GameLoopState>();
        }

        private void ConstructPlayScene()
        {
            GameStaticData gameStaticData = _staticData.GetGameStaticData();
            GameObject player = ConstructPlayer(gameStaticData.PlayerStartPoint);
            GameObject hud = ConstructHUD(player);
        }

        private GameObject ConstructPlayer(Vector3 spawnPosition)
        {
            GameObject player = _playerFactory.CreatePlayer(spawnPosition);
            return player;
        }

        private GameObject ConstructHUD(GameObject player)
        {
            ConstructUIRoot();
            GameObject _hud = _uiFactory.CreateHUD(player);
            return _hud;
        }

        private void ConstructUIRoot() => _uiFactory.CreateRootUI();

    }
}
