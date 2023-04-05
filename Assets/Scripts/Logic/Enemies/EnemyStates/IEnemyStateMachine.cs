using System;

namespace Assets.Scripts.Logic.Enemies.EnemyStates
{
    public interface IEnemyStateMachine
    {
        public void EnterState<TEnemyState>() where TEnemyState : class, IEnemyState;
        public void ExitState();
    }
}
