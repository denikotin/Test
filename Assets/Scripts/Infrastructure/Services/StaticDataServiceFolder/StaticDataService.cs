using Assets.Scripts.Infrastructure.AssetsPathsFolder;
using Assets.Scripts.Infrastructure.StaticData.GameStaticDataFolder;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.StaticDataServiceFolder
{
    public class StaticDataService : IStaticDataService
    {
        private GameStaticData _gameStaticData;

        public void Load() => _gameStaticData = Resources.Load<GameStaticData>(AssetsPaths.GAME);

        public GameStaticData GetGameStaticData() => _gameStaticData;
    }
}
