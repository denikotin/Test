using Assets.Scripts.Logic.Enemies.EnemyStates;
using UnityEngine;

namespace Assets.Scripts.Logic.Enemies.Walker
{
    public  class WalkerPatrollingState : IPatrolling
    {
        private Transform _transform;
        private WalkerMover _walkerMover;

        public WalkerPatrollingState(Transform walkerTransform, WalkerMover walkerMover)
        {
            _walkerMover = walkerMover;
            _transform = walkerTransform;
        }

        public void Enter() => Debug.Log($"{_transform.name} вошел в сотояние patroll");

        public void Tick() => Patrol();

        public void Exit()
        {
            
        }

        public void Patrol() => _walkerMover.Move();


    }
}
