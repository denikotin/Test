
namespace Assets.Scripts.Logic.Enemies
{
    public interface IEnemyState
    {
        public void Enter();

        public void Tick();

        public void Exit();
    }
}
