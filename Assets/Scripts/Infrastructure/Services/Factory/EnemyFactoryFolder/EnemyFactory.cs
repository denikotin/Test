using Assets.Scripts.Infrastructure.AssetProviderFolder;
using Assets.Scripts.Infrastructure.AssetsPathsFolder;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Infrastructure.Services.Factory.EnemyFactoryFolder
{
    public class EnemyFactory : IEnemyFactory
    {
        private ServiceLocator _serviceLocator;
        private IAssetProvider _assetProvider;

        public EnemyFactory(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _assetProvider = _serviceLocator.GetService<IAssetProvider>();
        }


        public GameObject CreateEnemy(EnemyID enemy)
        {
            switch (enemy)
            {
                case EnemyID.Walker:
                    return Create(AssetsPaths.WALKER_ENEMY);
                case EnemyID.Flyer:
                    return Create(AssetsPaths.FLYER_ENEMY);
                default: return null;
            }

        }

        private GameObject Create(string path)
        {
            GameObject prefab = _assetProvider.Load(path);
            GameObject go = Object.Instantiate(prefab);
            return go;
        }
    }
}
