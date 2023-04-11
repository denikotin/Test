using UnityEngine;
using Assets.Scripts.Infrastructure.AssetProviderFolder;
using Assets.Scripts.Infrastructure.AssetsPathsFolder;


namespace Assets.Scripts.Infrastructure.Services.Factory.PlayerFactory
{
    public class PlayerFactory :IPlayerFactory
    {
        private readonly ServiceLocator _serviceLocator;

        private readonly IAssetProvider _assetProvider;

        public PlayerFactory(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _assetProvider = _serviceLocator.GetService<IAssetProvider>();

        }

        public GameObject CreatePlayer()
        {
            GameObject playerPrefab = _assetProvider.Load(AssetsPaths.PLAYER);
            GameObject player = Object.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

            return player;
        }
    }
}
