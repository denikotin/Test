using UnityEngine;
using Assets.Scripts.UI.Common;
using Assets.Scripts.UI.UIFactory;
using Assets.Scripts.Data.NewTypes;
using Assets.Scripts.Infrastructure.Services.PoolService;
using Assets.Scripts.Infrastructure.Services.StaticDataService;
using Assets.Scripts.Infrastructure.Services.SceneLoaderFolder;
using Assets.Scripts.Infrastructure.Services.Factory.PlayerFactory;
using System;
using Assets.Scripts.Infrastructure.Services.Factory.EnemyFactoryFolder;

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
        private IEnemyFactory _enemyFactory;
        private IObjectPoolService _objectPool;
        private IStaticDataService _staticDataService;


        public LoadPlaySceneState(IGameStateMachine gameStateMachine, ServiceLocator serviceLocator, GameObject loadingCurtain) 
        {
            _gameStateMachine = gameStateMachine;
            _serviceLocator = serviceLocator;
            _loadingCurtain = loadingCurtain.GetComponent<LoadingCurtains>();
        }

        public void Enter(string sceneName)
        {
            Debug.Log($"Entered {this.GetType().Name}");
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
            _enemyFactory = _serviceLocator.GetService<IEnemyFactory>();
            _objectPool = _serviceLocator.GetService<IObjectPoolService>();
            _staticDataService = _serviceLocator.GetService<IStaticDataService>();

        }

        private void LoadScene(string sceneName) => _sceneLoader.Load(sceneName, OnLoaded);

        private void OnLoaded()
        {
            ConstructPlayScene();
            _gameStateMachine.EnterToState<GameLoopState>();
        }


        private void ConstructPlayScene()
        {
            _objectPool.CleanUp();

            GameObject player = ConstructPlayer();
            ConstructEnemies();
            GameObject hud = ConstructHUD(player);
        }



        private GameObject ConstructPlayer()
        {
            GameObject player = _playerFactory.CreatePlayer();
            return player;
        }

        private void ConstructEnemies()
        {
            _enemyFactory.CreateEnemy(EnemyID.Walker);
            //_enemyFactory.CreateEnemy(EnemyID.Flyer);
        }

        private GameObject ConstructHUD(GameObject player)
        {
            ConstructUIRoot();
            GameObject _hud = _uiFactory.CreateHUD(player);
            return _hud;
        }

        private void ConstructUIRoot()
        {
           _uiFactory.CreateRootUI();
        }

    }
}
