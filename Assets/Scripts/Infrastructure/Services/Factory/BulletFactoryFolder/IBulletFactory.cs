using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Factory.BulletFactoryFolder
{
    public interface IBulletFactory:IService
    {
        GameObject CreateBullet();
    }
}