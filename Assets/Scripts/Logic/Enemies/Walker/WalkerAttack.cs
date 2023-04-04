using Assets.Scripts.Logic.Enemies.Walker.WalkerStateMachine;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic.Enemies.Walker
{
    public class WalkerAttack : EnemyAttacking
    {
        public override void OnAttackAreaEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //_stateMachine.EnterState<WalkerAttackingState>();
            }
            
        }

        public override void OnAttaclAreaExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //_stateMachine.EnterState<WalkerPatrollingState>();
            }
            
        }
    }
}
