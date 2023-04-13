using Assets.Scripts.UI.UIFactory;
using Assets.Scripts.Infrastructure.AssetProviderFolder;
using Assets.Scripts.Infrastructure.Services.SceneLoaderFolder;
using Assets.Scripts.Infrastructure.Services.Factory.PlayerFactory;
using Assets.Scripts.Infrastructure.Services.Factory.NetworkFactoryFolder;

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
            //Debug.Log($"Entered {this.GetType().Name}");
            RegisterServices();
            _gameStateMachine.EnterToState<LoadMenuSceneState,string>("Main");
        }

        public void Exit() { }

        public void RegisterServices()
        { 
            _serviceLocator.RegisterService<ISceneLoader>(_sceneLoader);
            _serviceLocator.RegisterService<IGameStateMachine>(_gameStateMachine);
            _serviceLocator.RegisterService<IAssetProvider>(new AssetProvider());
            _serviceLocator.RegisterService<IPlayerFactory>(new PlayerFactory(_serviceLocator));
            _serviceLocator.RegisterService<INetworkFactory>(new NetworkFactory(_serviceLocator));
            _serviceLocator.RegisterService<IUIFactory>(new UIFactory(_serviceLocator.GetService<IAssetProvider>(), _serviceLocator));
        }
    }
}
