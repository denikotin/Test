using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

namespace Assets.Scripts.Logic.Enemies.Walker
{
    public class WalkerMover : IMovable
    {
        public bool IsMoving { get; set; }

        private float _moveDistance;


        private NavMeshAgent _agent;
        private Transform _transform;
        private EnemyArea _enemyArea;
        private EnemyPathfinder _pathfinder;

        private Vector3 _walkPoint;
        private bool _isWalkPointSet;

        public WalkerMover(Transform transform,NavMeshAgent agent, EnemyArea enemyArea)
        {
            _agent = agent;
            _enemyArea = enemyArea;
            _transform = transform;
        }

        public void Initialize(float speed, float distance)
        {
            _agent.speed = speed;
            _moveDistance = distance;
            _pathfinder = new EnemyPathfinder(_transform,_enemyArea);
        }

        //public void SetDestination(Vector3 destination) => _destination = destination;

        public void Move()
        {
            IsMoving = true;
            _agent.isStopped = false;
            Vector3 destination = Vector3.zero;

            if (!_isWalkPointSet)
            {
                 destination = _pathfinder.FindNewPoint(_moveDistance);
                _isWalkPointSet = true;
                Debug.Log(destination);
                _agent.SetDestination(destination);
            }

            Vector3 distanceToWalkPoint = _transform.position - destination;
            Debug.Log(distanceToWalkPoint.magnitude);
            if (distanceToWalkPoint.magnitude < 2f)
            {
                _isWalkPointSet = false;
            }

        }

        public void Stop()
        {
            _agent.isStopped = true;
            IsMoving = false;
        }
    }
}
