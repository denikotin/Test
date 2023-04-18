using Assets.Scripts.Infrastructure.StaticData.GameStaticDataFolder;

namespace Assets.Scripts.Infrastructure.Services.StaticDataServiceFolder
{
    public interface IStaticDataService:IService
    {
        GameStaticData GetGameStaticData();
        void Load();
    }
}