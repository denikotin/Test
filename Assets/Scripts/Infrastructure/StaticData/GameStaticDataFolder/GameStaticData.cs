using UnityEngine;

namespace Assets.Scripts.Infrastructure.StaticData.GameStaticDataFolder
{
    [CreateAssetMenu(fileName = "GameStaticData", menuName = "StaticData/GameStaticData")]
    public class GameStaticData: ScriptableObject
    {
        public Vector3 PlayerStartPoint;
    }
}
