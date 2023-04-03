using UnityEngine;
using Assets.Scripts.UI.UIFactory;
using Assets.Scripts.Infrastructure.AssetProviderFolder;
using Assets.Scripts.Infrastructure.Services.PoolService;
using Assets.Scripts.Infrastructure.Services.StaticDataService;
using Assets.Scripts.Infrastructure.Services.SceneLoaderFolder;
using Assets.Scripts.Infrastructure.Services.InputServiceFolder;
using Assets.Scripts.Infrastructure.Services.Factory.PlayerFactory;
using Assets.Scripts.Infrastructure.Services.Factory.EnemyFactoryFolder;
using Assets.Scripts.Infrastructure.Services.Factory.BulletFactoryFolder;

namespace Assets.Scripts.Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ServiceLocator _serviceLocator;
        

        public BootstrapState(IGameStateMachine gameStateMachine, ServiceLocator serviceLocator, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _serviceLocator = serviceLocator;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            Debug.Log($"Entered {this.GetType().Name}");
            RegisterServices();
            _gameStateMachine.EnterToState<LoadMenuSceneState,string>("Main");
        }

        public void Exit() { }

        public void RegisterServices()
        { 
            _serviceLocator.RegisterService<ISceneLoader>(_sceneLoader);
            _serviceLocator.RegisterService<IGameStateMachine>(_gameStateMachine);
            _serviceLocator.RegisterService<IStaticDataService>(new StaticDataService());
            _serviceLocator.RegisterService<IObjectPoolService>(new ObjectPoolService());
            _serviceLocator.RegisterService<IAssetProvider>(new AssetProvider());
            _serviceLocator.RegisterService<IUIFactory>(new UIFactory(_serviceLocator.GetService<IAssetProvider>(), _serviceLocator));
            _serviceLocator.RegisterService<IPlayerFactory>(new PlayerFactory(_serviceLocator));
            _serviceLocator.RegisterService<IEnemyFactory>(new EnemyFactory(_serviceLocator));
            _serviceLocator.RegisterService<IBulletFactory>(new BulletFactory(_serviceLocator));
            _serviceLocator.RegisterService<IInputService>(new InputService());
        }
    }
}
