using UnityEngine;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.AssetProviderFolder;
using Assets.Scripts.Infrastructure.AssetsPathsFolder;


namespace Assets.Scripts.UI.UIFactory
{
    public class UIFactory : IUIFactory
    {
        private Transform _root;
        private readonly IAssetProvider _assetProvider;
        private readonly ServiceLocator _serviceLocator;
        private readonly IGameStateMachine _gameStateMachine;



        public UIFactory(IAssetProvider assetProvider, ServiceLocator serviceLocator)
        {
            _assetProvider = assetProvider;
            _serviceLocator = serviceLocator;  
            _gameStateMachine = _serviceLocator.GetService<IGameStateMachine>();
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
