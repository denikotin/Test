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

            _isAttacking = false;
            _walkerMover.Stop();
        }

        public void Tick()
        {
            Debug.Log($"Is moving:  {_walkerMover.IsMoving}");
            Debug.Log($"Is attacking: {_isAttacking}");
            if (!_walkerMover.IsMoving)
            {
                Attack();
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
            Debug.Log("Enemy attacking");
            float timer = _attackTime;
            while(timer >= 0)
            {
                _transform.LookAt(_player);
                timer -= Time.deltaTime;
                yield return null;
            }
            _isAttacking=false;
            Debug.Log("NotAttacking");
            ChangePosition();
        }

        private void ChangePosition()
        {
            _walkerMover.Move();   
        }

    }
}
