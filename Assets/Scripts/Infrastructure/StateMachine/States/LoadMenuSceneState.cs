using UnityEngine;
using Assets.Scripts.UI.UIFactory;
using Assets.Scripts.Infrastructure.Services.SceneLoaderFolder;
using Assets.Scripts.UI.Common;
using Assets.Scripts.Infrastructure.Services.Factory.NetworkFactoryFolder;

namespace Assets.Scripts.Infrastructure.StateMachine.States
{
    public class LoadMenuSceneState : IPayloadState<string>
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ServiceLocator _serviceLocator;
        
        private IUIFactory _uIFactory;
        private ISceneLoader _sceneLoader;
        private INetworkFactory _networkFactory;
        private LoadingCurtains _loadingCurtain;


        public LoadMenuSceneState(IGameStateMachine gameStateMachine, ServiceLocator serviceLocator, GameObject loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _serviceLocator = serviceLocator;
            _loadingCurtain = loadingCurtain.GetComponent<LoadingCurtains>();
        }

        public void Enter(string sceneName )
        {
            //Debug.Log($"Entered {this.GetType().Name}");
            _loadingCurtain.Show();
            GetServices();
            LoadScene(sceneName);
        }

        public void Exit() => _loadingCurtain.Hide();


        private void LoadScene(string sceneName)
        {
            if (sceneName == "Main")
                _sceneLoader.Load(sceneName, OnLoadedMain);
        }

        private void OnLoadedMain()
        {
            ConstructUI();
            CreateNetworkManager();
            _gameStateMachine.EnterToState<GameLoopState>();
        }

       
        private void GetServices()
        {
            _uIFactory = _serviceLocator.GetService<IUIFactory>();
            _sceneLoader = _serviceLocator.GetService<ISceneLoader>();
            _networkFactory = _serviceLocator.GetService<INetworkFactory>();
        }

        private void CreateNetworkManager() => _networkFactory.CreateNetworkManager();

        private void ConstructUI()
        {
            ConstructUIRoot();
            ConstructMainMenu();
        }

        private void ConstructUIRoot() => _uIFactory.CreateRootUI();

        private void ConstructMainMenu() => _uIFactory.CreateMainMenu();

    }
}
