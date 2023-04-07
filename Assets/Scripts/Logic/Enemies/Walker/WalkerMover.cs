using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Assets.Scripts.Logic.Enemies.Walker
{
    public class WalkerMover : MonoBehaviour, IMove
    {
        public bool IsMoving { get; set; }

        public NavMeshAgent Agent;
        public EnemyArea EnemyArea;
        public WalkerStats Stats;

        private EnemyPathfinder _pathfinder;
        private Coroutine _moveCoroutine;
        private Vector3 _walkPoint;
        private float _moveDistance;
        private float _distanceToWalkPoint;



        public void Start()
        {
            Agent.speed = Stats.Speed;
            _moveDistance = Stats.MoveDistance;
            _pathfinder = new EnemyPathfinder(transform,EnemyArea);
            _walkPoint = _pathfinder.FindNewPoint(_moveDistance);
        }

        public void Move()
        {
            _distanceToWalkPoint = Vector3.Distance(transform.position, _walkPoint);
            if (!IsMoving)
            {
                IsMoving = true;
                Agent.isStopped = false;

                _walkPoint = _pathfinder.FindNewPoint(_moveDistance);
                _moveCoroutine = StartCoroutine(MoveRoutine());
            }
        }

        public void Stop()
        {
            IsMoving = false;
            Agent.isStopped = true;
            StopCoroutine(_moveCoroutine);
        }

        private IEnumerator MoveRoutine()
        {
            Agent.SetDestination(_walkPoint);
            yield return new WaitUntil(() => _distanceToWalkPoint <= 2f);
            IsMoving = false;
        }
    }
}
