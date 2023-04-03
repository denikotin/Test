using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Factory.EnemyFactoryFolder
{
    public interface IEnemyFactory:IService
    {
       public GameObject CreateEnemy(EnemyID enemy);
    }
}