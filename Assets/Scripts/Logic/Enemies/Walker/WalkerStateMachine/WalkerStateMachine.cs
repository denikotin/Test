using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using Assets.Scripts.Logic.Enemies.EnemyStates;

namespace Assets.Scripts.Logic.Enemies.Walker.WalkerStateMachine
{
    public class WalkerStateMachine : MonoBehaviour, IEnemyStateMachine
    {
        
        public EnemyArea EnemyArea;
        public WalkerMover WalkerMover;
        public NavMeshAgent NavMeshAgent;
        public WalkerDetecting WalkerDetecting;


        private Dictionary<Type, IEnemyState> _enemyStates;
        private IEnemyState _currentState;

        private Transform _player;

        public void Construct(Transform player)
        {
            _player = player;
            WalkerDetecting.Construct(_player); 
        }

        public void Start()
        {
            CreateStates();
            EnterState<WalkerPatrollingState>();
        }


        public void Update()
        {
            if( _currentState != null)
            {
                _currentState.Tick();
            }
        }

        public void EnterState<TEnemyState>() where TEnemyState : class, IEnemyState
        {
            TEnemyState state = ChangeState<TEnemyState>();
            state.Enter();
        }

        public TEnemyState GetState<TEnemyState>() where TEnemyState : class, IEnemyState
        {
            return _enemyStates[typeof(TEnemyState)] as TEnemyState;
        }

        private void CreateStates()
        {
            _enemyStates = new Dictionary<Type, IEnemyState>();

            _enemyStates[typeof(WalkerAttackingState)] = new WalkerAttackingState(transform,_player);

            _enemyStates[typeof(WalkerPatrollingState)] = new WalkerPatrollingState(transform);
        }
        private TEnemyState ChangeState<TEnemyState>() where TEnemyState : class, IEnemyState
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }
            TEnemyState state = GetState<TEnemyState>();
            _currentState = state;
            return state;
        }
    }
}
