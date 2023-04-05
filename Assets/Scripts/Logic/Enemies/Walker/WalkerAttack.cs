using Assets.Scripts.Logic.Enemies.Walker.WalkerStateMachine;
using UnityEngine;

namespace Assets.Scripts.Logic.Enemies.Walker
{
    public class WalkerAttack : EnemyAttacking
    {
        public Collider Target { get; private set; }

        public override void OnAttackAreaEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _stateMachine.EnterState<WalkerAttackingState>();
                Target = other;
            }
            
        }

        public override void OnAttaclAreaExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _stateMachine.ExitState();
                Target = null;
            }
            
        }
    }
}
