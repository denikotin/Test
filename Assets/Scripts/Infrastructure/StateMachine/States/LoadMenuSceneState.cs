using UnityEngine;
using Assets.Scripts.UI.UIFactory;
using Assets.Scripts.Infrastructure.Services.SceneLoaderFolder;
using Assets.Scripts.UI.Common;
using Assets.Scripts.Infrastructure.Services.StaticDataServiceFolder;

namespace Assets.Scripts.Infrastructure.StateMachine.States
{
    public class LoadMenuSceneState : IPayloadState<string>
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ServiceLocator _serviceLocator;
        
        private IUIFactory _uIFactory;
        private ISceneLoader _sceneLoader;
        private LoadingCurtains _loadingCurtain;
        private IStaticDataService _staticData;

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
            _staticData.Load();
            ConstructUI();
            _gameStateMachine.EnterToState<GameLoopState>();
        }

       
        private void GetServices()
        {
            _uIFactory = _serviceLocator.GetService<IUIFactory>();
            _sceneLoader = _serviceLocator.GetService<ISceneLoader>();
            _staticData = _serviceLocator.GetService<IStaticDataService>();
        }


        private void ConstructUI()
        {
            ConstructUIRoot();
            ConstructMainMenu();
        }

        private void ConstructUIRoot() => _uIFactory.CreateRootUI();

        private void ConstructMainMenu()
        {
            GameObject menu = _uIFactory.CreateMainMenu();
            menu.GetComponentInChildren<Play>().Construct(_gameStateMachine);
        }
    }
}
