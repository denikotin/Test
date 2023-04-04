using Assets.Scripts.Logic.Enemies.EnemyStates;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic.Enemies.Walker.WalkerStateMachine
{
    public class WalkerAttackingState : IAttacking
    {
        private Transform _transform;
        private Transform _player;
        private WalkerMover _walkerMover;
        private WalkerAttack _walkerAttack;

        private float _attackTime = 2f;

        private EnemyArea _area;
        private Vector3 _walkPoint;

        private bool _isPositionChanged = true;
        private bool _isWalkPointSet;
        private bool _isAttacking = false;

        public WalkerAttackingState(Transform transform,Transform player, WalkerMover walkerMover, EnemyArea enemyArea)
        {
            _transform = transform;
            _player = player;
            _walkerMover = walkerMover;
            _area = enemyArea;
        }

        public void Enter()
        {
            Debug.Log($"{_transform.name} вошел в сотояние Attacking");
            _walkerAttack = _transform.GetComponent<WalkerAttack>();
        }

        public void Tick()
        {
            if (_walkerMover.IsMoving && _isPositionChanged)
            {
                Attack();
            }
            if (!_isAttacking)
            {
                ChangePosition();
            }
            
        }

        public void Exit()
        {

        }

        public void Attack()
        {
            if (!_isAttacking)
            {
                _walkerAttack.StartCoroutine(AttackRoutine());
            }
        }

        private IEnumerator AttackRoutine()
        {
            _isAttacking = true;
            _walkerMover.Stop();
            float timer = _attackTime;
            while(timer >= 0)
            {
                _transform.LookAt(_player);
                timer -= Time.deltaTime;
                yield return null;
            }
            _isAttacking=false;
        }

        private void ChangePosition()
        {
            _isPositionChanged = false;
            if (!_isWalkPointSet)
            {
                SearchWalkPoint();
            }
            else
            {
                _walkerMover.Move();
            }

            Vector3 distanceToWalkPoint = _transform.position - _walkPoint;
            if (distanceToWalkPoint.magnitude < 1f)
            {
                _isWalkPointSet = false;
                _isPositionChanged=true;
            }
            
        }

        private void SearchWalkPoint()
        {
            float randomZ = Random.Range(_area.MinZ, _area.MaxZ);
            float randomX = Random.Range(_area.MinX, _area.MaxX);

            _walkPoint = new Vector3(randomX, _transform.position.y, randomZ);
            _isWalkPointSet = true;
        }

    }
}
