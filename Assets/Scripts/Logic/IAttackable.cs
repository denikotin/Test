
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public interface IAttackable
    {
        public void OnAttackAreaEnter(Collider other);

        public void OnAttaclAreaExit(Collider other);
    }
}
