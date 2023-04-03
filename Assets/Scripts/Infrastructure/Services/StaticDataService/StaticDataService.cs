using Assets.Scripts.Infrastructure.StaticData.EquipmentStaticDataFolder;
using Assets.Scripts.Infrastructure.StaticData.GameStaticDataFolder;

namespace Assets.Scripts.Infrastructure.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {

        private GameStaticData _gameStaticData;
        private ResourceIconStaticData _resourceIconStaticData;

        public void Load()
        {
        }
        public GameStaticData GetGameStaticData() => _gameStaticData;

        public ResourceIconStaticData GetResourceIconStaticData() => _resourceIconStaticData;


    }
}
