using UnityEngine;

namespace Assets.Scripts.Infrastructure.StaticData.EquipmentStaticDataFolder
{
    [CreateAssetMenu(fileName = "ResourceIconData", menuName = "StaticData/ResourcesIcon")]
    public class ResourceIconStaticData:ScriptableObject
    {
        public Sprite Diamond;
        public Sprite Stone;
        public Sprite Wood;
        public Sprite Iron;
    }
}
