using Assets.Scripts.Infrastructure.AssetProviderFolder;
using Assets.Scripts.Infrastructure.AssetsPathsFolder;

using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Factory.BulletFactoryFolder
{
    public class BulletFactory : IBulletFactory
    {
        private ServiceLocator _serviceLocator;
        private IAssetProvider _assetProvider;

        public BulletFactory(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _assetProvider = _serviceLocator.GetService<IAssetProvider>();
        }

        public GameObject CreateBullet()
        {
            GameObject prefab = _assetProvider.Load(AssetsPaths.BULLET);
            GameObject bullet = Object.Instantiate(prefab);
            return bullet;
        }
    }
}
