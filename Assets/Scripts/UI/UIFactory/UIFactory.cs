using UnityEngine;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.AssetProviderFolder;
using Assets.Scripts.Infrastructure.AssetsPathsFolder;
using Assets.Scripts.Infrastructure.Services.StaticDataService;


namespace Assets.Scripts.UI.UIFactory
{
    public class UIFactory : IUIFactory
    {
        private Transform _root;
        private readonly IAssetProvider _assetProvider;
        private readonly ServiceLocator _serviceLocator;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticDataService;


        public UIFactory(IAssetProvider assetProvider, ServiceLocator serviceLocator)
        {
            _assetProvider = assetProvider;
            _serviceLocator = serviceLocator;  
            _gameStateMachine = _serviceLocator.GetService<IGameStateMachine>();
            _staticDataService = _serviceLocator.GetService<IStaticDataService>();
        }

        public GameObject CreateRootUI()
        {
            GameObject rootPrefab = _assetProvider.Load(AssetsPaths.UIROOT);
            GameObject root = Object.Instantiate(rootPrefab);
            _root = root.transform;
            return root;
        }

        public GameObject CreateMainMenu()
        {
            GameObject mainMenuPrefab = _assetProvider.Load(AssetsPaths.MAINMENU);
            GameObject mainMenu = Object.Instantiate(mainMenuPrefab, _root);

            mainMenu.GetComponentInChildren<Play>().Construct(_gameStateMachine);

            return mainMenu;
        }

        public GameObject CreateHUD(GameObject player)
        {
            GameObject hudPrefab = _assetProvider.Load(AssetsPaths.HUD);
            GameObject hud = Object.Instantiate(hudPrefab, _root);
            return hud;
        }



    }
}
