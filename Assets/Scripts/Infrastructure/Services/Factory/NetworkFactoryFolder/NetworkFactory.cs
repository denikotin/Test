using Assets.Scripts.Infrastructure.AssetProviderFolder;
using Assets.Scripts.Infrastructure.AssetsPathsFolder;
using UnityEngine;


namespace Assets.Scripts.Infrastructure.Services.Factory.NetworkFactoryFolder
{
    public class NetworkFactory : INetworkFactory
    {
        private readonly ServiceLocator _serviceLocator;

        private readonly IAssetProvider _assetProvider;

        public NetworkFactory(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _assetProvider = _serviceLocator.GetService<IAssetProvider>();
        }

        public GameObject CreateNetworkManager()
        {
            GameObject managerPrefab = _assetProvider.Load(AssetsPaths.NETWORK_MANAGER);
            GameObject networkPrefab = Object.Instantiate(managerPrefab);
            return networkPrefab;
        }

    }
}
