using UnityEngine;

namespace Assets.Scripts.Logic
{
    public interface IAggressable
    {
        public void Aggress(Collider other);

        public void UnAggress(Collider other);
    }
}
