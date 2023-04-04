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
        public NavMeshAgent NavMeshAgent;

        private WalkerMover _walkerMover;

        private Dictionary<Type, IEnemyState> _enemyStates;
        private IEnemyState _currentState;

        private Transform _player;

        public void Construct(Transform player)
        {
            _player = player;
        }

        public void Start()
        {
            CreateUtils();
            CreateStates();
            EnterState<WalkerPatrollingState>();
        }

        private void CreateUtils()
        {
            WalkerStats walkerStats = GetComponent<WalkerStats>();
            _walkerMover = new WalkerMover(transform,NavMeshAgent, EnemyArea);
            _walkerMover.Initialize(walkerStats.Speed, walkerStats.MoveDistance);
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

            _enemyStates[typeof(WalkerAttackingState)] = new WalkerAttackingState(transform,
                                                                                  _player,
                                                                                  _walkerMover,
                                                                                  EnemyArea);

            _enemyStates[typeof(WalkerPatrollingState)] = new WalkerPatrollingState(transform,
                                                                                    _walkerMover);
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
