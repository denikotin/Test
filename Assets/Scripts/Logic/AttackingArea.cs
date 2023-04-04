using System;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class AttackingArea : MonoBehaviour
    {
        public event Action<Collider> OnAttackingAreaEnterEvent;
        public event Action<Collider> OnAttackingAreaExitEvent;


        private void OnTriggerEnter(Collider other)
        {
            OnAttackingAreaEnterEvent?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnAttackingAreaExitEvent?.Invoke(other);
        }
    }
}