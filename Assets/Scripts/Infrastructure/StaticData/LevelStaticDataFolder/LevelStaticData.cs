using UnityEngine;

namespace Assets.Scripts.Infrastructure.StaticData.LevelStaticDataFolder
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData:ScriptableObject
    {
       
        public int TerrainQuantity = 5;
        public int MapCount = 5;
        public int ItemsInMap = 3;
        public int PropsInItem = 3;
        public float LevelTime;
        public GameObject[] TerrainsPrefabs;
        public GameObject[] PropsPrefab;

    }
}
