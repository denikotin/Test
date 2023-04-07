using Assets.Scripts.Logic.Enemies.EnemyStates;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic.Enemies.Walker.WalkerStateMachine
{
    public class WalkerAttackingState : IAttacking
    {
        private EnemyArea _area;
        private Transform _player;
        private Transform _transform;
        private WalkerMover _walkerMover;
        private WalkerAttack _walkerAttack;
        
        private float _attackTime = 2f;
        private bool _isAttacking = false;

        private Coroutine _attackCoroutine;

        public WalkerAttackingState(Transform transform, Transform player)
        {
            _player = player;
            _transform = transform;
            _area = _transform.GetComponent<EnemyArea>();
            _walkerMover = _transform.GetComponent<WalkerMover>();
            _walkerAttack = _transform.GetComponent<WalkerAttack>();
        }

        public void Enter()
        {
            Debug.Log($"{_transform.name} вошел в сотояние Attacking");
        }

        public void Tick() => Attack();

        public void Exit()
        {
            _walkerAttack.StopCoroutine(_attackCoroutine);
            _isAttacking = false;
        }

        public void Attack()
        {
            _walkerAttack.Attack();

            if (!_isAttacking)
            {
               _attackCoroutine = _walkerAttack.StartCoroutine(AttackRoutine());
            }
        }

        private IEnumerator AttackRoutine()
        {
            _walkerMover.Stop();

            Debug.Log("Enemy attacking");
            _isAttacking = true;
            float timer = _attackTime;
            while(timer >= 0)
            {
                //_transform.LookAt(_walkerAttack.Target.transform);
                timer -= Time.deltaTime;
                yield return null;
            }
            _transform.LookAt(null);
            Debug.Log("NotAttacking");

            ChangePosition();
            _isAttacking=false;
        }

        private void ChangePosition()
        {
            _walkerMover.Move();   
        }

    }
}
