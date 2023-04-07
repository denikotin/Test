﻿using UnityEngine;
using Assets.Scripts.UI.Common;
using Assets.Scripts.UI.UIFactory;
using Assets.Scripts.Data.NewTypes;
using Assets.Scripts.Infrastructure.Services.PoolService;
using Assets.Scripts.Infrastructure.Services.StaticDataService;
using Assets.Scripts.Infrastructure.Services.SceneLoaderFolder;
using Assets.Scripts.Infrastructure.Services.Factory.PlayerFactory;
using System;
using Assets.Scripts.Infrastructure.Services.Factory.EnemyFactoryFolder;
using Assets.Scripts.Logic.Player;
using Assets.Scripts.Logic.Weapon;
using Assets.Scripts.Infrastructure.Services.Factory.BulletFactoryFolder;
using Assets.Scripts.Logic.Enemies.Walker.WalkerStateMachine;

namespace Assets.Scripts.Infrastructure.StateMachine.States
{
    public class LoadPlaySceneState : IPayloadState<string>
    {
        private readonly ServiceLocator _serviceLocator;
        private readonly LoadingCurtains _loadingCurtain;
        private readonly IGameStateMachine _gameStateMachine;

        private IUIFactory _uiFactory;
        private ISceneLoader _sceneLoader;
        private IEnemyFactory _enemyFactory;
        private IBulletFactory _bulletFactory;
        private IPlayerFactory _playerFactory;
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
            _enemyFactory = _serviceLocator.GetService<IEnemyFactory>();
            _bulletFactory = _serviceLocator.GetService<IBulletFactory>();
            _playerFactory = _serviceLocator.GetService<IPlayerFactory>();
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
            ConstructEnemies(player.transform);
            GameObject hud = ConstructHUD(player);
        }



        private GameObject ConstructPlayer()
        {
            GameObject player = _playerFactory.CreatePlayer();
            return player;
        }

        private void ConstructEnemies(Transform player)
        {
            _enemyFactory.CreateEnemy(EnemyID.Walker)
                .GetComponent<WalkerStateMachine>()
                .Construct(player);


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
